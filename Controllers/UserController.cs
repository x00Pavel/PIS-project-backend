using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using video_pujcovna_back.DTO.Output;
using video_pujcovna_back.Facades;
using video_pujcovna_back.Models;
using video_pujcovna_back.Repository;

namespace video_pujcovna_back.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "admin,employee,lead,customer")]
public class UserController: ControllerBase<UserRepository>
{

    private readonly UserManager<UserModel> _userManager;
    private readonly UserFacade _userFacade;

    public UserController(UserRepository userRepository, UserManager<UserModel> userManager, UserFacade userFacade) : base(userRepository)
    {
        _userManager = userManager;
        _userFacade = userFacade;
    }
    
    
    [HttpGet("all")]
    [Authorize(Roles = "admin")]
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

    [HttpGet("{id:guid}/payments")]
    public async Task<IEnumerable<PaymentEntityOutput>> GetUserPayments(Guid id)
    {
        return await Repository.GetUserPayments(id);
    }
}
