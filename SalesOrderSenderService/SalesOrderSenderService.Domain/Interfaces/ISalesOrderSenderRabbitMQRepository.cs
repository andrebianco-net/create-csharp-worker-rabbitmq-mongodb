using SalesOrderSenderService.Domain.Entities;

namespace SalesOrderSenderService.Domain.Interfaces
{
    public interface ISalesOrderSenderRabbitMQRepository
    {
        Task<bool> Send(string messageBody);
    }
}