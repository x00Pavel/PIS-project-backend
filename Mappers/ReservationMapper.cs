using AutoMapper;
using video_pujcovna_back.DTO.Input;
using video_pujcovna_back.Models;
using video_pujcovna_back.DTO.Output;

namespace video_pujcovna_back.Mappers;

public class ReservationMapper: Profile
{
    public ReservationMapper()
    {
        CreateMap<ReservationModel, ReservationEntityOutput>();
        CreateMap<ReservationEntityInput, ReservationModel>();
    }
}