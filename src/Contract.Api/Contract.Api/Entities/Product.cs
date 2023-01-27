using System.ComponentModel.DataAnnotations.Schema;

namespace Contract.Api.Entities
{
    public class Product
    {
        public string Id { get; set; }
        public Guid AuthorId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool? WithInstallation { get; set; }
        public string? Brend { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Material { get; set; }
        public Dictionary<string, string>? Properties { get; set; }
        public decimal Price { get; set; }
        public virtual List<string>? Images { get; set; }
        public bool IsAvailable { get; set; }
        public uint Count { get; set; }
        public int Views { get; set; }
        public int? CategoryId { get; set; }
    }
}
