using ERP_Project.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ERP_Project.Services
{
    public class NotificationsService
    {
        private readonly IMongoCollection<Notifications> _NotificationsCollection;



        public NotificationsService(
            IOptions<NotificationDatabaseSettings> NotificationDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                NotificationDatabaseSettings.Value.ConnectionStrings);

            var mongoDatabase = mongoClient.GetDatabase(
                NotificationDatabaseSettings.Value.DatabaseName);

            _NotificationsCollection = mongoDatabase.GetCollection<Notifications>(
                NotificationDatabaseSettings.Value.Notifications);
        }
        public async Task<List<Notifications>> GetAsync() =>
            await _NotificationsCollection.Find(_ => true).ToListAsync();

        public async Task CreateAsync(Notifications newNotification) =>
            await _NotificationsCollection.InsertOneAsync(newNotification);
        public async Task<Notifications?> GetAsync(string id) =>
            await _NotificationsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task UpdateAsync(string id, Notifications updatedBook) =>
            await _NotificationsCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _NotificationsCollection.DeleteOneAsync(x => x.Id == id);
    }
}
