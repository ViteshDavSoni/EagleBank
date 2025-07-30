using EagleBank.Application.Dtos;
using EagleBank.Domain.Entities;
using EagleBank.Domain.Repositories;

namespace EagleBank.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDto> CreateUser(CreateUserRequest request)
    {
        var user = User.CreateUser(request.FirstName, request.LastName, request.Email);
        user = await _userRepository.AddUserAsync(user);
        return UserDto.FromEntity(user);
    }
}