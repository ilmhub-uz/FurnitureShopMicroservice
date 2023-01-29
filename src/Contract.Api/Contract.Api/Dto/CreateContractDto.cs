using Contract.Api.Entities;

namespace Contract.Api.Dto;

public class CreateContractDto
{
    public List<ContractOrderDto>? ContractOrders { get; set; }
}