using AutoMapper;
using Microsoft.AspNetCore.Identity;
using video_pujcovna_back.DTO.Input;
using video_pujcovna_back.DTO.Output;
using video_pujcovna_back.Factories;
using video_pujcovna_back.Models;

namespace video_pujcovna_back.Mappers;


public class String2RoleMapper : IValueResolver<UserEntityInput, UserModel, IEnumerable<RoleModel>>
{
    private readonly RoleManager<RoleModel> _roleManager;

    public String2RoleMapper(RoleManager<RoleModel> roleManager)
    {
        _roleManager = roleManager;
    }

    public IEnumerable<RoleModel> Resolve(UserEntityInput source, UserModel destination, IEnumerable<RoleModel> destMember, ResolutionContext context)
    {
        return source.Roles.Select(role => _roleManager.FindByNameAsync(role).Result ?? throw new KeyNotFoundException("Role not found")).ToList();
    }
}

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<UserModel, UserEntityOutput>()
            .ForMember(src => src.Reservations,
                opt => opt.MapFrom(src => src.Reservations.Select(x => x.Id)));
        // .ForMember(src => src.Roles,
            //     opt => opt.MapFrom(src => src.Roles.Select(x => x.Name)));
            //
        // For Role parameter query database for Role by Name
        CreateMap<UserEntityInput, UserModel>();
            // .ForMember(src => src.Roles,
            //     opt => opt.Ignore());
    }
}