using Microsoft.AspNetCore.Authorization;
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

    [HttpPost]
    [Authorize(Roles = "admin,lead")]
    public async Task<ActorEntity> AddActor(ActorEntity actor)
    {
        return await Repository.AddActor(actor);
    }

    [HttpDelete]
    [Authorize(Roles = "admin,lead")]
    public async Task<ActorEntity> DeleteActor(ActorEntity actor)
    {
        return await Repository.DeleteActor(actor);
    }

    [HttpPut("{actorName}")]
    public async Task<ActorEntity> UpdateActor(string actorName, [FromBody] ActorEntity actor)
    {
        return await Repository.UpdateActor(actorName, actor);
    }
    
}