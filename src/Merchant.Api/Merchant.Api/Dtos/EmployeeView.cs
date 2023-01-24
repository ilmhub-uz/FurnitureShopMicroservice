using Merchant.Api.Entities;

namespace Merchant.Api.Dtos;

public class EmployeeView
{
    public Guid Id { get; set;}
    public string? Name { get; set;}
    public ERole Role { get; set;}
}
