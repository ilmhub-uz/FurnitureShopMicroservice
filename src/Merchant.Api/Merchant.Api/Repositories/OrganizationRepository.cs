using Merchant.Api.Context;
using Merchant.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Merchant.Api.Repositories;

public class OrganizationRepository : IOrganizationRepository
{
    private readonly AppDbContext context;

    public OrganizationRepository(AppDbContext context)
    {
        this.context = context;
    }

    public async Task CreateOrganizationAsync(Organization createOrganization)
    {
        await context.Organizations!.AddAsync(createOrganization);
        await context.SaveChangesAsync();
    }

    public Task DeleteOrganizationAsync(Guid organizationId)
    {
        throw new NotImplementedException();
    }

    public Task<Organization> GetOrganizationByIdAsync(Guid organizationId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Organization>> GetOrganizations() => await context.Organizations.ToListAsync();

    public void UpdateOrganizationAsync(Organization updateOrganization)
    {
        context.Organizations.Update(updateOrganization);
        context.SaveChanges();
    }
}
