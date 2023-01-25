using Merchant.Api.Dtos.Enums;

namespace Merchant.Api.Dtos;

public class EmployeeView
{
    public Guid Id { get; set; }
    public string? UserName { get; set; }
    public ERole Role { get; set; }
}
