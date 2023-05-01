using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using video_pujcovna_back.DTO.Input;
using video_pujcovna_back.DTO.Output;
using video_pujcovna_back.Repository;
using video_pujcovna_back.Facades;
using JsonResult = video_pujcovna_back.Repository.JsonResult;

namespace video_pujcovna_back.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VideoTapeController: ControllerBase<VideotapeRepository, VideoTapeFacade>
{
    public VideoTapeController(VideotapeRepository repository, VideoTapeFacade facade) : base(repository, facade)
    {
    }
    
    [HttpGet("{id:guid}")]
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
    public async Task<JsonResult> GetAllVideotapes()
    {
        try
        {
            return new JsonResult()
            {
                Data = await Repository.GetAllVideotapes(),
                Status = HttpStatusCode.OK
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new JsonResult()
            {
                Status = HttpStatusCode.ExpectationFailed,
                Errors = new[] { "Error while getting all videotapes" }
            };
        }
    }
    
    [HttpPost]
    [Authorize(Roles = "admin,lead")]
    public async Task<JsonResult> AddVideoTape(VideoTapeEntityInput videoTape)
    {
        try
        {
            return new JsonResult()
            {
                Status = HttpStatusCode.OK,
                Data = await Repository.AddVideotape(videoTape)
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new JsonResult()
            {
                Errors = new[] { "Error while adding videotape" },
                Status = HttpStatusCode.ExpectationFailed
            };
        }
    }

    // TODO Authorize
    [HttpPut]
    [Authorize(Roles = "admin,lead")]
    public async Task<JsonResult> UpdateVideoTape(VideoTapeEntityOutput videoTape)
    {
        try
        {
            return new JsonResult()
            {
                Status = HttpStatusCode.OK,
                Data = await Repository.UpdateVideotape(videoTape)
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new JsonResult()
            {
                Status = HttpStatusCode.ExpectationFailed,
                Errors = new[] { "Videotape update failed" }
            };
        }
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "admin,lead")]
    public async Task<JsonResult> DeleteVideoTape(Guid id)
    {
        try
        {
            return new JsonResult()
            {
                Status = HttpStatusCode.OK,
                Data = await Repository.DeleteVideoTape(id)
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new JsonResult()
            {
                Status = HttpStatusCode.ExpectationFailed,
                Errors = new[] { "Videotape delete failed" }
            };
        }
    }

    [HttpPost("image")]
    [Authorize(Roles = "admin,lead")]
    public async Task<JsonResult> UploadImage(Guid id, IFormFile file)
    {   
        var result = await Facade.UploadImage(id, file) ?? null;
        if (result == null)
        {
            return new JsonResult()
            {
                Status = HttpStatusCode.ExpectationFailed,
                Errors = new[] { "Image upload failed" }
            };
        }

        return new JsonResult()
        {
            Status = HttpStatusCode.OK,
            Data = result
        };
    }
        
    [HttpGet("image")]
    public async Task<IActionResult> GetImage(Guid id)
    {   
        return await Facade.GetImage(id);
    }

    [HttpDelete("image")]
    [Authorize(Roles = "admin,lead")]
    public async Task<JsonResult> DeleteImage(Guid id)
    {
        try
        {
            return new JsonResult()
            {
                Status = HttpStatusCode.OK,
                Data = await Repository.DeleteImage(id)
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new JsonResult()
            {
                Status = HttpStatusCode.ExpectationFailed,
                Errors = new[] { "Image delete failed" }
            };
        }
    }
}