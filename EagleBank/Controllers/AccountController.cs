using Microsoft.AspNetCore.Mvc;

namespace EagleBank.Api.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class AccountController : ControllerBase
{
    [HttpPost]
    public ActionResult CreateAccount()
    {
        return Ok();
    }
    
    [HttpGet]
    public ActionResult GetAccount()
    {
        return Ok();
    }
    
    [HttpPut]
    public ActionResult UpdateAccount()
    {
        return Ok();
    }
    
    [HttpDelete]
    public ActionResult DeleteAccount()
    {
        return Ok();
    }
}