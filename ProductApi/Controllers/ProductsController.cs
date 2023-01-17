using Mapster;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using ProductApi.Dtos;
using ProductApi.Entities;
using RabbitMQ.Client;
using System.Text;

namespace ProductApi.Controllers;

[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly MongoClient _mongoClient;
    private readonly IMongoDatabase _database;
    private readonly IMongoCollection<Product> _products;

    public ProductsController()
    {
        _mongoClient = new MongoClient("mongodb://mongodb:27017");
        _database = _mongoClient.GetDatabase("products_db");
        _products = _database.GetCollection<Product>("products");
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await (await _products.FindAsync(product => true)).ToListAsync();

        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto createProductDto)
    {
        var product = createProductDto.Adapt<Product>();

        product.Id = ObjectId.GenerateNewId(DateTime.Now).ToString();

        await _products.InsertOneAsync(product);

        SendMessage(product);

        return Ok(product);
    }

    private void SendMessage(Product product)
    {
        var factory = new ConnectionFactory
        {
            HostName = "furniture_rabbitmq",
            UserName = "guest",
            Password = "guest",
            Port = 5672
        };

        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();

        //channel.QueueDeclare("product_added", false, false, false, null);

        channel.ExchangeDeclare("product_added", ExchangeType.Fanout);

        var productJson = Newtonsoft.Json.JsonConvert.SerializeObject(product);
        var productJsonByte = Encoding.UTF8.GetBytes(productJson);

        channel.BasicPublish("product_added", "", null, productJsonByte);

        channel.Close();
        connection.Close();
    }
}