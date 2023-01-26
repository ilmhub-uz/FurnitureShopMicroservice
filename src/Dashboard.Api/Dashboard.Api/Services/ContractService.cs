using Dashboard.Api.Context;
using Dashboard.Api.Entities;
using Dashboard.Api.Exceptions;
using Dashboard.Api.Services.Interfaces;
using Dashboard.Api.ViewModels;
using JFA.DependencyInjection;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Api.Services;


[Scoped]
public class ContractService : IContractService
{
    private readonly AppDbContext _context;

    public ContractService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ContractView> GetContractByIdAsync(Guid contractId)
    {
        var contract = await _context.Contracts.FirstOrDefaultAsync();

        if (contract is null)
        {
            throw new NotFoundException<Contract>();
        }

        return contract.Adapt<ContractView>();
    }

    public async Task<List<ContractView>> GetContractsAsync()
    {
        var contracts = await _context.Contracts.ToListAsync();
        contracts ??= new List<Contract>();
        return contracts.Select(c => c.Adapt<ContractView>()).ToList();
    }
}
