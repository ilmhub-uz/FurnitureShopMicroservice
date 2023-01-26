using Dashboard.Api.Services.Interfaces;
using Dashboard.Api.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContractController : ControllerBase
{
    private readonly IContractService _contractService;


    public ContractController(IContractService contractService)
    {
        _contractService = contractService;
    }

    [HttpGet]
    public async Task<IActionResult> GetContracts()
    {
        var contracts = await _contractService.GetContractsAsync();

        return Ok(contracts);
    }

    [HttpGet("{categoryId:Guid}")]
    [ProducesResponseType(typeof(CategoryView), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(CategoryView), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetContractById(Guid contractId)
    {
        return Ok();
    }
}
