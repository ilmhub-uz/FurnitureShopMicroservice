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
        //some code

        return Ok();
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
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(updateOrganizationDto);

            if(!await organizationService.ExistsAsync(organizationId))
                return NotFound(new { ErrorMessage = "Organization with given ID not found." });

            var updateOrganizationResult = await organizationService.UpdateOrganizationAsync()
        }

        return Ok(await organizationService.UpdateOrganizationAsync(organizationId, updateOrganizationDto));
    }
}
