namespace Contract.Api.Entities;

public class Contract
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid OrderId { get; set; }
    public EContractStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime FinishDate { get; set; }
    public virtual ICollection<ContractOrder>? Products { get; set; }
}