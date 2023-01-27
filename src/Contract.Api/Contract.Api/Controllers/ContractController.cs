using Contract.Api.Dto;
using Contract.Api.Services;
using Contract.Api.Services.Interface;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Contract.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContractController : Controller
{
    private readonly IContractService contractService;
    public ContractController(ContractService contractService)
    {
        this.contractService = contractService;
    }

    [HttpPost]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK,type: typeof(Guid))]
    public async Task<IActionResult> CreateContract([FromQuery]CreateContractDto createContractDto)
    {
     // var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        var contractId = await contractService.AddContract(createContractDto/*,userId*/);
        return Ok(contractId);
    }

    [HttpGet("{contractId}")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(ContractViewDto))]
    public async Task<IActionResult> GetContractById(Guid contractId)
    {
        var contract = await contractService.GetContractById(contractId);
        return Ok(contract);
    }


    [HttpGet]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK,type:typeof(List<ContractViewDto>))]
    public async Task<IActionResult> GetContracts([FromQuery]ContractFilterDto? contractFilterDto = null)
    {
        var contracts = await contractService.GetContracts(contractFilterDto);
        return Ok(contracts);
    }

    [HttpPut]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateContract([FromQuery]UpdateContractDto updateContractDto)
    {
        await contractService.UpdateContact(updateContractDto);
        return Ok();
    }

    [HttpDelete]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteContract(Guid contractId)
    {
        await contractService.DeleteContract(contractId);
        return Ok();
    }
}
