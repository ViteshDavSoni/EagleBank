using EagleBank.Domain.Entities;
using EagleBank.Domain.Exceptions;
using EagleBank.Domain.Repositories;
using Microsoft.AspNetCore.Http;

namespace EagleBank.Application.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserRepository _userRepository;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
    {
        _httpContextAccessor = httpContextAccessor;
        _userRepository = userRepository;
    }

    public string? UserEmail => _httpContextAccessor.HttpContext?.User?.Identity?.Name;

    public async Task<User> GetCurrentUser()
    {
        if (UserEmail == null)
        {
            throw new UnauthorizedException();
        }
        
        var user = await _userRepository.GetUserByEmailAsync(UserEmail);
        
        if (user == null)
        {
            throw new ForbiddenException();
        }
        
        return user;
    }
}