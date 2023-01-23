using Merchant.Api.Dtos;

namespace Merchant.Api.Services;

public interface IOrganizationService
{
    Task<Result<OrganizationDto>> CreateOrganizationAsync(CreateOrganizationDto createOrganization);
    Task<Result<List<OrganizationDto>>> GetOrganizationsAsync();
    Task<Result<OrganizationDto>> GetOrganizationByIdAsync(Guid organizationId);
    Task<Result<OrganizationDto>> UpdateOrganizationAsync(Guid organizationId, UpdateOrganizationDto updateOrganization);
    Task DeleteOrganizationAsync(Guid organizationId);
    Task<bool> ExistsAsync(Guid organizationId);
}
