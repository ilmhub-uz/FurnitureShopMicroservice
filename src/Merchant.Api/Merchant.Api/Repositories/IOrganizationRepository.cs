using Merchant.Api.Dtos;
using Merchant.Api.Entities;

namespace Merchant.Api.Repositories;

public interface IOrganizationRepository
{
    Task<Organization> CreateOrganizationAsync(CreateOrganizationDto createOrganization);
    Task<Organization> UpdateOrganizationAsync(UpdateOrganizationDto updateOrganization);
    Task DeleteOrganizationAsync(Guid organizationId);
    Task<Organization> GetOrganizationByIdAsync(Guid organizationId);
    Task<List<Organization>> GetOrganizations();
}
