namespace Dashboard.Api.ModelsDto;

public class CreateCategoryDto
{
    public string Name { get; set; }
    public int? ParentId { get; set; }
}