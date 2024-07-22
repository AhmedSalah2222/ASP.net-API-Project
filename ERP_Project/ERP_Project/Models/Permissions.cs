using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ERP_Project.Models
{
    public class Permissions
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Permission_ID { get; set; }
        public string Organization_ID { get; set; }
        public string Org_Admin_ID { get; set; }
        public bool User_Status { get; set; }
        public bool Super_Admin { get; set; }
        public bool Orgnaization_Admin { get; set; }
    }
}
