namespace Dashboard.Api.Entities;

public class Product
{
    public Guid Id { get; set; }
    public string ProductId { get; set; }
    public string? ProductName { get; set; }
    public string? Description { get; set; }
    public bool? WithInstallation { get; set; }
    public string? Brend { get; set; }
    public string? Material { get; set; }
    public Dictionary<string, string>? Properties { get; set; }
    public decimal Price { get; set; }
    public virtual List<string>? Images { get; set; }
    public bool IsAvailable { get; set; }
    public uint ProductCount { get; set; }
    public int Views { get; set; }
    public EProductStatus Status { get; set; }
}