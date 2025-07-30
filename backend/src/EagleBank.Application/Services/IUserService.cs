using EagleBank.Application.Dtos;

namespace EagleBank.Application.Services;

public interface IUserService
{
    Task<UserDto> CreateUserAsync(CreateUserRequest request);
    Task<string> AuthorizeUserAsync(LoginUserRequest request);
}