using EagleBank.Application.Dtos;
using EagleBank.Domain.Entities;
using EagleBank.Domain.Exceptions;
using EagleBank.Domain.Repositories;

namespace EagleBank.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly ICurrentUserService _currentUserService;
    
    public UserService(IUserRepository userRepository,  ICurrentUserService currentUserService)
    {
        _userRepository = userRepository;
        _currentUserService = currentUserService;
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
    
    public async Task<UserDto> GetUserAsync(Guid id)
    {
        var user = await _userRepository.GetUserAsync(id);
        if (user == null)
        {
            throw new NotFoundException();
        }
        if (_currentUserService.UserEmail == null || user.Email != _currentUserService.UserEmail)
        {
            throw new ForbiddenException();
        }
        return UserDto.FromEntity(user);
    }
    
    public async Task<UserDto> GetCurrentUserAsync()
    {
        var user = await _currentUserService.GetCurrentUser();
        return UserDto.FromEntity(user);
    }
}