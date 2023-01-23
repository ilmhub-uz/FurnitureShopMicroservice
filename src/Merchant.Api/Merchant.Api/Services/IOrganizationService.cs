using Merchant.Api.Dtos;

namespace Merchant.Api.Services;

public interface IOrganizationService
{
    Task<OrganizationDto> CreateOrganization(CreateOrganizationDto createOrganization);
    Task<List<OrganizationDto>> GetOrganizations();
    Task<OrganizationDto> GetOrganizationById(Guid organizationId);
    Task<OrganizationDto> UpdateOrganization(Guid organizationId, UpdateOrganizationDto updateOrganization);
}
