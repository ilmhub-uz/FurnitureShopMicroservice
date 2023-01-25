using Merchant.Api.Dtos.Enums;

namespace Merchant.Api.Dtos;

public class ProductView
{
    public Guid Id { get; set; }
    public Guid AuthorId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}
