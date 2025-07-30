using EagleBank.Application.Dtos;

namespace EagleBank.Application.Services;

public interface IUserService
{
    Task<UserDto> CreateUserAsync(CreateUserRequest request);
    string AuthorizeUser(LoginUserRequest request);
}