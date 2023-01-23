using Mapster;
using Merchant.Api.Dtos;
using Merchant.Api.Dtos.Enums;
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

    public Task DeleteOrganizationAsync(Guid organizationId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ExistsAsync(Guid organizationId)
    {
        var organization = await _organizationRepository.GetOrganizationByIdAsync(organizationId);
        if(organization is null)
            return false;

        return true;
    }

    Task<Result<OrganizationDto>> IOrganizationService.CreateOrganizationAsync(CreateOrganizationDto createOrganization)
    {
        throw new NotImplementedException();
    }

    Task<Result<OrganizationDto>> IOrganizationService.GetOrganizationByIdAsync(Guid organizationId)
    {
        throw new NotImplementedException();
    }

    Task<Result<List<OrganizationDto>>> IOrganizationService.GetOrganizationsAsync()
    {
        throw new NotImplementedException();
    }

    Task<Result<OrganizationDto>> IOrganizationService.UpdateOrganizationAsync(Guid organizationId, UpdateOrganizationDto updateOrganization)
    {
        throw new NotImplementedException();
    }
}