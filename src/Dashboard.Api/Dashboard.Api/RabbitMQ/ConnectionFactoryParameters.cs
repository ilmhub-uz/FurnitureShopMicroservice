namespace Dashboard.Api.RabbitMQ;

public class ConnectionFactoryParameters
{
    public string HostName { get; set; }
    public string UserName { get; set; } 
    public string Password { get; set; }
    public string Port { get; set; }
    public string DispatchConsumersAsync { get; set; }
}