using Merchant.Api.Entities;

namespace Merchant.Api.Dtos;

public class OrganizationSortingFilter
{
    public string? OrganizationName { get; set; }
    public DateTime? DateTime { get; set; }
    public EOrganizationStatus? Status { get; set; }
}
