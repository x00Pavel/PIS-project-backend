using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace video_pujcovna_back.Models;

public record ReservationModel: BaseModel
{   
    [Required]
    public Guid UserId { get; set; }
    public UserModel User { get; set; }
    [Required]
    public Guid VideotapeId { get; set; }
    public VideotapeModel Videotape { get; set; }
    [Required]
    public DateTime ReservationDate { get; set; }
    [Required]
    public DateTime ReturnDate { get; set; }
}