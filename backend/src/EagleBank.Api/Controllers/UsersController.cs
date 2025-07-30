using Microsoft.AspNetCore.Mvc;

namespace EagleBank.Api.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class UsersController : ControllerBase
{
    [HttpGet("{id:guid}")]
    
    public ActionResult GetUser(Guid id) => Ok();
    
    [HttpPost]
    public ActionResult CreateUser() => Ok();
    
    [HttpPatch("{id:guid}")]
    public ActionResult UpdateUser(Guid id) => Ok();
    
    [HttpDelete("{id:guid}")]
    public ActionResult DeleteUser(Guid id) => NoContent();
}