using Dashboard.Blazor.ModelsDto.Enums;

namespace Dashboard.Blazor.ViewModels;

public class OrganizationView
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public EOrganizationStatus Status { get; set; }
    public virtual ICollection<OrganizationUserView>? Users { get; set; }
}