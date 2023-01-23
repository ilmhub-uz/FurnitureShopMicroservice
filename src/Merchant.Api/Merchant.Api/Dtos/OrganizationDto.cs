using Merchant.Api.Entities;

namespace Merchant.Api.Dtos;

public class OrganizationDto
{
    public string Id { get; set; }
    public string? Name { get; set; }
    public string? ImageUrl { get; set; }
    public EOrganizationStatus Status { get; set; }
    public ICollection<OrganizationUser>? Users { get; set; }
}
