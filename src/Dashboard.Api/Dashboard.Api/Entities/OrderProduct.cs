using System.ComponentModel.DataAnnotations.Schema;

namespace Dashboard.Api.Entities;

public class OrderProduct
{
    public Guid Id { get; set; }

    public Guid ProductId { get; set; }
    [ForeignKey(nameof(ProductId))]
    public virtual Product? Product { get; set; }

    public Guid OrderId { get; set; }
    [ForeignKey(nameof(OrderId))]
    public virtual Order? Order { get; set; }

    public uint Count { get; set; }
    public string? Properties { get; set; }
}