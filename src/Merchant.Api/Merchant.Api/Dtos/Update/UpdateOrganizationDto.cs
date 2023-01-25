using Merchant.Api.Entities;

namespace Merchant.Api.Dtos.Update;

public class UpdateOrganizationDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public IFormFile? ImageUrl { get; set; }
}
