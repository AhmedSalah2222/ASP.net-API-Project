using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace ERP_Project.Models
{
    public class Users
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Org_Admin_ID { get; set; }
        public string Permission_ID { get; set; }
        public bool User_Status { get; set; }
        public string Business_User_ID { get; set; }
        public string Username { get; set; }
        public string User_Password { get; set; }
        public string User_Email { get; set; }
        public string User_Mobile_Number { get; set; }
        [StringLength(14)]
        public string User_National_ID { get; set; }
        public string Organization_ID { get; set; }
        public string Organization_Name { get; set; }



        public Users(string Org_Admin_ID, string Permission_ID, bool User_Status, string Business_User_ID, string Username, string User_Password,
            string User_Email, string User_Mobile_Number, string User_National_ID, string Organization_ID, string Organization_Name)
        {
            this.Org_Admin_ID = Org_Admin_ID;
            this.Permission_ID = Permission_ID;
            this.Organization_Name = Organization_Name;
            this.Organization_ID = Organization_ID;
            this.User_Status = User_Status;
            this.User_Password = User_Password;
            this.User_National_ID = User_National_ID;
            this.User_Mobile_Number = User_Mobile_Number;
            this.User_Email = User_Email;
            this.Username = Username;
            this.Business_User_ID = Business_User_ID;
        }
        public Users() { }
        /*public static Users FromMap(Dictionary<string, dynamic> map)
        {
            return new Users(
                map["Organization_ID"] as string,
                map["Organization_Name"] as string,
                map["Permission_ID"] as string,
                map["Org_Admin_ID"] as string,
                map["User_Status"] as bool,
                map["Business_User_ID"] as string,
                map["Username"] as string,
                map["User_Password"] as string,
                map["User_Mobile_Number"] as string,
                map["User_National_ID"] as string,
                map["User_Email"] as string
            );
        }*/
    }
}
