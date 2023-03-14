namespace video_pujcovna_back.DTO.Input;

public record UserEntityInput
{
    public string Username { get; set; }
    public string Password { get; set; }
}
