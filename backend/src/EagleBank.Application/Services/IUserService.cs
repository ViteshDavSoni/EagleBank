using EagleBank.Application.Dtos;

namespace EagleBank.Application.Services;

public interface IUserService
{
    Task<UserDto> CreateUser(CreateUserRequest request);
}