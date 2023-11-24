using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using SalesOrderSenderService.RabbitMQ.Interfaces;
using System.Text;
using System.Xml;

namespace SalesOrderSenderService.RabbitMQ
{
    public class SalesOrderSenderRabbitMQ : ISalesOrderSenderRabbitMQ
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<SalesOrderSenderRabbitMQ> _logger;

        public SalesOrderSenderRabbitMQ(IConfiguration configuration,
                                        ILogger<SalesOrderSenderRabbitMQ> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<bool> Send(string messageBody)
        {

            //Test
            //messageBody = Guid.NewGuid().ToString();

            try
            {
                ConnectionFactory factory = new ConnectionFactory();
                factory.Uri = new Uri(_configuration["RabbitMQ:Uri"]);
                factory.ClientProvidedName = _configuration["RabbitMQ:ClientProvidedName"];

                IConnection connection = factory.CreateConnection();
                IModel channel = connection.CreateModel();
                channel.ConfirmSelect();

                string exchangeName = _configuration["RabbitMQ:ExchangeName"];
                string routingKey = _configuration["RabbitMQ:RoutingKey"];
                string queueName = _configuration["RabbitMQ:QueueName"];

                channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
                channel.QueueDeclare(queueName, false, false, false, null);
                channel.QueueBind(queueName, exchangeName, routingKey);

                byte[] messageBytes = Encoding.UTF8.GetBytes(messageBody);

                IBasicProperties properties = channel.CreateBasicProperties();
                properties.Persistent = true;

                channel.BasicPublish(exchangeName, routingKey, properties, messageBytes);

                channel.WaitForConfirmsOrDie(TimeSpan.FromSeconds(5));

                channel.Close();
                connection.Close();

            }
            catch (System.Exception ex)
            {
                _logger.LogError($"SalesOrderSenderRabbitMQ -> Error: {ex.Message}");
                return false;
            }

            return true;
        }
    }
}
