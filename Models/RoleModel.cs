using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace video_pujcovna_back.Models;

[Index(nameof(Name))]
public record RoleModel: BaseModel
{   
    [Required]
    public int Priority { get; set; }

    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Description { get; set; }
    
}