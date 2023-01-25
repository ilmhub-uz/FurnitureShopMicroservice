using Dashboard.Api.Entities.Enums;

namespace Dashboard.Api.ModelsDto;

public class UpdateProductDto
{
    public EProductStatus Status { get; set; }
}