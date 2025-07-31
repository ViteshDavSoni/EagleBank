using EagleBank.Application.Dtos;
using EagleBank.Domain.Entities;
using EagleBank.Domain.Exceptions;
using EagleBank.Domain.Repositories;
using Microsoft.AspNetCore.Http;

namespace EagleBank.Application.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly ICurrentUserService _currentUserService;
    
    public AccountService(IAccountRepository accountRepository, ICurrentUserService currentUserService)
    {
        _accountRepository = accountRepository;
        _currentUserService = currentUserService;
    }
    
    public async Task<AccountDto> GetAccountAsync(Guid id)
    {
        var user = await _currentUserService.GetCurrentUser();
        var account = await _accountRepository.GetAccountAsync(id);
        
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

    public async Task<IEnumerable<AccountDto>> GetAccountsAsync()
    {
        var user = await _currentUserService.GetCurrentUser();
        var accounts = await _accountRepository.GetAccountsAsync(user.Email);
        return accounts.Select(AccountDto.FromEntity);
    }

    public async Task<AccountDto> AddAccountAsync(CreateAccountRequest request)
    {
        var user = await _currentUserService.GetCurrentUser();
        var account = Account.CreateAccount(request.AccountName, user.Id);
        account = await _accountRepository.AddAccountAsync(account);
        return AccountDto.FromEntity(account);

    }
}