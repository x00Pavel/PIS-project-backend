using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace video_pujcovna_back.Models;

public class UserModel
{   
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid UserId { get; set; } = Guid.NewGuid();
    
    [Required]
    public string Username { get; set; }
    
    [Required]
    public string Password { get; set; }

    // TODO add other fields from model
}