using SalesOrderSenderService.Application.DTOs;

namespace SalesOrderSenderService.Application.Interfaces
{
    public interface ISalesOrderSenderRabbitMQService
    {
        Task Send();
    }
}