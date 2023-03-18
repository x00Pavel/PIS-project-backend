using AutoMapper;
using video_pujcovna_back.DTO.Input;
using video_pujcovna_back.DTO.Output;
using video_pujcovna_back.Models;

namespace video_pujcovna_back.Mappers;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<UserModel, UserEntityOutput>()
            .ForMember(src => src.Reservations, 
                opt => opt.MapFrom(src => src.Reservations.Select(x => x.Id)));
        CreateMap<UserEntityInput, UserModel>();
    }
}