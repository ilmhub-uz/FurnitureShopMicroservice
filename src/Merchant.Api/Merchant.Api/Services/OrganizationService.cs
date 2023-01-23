using Merchant.Api.Dtos;
using MongoDB.Bson;

namespace Merchant.Api.Services;

public class OrganizationService : IOrganizationService
{
    public Task<Organization> AddOrganization(ObjectId , CreateOrganization createOrganization)
    {
        throw new NotImplementedException();
    }

    public Task<Organization> GetOrganizationById(ObjectId organizationId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Organization>> GetOrganizations()
    {
        throw new NotImplementedException();
    }
}
