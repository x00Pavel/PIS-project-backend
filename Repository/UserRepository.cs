using AutoMapper;
using Microsoft.EntityFrameworkCore;
using video_pujcovna_back.DTO.Input;
using video_pujcovna_back.DTO.Output;
using video_pujcovna_back.Factories;
using video_pujcovna_back.Models;

namespace video_pujcovna_back.Repository;

public class UserRepository
{   
    private readonly DbContextFactory _contextFactory;
    private readonly IMapper _mapper;
    
    public UserRepository(DbContextFactory factory, IMapper mapper)
    {
        _contextFactory = factory;    
        _mapper = mapper;
    }
    
    public async Task<UserEntityOutput> AddUser(UserEntityInput user)
    {   
        var userMapped = _mapper.Map<UserModel>(user);
        await using (var context = _contextFactory.CreateDbContext())
        {
            var result = await context.Users.AddAsync(userMapped);
            await context.SaveChangesAsync();
            var userEntity = _mapper.Map<UserEntityOutput>(result.Entity);
            return userEntity;
        }
    }

    public async Task<ICollection<ReservationEntityOutput>> GetUserReservations(Guid userId)
    {
        await using (var context = _contextFactory.CreateDbContext())
        {
            var result = await context.Users
                .Include(u => u.Reservations)
                .FirstAsync(u => u.Id == userId) ?? throw new Exception("User not found");
            return _mapper.Map<IList<ReservationModel>, IList<ReservationEntityOutput>>(result.Reservations.ToList());
        }
    }

    public async Task<UserModel> UpdateUser(UserModel userModel)
    {
        await using (var context = _contextFactory.CreateDbContext())
        {
            context.Users.Update(userModel);
            await context.SaveChangesAsync();
            return userModel;
        }
    }
    
    public void DeleteUser(UserModel userModel)
    {
        using (var context = _contextFactory.CreateDbContext())
        {
            context.Users.Remove(userModel);
            context.SaveChanges();
        }
    }
    
    public async Task<UserEntityOutput> GetUser(Guid id)
    {
        await using (var context = _contextFactory.CreateDbContext())
        {
            var user = await context.Users
                .Include(u => u.Reservations)
                .FirstAsync(u => u.Id == id) ?? throw new Exception("User not found");
            return _mapper.Map<UserEntityOutput>(user);
        }
    }

    public async Task<IEnumerable<UserEntityOutput>> GetAllUser()
    {
        await using (var context = _contextFactory.CreateDbContext())
        {
            var result = await context.Users
                .Include(u => u.Reservations)
                .ToListAsync();
            return _mapper.Map<IList<UserModel>, IList<UserEntityOutput>>(result);
        }
    }
}