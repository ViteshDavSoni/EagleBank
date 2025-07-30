using EagleBank.Domain.Entities;
using EagleBank.Domain.Repositories;

namespace EagleBank.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IDbContext _dbContext;

    public UserRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> AddUserAsync(User user)
    {
        user = _dbContext.Users.Add(user).Entity;
        await _dbContext.SaveChangesAsync();
        return user;
    }
}