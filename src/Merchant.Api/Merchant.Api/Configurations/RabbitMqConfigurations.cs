namespace Merchant.Api.Configurations;

public class RabbitMqConfigurations
{
    public string? HostName { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public int Port { get; set; }
    public string? PostOrganizationName { get; set; }
    public string? PutOrganizationName { get; set; }
    public string? PostEmploeeName { get; set; }
    public string? GetProductName { get; set; }
}
