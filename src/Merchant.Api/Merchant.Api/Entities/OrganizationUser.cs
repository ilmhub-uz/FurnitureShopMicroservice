using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;

namespace Merchant.Api.Entities;

public class OrganizationUser
{
    public string UserId { get; set; }
    public string OrganizationId { get; set; }
    public Organization? Organization { get; set; }
    public ERole Role { get; set; }
}