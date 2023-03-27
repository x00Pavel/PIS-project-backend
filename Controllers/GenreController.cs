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
    public Task<ICollection<GenreEntity>> GetAllGenres()
    {
        return Repository.GetAllGenres();
    }



}