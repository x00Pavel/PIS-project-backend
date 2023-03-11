using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using video_pujcovna_back.Facade;
using video_pujcovna_back.Factories;
using video_pujcovna_back.Models;

namespace video_pujcovna_back.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController
{
    private readonly UserFacade _userFacade;
    
    public UserController(UserFacade userFacade)
    {
        _userFacade = userFacade;
    }

    [HttpPost]
    public async Task<EntityEntry<User>> AddUser([FromBody] User user)
    {
        return await _userFacade.Add(user);
    }
    
    [HttpGet]
    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _userFacade.GetAllUser();
    }
}