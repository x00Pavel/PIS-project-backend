namespace video_pujcovna_back.DTO.Input;


public class UserEntityInput: UserBaseDTO
{
    public string? UserName { get; set; } = string.Empty;
    
    public ICollection<string> Roles { get; set; }
    
}
