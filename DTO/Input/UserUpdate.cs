using System.ComponentModel.DataAnnotations;
using video_pujcovna_back.Validators;

namespace video_pujcovna_back.DTO.Input;

public class UserUpdate
{   
    public Guid Id { get; set; }
    
    [SecurityCharactersValidator(ErrorMessage = "Input contains special characters.")]
    public string? UserName { get; set; }
    
    [EmailAddress]
    public string? Email { get; set; }
    
    public string? Password { get; set; }
    
    [SecurityCharactersValidator(ErrorMessage = "Input contains special characters.")]
    public string? Role { get; set; }
}