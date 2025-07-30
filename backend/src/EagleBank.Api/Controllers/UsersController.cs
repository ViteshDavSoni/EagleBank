using EagleBank.Application.Dtos;
using EagleBank.Application.Services;
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
    
    [HttpGet("{id:guid}")]
    public ActionResult GetUser(Guid id) => Ok();

    [HttpPost]
    public async Task<ActionResult> CreateUser(CreateUserRequest request)
    {
        return Ok(await _userService.CreateUser(request));
    }
    
    [HttpPatch("{id:guid}")]
    public ActionResult UpdateUser(Guid id) => Ok();
    
    [HttpDelete("{id:guid}")]
    public ActionResult DeleteUser(Guid id) => NoContent();
}