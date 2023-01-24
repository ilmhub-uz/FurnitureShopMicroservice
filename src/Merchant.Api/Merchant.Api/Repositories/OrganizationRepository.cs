using Merchant.Api.Context;
using Merchant.Api.Dtos;
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

    public Task CreateOrganizationAsync(Organization createOrganization)
    {
        throw new NotImplementedException();
    }

    public Task DeleteOrganizationAsync(Guid organizationId)
    {
        throw new NotImplementedException();
    }

    public async Task<OrganizationDto> GetOrganizationByIdAsync(Guid organizationId)
    {
        var entity = await context.Organizations.FirstOrDefaultAsync(organization => organization.Id == organizationId);
        return entity.Adapt<OrganizationDto>();
    }
    

    public Task <List<OrganizationDto>> GetOrganizations()
    {
        throw new NotImplementedException();
    }

    public void UpdateOrganizationAsync(OrganizationDto updateOrganization)
    {
        context.Organizations.Update(updateOrganization.Adapt<Organization>());
        context.SaveChanges();
    }
}
