using Contract.Api.Entities;

namespace Contract.Api.Dto;

public class UpdateContractDto
{
    public EContractStatus? Status { get; set; }
}