using Merchant.Api.Dtos.Enums;

namespace Merchant.Api.Dtos;

public class OrganizationView
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public EOrganizationStatus Status { get; set; }
    public virtual ICollection<OrganizationUserView>? Users { get; set; }
}