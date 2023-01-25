using System.ComponentModel.DataAnnotations.Schema;
using Merchant.Api.Dtos.Enums;

namespace Merchant.Api.Entities;

public class Product
{
    public Guid Id { get; set; }
    public Guid AuthorId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool? WithInstallation { get; set; }
    public string? Brend { get; set; }
    public string? Material { get; set; }
    public Dictionary<string, string>? Properties { get; set; }
    public decimal Price { get; set; }
    public virtual List<string>? Images { get; set; }
    public bool IsAvailable { get; set; }
    public uint Count { get; set; }
    public int Views { get; set; }
    public EProductStatus Status { get; set; }
    public int? CategoryId { get; set; }
    [ForeignKey(nameof(CategoryId))]
    public virtual Category? Category { get; set; }
}
