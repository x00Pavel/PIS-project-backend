using video_pujcovna_back.Validators;

namespace video_pujcovna_back.DTO.Input;


public class UserEntityInput: UserBaseDTO
{
    [SecurityCharactersValidator(ErrorMessage = "Input contains special characters.")]
    public string UserName { get; set; } = string.Empty;
    
    [SecurityCharactersValidator(ErrorMessage = "Input contains special characters.")]
    public string Role { get; set; }
    
    public string? Password { get; set; }
     
}
