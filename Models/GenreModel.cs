using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace video_pujcovna_back.Models;

[Table("Genre")]
public record GenreModel
{
    [Key]
    public string Name { get; set; }
    
    [Column("Videotapes")]
    public ICollection<VideotapeModel> Videotapes { get; set; }
}