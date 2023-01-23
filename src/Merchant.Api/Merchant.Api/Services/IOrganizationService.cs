using Merchant.Api.Dtos;

namespace Merchant.Api.Services;

public interface IOrganizationService
{
    Task<OrganizationDto> CreateOrganizationAsync(CreateOrganizationDto createOrganization);
    Task<List<OrganizationDto>> GetOrganizationsAsync();
    Task<OrganizationDto> GetOrganizationByIdAsync(Guid organizationId);
    Task<OrganizationDto> UpdateOrganizationAsync(Guid organizationId, UpdateOrganizationDto updateOrganization);
    Task DeleteOrganizationAsync(Guid organizationId);
}
