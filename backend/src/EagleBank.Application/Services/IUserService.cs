using EagleBank.Application.Dtos;
using EagleBank.Application.Dtos.Requests;

namespace EagleBank.Application.Services;

public interface IUserService
{
    Task<UserDto> CreateUserAsync(CreateUserRequest request);
    Task<string> AuthorizeUserAsync(LoginUserRequest request);
    Task<UserDto> GetUserAsync(Guid id);
    Task<UserDto> GetCurrentUserAsync();
}