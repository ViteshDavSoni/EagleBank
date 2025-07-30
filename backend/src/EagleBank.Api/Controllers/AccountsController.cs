using EagleBank.Application.Dtos;
using EagleBank.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EagleBank.Api.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class AccountsController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountsController(IAccountService accountService)
    {
        _accountService = accountService;
    }
    
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAccounts() => Ok(await _accountService.GetAccountsAsync(User.Identity?.Name));
    
    [Authorize]
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetAccount(Guid id) => Ok(await _accountService.GetAccountAsync(id, User.Identity?.Name));
    
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateAccount(CreateAccountRequest request) => Ok(await _accountService.AddAccountAsync(request, User.Identity?.Name));
}