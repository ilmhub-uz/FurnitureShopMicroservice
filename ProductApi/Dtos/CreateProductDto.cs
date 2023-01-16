namespace ProductApi.Dtos;

public class CreateProductDto
{
    public string? Name { get; set; }
    public int Count { get; set; }
    public decimal Price { get; set; }

    public CreateCategoryDto? Category { get; set; }
    public CreateBrandDto? Brand { get; set; }
}

public class CreateCategoryDto
{
    public string? Name { get; set; }
}

public class CreateBrandDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
}