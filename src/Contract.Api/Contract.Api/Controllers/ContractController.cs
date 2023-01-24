using Contract.Api.Dto;
using Contract.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Contract.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : Controller
    {
        private readonly IContractService _contractService;
        public ContractController(IContractService contractService)
        {
            _contractService = contractService;
        }

        [HttpGet]
        public async Task<IActionResult> CreateContract()
        {
            var contract = await _contractService.AddContractAsync();

            return Ok();
        }
    }
}
