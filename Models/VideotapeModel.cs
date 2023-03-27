using System.ComponentModel.DataAnnotations;

namespace video_pujcovna_back.Models;

public record VideotapeModel : BaseModel
{   
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    public ICollection<GenreModel> Genre { get; set; }
    public ICollection<ActorModel>? Actors { get; set; }
}