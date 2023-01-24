using System.ComponentModel.DataAnnotations.Schema;

namespace Dashboard.Data.Entites;

public class OrganizationUser
{
    public Guid UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public virtual AppUser? User { get; set; }
    
    public Guid OrganizationId { get; set; }
    [ForeignKey(nameof(OrganizationId))]
    public virtual Organization? Organization { get; set; }

    public string UserId { get; set; }
    public Guid OrganizationId { get; set; }
    public virtual Organization? Organization { get; set; }
    public ERole Role { get; set; }
}