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

            try
            {
                //First, take data from MongoDB
                IEnumerable<SalesOrderDTO> salesOrders = await _salesOrderService.GetSalesOrders();

                //Second, send data to RabbitMQ queue
                foreach (SalesOrderDTO salesOrder in salesOrders)
                {
                    bool successSending = false;                
                    successSending = await _salesOrderSenderRabbitMQService.Send(salesOrder);
                    
                    if (successSending)
                    {
                        //Third, update file on MongoDB with accepted order result value
                        salesOrder.AcceptedOrder = true;
                        await _salesOrderService.UpdateAcceptedOrder(salesOrder);
                    }
                }

            }
            catch (System.Exception ex)
            {
                _logger.LogError($"SalesOrderReceiverService -> Error: {ex.Message}");
            }

        }
    }
}