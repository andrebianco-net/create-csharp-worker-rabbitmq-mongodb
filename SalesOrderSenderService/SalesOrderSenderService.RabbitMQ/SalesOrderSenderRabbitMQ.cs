using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

using SalesOrderSenderService.RabbitMQ.Interfaces;

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

        public async Task Send()
        {
            throw new NotImplementedException();
        }
    }
}
