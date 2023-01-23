using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;




namespace Dashboard.Api.Controllers;

[Route("api/[controller]")]
public class OrganizationsController : Controller
{

    [HttpGet]
    public async Task<IActionResult> GetOrganizations()
    {
        return Ok();
    }

    [HttpGet("{organization:Guid}")]
    public async Task<IActionResult> GetOrganizationById(Guid organizationId)
    {
        return Ok();
    }

    [HttpPut("{organization:Guid}")]
    public async Task<IActionResult> OrganizationUpdateStatus(Guid organizationId)
    {
        return Ok();
    }
}

