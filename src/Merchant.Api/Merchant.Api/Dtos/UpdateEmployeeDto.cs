using Merchant.Api.Dtos.Enums;
using Merchant.Api.Entities;

namespace Merchant.Api.Dtos;

public class UpdateEmployeeDto
{
    public Guid OrganizationId { get; set; }
    public ERole Role { get; set; }
}
