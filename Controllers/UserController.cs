using Microsoft.AspNetCore.Mvc;
using video_pujcovna_back.DTO.Input;
using video_pujcovna_back.DTO.Output;
using video_pujcovna_back.Repository;

namespace video_pujcovna_back.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController
{
    private readonly UserRepository _userRepository;
    
    public UserController(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost]
    public async Task<UserEntityOutput> AddUser(UserEntityInput user)
    {   
        return await _userRepository.AddUser(user);
    }
    
    [HttpGet("all")]
    public async Task<IEnumerable<UserEntityOutput>> GetAllUsers()
    {
        return await _userRepository.GetAllUser();
    }

    [HttpGet("{id:guid}/reservations")]
    public async Task<IEnumerable<ReservationEntityOutput>> GetUserReservations(Guid id)
    {
        return await _userRepository.GetUserReservations(id);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<UserEntityOutput> GetUser(Guid id)
    {
        return await _userRepository.GetUser(id);
    }
}