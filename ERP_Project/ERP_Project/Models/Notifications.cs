using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ERP_Project.Models
{
    public class Notifications
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string[] Channel_Type { get; set; }
        public string Sender_ID { get; set; }
        public string Reciever_ID { get; set; }
        public DateTime Sending_Date { get; set; }
        public bool Creator_type { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Description { get; set; }
    }
}
