namespace video_pujcovna_back.DTO.Input;


public class UserEntityInput: UserBaseDTO
{
    public string UserName { get; set; } = string.Empty;
    
    public string Role { get; set; }
    
    public string? Password { get; set; }
     
}
