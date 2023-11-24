using Microsoft.Extensions.Logging;
using SalesOrderSenderService.Application.DTOs;
using SalesOrderSenderService.Application.Interfaces;

namespace SalesOrderSenderService.Application.Services
{
    public class SalesOrderSenderAppService : ISalesOrderSenderAppService
    {
        private readonly ISalesOrderService _salesOrderService;
        private readonly ISalesOrderSenderRabbitMQService _salesOrderSenderRabbitMQService;
        private readonly ILogger<SalesOrderSenderAppService> _logger;

        public SalesOrderSenderAppService(ISalesOrderService salesOrderService,
                                          ISalesOrderSenderRabbitMQService salesOrderSenderRabbitMQService,
                                          ILogger<SalesOrderSenderAppService> logger)
        {
            _salesOrderService = salesOrderService;
            _salesOrderSenderRabbitMQService = salesOrderSenderRabbitMQService;
            _logger = logger;
        }

        public async Task SalesOrderSenderRun()
        {
            // IEnumerable<SalesOrderDTO> listSalesOrder = await _salesOrderService.GetSalesOrders();

            // SalesOrderDTO salesOrderDTO = listSalesOrder.FirstOrDefault();
            // salesOrderDTO.AcceptedOrder = true;

            // _salesOrderService.UpdateAcceptedOrder(salesOrderDTO);
            
            bool successSending = false;
            
            successSending = await _salesOrderSenderRabbitMQService.Send("TestXXX");
        }
    }
}