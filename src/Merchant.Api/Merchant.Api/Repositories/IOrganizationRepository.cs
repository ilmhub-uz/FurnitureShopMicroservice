using Merchant.Api.Dtos;
using Merchant.Api.Entities;

namespace Merchant.Api.Repositories;

public interface IOrganizationRepository
{
    Task CreateOrganizationAsync(Organization createOrganization);
    void UpdateOrganizationAsync(Organization updateOrganization);
    Task DeleteOrganizationAsync(Guid organizationId);
    Task<OrganizationDto> GetOrganizationByIdAsync(Guid organizationId);
    Task<List<OrganizationDto>> GetOrganizations();
}
