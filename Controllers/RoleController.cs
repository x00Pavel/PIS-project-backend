using Microsoft.AspNetCore.Mvc;
using video_pujcovna_back.Repository;

namespace video_pujcovna_back.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoleController : ControllerBase<RoleRepository>
{
    public RoleController(RoleRepository repository) : base(repository)
    {
    }
        
    [HttpGet("all")]
    public async Task<ICollection<string>> GetAllRoles()
    {
        return await Repository.GetAllRoles();
    }
}