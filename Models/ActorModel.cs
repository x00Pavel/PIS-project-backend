using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace video_pujcovna_back.Models;


[Table("Actor")]
public record ActorModel: BaseModel
{   
    [Required]
    public string NameAndSurname { get; set; }
    
    [Column("Videotapes")]
    public ICollection<VideotapeModel> Videotapes { get; set; }
}