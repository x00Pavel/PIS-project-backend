using AutoMapper;
using video_pujcovna_back.DTO.Input;
using video_pujcovna_back.DTO.Output;
using video_pujcovna_back.Factories;
using video_pujcovna_back.Models;

namespace video_pujcovna_back.Mappers;


public class UserRoleMapper : IValueResolver<UserEntityInput, UserModel, RoleModel>
{
    private readonly DbContextFactory _factory;
    public UserRoleMapper(DbContextFactory context)
    {
        _factory = context;
    }
    public RoleModel Resolve(UserEntityInput source, UserModel destination, RoleModel destMember, ResolutionContext context)
    {
        using (var dbContext = _factory.CreateDbContext())
        {
            return dbContext.Roles.FirstOrDefault(x => x != null && x.Name == source.Role.Name);
        }
    }
}


public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<UserModel, UserEntityOutput>()
            .ForMember(src => src.Reservations,
                opt => opt.MapFrom(src => src.Reservations.Select(x => x.Id)));
        // For Role parameter query database for Role by Name
        CreateMap<UserEntityInput, UserModel>()
            .ForMember(opt => opt.Role,
                opt => opt.MapFrom<UserRoleMapper>());
    }
}