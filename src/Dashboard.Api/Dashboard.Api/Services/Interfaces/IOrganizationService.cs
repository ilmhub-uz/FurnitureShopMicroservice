using Dashboard.Api.ModelsDto;
using Dashboard.Api.ViewModels;

namespace Dashboard.Api.Services.Interfaces;

public interface IOrganizationService
{
    Task<List<OrganizationView>> GetOrganizations();
    Task<OrganizationView> GetOrganizationById(Guid organizationId);
    Task UpdateOrganizationStatus(Guid organizationId, UpdateOrganizationDto updateOrganizationDto);


}
