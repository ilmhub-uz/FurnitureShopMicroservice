using Merchant.Api.Context;
using Merchant.Api.Dtos;
using Merchant.Api.Entities;

namespace Merchant.Api.Repositories;

public class OrganizationRepository : IOrganizationRepository
{
    private readonly AppDbContext context;

    public OrganizationRepository(AppDbContext context)
    {
        this.context = context;
    }

    public Task CreateOrganizationAsync(Organization createOrganization)
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

    public void UpdateOrganizationAsync(Organization updateOrganization)
    {
        context.Organizations.Update(updateOrganization);
        context.SaveChanges();
    }
}
