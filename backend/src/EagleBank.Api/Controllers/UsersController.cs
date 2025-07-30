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
    public async Task<ActionResult> AuthorizeUser(LoginUserRequest request)
    {
        var token = await _userService.AuthorizeUserAsync(request);
        return Ok(new { token });
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult> GetUser(Guid id)
    {
        return Ok(await _userService.GetUserAsync(id, User.Identity?.Name));
    }
    
    [Authorize]
    [HttpGet]
    public async Task<ActionResult> GetUser()
    {
        return Ok(await _userService.GetCurrentUserAsync(User.Identity?.Name));
    }

    [HttpPost]
    public async Task<ActionResult> CreateUser(CreateUserRequest request)
    {
        return Ok(await _userService.CreateUserAsync(request));
    }
    
    [HttpPatch("{id:guid}")]
    public ActionResult UpdateUser(Guid id) => Ok();
    
    [HttpDelete("{id:guid}")]
    public ActionResult DeleteUser(Guid id) => NoContent();
}