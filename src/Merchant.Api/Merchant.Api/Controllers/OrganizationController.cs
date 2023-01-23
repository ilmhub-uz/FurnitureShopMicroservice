using Merchant.Api.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Merchant.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrganizationController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(List<Organization>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetOrganizations()
    {
        //some code

        return Ok();
    }

    [HttpPost]
    [ProducesResponseType(typeof(Organization), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateOrganization([FromBody] CreateOrganization createOrganization)
    {
        //some code

        return Ok();
    }

    [HttpGet("{organizationId:guid}"))]
    [ProducesResponseType(typeof(Organization), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetOrganizationByID(string organizationId)
    {
        //some code

        return Ok();
    }
}
