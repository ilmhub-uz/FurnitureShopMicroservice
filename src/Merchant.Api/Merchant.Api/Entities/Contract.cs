namespace Merchant.Api.Entities;
public class Contract
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public uint ProductCount { get; set; }
    public decimal TotalPrice { get; set; }
}
