using API.DTO_s;
using Core.Entities;
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
    public IActionResult GetNot() 
    {
        return Unauthorized();
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
   
}
