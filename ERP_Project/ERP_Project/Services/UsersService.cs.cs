using ERP_Project.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ERP_Project.Services
{
    public class UsersService
    {
        private readonly IMongoCollection<Users> _UsersCollection;
        public UsersService(
            IOptions<NotificationDatabaseSettings> NotificationDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                NotificationDatabaseSettings.Value.ConnectionStrings);

            var mongoDatabase = mongoClient.GetDatabase(
                NotificationDatabaseSettings.Value.DatabaseName);

            _UsersCollection = mongoDatabase.GetCollection<Users>(
                NotificationDatabaseSettings.Value.Users);
        }
        public async Task<List<Users>> GetAsync() =>
            await _UsersCollection.Find(_ => true).ToListAsync();

        public async Task CreateAsync(Users newNotification) =>
            await _UsersCollection.InsertOneAsync(newNotification);



        public async Task CreateAsyncList(List<Users> usersList)
        {
            /*var users = new List<Users>(); // Assuming User is a class representing a user
            foreach (var userMap in usersList)
            {
                var newUser = new Users();
                foreach (var kvp in userMap)
                {
                    typeof(Users).GetProperty(kvp.Key)?.SetValue(newUser, kvp.Value);
                }
                users.Add(newUser);
            }
            await _UsersCollection.InsertManyAsync(users);*/


            /*var new_list_user = new List<Users>();
            foreach (var map in usersList)
            {
                Users users = new Users();

                users.Organization_ID = map["Organization_ID"] as string;
                users.Organization_Name = map["Organization_Name"] as string;
                users.Permission_ID = map["Permission_ID"] as string;
                users.Org_Admin_ID = map["Org_Admin_ID"] as string;
                if (map["User_Status"] == "Active")
                {
                    users.User_Status = true;
                }
                else { users.User_Status = false; }
                
                users.Business_User_ID = map["Business_User_ID"] as string;
                users.Username = map["Username"] as string;
                users.User_Password = map["User_Password"] as string;
                users.User_Mobile_Number = map["User_Mobile_Number"] as string;
                users.User_National_ID = map["User_National_ID"] as string;
                users.User_Email = map["User_Email"] as string;
                
                new_list_user.Add(users);
            }*/
            await _UsersCollection.InsertManyAsync(usersList);
        }




        public async Task<Users?> GetAsync(string id) =>
            await _UsersCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task<Users?> GetEmailAsync(string user_email) =>
           await _UsersCollection.Find(x => x.User_Email == user_email).FirstOrDefaultAsync();
        public async Task UpdateAsync(string id, Users updatedBook) =>
            await _UsersCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _UsersCollection.DeleteOneAsync(x => x.Id == id);

        internal async Task CreateAsync(List<Users> users)
        {
            throw new NotImplementedException();
        }
    }
}
