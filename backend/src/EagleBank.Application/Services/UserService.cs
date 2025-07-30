using System.Security.Authentication;
using EagleBank.Application.Dtos;
using EagleBank.Domain.Entities;
using EagleBank.Domain.Exceptions;
using EagleBank.Domain.Repositories;

namespace EagleBank.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<string> AuthorizeUserAsync(LoginUserRequest request)
    {
        var user = await _userRepository.GetUserAsync(request.Email);
        
        if (user == null)
        {
            throw new NotFoundException("User not found.");
        }
        
        if (user.HashedPassword.Equals(AuthExtensions.HashPassword(request.Password)))
        {
            return AuthExtensions.GetToken(request.Email);
        }
        throw new UnauthorizedException("Unable to authenticate user.");
    }

    public async Task<UserDto> CreateUserAsync(CreateUserRequest request)
    {
        var user = User.CreateUser(request.FirstName, request.LastName, request.Email, AuthExtensions.HashPassword(request.Password));
        user = await _userRepository.AddUserAsync(user);
        return UserDto.FromEntity(user);
    }
}