using Merchant.Api.Dtos;
using Merchant.Api.Entities;

namespace Merchant.Api.Repositories;

public class OrganizationRepository : IOrganizationRepository
{
    public Task<Organization> CreateOrganizationAsync(CreateOrganizationDto createOrganization)
    {
        throw new NotImplementedException();
    }

    public Task DeleteOrganizationAsync(Guid organizationId)
    {
        throw new NotImplementedException();
    }

    public Task<Organization> GetOrganizationByIdAsync(Guid organizationId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Organization>> GetOrganizations()
    {
        throw new NotImplementedException();
    }

    public Task<Organization> UpdateOrganizationAsync(UpdateOrganizationDto updateOrganization)
    {
        throw new NotImplementedException();
    }
}
