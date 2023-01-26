using Mapster;
using Merchant.Api.Dtos.Create;
using Merchant.Api.Dtos.Update;
using Merchant.Api.Entities;
using Merchant.Api.Repositories;
using Merchant.Api.Services;
using Moq;

namespace Merchant.Api.Test;
public class OrganizationServiceTest
{
    private readonly OrganizationService _organizationService;
    private readonly Mock<IOrganizationRepository> _mockRepo;
    private readonly Mock<IFileHelper> _mockService;

    public OrganizationServiceTest()
    {
        _mockRepo = new Mock<IOrganizationRepository>();
        _mockService = new Mock<IFileHelper>();
        _organizationService = new OrganizationService(_mockRepo.Object, _mockService.Object);
    }

    [Fact]
    public async Task GetALlOrganizations_Test()
    {
        var organizations = new List<Organization>
        {
            new Organization
            {
                Id = Guid.NewGuid(),
                Name="Organization1",
                Description="string",
                ImageUrl = "string",
                Status = Dtos.Enums.EOrganizationStatus.Created
            },
            new Organization
            {
                Id = Guid.NewGuid(),
                Name="Organization2",
                Description="string2",
                ImageUrl = "string2",
                Status = Dtos.Enums.EOrganizationStatus.Created
            },
        };

        _mockRepo.Setup(repo => repo.GetOrganizations()).ReturnsAsync(organizations);

        var finalResult = await _organizationService.GetOrganizationsAsync();

        Assert.NotNull(finalResult);
        Assert.Equal(2, finalResult!.Count);
    }

    [Fact]
    public async Task GetOrganizationById_Test()
    {
        var organizationId = Guid.Parse("82d11dcb-f3d4-4d6f-9d8e-d8480994e838");
        var organization = new Organization
        {
            Id = organizationId,
            Name = "OrganizationToTest",
            Description = "string1.1",
            ImageUrl = "string1.1",
            Status = Dtos.Enums.EOrganizationStatus.Created
        };
        _mockRepo.Setup(repo => repo.GetOrganizationByIdAsync(organizationId)).ReturnsAsync(organization);

        var result = await _organizationService.GetOrganizationByIdAsync(organizationId);

        Assert.NotNull(result);
        Assert.Contains(organization.Name, result.Name);
    }

    [Fact]
    public async Task CreateOrganization_Test()
    {
        var organization = new Organization
        {
            Id = Guid.Parse("82d11dcb-f3d4-4d6f-9d8e-d8480994e838"),
            Name = "Organization1",
            Description = "string",
            ImageUrl = null,
            Status = Dtos.Enums.EOrganizationStatus.Created
        };

        _mockRepo.Setup(repo => repo.CreateOrganizationAsync(organization)).ReturnsAsync(organization);

        var createOrganizationDto = organization.Adapt<CreateOrganizationDto>();
        var result = await _organizationService.CreateOrganizationAsync(createOrganizationDto);

        Assert.NotNull(result);
        Assert.Equal(createOrganizationDto.Name, result.Name);
        Assert.Equal(createOrganizationDto.Description, result.Description);
    }

    [Fact]
    public async Task DeleteOrganization_Test()
    {
        var organizationId = Guid.Parse("82d11dcb-f3d4-4d6f-9d8e-d8480994e838");

        _mockRepo.Setup(repo => repo.DeleteOrganizationAsync(organizationId)).ReturnsAsync(true);

        var result = await _organizationService.DeleteOrganizationAsync(organizationId);

        Assert.True(result);
    }

    [Fact]
    public async Task UpdateOrganization_Test()
    {
        var organization = new Organization
        {
            Id = Guid.Parse("82d11dcb-f3d4-4d6f-9d8e-d8480994e838"),
            Name = "Organization1",
            Description = "string",
            ImageUrl = null,
            Status = Dtos.Enums.EOrganizationStatus.Created
        };

        _mockRepo.Setup(repo => repo.UpdateOrganizationAsync(organization)).ReturnsAsync(organization);
        var updateOrganizationDto = organization.Adapt<UpdateOrganizationDto>();
        
        var result = await _organizationService.UpdateOrganizationAsync(organization.Id,updateOrganizationDto);

        Assert.Equal(organization.Description, result.Description);
        Assert.Equal(organization.Name, updateOrganizationDto.Name);
    }
}