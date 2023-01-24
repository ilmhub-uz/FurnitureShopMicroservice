using Merchant.Api.Dtos;

namespace Merchant.Api.Services;

public interface IOrganizationService
{
    Task CreateOrganizationAsync(CreateOrganizationDto createOrganization);
    Task<List<OrganizationView>?> GetOrganizationsAsync();
    Task<OrganizationView> GetOrganizationByIdAsync(Guid organizationId);
    Task UpdateOrganizationAsync(Guid organizationId, UpdateOrganizationDto updateOrganization);
    Task DeleteOrganizationAsync(Guid organizationId);
}
