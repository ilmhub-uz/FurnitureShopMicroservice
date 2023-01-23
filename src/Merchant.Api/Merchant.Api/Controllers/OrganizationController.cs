using Merchant.Api.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Merchant.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrganizationController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(List<OrganizationDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetOrganizations()
    {
        //some code

        return Ok();
    }

    [HttpPost]
    [ProducesResponseType(typeof(OrganizationDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateOrganization([FromBody] CreateOrganizationDto createOrganization)
    {
        //some code

        return Ok();
    }

    [HttpGet("{organizationId:guid}")]
    [ProducesResponseType(typeof(OrganizationDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetOrganizationByID(string organizationId)
    {
        //some code

        return Ok();
    }

    [HttpPut("{organizationId:guid}")]
    [ProducesResponseType(typeof(OrganizationDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateOrganization(string organizationId, UpdateOrganizationDto updateOrganizationDto)
    {
        //some code

        return Ok();
    }
}
