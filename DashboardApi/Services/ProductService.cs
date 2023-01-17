using DashboardApi.Data;
using DashboardApi.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace DashboardApi.Services;

public class ProductService : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private AppDbContext _context;
    private IConnection _connection;
    private IModel _channel;

    public ProductService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _context = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();

        var factory = new ConnectionFactory
        {
            HostName = "furniture_rabbitmq",
            UserName = "guest",
            Password = "guest",
            Port = 5672
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        _channel.QueueDeclare("product_added", false, false, false, null);

        HandleQueue();
    }

    private void HandleQueue()
    {
        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += ConsumerOnReceived();
        _channel.BasicConsume("product_added", false, consumer);
    }

    private EventHandler<BasicDeliverEventArgs> ConsumerOnReceived()
    {
        return (sender, args) =>
        {
            var productJson = Encoding.UTF8.GetString(args.Body.ToArray());
            var product = Newtonsoft.Json.JsonConvert.DeserializeObject<ProductQueue>(productJson);
            SaveProduct(product);
        };
    }

    private void SaveProduct(ProductQueue productQueue)
    {
        _context.Products?.Add(new Product()
        {
            ProductId = productQueue.Id,
            ProductCount = productQueue.Count,
            ProductName = productQueue.Name,
        });

        _context.SaveChanges();
    }
}