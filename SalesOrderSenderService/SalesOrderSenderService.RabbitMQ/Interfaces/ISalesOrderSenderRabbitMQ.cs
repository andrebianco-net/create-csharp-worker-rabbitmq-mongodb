namespace SalesOrderSenderService.RabbitMQ.Interfaces
{
    public interface ISalesOrderSenderRabbitMQ
    {
        Task Send();
    }
}
