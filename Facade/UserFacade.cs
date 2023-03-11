using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using video_pujcovna_back.DTO.Input;
using video_pujcovna_back.DTO.Output;
using video_pujcovna_back.Factories;
using video_pujcovna_back.Models;

namespace video_pujcovna_back.Facade;

public class UserFacade
{   
    private readonly DbContextFactory _contextFactory;
    private readonly IMapper _mapper;
    
    public UserFacade(DbContextFactory factory, IMapper mapper)
    {
        _contextFactory = factory;    
        _mapper = mapper;
    }
        
    public async Task<EntityEntry<T>> Add<T>(T entity) where T : class
    {   
        var entityMapped = _mapper.Map<T>(entity);
        await using (var context = _contextFactory.CreateDbContext())
        {
            var user = await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return user;
        }
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
    
    public async Task<UserModel> GetUser(int id)
    {
        await using (var context = _contextFactory.CreateDbContext())
        {
            return await context.Users.FindAsync(id) ?? throw new Exception("User not found");
        }
    }

    public async Task<IEnumerable<UserEntityOutput>> GetAllUser()
    {
        await using (var context = _contextFactory.CreateDbContext())
        {   
            
            return _mapper.Map<IList<UserModel>, IList<UserEntityOutput>>(context.Users.ToList());
        }
    }
}