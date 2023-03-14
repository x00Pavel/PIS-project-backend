using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace video_pujcovna_back.Models;

[Table("reservations")]
public record ReservationModel: BaseModel
{   
    [Required]
    public Guid UserId { get; set; }
    public UserModel User { get; set; }
    [Required]
    public Guid RecordId { get; set; }
    public RecordModel Record { get; set; }
    [Required]
    public DateTime ReservationDate { get; set; }
    [Required]
    public DateTime ReturnDate { get; set; }
}