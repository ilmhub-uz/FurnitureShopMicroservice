using Contract.Api.Context.Repositories;
using Contract.Api.Dto;
using Contract.Api.Services.Interface;
using JFA.DependencyInjection;
using Mapster;

namespace Contract.Api.Services;

[Scoped]
public class ContractService : IContractService
{

    private readonly IContractRepository contractRepository;

    public ContractService(ContractRepository contractRepository)
    {
        this.contractRepository = contractRepository;
    }

    public async Task<Guid> AddContract(CreateContractDto createContractDto)
    {
        var contract = createContractDto.Adapt<Entities.Contract>();

        var contractId = Guid.NewGuid();
        contract.Id = contractId;
        // contract.UserId =Guid.Parse(userId);
        await contractRepository.AddContract(contract);

        return contractId;
    }

    public async Task DeleteContract(Guid contractId)
    {
        await contractRepository.DeleteContract(contractId);
    }

    public async Task<ContractViewDto> GetContractById(Guid contractId)
    {
        var contract = await contractRepository.GetContractById(contractId);
        return contract.Adapt<ContractViewDto>();
    }

    public async Task<List<ContractViewDto>> GetContracts(ContractFilterDto? contractFilterDto = null)
    {
        var contracts = await contractRepository.GetContracts(contractFilterDto);
        return contracts.Select(c => c.Adapt<ContractViewDto>()).ToList();
    }

    public async Task UpdateContact(UpdateContractDto updateContractDto)
    {
        await contractRepository.UpdateContact(updateContractDto);
    }
}