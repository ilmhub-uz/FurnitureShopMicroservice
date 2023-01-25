using Contract.Api.Context.Repositories;
using Contract.Api.Dto;
using JFA.DependencyInjection;

namespace Contract.Api.Services;

[Scoped]
public class ContractService : IContractService
{

    private readonly IContractRepository contractRepository;

    public ContractService(IContractRepository contractRepository)
    {
        this.contractRepository = contractRepository;
    }

    public async Task AddContract(CreateContractDto createContractDto)
    {
        await contractRepository.AddContract(createContractDto);
    }

    public async Task DeleteContract(Guid contractId)
    {
        await contractRepository.DeleteContract(contractId);
    }

    public async Task<ContractViewDto> GetContractById(Guid contractId)
    {
        return await contractRepository.GetContractById(contractId);
    }

    public async Task<List<ContractViewDto>> GetContracts(ContractFilterDto? contractFilterDto = null)
    {
        return await contractRepository.GetContracts(contractFilterDto);
    }

    public async Task UpdateContact(UpdateContractDto updateContractDto)
    {
        await contractRepository.UpdateContact(updateContractDto);
    }
}