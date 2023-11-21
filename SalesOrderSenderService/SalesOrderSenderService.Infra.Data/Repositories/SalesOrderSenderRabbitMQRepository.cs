using AutoMapper;
using Microsoft.Extensions.Logging;
using SalesOrderSenderService.Domain.Interfaces;
using SalesOrderSenderService.RabbitMQ.Interfaces;

namespace SalesOrderSenderService.Infra.Data.Repositories
{
    public class SalesOrderSenderRabbitMQRepository : ISalesOrderSenderRabbitMQRepository
    {
        private readonly ISalesOrderSenderRabbitMQ _salesOrderSenderRabbitMQ;
        private readonly IMapper _mapper;
        private readonly ILogger<SalesOrderSenderRabbitMQRepository> _logger;

        public SalesOrderSenderRabbitMQRepository(ISalesOrderSenderRabbitMQ salesOrderSenderRabbitMQ,
                                     IMapper mapper,
                                     ILogger<SalesOrderSenderRabbitMQRepository> logger)
        {
            _salesOrderSenderRabbitMQ = salesOrderSenderRabbitMQ;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Send()
        {
            throw new NotImplementedException();
        }
    }
}