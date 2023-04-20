namespace video_pujcovna_back.DTO.Input;

public class UserUpdate
{   
    public Guid Id { get; set; }
    
    public string? UserName { get; set; }
    
    public string? Email { get; set; }
    
    public string? Password { get; set; }
    
    public string? Role { get; set; }
}