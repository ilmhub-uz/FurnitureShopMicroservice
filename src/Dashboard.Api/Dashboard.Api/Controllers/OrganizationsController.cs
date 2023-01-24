using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboard.Api.ModelsDto;
using Dashboard.Api.Services.Interfaces;
using Dashboard.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;




namespace Dashboard.Api.Controllers;

[Route("api/[controller]")]
public class OrganizationsController : Controller
{
    private readonly IOrganizationService _organizationService;

    public OrganizationsController(IOrganizationService organizationService)
    {
        _organizationService = organizationService;
    }


    [HttpGet]
    [ProducesResponseType(typeof(List<OrganizationView>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetOrganizations()
    {
        var organizations = await _organizationService.GetOrganizations();

        return Ok(organizations);
    }

    [HttpGet("{organization:Guid}")]
    [ProducesResponseType(typeof(OrganizationView), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(OrganizationView), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetOrganizationById(Guid organizationId)
    {
        var organization = await _organizationService.GetOrganizationById(organizationId);

        return Ok(organization);
    }

    [HttpPut("{organization:Guid}")]

    public async Task<IActionResult> OrganizationUpdateStatus(Guid organizationId, UpdateOrganizationDto updateOrganizationDto)
    {
        await _organizationService.UpdateOrganizationStatus(organizationId, updateOrganizationDto);

        return Ok();
    }
}

