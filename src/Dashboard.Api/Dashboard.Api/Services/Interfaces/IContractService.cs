using Dashboard.Api.ViewModels;

namespace Dashboard.Api.Services.Interfaces;

public interface IContractService
{
    Task<List<ContractView>> GetContractsAsync();
    Task<ContractView> GetContractByIdAsync(Guid contractId);
}
