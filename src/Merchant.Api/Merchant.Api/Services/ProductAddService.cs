using Merchant.Api.Data;
using Merchant.Api.Entities;
using Merchant.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Data;
using System.Text;

namespace Merchant.Api.Services;

public class ProductAddService : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private AppDbContext _context;
    private IConnection _connection;
    private IModel _channel;
    private string _queueName;

    public ProductAddService(AppDbContext context, IServiceScopeFactory scopeFactory)
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
            DispatchConsumersAsync = true
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        _channel.ExchangeDeclare("product_added", ExchangeType.Fanout);
        _queueName = _channel.QueueDeclare().QueueName;

        _channel.QueueBind(_queueName, "product_added", "");

        HandleQueue();
    }

    private void HandleQueue()
    {
        var consumer = new AsyncEventingBasicConsumer(_channel);
        consumer.Received += async (sender, args) =>
        {
            var productJson = Encoding.UTF8.GetString(args.Body.ToArray());
            var product = Newtonsoft.Json.JsonConvert.DeserializeObject<Product>(productJson);
            await SaveProductAsync(product);
        };

        _channel.BasicConsume(_queueName, false, consumer);
    }

    private async Task SaveProductAsync(Product productQueue)
    {
        var product = new Product()
        {
            Id = productQueue.Id,
            AuthorId = productQueue.AuthorId,
            Name = productQueue.Name,
            Description = productQueue.Description
        };

        await _context.Products.AddAsync(product);

        await _context.SaveChangesAsync();
    }
}