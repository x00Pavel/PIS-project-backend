using video_pujcovna_back.DTO.Input;

namespace video_pujcovna_back.DTO.Output;

public record VideoTapeEntityOutput
{
    public Guid Id { get; init; }
    public string Title { get; init; }
    public string Description { get; init; }
    public int Duration { get; set; }
    public string CountryOfOrigin { get; set; }
    public string Language { get; set; }
    public string Count { get; set; }
    public string Director { get; set; }
    public int year { get; set; }
    public int PricePerDay { get; set; }
    public ICollection<GenreEntity> Genre { get; init; }
    public ICollection<ActorEntity> Actors { get; init; }
    public StockEntityOutput Stock { get; init; }
}