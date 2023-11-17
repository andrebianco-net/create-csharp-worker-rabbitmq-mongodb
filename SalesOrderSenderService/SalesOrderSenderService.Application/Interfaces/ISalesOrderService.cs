using SalesOrderSenderService.Application.DTOs;

namespace SalesOrderSenderService.Application.Interfaces
{
    public interface ISalesOrderService
    {
        Task<IEnumerable<SalesOrderDTO>> GetSalesOrders();

        Task SalesOrderUpdateAcceptedOrder(SalesOrderDTO SalesOrder);
    }
}