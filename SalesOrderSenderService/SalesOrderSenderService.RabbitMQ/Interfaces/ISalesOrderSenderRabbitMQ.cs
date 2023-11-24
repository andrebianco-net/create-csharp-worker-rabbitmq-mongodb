namespace SalesOrderSenderService.RabbitMQ.Interfaces
{
    public interface ISalesOrderSenderRabbitMQ
    {
        Task<bool> Send(string messageBody);
    }
}
