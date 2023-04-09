using System.Net;

namespace video_pujcovna_back.DTO.Output;

public class AuthResult
{
    public string Token { get; set; }
    public HttpStatusCode Result { get; set; }
    public List<string> Errors { get; set; }
}