using Merchant.Api.Dtos;
using MongoDB.Bson;

namespace Merchant.Api.Services;

public class OrganizationService : IOrganizationService
{
    public Task<OrganizationDto> CreateOrganization(CreateOrganizationDto createOrganization)
    {
        throw new NotImplementedException();
    }

    public Task<OrganizationDto> GetOrganizationById(ObjectId organizationId)
    {
        throw new NotImplementedException();
    }

    public Task<List<OrganizationDto>> GetOrganizations()
    {
        throw new NotImplementedException();
    }

    public Task<OrganizationDto> UpdateOrganization(ObjectId organizationId, UpdateOrganizationDto updateOrganization)
    {
        throw new NotImplementedException();
    }
}
