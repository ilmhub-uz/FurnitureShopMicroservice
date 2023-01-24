using Dashboard.Api.Entities.Enums;

namespace Dashboard.Api.Entities;

public class Organization
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? ImageUrl { get; set; }
    public EOrganizationStatus Status { get; set; }
    public virtual ICollection<OrganizationUser>? Users { get; set; }
}
