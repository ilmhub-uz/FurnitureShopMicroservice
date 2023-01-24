using Dashboard.Api.Entities;
using Dashboard.Api.Entities.Enums;

namespace Dashboard.Api.ViewModels;

public class OrderView
{
    public Guid Id { get; set; }
    public Guid OrganizationId { get; set; }
    public Guid UserId { get; set; }
    public EOrderStatus Status { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime LastUpdate { get; set; }

    public virtual ICollection<OrderProductView>? OrderProduct { get; set; }
}
