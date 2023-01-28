using Mapster;
using Merchant.Api.Dtos;
using Merchant.Api.Dtos.Create;
using Merchant.Api.Dtos.Enums;
using Merchant.Api.Dtos.Update;
using Merchant.Api.Entities;
using Merchant.Api.Exceptions;
using Merchant.Api.Options;
using Merchant.Api.Repositories;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Merchant.Api.Services;
public class OrganizationService : IOrganizationService
{
    private readonly IOrganizationRepository _organizationRepository;
    private readonly IFileHelper _fileHelper;
    private readonly IOptions<FactoryConfigurationOptions> _config;

    public OrganizationService(
        IOrganizationRepository organizationRepository,
        IFileHelper fileHelper,
        IOptions<FactoryConfigurationOptions> config)
    {
        _organizationRepository = organizationRepository;
        _fileHelper = fileHelper;
        _config = config;
    }

    public async Task<OrganizationView> CreateOrganizationAsync(CreateOrganizationDto createOrganization)
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

        if (createOrganization.ImageUrl is not null)
            organization.ImageUrl = await _fileHelper.
                SaveFileAsync(createOrganization.ImageUrl!, EFileType.Images, EFileFolder.Organization);

        await _organizationRepository.CreateOrganizationAsync(organization);

        SendMessage(organization, "organization_added");

        return createOrganization.Adapt<OrganizationView>();
    }

    public async Task<bool> DeleteOrganizationAsync(Guid organizationId)
    {
        var organization = await _organizationRepository.GetOrganizationByIdAsync(organizationId);

        if (organization is null)
            throw new NotFoundException<Organization>();

        return await _organizationRepository.DeleteOrganizationAsync(organizationId);
    }

    public async Task<OrganizationView> GetOrganizationByIdAsync(Guid organizationId)
    {
        var organization = await _organizationRepository.GetOrganizationByIdAsync(organizationId);

        if (organization is null)
            throw new NotFoundException<Organization>();

        return organization.Adapt<OrganizationView>();
    }

    public async Task<List<OrganizationView>?> GetOrganizationsAsync()
    {
        var organizations = await _organizationRepository.GetOrganizations();
        return organizations?.Select(x => x.Adapt<OrganizationView>()).ToList();
    }

    public async Task<OrganizationView> UpdateOrganizationAsync(Guid organizationId, UpdateOrganizationDto updateOrganization)
    {
        var organization = await _organizationRepository.GetOrganizationByIdAsync(organizationId);
        if (organization is null)
            throw new NotFoundException<Organization>();

        if (updateOrganization.Name is not null)
            organization.Name = updateOrganization.Name;

        if (updateOrganization.Description is not null)
            organization.Description = updateOrganization.Description;

        if (updateOrganization.ImageUrl is not null)
        {
            organization.ImageUrl = await _fileHelper.
                SaveFileAsync(updateOrganization.ImageUrl, EFileType.Images, EFileFolder.Organization);
        }

        await _organizationRepository.UpdateOrganizationAsync(organization);

        SendMessage(organization, "organization_updated");

        return updateOrganization.Adapt<OrganizationView>();
    }

    private void SendMessage(Organization organization, string exchange)
    {
        var factory = new ConnectionFactory
        {
            HostName = _config.Value.HostName,
            UserName = _config.Value.UserName,
            Password = _config.Value.Password,
            Port = _config.Value.Port
        };

        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();

        channel.ExchangeDeclare(exchange, ExchangeType.Fanout);
        var productJson = JsonConvert.SerializeObject(organization, Formatting.None, new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });
        var productJsonByte = Encoding.UTF8.GetBytes(productJson);

        channel.BasicPublish(exchange, "", null, productJsonByte);

        // channel.Close();
        // connection.Close();
    }
}