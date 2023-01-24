using Contract.Api.Dto;

namespace Contract.Api.Services;

public interface IContractService
{
    Task<ContractViewDto> GetContractById(Guid contractId);
    Task<List<ContractViewDto>> GetContracts();
    Task AddContract(CreateContractDto createContractDto);
    Task UpdateContact(UpdateContractDto updateContractDto);
    Task DeleteContract(Guid contractId);
}
