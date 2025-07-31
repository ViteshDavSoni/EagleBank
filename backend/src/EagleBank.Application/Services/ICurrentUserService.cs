using EagleBank.Domain.Entities;

namespace EagleBank.Application.Services;

public interface ICurrentUserService
{
    string? UserEmail { get; }
    Task<User> GetCurrentUser();
}