using System.ComponentModel.DataAnnotations.Schema;

namespace Dashboard.Data.Entities;

public class Product
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string? ProductName { get; set; }
    public uint ProductCount { get; set; }
}