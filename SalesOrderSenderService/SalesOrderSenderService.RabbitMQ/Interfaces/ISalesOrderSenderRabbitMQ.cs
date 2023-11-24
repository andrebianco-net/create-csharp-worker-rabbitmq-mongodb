using SalesOrderSenderService.Domain.Entities;

namespace SalesOrderSenderService.RabbitMQ.Interfaces
{
    public interface ISalesOrderSenderRabbitMQ
    {
        Task<bool> Send(SalesOrder salesOrder);
    }
}
