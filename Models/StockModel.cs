using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace video_pujcovna_back.Models;

[Table("Stock")]
public record StockModel : BaseModel
{
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<VideotapeModel> Videotapes { get; set; }
}