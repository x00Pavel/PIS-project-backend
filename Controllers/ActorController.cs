using Microsoft.AspNetCore.Mvc;
using video_pujcovna_back.DTO.Input;
using video_pujcovna_back.Repository;

namespace video_pujcovna_back.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActorController: ControllerBase<ActorRepository>
{
    public ActorController(ActorRepository repository) : base(repository)
    {
    }
    
    [HttpGet("all")]
    public async Task<IEnumerable<ActorEntity>> GetAllActors()
    {
        return await Repository.GetAllActors();
    }
    
}