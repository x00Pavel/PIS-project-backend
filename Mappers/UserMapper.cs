using AutoMapper;
using Microsoft.AspNetCore.Identity;
using video_pujcovna_back.DTO.Input;
using video_pujcovna_back.DTO.Output;
using video_pujcovna_back.Factories;
using video_pujcovna_back.Models;

namespace video_pujcovna_back.Mappers;


public class String2RoleMapper : IValueResolver<UserEntityInput, UserModel, RoleModel>
{
    private readonly RoleManager<RoleModel> _roleManager;

    public String2RoleMapper(RoleManager<RoleModel> roleManager)
    {
        _roleManager = roleManager;
    }

    public RoleModel Resolve(UserEntityInput source, UserModel destination, RoleModel destMember, ResolutionContext context)
    {
        return _roleManager.FindByNameAsync(source.Role).Result ?? throw new KeyNotFoundException("Role not found");
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
        CreateMap<UserEntityInput, UserModel>();
    }
}