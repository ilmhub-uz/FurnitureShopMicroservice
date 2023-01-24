using Dashboard.Api.Context;
using Dashboard.Api.Entities;
using Dashboard.Api.ModelsDto;
using Dashboard.Api.Services.Interfaces;
using Dashboard.Api.ViewModels;
using JFA.DependencyInjection;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Api.Services;


[Scoped]
public class OrganizationService : IOrganizationService
{
    private readonly AppDbContext _context;

    public OrganizationService(AppDbContext context)
    {
        _context = context;
    }


    public async Task<OrganizationView> GetOrganizationById(Guid organizationId)
    {
        var organization = await _context.Organizations.FirstOrDefaultAsync(or => or.Id == organizationId);
        if (organization is null)
        {
            throw new Exception("not found"); // exception qoshish
        }

        return organization.Adapt<OrganizationView>();

    }

    public async Task<List<OrganizationView>> GetOrganizations()
    {
        var organizations = await _context.Organizations.ToListAsync();
        organizations ??= new List<Organization>();
        var mapping = organizations.Select(s => s.Adapt<OrganizationView>()).ToList();

        return mapping;

    }

    public async Task UpdateOrganizationStatus(Guid organizationId, UpdateOrganizationDto updateOrganizationDto)
    {
        var organization = await _context.Organizations.FirstOrDefaultAsync(or => or.Id == organizationId);
        if (organization is null)
        {
            throw new Exception("not found");
            organization.Name = updateOrganizationDto.Name;
            organization.Status = updateOrganizationDto.Status;

            await _context.SaveChangesAsync();
        }
    }
