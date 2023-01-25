using Merchant.Api.Dtos;
using Merchant.Api.Dtos.Create;
using Merchant.Api.Dtos.Update;

namespace Merchant.Api.Services;

public interface IOrganizationService
{
    Task<OrganizationView> CreateOrganizationAsync(CreateOrganizationDto createOrganization);
    Task<List<OrganizationView>?> GetOrganizationsAsync();
    Task<OrganizationView> GetOrganizationByIdAsync(Guid organizationId);
    Task<OrganizationView> UpdateOrganizationAsync(Guid organizationId, UpdateOrganizationDto updateOrganization);
    Task<bool> DeleteOrganizationAsync(Guid organizationId);
}
