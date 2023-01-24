using Contract.Api.Entities;

namespace Contract.Api.Dto;

public class UpdateContractDto
{
    public Guid Id { get; set; }
    public EContractStatus Status { get; set; }
    public uint ProductCount { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime FinishDate { get; set; }
}