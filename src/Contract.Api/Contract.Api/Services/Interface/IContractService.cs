using Contract.Api.Dto;

namespace Contract.Api.Services.Interface;

public interface IContractService
{
    Task<ContractViewDto> GetContractById(Guid contractId);
    Task<List<ContractViewDto>> GetContracts(ContractFilterDto? contractFilterDto);
    Task<Guid> AddContract(CreateContractDto contract);
    Task UpdateContact(UpdateContractDto updateContractDto);
    Task DeleteContract(Guid contractId);
}
