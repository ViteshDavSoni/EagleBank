using EagleBank.Domain.Entities;
using EagleBank.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

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

    public async Task<User?> GetUserAsync(Guid id)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
    }
    
    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
    
    
}