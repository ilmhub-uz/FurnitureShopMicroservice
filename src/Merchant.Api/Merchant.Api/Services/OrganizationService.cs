using JFA.DependencyInjection;
using Mapster;
using Merchant.Api.Dtos;
using Merchant.Api.Dtos.Enums;
using Merchant.Api.Repositories;

namespace Merchant.Api.Services;

[Scoped]
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

    public Task<OrganizationDto> CreateOrganizationAsync(CreateOrganizationDto createOrganization)
    {
        throw new NotImplementedException();
    }

    public Task DeleteOrganizationAsync(Guid organizationId)
    {
        throw new NotImplementedException();
    }

    public Task<OrganizationDto> GetOrganizationByIdAsync(Guid organizationId)
    {
        throw new NotImplementedException();
    }

    public Task<List<OrganizationDto>> GetOrganizationsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<OrganizationDto> UpdateOrganizationAsync(Guid organizationId, UpdateOrganizationDto updateOrganization)
    {
        var organization = await _organizationRepository.GetOrganizationByIdAsync(organizationId);
        if (organization is null)
            return null;

        organization.Name = updateOrganization.Name;
        organization.Status = updateOrganization.Status;
        organization.Users = updateOrganization.Users;
        if (updateOrganization.ImageUrl is not null)
            organization.ImageUrl = await _fileHelper.SaveFileAsync(updateOrganization.ImageUrl, EFileType.Images, EFileFolder.Organization);


        return organization.Adapt<OrganizationDto>();
    }
}