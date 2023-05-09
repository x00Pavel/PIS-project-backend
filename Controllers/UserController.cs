using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using video_pujcovna_back.DTO.Input;
using video_pujcovna_back.DTO.Output;
using video_pujcovna_back.Facades;
using video_pujcovna_back.Models;
using video_pujcovna_back.Repository;
using JsonResult = video_pujcovna_back.Repository.JsonResult;

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
    public async Task<JsonResult> GetAllUsers()
    {
        try
        {
            return new JsonResult()
            {
                Status = HttpStatusCode.OK,
                Data = await Repository.GetAllUser()
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new JsonResult()
            {
                Status = HttpStatusCode.ExpectationFailed,
                Errors = new[] { "Error while getting all users" }
            };
        }
    }

    [HttpGet("{id:guid}/reservations")]
    public async Task<JsonResult> GetUserReservations(Guid id)
    {
        try
        {
            return new JsonResult()
            {
                Status = HttpStatusCode.OK,
                Data = await Repository.GetUserReservations(id)
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new JsonResult()
            {
                Status = HttpStatusCode.ExpectationFailed,
                Errors = new[] { "Error while getting user reservations" }
            };
        }
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
    
    [HttpPut("{id:guid}")]
    [Authorize(Roles = "admin,employee,lead,customer")]
    public async Task<UserEntityOutput> UpdateUser(Guid id, [FromBody] UserUpdate userUpdate)
    {
        Console.WriteLine("User role is " + userUpdate.Role);
        return await _userFacade.UpdateUser(id, userUpdate);
        
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "admin")]
    public async Task<JsonResult> DeleteUser(Guid id)
    {
        try
        {
            return new JsonResult()
            {
                Status = HttpStatusCode.OK,
                Data = await _userFacade.DeleteUser(id)
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new JsonResult
            {
                Status = HttpStatusCode.BadRequest,
                Errors = new[] { "Error while deleting user" }
            };
        }
    }
}
