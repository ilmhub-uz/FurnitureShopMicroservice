using Contract.Api.Dto;
using Microsoft.EntityFrameworkCore;
using Mapster;
using JFA.DependencyInjection;

namespace Contract.Api.Context.Repositories;

[Scoped]
public class ContractRepository : IContractRepository
{
    private readonly AppDbContext context;

    public ContractRepository(AppDbContext context)
    {
        this.context = context;
    }

    public async Task AddContract(CreateContractDto createContractDto)
    {
        var product = createContractDto.Adapt<Entities.Contract>();
        await context.Contracts!.AddAsync(product);
        await context.SaveChangesAsync();
    }

    public async Task DeleteContract(Guid contractId)
    {
        if (!await context.Contracts!.AnyAsync(c => c.Id == contractId))
        {
            throw new Exception(message: "contract not found");
        }

        var product = await context.Contracts!.FirstAsync(c => c.Id == contractId);

        context.Contracts!.Remove(product);
        await context.SaveChangesAsync();
    }

    public async Task<ContractViewDto> GetContractById(Guid contractId)
    {
        if (!await context.Contracts!.AnyAsync(c => c.Id == contractId))
        {
            throw new Exception(message: "contract not found");
        }
        var product = await context.Contracts!.FirstAsync(c => c.Id == contractId);
        return product.Adapt<ContractViewDto>();
    }

    public async Task<List<ContractViewDto>> GetContracts()
    {
        var contracts = await context.Contracts!.Select(c => c.Adapt<ContractViewDto>()).ToListAsync();
        return contracts;
    }

    public async Task UpdateContact(UpdateContractDto updateContractDto)
    {
        if (!await context.Contracts!.AnyAsync(c => c.Id == updateContractDto.Id))
        {
            throw new Exception(message: "contract not found");
        }
        var product = await context.Contracts!.FirstAsync(c => c.Id == updateContractDto.Id);

        context.Contracts!.Update(product);
        await context.SaveChangesAsync();
    }
}