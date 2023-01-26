using System.Text;
using Dashboard.Api.Context;
using Dashboard.Api.Entities;
using Mapster;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Dashboard.Api.RabbitMQ;

//public class ProductConsumer : BackgroundService
//{
//    private readonly IServiceScopeFactory _scopeFactory;
//    private readonly AppDbContext _context;
//    private IConnection _connection;
//    private readonly ConnectionFactoryParameters _connectionFactory;
//    private IModel _channel;
//    private string _queueName;

//    public ProductConsumer(IServiceScopeFactory scopeFactory, IConfiguration configuration)
//    {
//        _scopeFactory = scopeFactory;
//        _context = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();
//        _connectionFactory = configuration.GetSection("ConnectionFactory").Get<ConnectionFactoryParameters>();
//    }

//    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
//    {
//        var factory = new ConnectionFactory()
//        {
//            HostName = _connectionFactory.HostName,
//            UserName = _connectionFactory.UserName,
//            Password = _connectionFactory.Password,
//            Port = int.Parse(_connectionFactory.Port),
//            DispatchConsumersAsync = bool.Parse(_connectionFactory.DispatchConsumersAsync)
//        };

//        _connection = factory.CreateConnection();
//        _channel = _connection.CreateModel();

//        _channel.ExchangeDeclare("product_added", ExchangeType.Fanout);
//        _queueName = _channel.QueueDeclare().QueueName;

//        _channel.QueueBind(_queueName, "product_added","");

//        HandleQueue();

//    }

//    private void HandleQueue()
//    {
//        var consumer = new AsyncEventingBasicConsumer(_channel);
//        consumer.Received += async (sender, args) =>
//        {
//            var productJson = Encoding.UTF8.GetString(args.Body.ToArray());
//            var product = JsonConvert.DeserializeObject<ProductQueue>(productJson);
//            await SaveProductAsync(product);
//        };

//        _channel.BasicConsume(_queueName, false, consumer);
//    }

//    private async Task SaveProductAsync(ProductQueue productQueue)
//    {
//        var product = new Product();
//        product.Adapt<ProductQueue>();

//        await _context.Products.AddAsync(product);

//        await _context.SaveChangesAsync();

//    }
//}