using Merchant.Api.Dtos;
using MongoDB.Bson;

namespace Merchant.Api.Services;

public interface IOrganizationService
{
    Task<OrganizationDto> CreateOrganization(CreateOrganizationDto createOrganization);
    Task<List<OrganizationDto>> GetOrganizations();
    Task<OrganizationDto> GetOrganizationById(ObjectId organizationId);
    Task<OrganizationDto> UpdateOrganization(ObjectId organizationId, UpdateOrganizationDto updateOrganization);
}
