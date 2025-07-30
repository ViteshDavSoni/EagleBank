using EagleBank.Application.Dtos;
using EagleBank.Domain.Entities;
using EagleBank.Domain.Exceptions;
using EagleBank.Domain.Repositories;

namespace EagleBank.Application.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IUserRepository _userRepository;
    
    public AccountService(IAccountRepository accountRepository,  IUserRepository userRepository)
    {
        _accountRepository = accountRepository;
        _userRepository = userRepository;
    }
    
    public async Task<AccountDto> GetAccountAsync(Guid id, string? currentUserEmail)
    {
        return await GetAccountWithAuthAsync(id, currentUserEmail);
    }

    public async Task<IEnumerable<AccountDto>> GetAccountsAsync(string? currentUserEmail)
    {
        var accounts = await _accountRepository.GetAccountsAsync(currentUserEmail);
        return accounts.Select(AccountDto.FromEntity);
    }

    public async Task<AccountDto> AddAccountAsync(CreateAccountRequest request, string? currentUserEmail)
    {
        var user = await _userRepository.GetUserByEmailAsync(currentUserEmail);
        if (user == null)
        {
            throw new ForbiddenException();
        }

        var account = Account.CreateAccount(request.AccountName, user.Id);
        account = await _accountRepository.AddAccountAsync(account);
        return AccountDto.FromEntity(account);

    }

    private async Task<AccountDto> GetAccountWithAuthAsync(Guid id, string? currentUserEmail)
    {
        if (currentUserEmail == null)
        {
            throw new ForbiddenException();
        }
        
        var account = await _accountRepository.GetAccountAsync(id);
        var user = await _userRepository.GetUserByEmailAsync(currentUserEmail);
        
        if (account == null)
        {
            throw new NotFoundException();
        }

        if (user == null || account.UserId != user.Id)
        {
            throw new ForbiddenException();
        }
        
        return AccountDto.FromEntity(account);
    }
}