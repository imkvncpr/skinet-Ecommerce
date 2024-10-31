using System.Security.Claims;
using API.DTO_s;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class BuggyController : BaseApiController
{
    [HttpGet("unauthorized")]
    public IActionResult GetUnauthorized() 
    {
        return Unauthorized("User does not have access");
    }
   
    [HttpGet("badrequest")]
    public IActionResult GetBadRequest() 
    {
        return BadRequest("Request is invalid");
    }
   
    [HttpGet("notfound")]
    public IActionResult GetNotFound() 
    {
        return NotFound();
    }
   
    [HttpGet("internalerror")]
    public IActionResult GetInternalError() 
    {
        throw new Exception("This is a test exception");
    }

    [HttpPost("validationerror")]
    public IActionResult GetValidationError(CreateProductDTO product) 
    {
        return Ok();
    }
    
    [Authorize]
    [HttpGet("secret")]
    public IActionResult GetSecret()
    {
        var name = User.FindFirst(ClaimTypes.Name)?.Value;
        var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        return Ok(" Hello "  +  name  +  " Customer Id " + id);
    }

    
}
