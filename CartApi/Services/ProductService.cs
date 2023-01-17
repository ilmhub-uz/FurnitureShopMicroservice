using System.Text;
using System.Threading.Channels;
using Microsoft.Extensions.Caching.Distributed;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace CartApi.Services;

public class ProductConsumer : BackgroundService
{
    private IConnection _connection;
    private IModel _channel;
    private readonly IDistributedCache _distributedCache;

    public ProductConsumer(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var factory = new ConnectionFactory
        {
            HostName = "furniture_rabbitmq",
            UserName = "guest",
            Password = "guest",
            Port = 5672
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        //_channel.QueueDeclare("product_added", false, false, false, null);
        _channel.ExchangeDeclare("product_added", ExchangeType.Fanout);
        var queueName = _channel.QueueDeclare().QueueName;
        _channel.QueueBind(queueName, "product_added", "");

        HandleQueue(queueName);
    }

    private void HandleQueue(string queueName)
    {
        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += ConsumerOnReceived();
        _channel.BasicConsume(queueName, false, consumer);
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
        _distributedCache.SetString("product", 
            Newtonsoft.Json.JsonConvert.SerializeObject(productQueue));
    }
}