using Microsoft.Extensions.Logging;
using SalesOrderSenderService.Application.DTOs;
using SalesOrderSenderService.Application.Interfaces;

namespace SalesOrderSenderService.Application.Services
{
    public class SalesOrderSenderAppService : ISalesOrderSenderAppService
    {
        private readonly ISalesOrderService _salesOrderService;
        private readonly ISalesOrderSenderAppService _salesOrderSenderAppService;
        private readonly ILogger<SalesOrderSenderAppService> _logger;

        public SalesOrderSenderAppService(ISalesOrderService salesOrderService,
                                          ISalesOrderSenderAppService salesOrderSenderAppService,
                                          ILogger<SalesOrderSenderAppService> logger)
        {
            _salesOrderService = salesOrderService;
            _salesOrderSenderAppService = salesOrderSenderAppService;
            _logger = logger;
        }

        public async Task SalesOrderSenderRun()
        {
            // IEnumerable<SalesOrderDTO> listSalesOrder = await _salesOrderService.GetSalesOrders();

            // SalesOrderDTO salesOrderDTO = listSalesOrder.FirstOrDefault();
            // salesOrderDTO.AcceptedOrder = true;

            // _salesOrderService.UpdateAcceptedOrder(salesOrderDTO);
        }
    }
}