using EagleBank.Application.Dtos;

namespace EagleBank.Application.Services;

public interface IUserService
{
    Task<UserDto> CreateUserAsync(CreateUserRequest request);
    Task<string> AuthorizeUserAsync(LoginUserRequest request);
    Task<UserDto> GetUserAsync(Guid id, string? currentUserEmail);
    Task<UserDto> GetCurrentUserAsync(string? currentUserEmail);
}