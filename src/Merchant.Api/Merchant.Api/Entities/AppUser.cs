namespace Merchant.Api.Entities;

public class AppUser
{
    public Guid Id { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public virtual ICollection<OrganizationUser>? Users { get; set; }
}
