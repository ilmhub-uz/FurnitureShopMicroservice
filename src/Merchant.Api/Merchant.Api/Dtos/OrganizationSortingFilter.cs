using Merchant.Api.Dtos.Enums;

namespace Merchant.Api.Dtos;

public class OrganizationSortingFilter
{
    public string? OrganizationName { get; set; }
    public DateTime? DateTime { get; set; }
    public EOrganizationStatus? Status { get; set; }
}
