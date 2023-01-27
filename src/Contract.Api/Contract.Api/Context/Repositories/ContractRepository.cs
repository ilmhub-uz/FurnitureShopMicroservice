using Contract.Api.Dto;
using Contract.Api.Entities;
using Contract.Api.Entities.Enums;
using Contract.Api.Exceptions;
using Contract.Api.RabbitMq;
using JFA.DependencyInjection;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Contract.Api.Context.Repositories;

[Scoped]
public class ContractRepository : IContractRepository
{
    private readonly AppDbContext context;
    private readonly SendToGetMessage sendToGet;

    public ContractRepository(AppDbContext context, SendToGetMessage sendToGet)
    {
        this.context = context;
        this.sendToGet = sendToGet;
    }

    public async Task AddContract(CreateContractDto createContractDto)
    {
        var contract = createContractDto.Adapt<Entities.Contract>();
        sendToGet.SendMessageContract(contract, "contractadded");
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

    public async Task<List<Entities.Contract>> GetContracts(ContractFilterDto? contractFilterDto)
    {
        var query = context.Contracts!.Select(c => c.Adapt<Entities.Contract>());

        if (contractFilterDto is not null)
        {
            query = FilterContract(query, contractFilterDto);
        }

        return await query.ToListAsync();
    }

    public async Task UpdateContact(UpdateContractDto updateContractDto)
    {
        if (!await context.Contracts!.AnyAsync(c => c.Id == updateContractDto.Id))
        {
            throw new NotFoundException<Entities.Contract>();
        }
        var product = await context.Contracts!.FirstAsync(c => c.Id == updateContractDto.Id);

        context.Contracts!.Update(product);
        await context.SaveChangesAsync();
    }

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