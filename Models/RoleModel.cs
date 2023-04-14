using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace video_pujcovna_back.Models;

public class RoleModel: IdentityRole<Guid>
{
    [Required]
    public string Description { get; set; }
}