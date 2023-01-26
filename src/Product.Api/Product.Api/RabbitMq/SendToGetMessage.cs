using Product.Api.Entities;
using RabbitMQ.Client;
using System.Text;

namespace Product.Api.RabbitMq
{
	public class SendToGetMessage
	{
		public void SendMessage(ProductModel product , string message)
		{
			var factory = new ConnectionFactory
			{
				HostName = "localhost",
				UserName = "guest",
				Password = "guest",
				Port = 5672
			};

			var connection = factory.CreateConnection();
			var channel = connection.CreateModel();

			//channel.QueueDeclare("product_added", false, false, false, null);
			channel.ExchangeDeclare(message, ExchangeType.Fanout);

			var productJson = Newtonsoft.Json.JsonConvert.SerializeObject(product);
			var productJsonByte = Encoding.UTF8.GetBytes(productJson);
			channel.BasicPublish("product_added", "", null, productJsonByte);
			if(!channel.IsClosed)channel.Close();
			if(connection.IsOpen)connection.Close();
		}
	}
}
