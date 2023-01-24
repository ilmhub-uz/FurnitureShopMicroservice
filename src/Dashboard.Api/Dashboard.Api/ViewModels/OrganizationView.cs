using Dashboard.Api.Entities;

namespace Dashboard.Api.ViewModels;

public class OrganizationView
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public EOrganizationStatus Status { get; set; }
    public virtual ICollection<OrganizationUserView>? OrganizationUserViews { get; set; }

}
