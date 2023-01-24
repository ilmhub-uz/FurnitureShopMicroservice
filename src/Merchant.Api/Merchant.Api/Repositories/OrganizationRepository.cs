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

    public async Task DeleteOrganizationAsync(Organization deleteOrganization)
    {
        context.Organizations.Remove(deleteOrganization);
        await context.SaveChangesAsync();
    }

    public async Task<Organization?> GetOrganizationByIdAsync(Guid organizationId)
    {
        var organization = await context.Organizations.FirstOrDefaultAsync(x => x.Id == organizationId);
        return organization;
    }

    public async Task<List<Organization>?> GetOrganizations()
    {
        var organizations = await context.Organizations.ToListAsync();
        return organizations;
    }

    public async Task UpdateOrganizationAsync(Organization updateOrganization)
    {
        context.Organizations.Update(updateOrganization);
        await context.SaveChangesAsync();
    }
}
