using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using video_pujcovna_back.DTO.Input;
using video_pujcovna_back.DTO.Output;
using video_pujcovna_back.Factories;
using video_pujcovna_back.Models;

namespace video_pujcovna_back.Repository;

public class UserRepository: RepositoryBase
{
    private readonly UserManager<UserModel> _userManager;
    private readonly RoleManager<RoleModel> _roleManager;

    public UserRepository(
        DbContextFactory dbFactory, 
        IMapper mapper,
        UserManager<UserModel> userManager, 
        RoleManager<RoleModel> roleManager
    ) : base(dbFactory, mapper)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<UserModel> AddUser(UserEntityInput user)
    {
        var userMapped = new UserModel
        {
            Id = Guid.NewGuid(),
            Email = user.Email,
            UserName = user.UserName
        };

        var result = await _userManager.CreateAsync(userMapped, user.Password);
        if (!result.Succeeded)
        {
            throw new Exception("User not created");
        }
            
        await _userManager.AddToRoleAsync(userMapped, user.Role);
        
        return await _userManager.FindByEmailAsync(user.Email);
    }

    public async Task<ICollection<ReservationEntityOutput>> GetUserReservations(Guid userId)
    {
        await using var context = _dbFactory.CreateDbContext();
        var result = context.Reservations
            .Where(r => r.UserId == userId)
            .Include(r => r.Videotape)
            .Include(r => r.Payment).ToList()
                     ?? throw new Exception("Reservation not found");
        return _mapper.Map<IList<ReservationModel>, IList<ReservationEntityOutput>>(result);
    }

    public async Task<UserModel> UpdateUser(Guid id, UserUpdate userUpdate)
    {
        // await using var context = _dbFactory.CreateDbContext();
        // var user = await context.Users
        //     .FirstOrDefaultAsync(u => u.Id == id) ?? throw new Exception("User not found");
        var user = await _userManager.FindByIdAsync(id.ToString()) ?? throw new Exception("No user found");
        if (userUpdate.UserName != null)
        {
            user.UserName = userUpdate.UserName;
        }
        if (userUpdate.Email != null)
        {
            user.Email = userUpdate.Email;
        }
        if (!string.IsNullOrEmpty(userUpdate.Password))
        {
            Console.WriteLine("Updating user password");
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, userUpdate.Password);
            if (!result.Succeeded)
            {
                throw new Exception("Password not updated");
            }
        }
        if (userUpdate.Role != null)
        {
            var role = await _roleManager.FindByNameAsync(userUpdate.Role);
            if (role == null)
            {
                throw new Exception("Role not found");
            }
            var roles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, roles);
            await _userManager.AddToRoleAsync(user, userUpdate.Role);
        }

        await _userManager.UpdateAsync(user);
        // context.Users.Update(user);
        return user;
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
            .FirstOrDefaultAsync(u => u.Id == id) ?? throw new Exception("User not found");
    }

    public async Task<IEnumerable<UserEntityOutput>> GetAllUser()
    {
        var allUsers = await _userManager.Users
            .ToListAsync();
        var mapped = _mapper.Map<IList<UserModel>, IList<UserEntityOutput>>(allUsers);
        foreach (var u in mapped)
        {
            u.Role = (await _userManager.GetRolesAsync(allUsers.First(x => x.Id == u.Id)))[0];
        }
        return mapped;
    }

    public async Task<IEnumerable<string>> GetUserRoles(UserModel result)
    {
        return await _userManager.GetRolesAsync(result);
    }
    
    public async Task<UserModel?> GetUserByEmail(string userEmail)
    {
        return await _userManager.FindByEmailAsync(userEmail);
    }
    
    public async Task<UserModel?> GetUserByUserName(string userName)
    {
        return await _userManager.FindByNameAsync(userName);
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