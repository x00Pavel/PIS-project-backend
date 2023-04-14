using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using video_pujcovna_back.ModelConfig;

namespace video_pujcovna_back.Models;

public class UserModel : IdentityUser<Guid>
{
    // Fields such as name, email, password hash etc. are inherited from IdentityUser
    public ICollection<ReservationModel>? Reservations { get; set; }
}