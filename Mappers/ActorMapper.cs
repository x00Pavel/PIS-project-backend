using AutoMapper;
using video_pujcovna_back.DTO.Input;
using video_pujcovna_back.Models;

namespace video_pujcovna_back.Mappers;

public class ActorMapper: Profile
{
    public ActorMapper()
    {
        CreateMap<ActorEntityInput, ActorModel>();
        CreateMap<ActorModel, ActorEntityInput>();
    }
}