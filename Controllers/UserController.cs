using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using video_pujcovna_back.Configs;
using video_pujcovna_back.DTO;
using video_pujcovna_back.DTO.Input;
using video_pujcovna_back.DTO.Output;
using video_pujcovna_back.Facades;
using video_pujcovna_back.Models;
using video_pujcovna_back.Repository;

namespace video_pujcovna_back.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController: ControllerBase<UserRepository>
{
    private readonly IMapper _mapper;
    private readonly JwtConfig _jwtConfig;
    private readonly UserManager<UserModel> _userManager;
    private readonly UserFacade _userFacade;

    public UserController(UserRepository userRepository, IMapper mapper, JwtConfig jwtConfig, UserManager<UserModel> userManager, UserFacade userFacade) : base(userRepository)
    {
        _mapper = mapper;
        _jwtConfig = jwtConfig;
        _userManager = userManager;
        _userFacade = userFacade;
    }
    
    
    [HttpPost("login")]
    public async Task<AuthResult> Login(UserLogin user)
    {
        if (!ModelState.IsValid)
            return new AuthResult
            {
                Result = HttpStatusCode.BadRequest,
                Errors = new List<string>
                {
                    "Invalid authentication request"
                }
            };
        var userExist = await _userFacade.GetUserByEmail(user.Email);
        if (userExist == null)
            return new AuthResult()
            {
                Result = HttpStatusCode.BadRequest,
                Errors = new List<string>()
                {
                    "User does not exists"
                }
            };
        
        return new AuthResult
        {
            Result = HttpStatusCode.Accepted,
            Token = GenerateJwtToken(userExist)
        };
    }

    [HttpPost("register")]
    public async Task<AuthResult> AddUser(UserEntityInput user)
    {
        if (!ModelState.IsValid)
            return new AuthResult()
            {
                Result = HttpStatusCode.BadRequest,
                Errors = new List<string>()
                {
                    "Bad request"
                }
            };
        
        
        if (_userFacade.GetUserByEmail(user.Email).Result != null 
            || _userFacade.GetUserByUserName(user.UserName).Result != null)
            return new AuthResult()
                {
                    Result = HttpStatusCode.BadRequest,
                    Errors = new List<string>()
                    {
                        "User already exists"
                    }
                };
        try
        {
            var result = await _userFacade.CreateUser(user);
            return new AuthResult()
            {
                Token = GenerateJwtToken(result),
                Result = HttpStatusCode.Accepted
            };
        }
        catch (Exception e)
        {
            return new AuthResult()
            {
                Result = HttpStatusCode.BadRequest,
                Errors = new List<string>()
                {
                    e.Message
                }
            };
        }
        
    }
    
    [HttpGet("all")]
    [Authorize(Roles = "admin")]
    public async Task<IEnumerable<UserEntityOutput>> GetAllUsers()
    {
        return await Repository.GetAllUser();
    }

    [HttpGet("{id:guid}/reservations")]
    [Authorize(Roles = "customer")]
    public async Task<IEnumerable<ReservationEntityOutput>> GetUserReservations(Guid id)
    {
        return await Repository.GetUserReservations(id);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<UserEntityOutput> GetUser(Guid id)
    {
        return await Repository.GetUser(id);
    }
    
    private string GenerateJwtToken(UserModel user)
    {   
        var options = new IdentityOptions();
        var jwtTokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
        var userRoles = _userManager.GetRolesAsync(user).Result;
        var claims = new List<Claim> {
            new("Id", user.Id.ToString()),
            new(options.ClaimsIdentity.UserIdClaimType, user.Id.ToString()),
            new(options.ClaimsIdentity.EmailClaimType, user.Email),
            new(JwtRegisteredClaimNames.Sub, user.Email),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToUniversalTime().ToString())
        };
        
        
        claims.AddRange(userRoles.Select(userRole => new Claim(options.ClaimsIdentity.RoleClaimType, userRole)));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        
        var token = jwtTokenHandler.CreateToken(tokenDescriptor);
        return jwtTokenHandler.WriteToken(token);
         
    }
    
    [HttpGet("{id:guid}/payments")]
    public async Task<IEnumerable<PaymentEntityOutput>> GetUserPayments(Guid id)
    {
        return await Repository.GetUserPayments(id);
    }
}
