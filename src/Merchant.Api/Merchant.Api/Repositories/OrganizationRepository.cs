using Merchant.Api.Data;
using Merchant.Api.Entities;
using Merchant.Api.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Merchant.Api.Repositories;

public class OrganizationRepository : IOrganizationRepository
{
    private readonly AppDbContext context;

    public OrganizationRepository(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<Organization> CreateOrganizationAsync(Organization createOrganization)
    {
        await context.Organizations!.AddAsync(createOrganization);
        await context.SaveChangesAsync();
        return createOrganization;
    }

    public async Task<bool> DeleteOrganizationAsync(Guid organizationId)
    {
        var organization = await context.Organizations!.FindAsync(organizationId);

        if (organization == null)
            throw new NotFoundException<Organization>();

        context.Organizations!.Remove(organization);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<Organization?> GetOrganizationByIdAsync(Guid organizationId)
    {
        var organization = await context.Organizations!.FirstOrDefaultAsync(x => x.Id == organizationId);
        return organization;
    }

    public async Task<List<Organization>?> GetOrganizations()
    {
        var organizations = await context.Organizations!.ToListAsync();
        return organizations;
    }

    public async Task<Organization> UpdateOrganizationAsync(Organization updateOrganization)
    {
        context.Organizations!.Update(updateOrganization);
        await context.SaveChangesAsync();
        return updateOrganization;
    }
}
