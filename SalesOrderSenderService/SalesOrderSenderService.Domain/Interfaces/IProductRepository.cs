using SalesOrderSenderService.Domain.Entities;

namespace SalesOrderSenderService.Domain.Interfaces
{
    public interface ISalesOrderRepository
    {
        Task<IEnumerable<SalesOrder>> GetSalesOrdersAsync();
        Task UpdateAcceptedOrder(SalesOrder salesOrder);
    }
}