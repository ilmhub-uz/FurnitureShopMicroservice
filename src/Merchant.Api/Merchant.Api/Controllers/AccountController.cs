using Merchant.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Merchant.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    [HttpPost]
    public IActionResult Login(string username, string email, [FromServices] IJwtTokenService jwtTokenService)
    {
        return Ok(jwtTokenService.GenerateToken(username, email));
    }

    [HttpGet]
    [Authorize]
    public IActionResult Profile()
    {
        return Ok(User.FindFirst(ClaimTypes.Name)!.Value);
    }
}
