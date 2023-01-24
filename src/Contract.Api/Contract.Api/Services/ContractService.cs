using Contract.Api.Dto;
using Contract.Api.Entities;
using System.Diagnostics.Contracts;

namespace Contract.Api.Services
{
    public class ContractService : IContractService
    {
        public Task<Dto.Contract> AddContractAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteContractAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Dto.Contract> GetContractByIdAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Dto.Contract>> GetContractsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
