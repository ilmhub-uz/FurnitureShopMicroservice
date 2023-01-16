namespace ProductApi.Entities;

public class Product
{
    public string Id { get; set; }
    public string? Name { get; set; }
    public int Count { get; set; }
    public decimal Price { get; set; }

    public Category? Category { get; set; }
    public Brand? Brand { get; set; }
}

public class Category
{
    public string? Name { get; set; }
}

public class Brand
{
    public string? Name { get; set; }
    public string? Description { get; set; }
}