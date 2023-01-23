using System.ComponentModel.DataAnnotations.Schema;

namespace Product.Api.Entities;

public class Category
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Views { get; set; }
    public int? ParentId { get; set; }
    public virtual Category? Parent { get; set; }

    public virtual List<Category>? Children { get; set; }
    public virtual ICollection<ProductModel>? Products { get; set; }
}
