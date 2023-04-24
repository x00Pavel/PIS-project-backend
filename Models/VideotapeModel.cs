using System.ComponentModel.DataAnnotations;

namespace video_pujcovna_back.Models;

public record VideotapeModel : BaseModel
{   
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    public int Duration { get; set; }
    public string CountryOfOrigin { get; set; }
    public string Language { get; set; }
    public string Count { get; set; }
    public string Director { get; set; }
    public int year { get; set; }
    public int PricePerDay { get; set; }
    public ICollection<GenreModel> Genre { get; set; }
    public ICollection<ActorModel> Actors { get; set; }
    public StockModel Stock { get; set; }
}