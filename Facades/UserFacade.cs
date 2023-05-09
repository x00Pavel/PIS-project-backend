using AutoMapper;
using Microsoft.AspNetCore.Identity;
using video_pujcovna_back.DTO.Input;
using video_pujcovna_back.DTO.Output;
using video_pujcovna_back.Models;
using video_pujcovna_back.Repository;

namespace video_pujcovna_back.Facades;

public class UserFacade
{

    private readonly UserManager<UserModel> _userManager;
    private readonly UserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserFacade(UserManager<UserModel> userManager, UserRepository userRepository, IMapper mapper)
    {
        _userManager = userManager;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserModel> CreateUser(UserEntityInput user)
    {   
        var result = await _userManager.FindByEmailAsync(user.Email);
        if (result != null)
        {
            throw new Exception("User exists");
        }
        var userMapped = new UserModel
        {
            Id = Guid.NewGuid(),
            Email = user.Email,
            UserName = user.UserName
        };
        return await _userRepository.AddUser(user);
    }


    public async Task<UserModel?> GetUserByEmail(string userEmail)
    {
        return await _userRepository.GetUserByEmail(userEmail);
    }

    public async Task<UserModel?> GetUserByUserName(string userUserName)
    {
        return await _userRepository.GetUserByUserName(userUserName);
    }

    public async Task<UserEntityOutput> UpdateUser(Guid id, UserUpdate userUpdate)
    {
        var result = await _userRepository.UpdateUser(id, userUpdate);
        return _mapper.Map<UserModel, UserEntityOutput>(result);
    }

    public async Task<object> DeleteUser(Guid id)
    {
        return await _userRepository.DeleteUser(id);
    }
}