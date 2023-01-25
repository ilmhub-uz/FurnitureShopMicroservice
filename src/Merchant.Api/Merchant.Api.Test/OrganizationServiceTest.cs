using Merchant.Api.Dtos.Create;
using Merchant.Api.Entities;
using Merchant.Api.Repositories;
using Merchant.Api.Services;
using Moq;

namespace Merchant.Api.Test;
public class OrganizationServiceTest
{
    private readonly OrganizationService _organizationService;
    private readonly Mock<IOrganizationRepository> _mockRepo;
    private readonly Mock<IFileHelper> _mockFileRepo;
    
    public OrganizationServiceTest()
    {
        _mockRepo = new Mock<IOrganizationRepository>();
        _mockFileRepo = new Mock<IFileHelper>();
        _organizationService = new OrganizationService(_mockRepo.Object,_mockFileRepo.Object);
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
        var organization = new Organization
        {
            Id = Guid.Parse("82d11dcb-f3d4-4d6f-9d8e-d8480994e838"),
            Name = "OrganizationToTest",
            Description = "string1.1",
            ImageUrl = "string1.1",
            Status = Dtos.Enums.EOrganizationStatus.Created
        };

        _mockRepo.Setup(repo => repo.GetOrganizationByIdAsync
            (Guid.Parse("82d11dcb-f3d4-4d6f-9d8e-d8480994e838"))).ReturnsAsync(organization);

        var result = await _organizationService.
            GetOrganizationByIdAsync(Guid.Parse("82d11dcb-f3d4-4d6f-9d8e-d8480994e838"));

        Assert.NotNull(result);
        Assert.Contains("OrganizationToTest", result.Name);
    }
}