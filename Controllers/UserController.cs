using Microsoft.AspNetCore.Mvc;
using video_pujcovna_back.DTO.Input;
using video_pujcovna_back.DTO.Output;
using video_pujcovna_back.Facade;

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
    public async Task<UserEntityOutput> AddUser(UserEntityInput user)
    {   
        return await _userFacade.AddUser(user);
    }
    
    [HttpGet]
    public async Task<IEnumerable<UserEntityOutput>> GetAllUsers()
    {
        return await _userFacade.GetAllUser();
    }
}