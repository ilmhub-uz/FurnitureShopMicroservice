using Contract.Api.Dto;
using Contract.Api.Entities;
using JFA.DependencyInjection;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Contract.Api.Context.Repositories;

[Scoped]
public class ContractRepository : IContractRepository, IsEntityExistRepository
{
    private readonly AppDbContext context;

    public ContractRepository(AppDbContext context)
    {
        this.context = context;
    }

    public async Task AddContract(Entities.Contract contract)
    {
        await context.Contracts!.AddAsync(contract);
        await context.SaveChangesAsync();
    }

    public async Task DeleteContract(Entities.Contract contract)
    {
        context.Contracts!.Remove(contract);
        await context.SaveChangesAsync();
    }

    public async Task<Entities.Contract> GetContractById(Guid contractId)
    {
        var contract = await context.Contracts!.FirstAsync(c => c.Id == contractId);
        return contract;
    }

    public async Task<List<Entities.Contract>> GetContracts(ContractFilterDto? contractFilterDto = null)
    {
        var query = context.Contracts!.Where(c => true);

        if (contractFilterDto is not null)
        {
            query = FilterContract(query, contractFilterDto);
        }
        var contracts = await query.ToListAsync();

        return contracts.Select(c => c.Adapt<Entities.Contract>()).ToList();
    }

    public async Task UpdateContact(Entities.Contract contract)
    {

        context.Contracts!.Update(contract);
        context.SaveChanges();
    }

    public async Task<bool> IsEntityExist(Guid contractId)
    {
        if (await context.Contracts!.AnyAsync(c => c.Id == contractId)) return true;
        else return false;
    }

    private IQueryable<Entities.Contract> FilterContract(IQueryable<Entities.Contract> query, ContractFilterDto contractFilterDto)
    {
        if (contractFilterDto.CreatedAt is not null)
        {
            query = query.Where(c => c.UserId == contractFilterDto.UserId);
        }

        if (contractFilterDto.Status is not null)
        {
            query = contractFilterDto.Status switch
            {
                EContractStatus.Confirmed => query.Where(c => c.Status == EContractStatus.Confirmed),
                EContractStatus.Closed => query.Where(c => c.Status == EContractStatus.Closed),
                EContractStatus.Created => query.Where(c => c.Status == EContractStatus.Created),
                EContractStatus.Deleted => query.Where(c => c.Status == EContractStatus.Deleted)
            };
        }

        /* if (contractFilterDto.SortType is not null)
         {
             query = contractFilterDto.SortType switch
             {
                 ESortType.fromCheap => query.OrderByDescending(c => c.TotalPrice),
                 ESortType.fromExpensive => query.OrderBy(c => c.TotalPrice),
                 ESortType.fromCreateDate => query.OrderByDescending(c => c.CreatedAt)
             };
         }*/

        return query;
    }
}