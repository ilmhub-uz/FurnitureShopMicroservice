using Merchant.Api.Data;
using Merchant.Api.Entities;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Merchant.Api.RabbitMQServices;
public class AddContractQueueService : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private AppDbContext _context;
    private IConnection _connection;
    private IModel _channel;
    private string _queueName;

    public AddContractQueueService(AppDbContext context, IServiceScopeFactory scopeFactory)
    {
        _context = context;
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _context = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();

        var factory = new ConnectionFactory
        {
            HostName = "localhost",
            UserName = "guest",
            Password = "guest",
            Port = 5672,
            DispatchConsumersAsync = true,
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        _channel.ExchangeDeclare("contract_added",ExchangeType.Fanout);
        _queueName = _channel.QueueDeclare().QueueName;

        _channel.QueueBind(_queueName, "contract_added", "");

        HandleQueue();
    }

    private void HandleQueue()
    {
        var consumer = new AsyncEventingBasicConsumer(_channel);

        consumer.Received += async (sender, args) =>
        {
            var contractJson = Encoding.UTF8.GetString(args.Body.ToArray());
            var contract = JsonConvert.DeserializeObject<Contract>(contractJson);
            await SaveContractAsync(contract);
        };

        _channel.BasicConsume(_queueName, false, consumer);
    }

    private async Task SaveContractAsync(Contract contractQueue)
    {
        var contract = new Contract()
        {
            Id = contractQueue.Id,
            OrderId = contractQueue.OrderId,
            ProductCount = contractQueue.ProductCount,
            TotalPrice = contractQueue.TotalPrice,
        };

        await _context.Contracts!.AddAsync(contract);
        await _context.SaveChangesAsync();
    }
}
