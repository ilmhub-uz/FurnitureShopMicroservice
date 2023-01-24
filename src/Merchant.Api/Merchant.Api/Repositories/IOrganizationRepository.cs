using Merchant.Api.Dtos;
using Merchant.Api.Entities;

namespace Merchant.Api.Repositories;

public interface IOrganizationRepository
{
    Task CreateOrganizationAsync(OrganizationDto createOrganization);
    Task<List<OrganizationDto>> GetOrganizations();
    Task<OrganizationDto> GetOrganizationByIdAsync(Guid organizationId);
    void UpdateOrganizationAsync(OrganizationDto updateOrganization);
    Task DeleteOrganizationAsync(Guid organizationId);
}
