using Contract.Api.Entities;
using Contract.Api.Entities.Enums;

namespace Contract.Api.Dto;

public class ContractFilterDto
{
    public Guid? Id { get; set; }
    public Guid? UserId { get; set; }
    public Guid? OrderId { get; set; }
    public EContractStatus? Status { get; set; }
    public DateTime? CreatedAt { get; set; }
    public uint? ProductCount { get; set; }
    public decimal? TotalPrice { get; set; }
    public DateTime? FinishDate { get; set; }
    public ESortType? SortType { get; set; }
 
}