using Contract.Api.Context.Repositories;
using Contract.Api.Dto;
using Contract.Api.Services.Interface;
using Contract.Api.ViewModel;
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

        contract.Id = Guid.NewGuid();
        contract.CreatedAt = DateTime.UtcNow;

        await contractRepository.AddContract(contract);

        return contract.Id;
    }

    public async Task DeleteContract(Guid contractId)
    {
        var contract = await contractRepository.GetContractById(contractId);
        await contractRepository.DeleteContract(contract);
    }

    public async Task<ContractView> GetContractById(Guid contractId)
    {
        var contract = await contractRepository.GetContractById(contractId);
        return contract.Adapt<ContractView>();
    }

    public async Task<List<ContractView>> GetContracts(ContractFilterDto? contractFilterDto = null)
    {
        var contracts = await contractRepository.GetContracts(contractFilterDto);
        return contracts.Select(c => c.Adapt<ContractView>()).ToList();
    }

    public async Task UpdateContract(Guid contractId, UpdateContractDto updateContractDto)
    {
        var contract = await contractRepository.GetContractById(contractId);

        if (updateContractDto.Status != null) contract.Status = updateContractDto.Status.Value;

        await contractRepository.UpdateContact(contractId, contract);
    }
}