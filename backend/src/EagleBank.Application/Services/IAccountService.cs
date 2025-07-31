using EagleBank.Application.Dtos;
using EagleBank.Domain.Entities;

namespace EagleBank.Application.Services;

public interface IAccountService
{
    Task<AccountDto> GetAccountAsync(Guid id);
    
    Task<IEnumerable<AccountDto>> GetAccountsAsync();
    
    Task<AccountDto> AddAccountAsync(CreateAccountRequest request);
}