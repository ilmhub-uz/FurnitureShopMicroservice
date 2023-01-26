using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dashboard.Api.Entities.Enums;

namespace Dashboard.Api.Entities;

public class Contract
{
    public Guid Id { get; set; }

    public Guid ContractId { get; set; }
    [Required]
    public Guid UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public virtual AppUser? User { get; set; }
    public EContractStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }

    [Required]
    public uint ProductCount { get; set; }

    [Required]
    public decimal TotalPrice { get; set; }
    public DateTime FinishDate { get; set; }
    public Guid OrderId { get; set; }

    [ForeignKey(nameof(OrderId))]
    public virtual Order? Order { get; set; }
}