using AutoMapper;
using Microsoft.AspNetCore.Identity;
using video_pujcovna_back.DTO.Input;
using video_pujcovna_back.DTO.Output;
using video_pujcovna_back.Factories;
using video_pujcovna_back.Models;

namespace video_pujcovna_back.Mappers;

public class Role2StringMapper: IValueResolver<UserModel, UserEntityOutput, string>
{
    private readonly UserManager<UserModel> _userManager;

    public Role2StringMapper(UserManager<UserModel> userManager)
    {
        _userManager = userManager;
    }

    public string Resolve(UserModel source, UserEntityOutput destination, string destMember, ResolutionContext context)
    {
        return _userManager.GetRolesAsync(source).Result.FirstOrDefault() ?? "unknown";
    }
}


public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<UserModel, UserEntityOutput>()
            .ForMember(src => src.Reservations,
                opt => opt.MapFrom(
                    src => src.Reservations.Select(x => x.Id)))
            .ForMember(dst => dst.Role, 
                opt => opt.MapFrom<Role2StringMapper>());
        CreateMap<UserEntityInput, UserModel>();
    }
}