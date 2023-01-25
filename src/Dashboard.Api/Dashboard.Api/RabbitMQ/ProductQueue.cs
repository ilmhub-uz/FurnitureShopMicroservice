namespace Dashboard.Api.RabbitMQ;

public class ProductQueue
{
    public Guid AuthorId { get; set; }
    public string? Name { get; set; }
    public string ProductId { get; set; }
    public string? ProductName { get; set; }
    public string? Description { get; set; }
    public bool? WithInstallation { get; set; }
    public string? Brend { get; set; }
    public string? Material { get; set; }
    public Dictionary<string, string>? Properties { get; set; }
    public decimal Price { get; set; }
    public uint Count { get; set; }
    public int Views { get; set; }
    public List<uint>? Rates { get; set; }
    public int? CategoryId { get; set; }
    public Guid OrganizationId { get; set; }
    public virtual List<string>? Images { get; set; }
    public bool IsAvailable { get; set; }
    public uint ProductCount { get; set; }
}