using Dashboard.Api.Entities.Enums;

namespace Dashboard.Api.ViewModels;

public class OrganizationUserView
{
    public Guid UserId { get; set; }
    public Guid OrganizationId { get; set; }
    public ERole Role { get; set; }
}
