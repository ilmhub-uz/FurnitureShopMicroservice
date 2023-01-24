using Merchant.Api.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Merchant.Api.Dtos;

public class OrganizationUserView
{
    public Guid UserId { get; set; }
    public Guid OrganizationId { get; set; }
    public ERole Role { get; set; }
}
