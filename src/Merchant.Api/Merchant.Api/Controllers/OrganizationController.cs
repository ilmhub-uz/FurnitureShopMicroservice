﻿using Merchant.Api.Dtos;
using Merchant.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Merchant.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrganizationController : ControllerBase
{
    private readonly IOrganizationService _organizationService;

    public OrganizationController(IOrganizationService organizationService)
    {
        _organizationService = organizationService;
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
    public async Task<IActionResult> GetOrganizationByID(Guid organizationId)
    {
        //some code

        return Ok();
    }

    [HttpPut("{organizationId:guid}")]
    [ProducesResponseType(typeof(OrganizationDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateOrganization(Guid organizationId, UpdateOrganizationDto updateOrganizationDto)
    {
        //some code

        return Ok();
    }
}
