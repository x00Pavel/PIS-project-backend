using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using video_pujcovna_back.DTO.Input;
using video_pujcovna_back.DTO.Output;
using video_pujcovna_back.Repository;
using video_pujcovna_back.Facades;

namespace video_pujcovna_back.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VideoTapeController: ControllerBase<VideotapeRepository, VideoTapeFacade>
{
    public VideoTapeController(VideotapeRepository repository, VideoTapeFacade facade) : base(repository, facade)
    {
    }
    
    [HttpGet("{id}")]
    public async Task<VideoTapeEntityOutput> GetVideotape(Guid id)
    {
        return await Repository.GetVideotape(id);
    }

    [HttpGet("{name}")]
    public async Task<VideoTapeEntityOutput> GetVideotapeByName(string name)
    {
        return await Repository.GetVideotapeByName(name);
    }
    
    [HttpGet("all")]
    public async Task<IEnumerable<VideoTapeEntityOutput>> GetAllVideotapes()
    {
        return await Repository.GetAllVideotapes();
    }
    
    [HttpPost]
    [Authorize(Roles = "admin,lead")]
    public async Task<VideoTapeEntityOutput> AddVideoTape(VideoTapeEntityInput videoTape)
    {
        return await Repository.AddVideotape(videoTape);
    }

    // TODO Authorize
    [HttpPut]
    [Authorize(Roles = "admin,lead")]
    public async Task<VideoTapeEntityOutput> UpdateVideoTape(VideoTapeEntityOutput videoTape)
    {   
        Console.WriteLine("Hit update video tape");
        Console.WriteLine(videoTape);
        return await Repository.UpdateVideotape(videoTape);
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "admin,lead")]
    public async Task<bool> DeleteVideoTape(Guid id)
    {
        return await Repository.DeleteVideoTape(id);
    }

    [HttpPost("image")]
    //[Authorize(Roles = "admin,lead")]
    public async Task<IActionResult> UploadImage(Guid id, IFormFile file)
    {
        return await Facade.UploadImage(id, file);
    }

    [HttpGet("image")]
    public async Task<IActionResult> GetImage(Guid id)
    {
        return await Facade.GetImage(id);
    }

    [HttpDelete("image")]
    public async Task<IActionResult> DeleteImage(Guid id)
    {
        return await Facade.DeleteImage(id);
    }


}