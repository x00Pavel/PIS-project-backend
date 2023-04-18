using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using video_pujcovna_back.DTO.Input;
using video_pujcovna_back.Repository;

namespace video_pujcovna_back.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenreController: ControllerBase<GenreRepository>
{
    public GenreController(GenreRepository repository) : base(repository)
    {
    }

    [HttpGet("all")]
    public async Task<ICollection<GenreEntity>> GetAllGenres()
    {
        return await Repository.GetAllGenres();
    }

    [HttpPost]
    [Authorize(Roles = "admin,lead")]
    public async Task<GenreEntity> AddGenre(GenreEntity genre)
    {
        return await Repository.AddGenre(genre);
    }

    [HttpDelete]
    [Authorize(Roles = "admin,lead")]
    public async Task<GenreEntity> DeleteGenre(GenreEntity genre)
    {
        return await Repository.DeleteGenre(genre);
    }



}