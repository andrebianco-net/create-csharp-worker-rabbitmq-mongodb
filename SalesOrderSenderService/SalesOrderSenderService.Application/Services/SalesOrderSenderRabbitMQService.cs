using AutoMapper;
using SalesOrderSenderService.Application.DTOs;
using SalesOrderSenderService.Application.Interfaces;
using SalesOrderSenderService.Domain.Entities;
using SalesOrderSenderService.Domain.Interfaces;

namespace SalesOrderSenderService.Application.Services
{
    public class SalesOrderSenderRabbitMQService : ISalesOrderSenderRabbitMQService
    {
        private ISalesOrderSenderRabbitMQRepository _salesOrderSenderRabbitMQRepository;
        private readonly IMapper _mapper;

        public SalesOrderSenderRabbitMQService(ISalesOrderSenderRabbitMQRepository salesOrderSenderRabbitMQRepository, 
                                               IMapper mapper)
        {
            _salesOrderSenderRabbitMQRepository = salesOrderSenderRabbitMQRepository;
            _mapper = mapper;
        }

        public async Task Send()
        {
            throw new NotImplementedException();
        }
    }
}