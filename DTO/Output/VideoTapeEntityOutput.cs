using video_pujcovna_back.DTO.Input;

namespace video_pujcovna_back.DTO.Output;

public record VideoTapeEntityOutput
{
    public Guid Id { get; init; }
    public string Title { get; init; }
    public string Description { get; init; }
    public ICollection<GenreEntity> Genre { get; init; }
    public ICollection<ActorEntity> Actors { get; init; }
    public StockEntityOutput Stock { get; init; }
}