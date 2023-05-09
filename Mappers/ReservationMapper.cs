using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using video_pujcovna_back.DTO.Input;
using video_pujcovna_back.DTO.Output;
using video_pujcovna_back.Models;
using video_pujcovna_back.Repository;

namespace video_pujcovna_back.Mappers;


public class ReservationUserMapper : IValueResolver<ReservationEntityInput, ReservationModel, UserModel>
{
    private readonly UserRepository _userRepository;

    public ReservationUserMapper(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public UserModel Resolve(ReservationEntityInput source, ReservationModel destination, UserModel destMember, ResolutionContext context)
    {
        return _userRepository.GetUserModel(source.UserId).Result;
    }
}


public class ReservationVideotapeMapper : IValueResolver<ReservationEntityInput, ReservationModel, VideotapeModel>
{
    private readonly VideotapeRepository _videotapeRepository;

    public ReservationVideotapeMapper(VideotapeRepository videotapeRepository)
    {
        _videotapeRepository = videotapeRepository;
    }

    public VideotapeModel Resolve(ReservationEntityInput source, ReservationModel destination, VideotapeModel destMember, ResolutionContext context)
    {
        return _videotapeRepository.GetVideotapeModelByName(source.VideotapeName).Result;
    }
}


public class ReservationMapper: Profile
{
    public ReservationMapper()
    {
        CreateMap<ReservationModel, ReservationEntityOutput>()
            .ForMember(dst => dst.VideotapeName,
                opt => opt.MapFrom(src => src.Videotape.Title))
            .ForMember(dst => dst.Payed,
                opt => opt.MapFrom(src => src.Payment.Paid))
            .ForMember(dst => dst.UserName,
                opt => opt.MapFrom(src => src.User.UserName));
        CreateMap<ReservationEntityInput, ReservationModel>()
            .ForMember(opt => opt.User,
                opt => opt.MapFrom<ReservationUserMapper>())
            .ForMember(opt => opt.Videotape,
                opt => opt.MapFrom<ReservationVideotapeMapper>());
    }
}