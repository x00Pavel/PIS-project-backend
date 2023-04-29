using System.Net;

namespace video_pujcovna_back.Repository;

public record JsonResult
{
    public HttpStatusCode Status { get; set; }
    public ICollection<string> Errors { get; set; }
    public object Data { get; set; }
}