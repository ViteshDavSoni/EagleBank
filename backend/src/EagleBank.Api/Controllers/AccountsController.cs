using Microsoft.AspNetCore.Mvc;

namespace EagleBank.Api.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class AccountsController : ControllerBase
{
    [HttpGet]
    
    public ActionResult GetAccounts() => Ok();
    
    [HttpGet("{id:guid}")]
    
    public ActionResult GetAccount(Guid id) => Ok();
    
    [HttpPost]
    public ActionResult CreateAccount() => Ok();
    
    [HttpPatch("{id:guid}")]
    public ActionResult UpdateAccount(Guid id) => Ok();
    
    [HttpDelete("{id:guid}")]
    public ActionResult DeleteAccount(Guid id) => NoContent();
}