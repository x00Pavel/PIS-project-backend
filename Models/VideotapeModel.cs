using System.ComponentModel.DataAnnotations.Schema;

namespace video_pujcovna_back.Models;

public record VideotapeModel : BaseModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Genre { get; set; }
}