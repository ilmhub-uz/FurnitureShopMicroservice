using Contract.Api.Dto;
using Contract.Api.ViewModel;

namespace Contract.Api.Services.Interface;

public interface IContractService
{
    Task<ContractView> GetContractById(Guid contractId);
    Task<List<ContractView>> GetContracts(ContractFilterDto? contractFilterDto);
    Task<Guid> AddContract(Guid userId, CreateContractDto contract);
    Task UpdateContract(Guid contractId, UpdateContractDto updateContractDto);
    Task DeleteContract(Guid contractId);
}
