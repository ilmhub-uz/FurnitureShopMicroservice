using Contract.Api.Dto;
using Contract.Api.Filters;
using Contract.Api.Services;
using Contract.Api.Services.Interface;
using Contract.Api.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Contract.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContractController : Controller
{
    private readonly IContractService contractService;
    private readonly IEmailService emailService;
    public ContractController(ContractService contractService, EmailService emailService)
    {
        this.contractService = contractService;
        this.emailService = emailService;
    }

    [HttpPost]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(Guid))]
    public async Task<IActionResult> CreateContract([FromQuery] CreateContractDto createContractDto)
    {
        // var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        var contractId = await contractService.AddContract(createContractDto/*,userId*/);
        var emailReceiver = new string[] { "maxammatovabdurauftdyu@gmail.com" };
        emailService.SendEmail(emailReceiver);
        return Ok(contractId);
    }

    [HttpGet("{contractId}")]
    [IdValidation]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(ContractView))]
    public async Task<IActionResult> GetContractById(Guid contractId)
    {
        var contract = await contractService.GetContractById(contractId);
        return Ok(contract);
    }

    [HttpGet]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(List<ContractView>))]
    public async Task<IActionResult> GetContracts([FromQuery] ContractFilterDto? contractFilterDto = null)
    {
        var contracts = await contractService.GetContracts(contractFilterDto);
        return Ok(contracts);
    }

    [HttpPut("{contractId}")]
    [IdValidation]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateContract(Guid contractId, [FromQuery] UpdateContractDto updateContractDto)
    {
        await contractService.UpdateContract(contractId, updateContractDto);
        return Ok();
    }

    [HttpDelete("{contractId}")]
    [IdValidation]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteContract(Guid contractId)
    {
        await contractService.DeleteContract(contractId);
        return Ok();
    }
}