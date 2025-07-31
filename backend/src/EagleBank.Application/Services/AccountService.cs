using EagleBank.Application.Dtos;
using EagleBank.Application.Dtos.Requests;
using EagleBank.Domain.Entities;
using EagleBank.Domain.Exceptions;
using EagleBank.Domain.Repositories;

namespace EagleBank.Application.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly ITransactionRepository _transactionRepository;
    
    public AccountService(IAccountRepository accountRepository, ICurrentUserService currentUserService,  ITransactionRepository transactionRepository)
    {
        _accountRepository = accountRepository;
        _currentUserService = currentUserService;
        _transactionRepository = transactionRepository;
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

    public async Task<AccountDto> AddTransactionAsync(Guid id, CreateTransactionRequest request)
    {
        var account = await _accountRepository.GetAccountAsync(id);
        if (account == null)
        {
            throw new NotFoundException();
        }
        var transaction = Transaction.CreateTransaction(id, request.TransactionName, request.TransactionType, request.Amount);
        account.AddTransaction(transaction);
        account = await _accountRepository.UpdateAccountAsync(account);
        await _accountRepository.UpdateAccountAsync(account);
        await _transactionRepository.AddTransactionAsync(transaction);
        return await GetAccountAsync(id);
    }
}