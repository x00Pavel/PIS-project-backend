using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace video_pujcovna_back.Models;

public record UserModel : BaseModel
{
    
    [Required]
    public string Username { get; set; }
    
    [Required]
    public string Password { get; set; }
    
    public ICollection<ReservationModel> Reservations { get; set; }
    // TODO add other fields from model
}