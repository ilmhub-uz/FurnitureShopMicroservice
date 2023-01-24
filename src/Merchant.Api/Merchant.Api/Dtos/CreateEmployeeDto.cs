using Merchant.Api.Entities;

namespace Merchant.Api.Dtos;

public class CreateEmployeeDto
{
    public Guid OrganizationId { get; set; }
    public string? Email { get; set; }
    public ERole Role { get; set; }
}
