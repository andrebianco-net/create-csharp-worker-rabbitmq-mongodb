using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using SalesOrderSenderService.Domain.Entities;
using SalesOrderSenderService.Domain.Interfaces;
using SalesOrderSenderService.Infra.Data.Context;

namespace SalesOrderSenderService.Infra.Data.Repositories
{
   public class SalesOrderRepository : ISalesOrderRepository
    {

        private readonly IMongoCollection<SalesOrder> _salesOrdersRepository;
        private readonly ILogger<SalesOrderRepository> _logger;

        public SalesOrderRepository(IOptions<MongoDBSettings> mongoDBSettings,
                                 ILogger<SalesOrderRepository> logger)
        {
            _logger = logger;

            try
            {

                MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
                IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
                _salesOrdersRepository = database.GetCollection<SalesOrder>(mongoDBSettings.Value.CollectionName);

            }
            catch (System.Exception ex)
            {
                _logger.LogError($"SalesOrderRepository -> {ex.Message}");
            }
        }

        public async Task<IEnumerable<SalesOrder>> GetSalesOrdersAsync()
        {
            return await _salesOrdersRepository.Find(new BsonDocument()).ToListAsync();
        }

        public async Task SalesOrderUpdateAcceptedOrder(SalesOrder SalesOrder)
        {
            FilterDefinition<SalesOrder> filter = Builders<SalesOrder>.Filter.Eq("Id", SalesOrder.Id);

            var update = Builders<SalesOrder>.Update
                            .Set(p => p.AcceptedOrder, SalesOrder.AcceptedOrder);

            await _salesOrdersRepository.UpdateOneAsync(filter, update);
        }
    }
}