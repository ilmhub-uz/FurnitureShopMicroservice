using Contract.Api.Dto;
using Contract.Api.Entities;
using Contract.Api.Entities.Enums;
using Contract.Api.Exceptions;
using JFA.DependencyInjection;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Contract.Api.Context.Repositories;

[Scoped]
public class ContractRepository : IContractRepository
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

    public async Task DeleteContract(Guid contractId)
    {
        if (!await context.Contracts!.AnyAsync(c => c.Id == contractId))
        {
            throw new NotFoundException<Entities.Contract>();
        }

        var product = await context.Contracts!.FirstAsync(c => c.Id == contractId);

        context.Contracts!.Remove(product);
        await context.SaveChangesAsync();
    }

    public async Task<Entities.Contract> GetContractById(Guid contractId)
    {
        if (!await context.Contracts!.AnyAsync(c => c.Id == contractId))
        {
            throw new NotFoundException<Entities.Contract>();
        }
        var product = await context.Contracts!.FirstAsync(c => c.Id == contractId);
        return product.Adapt<Entities.Contract>();
    }

    public async Task<List<Entities.Contract>> GetContracts(ContractFilterDto? contractFilterDto = null)
    {
        var query = context.Contracts!.Where(c =>true);

        if (contractFilterDto is not null)
        {
            query = FilterContract(query, contractFilterDto);
        }
        var contracts  = await query.ToListAsync();

        return contracts.Select(c => c.Adapt<Entities.Contract>()).ToList();
    }

    public async Task UpdateContact(UpdateContractDto updateContractDto)
    {
        if (!await context.Contracts!.AnyAsync(c => c.Id == updateContractDto.Id))
        {
            throw new NotFoundException<Entities.Contract>();
        }
        var product = await context.Contracts!.FirstAsync(c => c.Id == updateContractDto.Id);

        if (updateContractDto.Status != null)       product.Status = updateContractDto.Status.Value;
        if (updateContractDto.ProductCount != null) product.ProductCount = updateContractDto.ProductCount.Value;
        if (updateContractDto.FinishDate != null)   product.FinishDate = updateContractDto.FinishDate.Value;
        if (updateContractDto.TotalPrice != null)   product.TotalPrice = updateContractDto.TotalPrice.Value;

        await context.SaveChangesAsync();
    }
 
    public EContractStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public uint ProductCount { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime FinishDate { get; set; }
    private IQueryable<Entities.Contract> FilterContract(IQueryable<Entities.Contract> query, ContractFilterDto contractFilterDto)
    {

        if (contractFilterDto.UserId is not null)
        {
            query = query.Where(c => c.UserId == contractFilterDto.UserId);
        }

        if (contractFilterDto.OrderId is not null)
        {
            query = query.Where(c => c.OrderId == contractFilterDto.OrderId);
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

        if (contractFilterDto.SortType is not null)
        {
            query = contractFilterDto.SortType switch
            {
                ESortType.fromCheap => query.OrderByDescending(c => c.TotalPrice),
                ESortType.fromExpensive => query.OrderBy(c => c.TotalPrice),
                ESortType.fromCreateDate => query.OrderByDescending(c => c.CreatedAt)
            };
        }
        
        return query;
    }
}