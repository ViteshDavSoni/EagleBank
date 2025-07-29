using Microsoft.AspNetCore.Mvc;

namespace EagleBank.Api.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class UserController : ControllerBase
{
    [HttpPost]
    public ActionResult CreateUser()
    {
        return Ok();
    }
    
    [HttpGet]
    public ActionResult GetUsers()
    {
        return Ok();
    }
    
    [HttpPut]
    public ActionResult UpdateUser()
    {
        return Ok();
    }
    
    [HttpDelete]
    public ActionResult DeleteUser()
    {
        return Ok();
    }
}