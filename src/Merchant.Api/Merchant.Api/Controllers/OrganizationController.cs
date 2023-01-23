using Merchant.Api.Dtos;
using Merchant.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Merchant.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrganizationController : ControllerBase
{
    private readonly IOrganizationService organizationService;

    public OrganizationController(IOrganizationService organizationService)
    {
        this.organizationService = organizationService;
    }

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
        if (!ModelState.IsValid)
            return BadRequest();

        var organization = await organizationService.CreateOrganizationAsync(createOrganization);

        return Ok(organization);
    }

    [HttpGet("{organizationId:guid}")]
    [ProducesResponseType(typeof(OrganizationDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetOrganizationById(Guid organizationId)
    {
        //organizationService.GetOrganizationById(organizationId);

        return Ok();
    }

    [HttpPut("{organizationId:guid}")]
    [ProducesResponseType(typeof(OrganizationDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateOrganization(Guid organizationId, UpdateOrganizationDto updateOrganizationDto)
        => Ok(await organizationService.UpdateOrganizationAsync(organizationId, updateOrganizationDto));
}
