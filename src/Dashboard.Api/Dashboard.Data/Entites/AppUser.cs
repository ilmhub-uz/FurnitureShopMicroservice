using System.Diagnostics.Contracts;

namespace Dashboard.Data.Entites;

public class AppUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public EUserStatus Status { get; set; }
    public string? AvatarUrl { get; set; }

    public virtual ICollection<OrganizationUser>? Organizations { get; set; }
    public virtual ICollection<Contract>? Contracts { get; set; }
}
