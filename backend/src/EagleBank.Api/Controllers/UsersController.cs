using EagleBank.Application.Dtos;
using EagleBank.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EagleBank.Api.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> AuthorizeUser(LoginUserRequest request)
    {
        var token = await _userService.AuthorizeUserAsync(request);
        return Ok(new { token });
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(Guid id)
    {
        return Ok(await _userService.GetUserAsync(id));
    }
    
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetUser()
    {
        return Ok(await _userService.GetCurrentUserAsync());
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserRequest request)
    {
        return Ok(await _userService.CreateUserAsync(request));
    }
}