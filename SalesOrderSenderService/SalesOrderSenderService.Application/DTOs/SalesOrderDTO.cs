using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SalesOrderSenderService.Application.DTOs
{
    public class SalesOrderDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public int CustomerId { get; set; }
        public int CategoryId { get; set; }
        public List<int> ListProductId { get; set; }
        public int PaymentType { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Total { get; set; }
        public string SoldAt { get; set; }
        public string createdAt { get; set; }
        public bool AcceptedOrder { get; set; }
    }
}