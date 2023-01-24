using Merchant.Api.Dtos;
using Merchant.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Merchant.Api.Controllers;
[Route("api/[controller]")]
[ApiController]

public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        this.employeeService = employeeService;
    }


    [HttpPost]
    public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeDto createEmployeeDto)
    {
        await employeeService.CreateEmployeeAsync(createEmployeeDto);

        return Ok();
    }

    [HttpGet("{organizationId:guid}")]
    [ProducesResponseType(typeof(List<EmployeeView?>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetEmployees(Guid organizationId)
        => Ok(await employeeService.GetEmployeesAsync(organizationId));

    [HttpGet("{organizationId:guid}/{employeeId:guid}")]
    [ProducesResponseType(typeof(EmployeeView), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetEmployee(Guid organizationId, Guid employeeId)
       => Ok(await employeeService.GetEmployeeByIdAsync(organizationId, employeeId));



    [HttpDelete("{organizationId:guid}/{employeeId:guid}")]
    public async Task<IActionResult> DeleteEmployee(Guid organizationId, Guid employeeId)
    {
        await employeeService.DeleteEmployeeAsync(organizationId, employeeId);
        return Ok();
    }

    [HttpPut("{organizationId:guid}/{employeeId:guid}")]
    public async Task<IActionResult> UpdateOrganization(Guid organizationId, Guid employeeId, [FromBody] UpdateEmployeeDto updateEmployeeDto)
    {
        await employeeService.UpdatEmployeeAsync(organizationId, employeeId, updateEmployeeDto);
        return Ok();
    }
}
