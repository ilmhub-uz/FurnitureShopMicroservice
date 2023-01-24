using Dashboard.Api.Entities;

namespace Dashboard.Api.ViewModels;

public class OrganizationUserView
{
    public Guid UserId { get; set; }
    public virtual UserView? User { get; set; }
    public Guid OrganizationId { get; set; }
    
    public virtual OrganizationView? Organization { get; set; }
    public ERole Role { get; set; }
}