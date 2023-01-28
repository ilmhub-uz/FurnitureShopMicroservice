using Contract.Api.Entities;
using JFA.DependencyInjection;
using Microsoft.AspNetCore.Connections;
using RabbitMQ.Client;
using System.Text;

namespace Contract.Api.RabbitMq
{
    [Scoped]
    public class SendToGetMessage
    {
        public void SendMessageOrder(Order order, string message)
        {
            var factory = CreateConnectionFactory();

            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.ExchangeDeclare(message, ExchangeType.Fanout);

            var orderJson = Newtonsoft.Json.JsonConvert.SerializeObject(order);
            var orderJsonByte = Encoding.UTF8.GetBytes(orderJson);
            channel.BasicPublish(message, "", null, orderJsonByte);
            if (!channel.IsClosed) channel.Close();
            if (connection.IsOpen) connection.Close();
        }
        public void SendMessageContract(Entities.Contract contract, string message)
        {
            var factory = CreateConnectionFactory();

            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.ExchangeDeclare(message, ExchangeType.Fanout);

            var contractJson = Newtonsoft.Json.JsonConvert.SerializeObject(contract);
            var contractJsonByte = Encoding.UTF8.GetBytes(contractJson);
            channel.BasicPublish(message, "", null, contractJsonByte);
            if (!channel.IsClosed) channel.Close();
            if (connection.IsOpen) connection.Close();
        }
        public  ConnectionFactory CreateConnectionFactory()
        {
            return new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
                Port = 5672
            };
        }
        
    }
}

