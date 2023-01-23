using Merchant.Api.Dtos;
using MongoDB.Bson;

namespace Merchant.Api.Services;

public interface IOrganizationService
{
    Task<OrganizationDto> CreateOrganizationAsync(CreateOrganizationDto createOrganization);
    Task<List<OrganizationDto>> GetOrganizationsAsync();
    Task<OrganizationDto> GetOrganizationByIdAsync(Guid organizationId);
    Task<OrganizationDto> UpdateOrganizationAsync(Guid organizationId, UpdateOrganizationDto updateOrganization);
    Task DeleteOrganizationAsync(Guid organizationId);
}
