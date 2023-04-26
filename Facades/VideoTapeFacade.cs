using video_pujcovna_back.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace video_pujcovna_back.Facades;

public class VideoTapeFacade : FacadeBase<VideotapeRepository>
{
    public VideoTapeFacade(VideotapeRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    public async Task<IActionResult> UploadImage(Guid id, IFormFile file)
    {
        if (file == null)
        {
            return new BadRequestObjectResult("File is null");
        }
        var videotape = await Repository.GetVideotapeModel(id);
        if (videotape == null)
        {
            return new NotFoundObjectResult("Videotape not found");
        }
        if (videotape.ImagePath != null && System.IO.File.Exists(videotape.ImagePath))
        {
            System.IO.File.Delete(videotape.ImagePath);
        }

        var path = Path.Combine(Directory.GetCurrentDirectory(), "images", id.ToString() + Path.GetExtension(file.FileName));
        var extension = Path.GetExtension(path).Replace(".", "");
        if (extension != "jpg" && extension != "png" && extension != "jpeg")
        {
            return new BadRequestObjectResult("Wrong file extension");
        }
        var folder = Path.GetDirectoryName(path);
        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }
        using var stream = new FileStream(path, FileMode.Create);
        await file.CopyToAsync(stream);
        return await Repository.UploadImage(videotape, path);
    }

    public async Task<IActionResult> GetImage(Guid id)
    {
        var videotape = await Repository.GetVideotapeModel(id);
        if (videotape == null || videotape.ImagePath == null)
        {
            return new NotFoundResult();
        }
        if (!System.IO.File.Exists(videotape.ImagePath))
        {
            return new NotFoundResult();
        }
        var extension = Path.GetExtension(videotape.ImagePath).Replace(".", "");
        var stream = new FileStream(videotape.ImagePath, FileMode.Open);
        var contentType = $"image/{extension}";
        return new FileStreamResult(stream, contentType);
    }

    public async Task<IActionResult> DeleteImage(Guid id)
    {
        var videotape = await Repository.GetVideotapeModel(id);
        if (videotape == null || videotape.ImagePath == null)
        {
            return new NotFoundResult();
        }
        if (!System.IO.File.Exists(videotape.ImagePath))
        {
            return new NotFoundResult();
        }
        System.IO.File.Delete(videotape.ImagePath);
        return await Repository.DeleteImage(videotape);
    }
}