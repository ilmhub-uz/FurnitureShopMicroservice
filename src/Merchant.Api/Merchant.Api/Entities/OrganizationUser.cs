namespace Merchant.Api.Entities;

public class OrganizationUser
{
    public Guid UserId { get; set; }
    public Guid OrganizationId { get; set; }
    public Organization? Organization { get; set; }
    public ERole Role { get; set; }
}