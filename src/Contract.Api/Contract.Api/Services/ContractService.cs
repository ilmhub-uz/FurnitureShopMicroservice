using Contract.Api.Context.Repositories;
using Contract.Api.Dto;
using Contract.Api.Entities;
using Contract.Api.Services.Interface;
using Contract.Api.ViewModel;
using JFA.DependencyInjection;
using MailKit.Search;
using Mapster;
namespace Contract.Api.Services;

[Scoped]
public class ContractService : IContractService
{

    private readonly IContractRepository contractRepository;

    public ContractService(ContractRepository contractRepository)
    {
        this.contractRepository = contractRepository;
    }

    public async Task<Guid> AddContract(Guid userId, CreateContractDto createContractDto)
    {
        var contractId = Guid.NewGuid();

        var contract   = new Entities.Contract()
        {
            Id         = contractId,
            UserId     = userId,
            CreatedAt  = DateTime.UtcNow,
            FinishDate = DateTime.UtcNow,
            Status     = EContractStatus.Created,
            Products   = ConvertToOrderProduct(createContractDto.ContractOrders!, contractId)
        };

        await contractRepository.AddContract(contract);
        return contractId;
    }

    public async Task DeleteContract(Guid contractId)
    {
        var contract = await contractRepository.GetContractById(contractId);
        await contractRepository.DeleteContract(contract);
    }

    public async Task<ContractView> GetContractById(Guid contractId)
    {
        var contract = await contractRepository.GetContractById(contractId);
        return contract.Adapt<ContractView>();
    }

    public async Task<List<ContractView>> GetContracts(ContractFilterDto? contractFilterDto = null)
    {
        var contracts = await contractRepository.GetContracts(contractFilterDto);
        return contracts.Select(c => c.Adapt<ContractView>()).ToList();
    }

    public async Task UpdateContract(Guid contractId, UpdateContractDto updateContractDto)
    {
        var contract = await contractRepository.GetContractById(contractId);

        if (updateContractDto.Status != null) contract.Status = updateContractDto.Status.Value;

        await contractRepository.UpdateContact(contract);
    }

    private List<ContractOrder> ConvertToOrderProduct(List<ContractOrderDto> contractOrders, Guid contractId)
    {
        var contractProductList = new List<ContractOrder>();
        foreach (var contractProduct in contractOrders)
        {
            contractProductList.Add(new ContractOrder
            {
                Id = Guid.NewGuid(),
                OrderId = contractProduct.OrderId,
                ContractId = contractId,
            });
        }
        return contractProductList;
    }
}