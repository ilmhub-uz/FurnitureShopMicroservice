﻿using Merchant.Api.Dtos;
using Merchant.Api.Services;
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
    [ProducesResponseType(typeof(List<OrganizationView?>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetOrganizations()
        => Ok(await organizationService.GetOrganizationsAsync());

    [HttpPost]
    public async Task<IActionResult> CreateOrganization([FromBody] CreateOrganizationDto createOrganization)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        await organizationService.CreateOrganizationAsync(createOrganization);

        return Ok();
    }

    [HttpGet("{organizationId:guid}")]
    [ProducesResponseType(typeof(OrganizationView), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetOrganizationById(Guid organizationId) 
        => Ok(await organizationService.GetOrganizationByIdAsync(organizationId));

    [HttpDelete("{organizationId:guid}")]
    public async Task<IActionResult> DeleteOrganization(Guid organizationId)
    {
        await organizationService.DeleteOrganizationAsync(organizationId);

        return Ok();
    }

    [HttpPut("{organizationId:guid}")]
    public async Task<IActionResult> UpdateOrganization(Guid organizationId, [FromBody] UpdateOrganizationDto updateOrganizationDto)
    {
        await organizationService.UpdateOrganizationAsync(organizationId, updateOrganizationDto);
        
        return Ok();
    }
}