using AutoMapper;
using Microsoft.EntityFrameworkCore;
using video_pujcovna_back.DTO.Input;
using video_pujcovna_back.DTO.Output;
using video_pujcovna_back.Factories;
using video_pujcovna_back.Migrations;
using video_pujcovna_back.Models;

namespace video_pujcovna_back.Repository;

public class UserRepository: RepositoryBase
{
    public UserRepository(DbContextFactory dbFactory, IMapper mapper) : base(dbFactory, mapper)
    {
    }

    public async Task<UserEntityOutput> AddUser(UserEntityInput user)
    {
        var userMapped = _mapper.Map<UserModel>(user);
        await using (var context = _dbFactory.CreateDbContext())
        {
            var result = await context.Users.AddAsync(userMapped);
            // This is needed to prevent EF insert the Role to the DB.
            // This is the behavior of EF that can't be changed in another way.
            Unchanged(context, result.Entity.Role);
            await context.SaveChangesAsync();
            var userEntity = _mapper.Map<UserModel, UserEntityOutput>(result.Entity);
            return userEntity;
        }
    }

    public async Task<ICollection<ReservationEntityOutput>> GetUserReservations(Guid userId)
    {
        await using var context = _dbFactory.CreateDbContext();
        var result = await context.Users
            .Include(u => u.Reservations)
            .FirstAsync(u => u.Id == userId) ?? throw new Exception("User not found");
        return _mapper.Map<IList<ReservationModel>, IList<ReservationEntityOutput>>(result.Reservations.ToList());
    }

    public async Task<UserModel> UpdateUser(UserModel userModel)
    {
        await using var context = _dbFactory.CreateDbContext();
        context.Users.Update(userModel);
        await context.SaveChangesAsync();
        return userModel;
    }

    public void DeleteUser(UserModel userModel)
    {
        using var context = _dbFactory.CreateDbContext();
        context.Users.Remove(userModel);
        context.SaveChanges();
    }

    public async Task<UserEntityOutput> GetUser(Guid id)
    {
        var user = await GetUserModel(id);
        return _mapper.Map<UserEntityOutput>(user);
    }

    public async Task<UserModel> GetUserModel(Guid id)
    {
        await using var ctx = _dbFactory.CreateDbContext();
        return await ctx.Users
            .Include(u => u.Reservations)
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.Id == id) ?? throw new Exception("User not found");
    }

    public async Task<IEnumerable<UserEntityOutput>> GetAllUser()
    {
        await using var context = _dbFactory.CreateDbContext();
        var result = await context.Users
            .Include(u => u.Reservations)
            .Include(u => u.Role)
            .ToListAsync();
        return _mapper.Map<IList<UserModel>, IList<UserEntityOutput>>(result);
    }

    public async Task<ICollection<PaymentEntityOutput>> GetUserPayments(Guid userId)
    {
        // First filter all user reservations
        await using var context = _dbFactory.CreateDbContext();
        var userReservationsHelper = await context.Users
            .Include(u => u.Reservations)
            .FirstAsync(u => u.Id == userId) ?? throw new Exception("User not found");

        // Make list of all user payments ids from his reservations
        List<Guid> paymentIds = new List<Guid>();
        foreach (var reservation in userReservationsHelper.Reservations)
        {
            paymentIds.Add(reservation.PaymentId);
        }
        
        // Get all the payments
        var payment = context.Payment
            .Where(p => paymentIds.Contains(p.Id)).ToList();

        return _mapper.Map<IList<PaymentModel>, IList<PaymentEntityOutput>>(payment);
    }
}