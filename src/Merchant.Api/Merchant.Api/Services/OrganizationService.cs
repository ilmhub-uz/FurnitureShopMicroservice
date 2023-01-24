using Mapster;
using Merchant.Api.Dtos;
using Merchant.Api.Dtos.Enums;
using Merchant.Api.Entities;
using Merchant.Api.Repositories;

namespace Merchant.Api.Services;

public class OrganizationService : IOrganizationService
{
    private readonly IOrganizationRepository _organizationRepository;
    private readonly IFileHelper _fileHelper;

    public OrganizationService(
        IOrganizationRepository organizationRepository,
        IFileHelper fileHelper)
    {
        _organizationRepository = organizationRepository;
        _fileHelper = fileHelper;
    }

    public async Task CreateOrganizationAsync(CreateOrganizationDto createOrganization)
    {
        var organization = createOrganization.Adapt<Organization>();

        organization.Users = new List<OrganizationUser>()
        {
            new OrganizationUser()
            {
                UserId = Guid.NewGuid(),
                Role = ERole.Owner,
                User= new AppUser()
                {
                    UserName = Guid.NewGuid().ToString(),
                    Email = Guid.NewGuid().ToString()
                }
            }
        };
        await _organizationRepository.CreateOrganizationAsync(organization);


        /*organization.ImageUrl = await _fileHelper.
            SaveFileAsync(createOrganization.ImageUrl!, EFileType.Images, EFileFolder.Organization);*/
    }

    public async Task DeleteOrganizationAsync(Guid organizationId)
    {
        var organization = await _organizationRepository.GetOrganizationByIdAsync(organizationId);

        if (organization == null)
            throw new Exception("not organization");

        await _organizationRepository.DeleteOrganizationAsync(organization);
    }

    public async Task<OrganizationView> GetOrganizationByIdAsync(Guid organizationId)
    {
        var organization = await _organizationRepository.GetOrganizationByIdAsync(organizationId);

        if (organization == null)
            throw new Exception("not organization");

        return organization.Adapt<OrganizationView>();
    }

    public async Task<List<OrganizationView>?> GetOrganizationsAsync()
    {
        var organizations = await _organizationRepository.GetOrganizations();
        return organizations?.Select(x => x.Adapt<OrganizationView>()).ToList();
    }

    public async Task UpdateOrganizationAsync(Guid organizationId, UpdateOrganizationDto updateOrganization)
    {
        var organization = await _organizationRepository.GetOrganizationByIdAsync(organizationId);
        if (organization is null)
            throw new Exception("not organization");

        organization.Name = updateOrganization.Name;
        organization.Status = updateOrganization.Status;
        //organization.Users = updateOrganization.Users;
        //if (updateOrganization.ImageUrl is not null)
        //organization.ImageUrl = await _fileHelper.SaveFileAsync(updateOrganization.ImageUrl, EFileType.Images, EFileFolder.Organization);

        await _organizationRepository.UpdateOrganizationAsync(organization);
    }
}