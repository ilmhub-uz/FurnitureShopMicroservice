using System.ComponentModel.DataAnnotations.Schema;

namespace Dashboard.Api.Entities;

public class OrganizationUser
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public virtual AppUser? User { get; set; }
    public Guid OrganizationId { get; set; }
    [ForeignKey(nameof(OrganizationId))]
    public virtual Organization? Organization { get; set; }
    public ERole Role { get; set; }
}
