using System.Collections;

namespace video_pujcovna_back.DTO.Input;

public record VideoTapeEntityInput
{

    public string Title { get; init; }
    public string Description { get; init; }
    public ICollection<GenreEntity> Genre { get; init; }
    public ICollection<ActorEntity> Actors { get; init; }
    public string StockName { get; init; }
}