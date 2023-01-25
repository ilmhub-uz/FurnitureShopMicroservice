using Identity.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Identity.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController : ControllerBase
{
    [HttpPost]
    public IActionResult Login(string username, [FromServices] IJwtTokenService jwtTokenService)
    {
        return Ok(jwtTokenService.GenerateToken(username));
    }

    [HttpGet]
    [Authorize]
    public IActionResult Profile()
    {
        return Ok(User.FindFirst(ClaimTypes.Name)!.Value);
    }
}