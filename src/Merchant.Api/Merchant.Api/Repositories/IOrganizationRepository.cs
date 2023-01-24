using Merchant.Api.Dtos;
using Merchant.Api.Entities;

namespace Merchant.Api.Repositories;

public interface IOrganizationRepository
{
    Task CreateOrganizationAsync(Organization createOrganization);
    Task UpdateOrganizationAsync(Organization updateOrganization);
    Task DeleteOrganizationAsync(Organization deleteOrganization);
    Task<Organization?> GetOrganizationByIdAsync(Guid organizationId);
    Task<List<Organization>?> GetOrganizations();
}
