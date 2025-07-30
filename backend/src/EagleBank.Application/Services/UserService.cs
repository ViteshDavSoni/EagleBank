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
        var user = await _userRepository.GetUserByEmailAsync(request.Email);
        
        if (user == null)
        {
            throw new NotFoundException();
        }
        
        if (user.HashedPassword.Equals(AuthExtensions.HashPassword(request.Password)))
        {
            return AuthExtensions.GetToken(request.Email);
        }
        throw new UnauthorizedException();
    }

    public async Task<UserDto> CreateUserAsync(CreateUserRequest request)
    {
        var user = User.CreateUser(request.FirstName, request.LastName, request.Email, AuthExtensions.HashPassword(request.Password));
        user = await _userRepository.AddUserAsync(user);
        return UserDto.FromEntity(user);
    }
    
    public async Task<UserDto> GetUserAsync(Guid id, string? currentUserEmail)
    {
        return await GetUserWithAuthAsync(id,  currentUserEmail);
    }
    
    public async Task<UserDto> GetCurrentUserAsync(string? currentUserEmail)
    {
        if (currentUserEmail == null)
        {
            throw new UnauthorizedException();
        }
        
        var user = await _userRepository.GetUserByEmailAsync(currentUserEmail);
        if (user == null)
        {
            throw new NotFoundException();
        }
        
        return await GetUserWithAuthAsync(user.Id,  currentUserEmail);
    }

    private async Task<UserDto> GetUserWithAuthAsync(Guid id, string? currentUserEmail)
    {
        var user = await _userRepository.GetUserAsync(id);

        if (user == null)
        {
            throw new NotFoundException();
        }
        
        if (currentUserEmail == null || user.Email != currentUserEmail)
        {
            throw new ForbiddenException();
        }
        
        return UserDto.FromEntity(user);
    }
}