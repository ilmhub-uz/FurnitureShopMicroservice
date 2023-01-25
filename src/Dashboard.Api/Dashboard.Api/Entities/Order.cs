using Dashboard.Api.Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using Dashboard.Api.Entities.Enums;

namespace Dashboard.Api.Entities;

public class Order
{
    public Guid Id { get; set; }
    
    public Guid OrganizationId { get; set; }
    [ForeignKey(nameof(OrganizationId))]
    public virtual Organization? Organization { get; set; }
    
    public Guid UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public virtual AppUser? User { get; set; }

    public EOrderStatus Status { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? LastUpdatedAt { get; set; }

    public virtual ICollection<Order>? OrderProducts { get; set; }
}