using EagleBank.Domain.Entities;

namespace EagleBank.Domain.Repositories;

public interface IUserRepository
{
    Task<User> AddUserAsync(User user);
    
    Task<User?> GetUserByEmailAsync(string email);

    Task<User?> GetUserAsync(Guid id);
}