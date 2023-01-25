using Contract.Api;
using Contract.Api.Context.Repositories;
using Contract.Api.Services;
using Moq;

namespace ContractApi.Test;

public class ContractApiTest
{
    private readonly ContractService contractServices;
    private readonly Mock<ContractRepository> contractRepository;

    public ContractApiTest(Mock<ContractRepository> contractRepository)
    {
        this.contractRepository = contractRepository;
        contractServices = new ContractService(contractRepository.Object);
    }

    [Fact]
    public async Task GetContracts()
    {
        var contracts = await contractServices.GetContracts();
        Assert.NotNull(contracts);
    }

    public async Task AddContract ()
    {
        var contract1 = new Contract.Api.Entities.Contract()
        {

        };

    }
}