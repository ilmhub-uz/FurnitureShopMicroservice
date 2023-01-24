using Contract.Api.Dto;

namespace Contract.Api.Services
{
    public interface IContractService
    {
        Task<List<Dto.Contract>> GetContractsAsync();
        Task<Dto.Contract> GetContractByIdAsync();
        Task<Dto.Contract> AddContractAsync();
        Task DeleteContractAsync();
    }
}
