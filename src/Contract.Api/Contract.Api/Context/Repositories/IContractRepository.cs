using Contract.Api.Dto;

namespace Contract.Api.Context.Repositories;

public interface IContractRepository
{
    Task<Entities.Contract> GetContractById(Guid contractId);
    Task<List<Entities.Contract>> GetContracts(ContractFilterDto? contractFilterDto);
    Task AddContract(Entities.Contract contract);
    Task UpdateContact(Guid userId, Entities.Contract updateContractDto);
    Task DeleteContract(Entities.Contract contract);
}