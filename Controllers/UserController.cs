using Microsoft.AspNetCore.Mvc;
using video_pujcovna_back.DTO.Input;
using video_pujcovna_back.DTO.Output;
using video_pujcovna_back.Repository;

namespace video_pujcovna_back.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController: ControllerBase<UserRepository>
{
    
    public UserController(UserRepository userRepository) : base(userRepository)
    {
    }
    

    [HttpPost]
    public async Task<UserEntityOutput> AddUser(UserEntityInput user)
    {   
        var userMapped = await Repository.AddUser(user);
        Console.WriteLine(userMapped);
        return userMapped;
    }
    
    [HttpGet("all")]
    public async Task<IEnumerable<UserEntityOutput>> GetAllUsers()
    {
        return await Repository.GetAllUser();
    }

    [HttpGet("{id:guid}/reservations")]
    public async Task<IEnumerable<ReservationEntityOutput>> GetUserReservations(Guid id)
    {
        return await Repository.GetUserReservations(id);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<UserEntityOutput> GetUser(Guid id)
    {
        return await Repository.GetUser(id);
    }
}