using Contract.Api.Dto;

namespace Contract.Api.Context.Repositories;

public interface IContractRepository
{
    Task<Entities.Contract> GetContractById(Guid contractId);
    Task<List<Entities.Contract>> GetContracts(ContractFilterDto? contractFilterDto);
    Task AddContract(CreateContractDto createContractDto);
    Task UpdateContact(UpdateContractDto updateContractDto);
    Task DeleteContract(Guid contractId);
}