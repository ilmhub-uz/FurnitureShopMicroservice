using Contract.Api.Entities;

namespace Contract.Api.ViewModel;

public class ContractView
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public EContractStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime FinishDate { get; set; }
    public virtual ICollection<ContractOrder>? Products { get; set; }
}