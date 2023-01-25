using Contract.Api.Context.Repositories;
using Contract.Api.Dto;
using Contract.Api.Services.Interface;
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

    public async Task<Entities.Contract> GetContractById(Guid contractId)
    {
        return await contractRepository.GetContractById(contractId);
    }

    public async Task<List<Entities.Contract>> GetContracts(ContractFilterDto? contractFilterDto = null)
    {
        return await contractRepository.GetContracts(contractFilterDto);
    }

    public async Task UpdateContact(UpdateContractDto updateContractDto)
    {
        await contractRepository.UpdateContact(updateContractDto);
    }

    Task<ContractViewDto> IContractService.GetContractById(Guid contractId)
    {
        throw new NotImplementedException();
    }

    Task<List<ContractViewDto>> IContractService.GetContracts(ContractFilterDto? contractFilterDto)
    {
        throw new NotImplementedException();
    }
}