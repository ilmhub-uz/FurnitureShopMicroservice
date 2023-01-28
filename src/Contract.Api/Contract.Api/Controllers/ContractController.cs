using Contract.Api.Dto;
using Contract.Api.Services;
using Contract.Api.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Contract.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IContractService contractService;
        public ContractController(IContractService contractService)
        {
            this.contractService = contractService;
        }

        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateContract(CreateContractDto createContractDto)
        {
            await contractService.AddContract(createContractDto);

            return Ok();
        }

        [HttpGet("{contractId}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetContractById(Guid contractId)
        {
            var contract = await contractService.GetContractById(contractId);
            return Ok(contract);
        }

        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetContracts([FromBody] ContractFilterDto? contractFilterDto = null)
        {
            var contracts = await contractService.GetContracts(contractFilterDto);
            return Ok(contracts);
        }

        [HttpPut]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateContract(UpdateContractDto updateContractDto)
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
}
