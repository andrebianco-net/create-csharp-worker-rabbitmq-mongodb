using Microsoft.Extensions.Logging;
using SalesOrderSenderService.Domain.Entities;
using SalesOrderSenderService.Domain.Interfaces;
using SalesOrderSenderService.RabbitMQ.Interfaces;

namespace SalesOrderSenderService.Infra.Data.Repositories
{
    public class SalesOrderSenderRabbitMQRepository : ISalesOrderSenderRabbitMQRepository
    {
        private readonly ISalesOrderSenderRabbitMQ _salesOrderSenderRabbitMQ;
        private readonly ILogger<SalesOrderSenderRabbitMQRepository> _logger;

        public SalesOrderSenderRabbitMQRepository(ISalesOrderSenderRabbitMQ salesOrderSenderRabbitMQ,
                                                  ILogger<SalesOrderSenderRabbitMQRepository> logger)
        {
            _salesOrderSenderRabbitMQ = salesOrderSenderRabbitMQ;
            _logger = logger;
        }

        public async Task<bool> Send(SalesOrder salesOrder)
        {
            return await _salesOrderSenderRabbitMQ.Send(salesOrder);
        }
    }
}