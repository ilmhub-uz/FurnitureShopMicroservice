using DashboardApi.Data;
using DashboardApi.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading.Channels;
using DashboardApi.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace DashboardApi.Services;

public class ProductService : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private AppDbContext _context;
    private IConnection _connection;
    private IModel _channel;
    private string _queueName;
    private readonly IHubContext<ProductsHub> _hubContext;

    public ProductService(IServiceScopeFactory scopeFactory, IHubContext<ProductsHub> hubContext)
    {
        _scopeFactory = scopeFactory;
        _hubContext = hubContext;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _context = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();

        var factory = new ConnectionFactory
        {
            HostName = "furniture_rabbitmq",
            UserName = "guest",
            Password = "guest",
            Port = 5672,
            DispatchConsumersAsync = true
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        //_channel.QueueDeclare("product_added", false, false, false, null);
        _channel.ExchangeDeclare("product_added", ExchangeType.Fanout);
        _queueName = _channel.QueueDeclare().QueueName;
        
        _channel.QueueBind(_queueName, "product_added", "");

        HandleQueue();
    }

    private void HandleQueue()
    {
        var consumer = new AsyncEventingBasicConsumer(_channel);
        consumer.Received += async  (sender, args) =>
            {
                var productJson = Encoding.UTF8.GetString(args.Body.ToArray());
                var product = Newtonsoft.Json.JsonConvert.DeserializeObject<ProductQueue>(productJson);
                await SaveProductAsync(product);
            };

        _channel.BasicConsume(_queueName, false, consumer);
    }

    private async Task SaveProductAsync(ProductQueue productQueue)
    {
        var product = new Product()
        {
            ProductId = productQueue.Id,
            ProductCount = productQueue.Count,
            ProductName = productQueue.Name,
        };

        _context.Products?.Add(product);

        await _context.SaveChangesAsync();

        await _hubContext.Clients.All.SendAsync("ProductAdded", product);
    }
}