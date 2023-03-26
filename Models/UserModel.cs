using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using video_pujcovna_back.ModelConfig;

namespace video_pujcovna_back.Models;

public record UserModel : BaseModel
{

    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
    
    [Required]
    public Guid RoleId { get; set; }
    public RoleModel? Role { get; set; }

    public ICollection<ReservationModel> Reservations { get; set; }
    
}