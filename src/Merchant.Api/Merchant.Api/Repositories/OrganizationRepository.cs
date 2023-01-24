using Mapster;
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

    public Task CreateOrganizationAsync(OrganizationDto createOrganization)
    {
        throw new NotImplementedException();
    }

    public Task <List<OrganizationDto>> GetOrganizations()
    {
        throw new NotImplementedException();
    }

    public async Task<OrganizationDto> GetOrganizationByIdAsync(Guid organizationId)
    {
        var entity = await context.Organizations.FirstOrDefaultAsync(organization => organization.Id == organizationId);
        return entity.Adapt<OrganizationDto>();
    }

    public void UpdateOrganizationAsync(OrganizationDto updateOrganization)
    {
        context.Organizations.Update(updateOrganization.Adapt<Organization>());
        context.SaveChanges();
    }

    public Task DeleteOrganizationAsync(Guid organizationId)
    {
        throw new NotImplementedException();
    }
}
