using System.Collections;
using video_pujcovna_back.Validators;

namespace video_pujcovna_back.DTO.Input;

public record VideoTapeEntityInput
{

    [SecurityCharactersValidator(ErrorMessage = "Input contains special characters.")]
    public string Title { get; init; }
    [SecurityCharactersValidator(ErrorMessage = "Input contains special characters.")]
    public string Description { get; init; }
    public int Duration { get; set; }
    [SecurityCharactersValidator(ErrorMessage = "Input contains special characters.")]
    public string CountryOfOrigin { get; set; }
    [SecurityCharactersValidator(ErrorMessage = "Input contains special characters.")]
    public string Language { get; set; }
    public int Count { get; set; }
    [SecurityCharactersValidator(ErrorMessage = "Input contains special characters.")]
    public string Director { get; set; }
    public int year { get; set; }
    public int PricePerDay { get; set; }
    public ICollection<GenreEntity> Genre { get; init; }
    public ICollection<ActorEntity> Actors { get; init; }
    public StockEntityReduced stock { get; init; }
    public int Rating { get; set; }
}