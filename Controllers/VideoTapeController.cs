using Microsoft.AspNetCore.Mvc;
using video_pujcovna_back.DTO.Input;
using video_pujcovna_back.DTO.Output;
using video_pujcovna_back.Repository;

namespace video_pujcovna_back.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VideoTapeController: ControllerBase<VideotapeRepository>
{
    public VideoTapeController(VideotapeRepository repository) : base(repository)
    {
    }
    
    [HttpGet("{id}")]
    public async Task<VideoTapeEntityOutput> GetVideotape(Guid id)
    {
        return await Repository.GetVideotape(id);
    }
    
    [HttpGet("all")]
    public async Task<IEnumerable<VideoTapeEntityOutput>> GetAllVideotapes()
    {
        return await Repository.GetAllVideotapes();
    }
    
    [HttpPost]
    public async Task<VideoTapeEntityOutput> AddVideoTape(VideoTapeEntityInput videoTape)
    {
        return await Repository.AddVideotape(videoTape);
    }


}