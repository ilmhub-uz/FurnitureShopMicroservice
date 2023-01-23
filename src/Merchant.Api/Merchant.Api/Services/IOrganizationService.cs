using Merchant.Api.Dtos;
using MongoDB.Bson;

namespace Merchant.Api.Services;

public interface IOrganizationService
{
    Task<Organization> AddOrganization(ObjectId, CreateOrganization createOrganization);
    Task<List<Organization>> GetOrganizations();
    Task<Organization> GetOrganizationById(ObjectId organizationId);
}
