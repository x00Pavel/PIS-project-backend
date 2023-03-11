using Microsoft.EntityFrameworkCore.ChangeTracking;
using video_pujcovna_back.Factories;
using video_pujcovna_back.Models;

namespace video_pujcovna_back.Facade;

public class UserFacade
{   
    private readonly DbContextFactory _contextFactory;
    
    public UserFacade(DbContextFactory factory)
    {
        _contextFactory = factory;    
    }
        
    public async Task<EntityEntry<T>> Add<T>(T entity) where T : class
    {
        await using (var context = _contextFactory.CreateDbContext())
        {
            var user = await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return user;
        }
    }
    
    public async Task<User> AddUser(User user)
    {
        await using (var context = _contextFactory.CreateDbContext())
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return user;
        }
    }

    public async Task<User> UpdateUser(User user)
    {
        await using (var context = _contextFactory.CreateDbContext())
        {
            context.Users.Update(user);
            await context.SaveChangesAsync();
            return user;
        }
    }
    
    public void DeleteUser(User user)
    {
        using (var context = _contextFactory.CreateDbContext())
        {
            context.Users.Remove(user);
            context.SaveChanges();
        }
    }
    
    public async Task<User> GetUser(int id)
    {
        await using (var context = _contextFactory.CreateDbContext())
        {
            return await context.Users.FindAsync(id) ?? throw new Exception("User not found");
        }
    }

    public async Task<IEnumerable<User>> GetAllUser()
    {
        await using (var context = _contextFactory.CreateDbContext())
        {
            return context.Users.ToList();
        }
    }
}