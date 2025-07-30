using EagleBank.Application.Dtos;
using EagleBank.Domain.Entities;

namespace EagleBank.Application.Services;

public interface IAccountService
{
    Task<AccountDto> GetAccountAsync(Guid id, string? currentUserEmail);
    
    Task<IEnumerable<AccountDto>> GetAccountsAsync(string? currentUserEmail);
    
    Task<AccountDto> AddAccountAsync(CreateAccountRequest request, string? currentUserEmail);
}