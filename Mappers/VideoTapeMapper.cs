using AutoMapper;
using video_pujcovna_back.DTO.Input;
using video_pujcovna_back.DTO.Output;
using video_pujcovna_back.Factories;
using video_pujcovna_back.Models;
using video_pujcovna_back.Repository;

namespace video_pujcovna_back.Mappers;

public class VideotapeActorMapper : IValueResolver<VideoTapeEntityInput, VideotapeModel, ICollection<ActorModel>>
{
    private readonly ActorRepository repository;

    public VideotapeActorMapper(ActorRepository repository)
    {
        this.repository = repository;
    }

    public ICollection<ActorModel> Resolve(VideoTapeEntityInput source, VideotapeModel destination, ICollection<ActorModel> destMember,
        ResolutionContext context)
    {
        return repository.GetActorModelList(source.Actors).Result;
    }
}
public class VideoTapeMapper: Profile
{
    public VideoTapeMapper()
    {
        CreateMap<VideotapeModel, VideoTapeEntityOutput>();
        CreateMap<VideoTapeEntityInput, VideotapeModel>()
            .ForMember(src => src.Actors, 
                opt => opt.MapFrom<VideotapeActorMapper>());
    }
}

public class GenreMapper: Profile
{
    public GenreMapper()
    {
        CreateMap<GenreModel, GenreEntity>();
        CreateMap<GenreEntity, GenreModel>();
    }
}