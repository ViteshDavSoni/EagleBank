using EagleBank.Application.Dtos;
using EagleBank.Application.Dtos.Requests;

namespace EagleBank.Application.Services;

public interface IAccountService
{
    Task<AccountDto> GetAccountAsync(Guid id);
    Task<IEnumerable<AccountDto>> GetAccountsAsync();
    Task<AccountDto> AddAccountAsync(CreateAccountRequest request);
    Task<AccountDto> AddTransactionAsync(Guid id, CreateTransactionRequest request);
    Task<IEnumerable<TransactionDto>> GetTransactionsAsync(Guid id);

}