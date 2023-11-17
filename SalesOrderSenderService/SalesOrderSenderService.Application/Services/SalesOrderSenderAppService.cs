using Microsoft.Extensions.Logging;
using SalesOrderSenderService.Application.DTOs;
using SalesOrderSenderService.Application.Interfaces;

namespace SalesOrderSenderService.Application.Services
{
    public class SalesOrderSenderAppService : ISalesOrderSenderAppService
    {
        private readonly ISalesOrderService _salesOrderService;
        private readonly ILogger<SalesOrderSenderAppService> _logger;

        public SalesOrderSenderAppService(ISalesOrderService salesOrderService,
                                          ILogger<SalesOrderSenderAppService> logger)
        {
            _salesOrderService = salesOrderService;
            _logger = logger;
        }

        public Task SalesOrderSenderRun()
        {
            throw new NotImplementedException();
        }
    }
}