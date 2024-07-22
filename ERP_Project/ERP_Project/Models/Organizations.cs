using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ERP_Project.Models
{
    public class Organizations
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Organization_ID { get; set; }
        public string License_ID { get; set; }
        public bool Org_Status { get; set; }
        //public string[] Organization_Type {  get; set; }
        public string Organization_Type { get; set; }

        public string Organization_Name { get; set; }
        public string Organization_Financial_ID { get; set; }
    }
}
