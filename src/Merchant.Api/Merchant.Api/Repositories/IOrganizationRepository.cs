using Merchant.Api.Dtos;
using Merchant.Api.Entities;

namespace Merchant.Api.Repositories;

public interface IOrganizationRepository
{
    Task<Organization> CreateOrganizationAsync(Organization createOrganization);
    Task<Organization> UpdateOrganizationAsync(Organization updateOrganization);
    Task<bool> DeleteOrganizationAsync(Guid organizationId);
    Task<Organization?> GetOrganizationByIdAsync(Guid organizationId);
    Task<List<Organization>?> GetOrganizations();
}
