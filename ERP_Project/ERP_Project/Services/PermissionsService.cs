using ERP_Project.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ERP_Project.Services
{
    public class PermissionsService
    {
        private readonly IMongoCollection<Permissions> _PermissionsCollection;
        public PermissionsService(
            IOptions<NotificationDatabaseSettings> NotificationDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                NotificationDatabaseSettings.Value.ConnectionStrings);

            var mongoDatabase = mongoClient.GetDatabase(
                NotificationDatabaseSettings.Value.DatabaseName);

            _PermissionsCollection = mongoDatabase.GetCollection<Permissions>(
                NotificationDatabaseSettings.Value.Permissions);
        }
        public async Task<List<Permissions>> GetAsync() =>
            await _PermissionsCollection.Find(_ => true).ToListAsync();

        public async Task CreateAsync(Permissions newNotification) =>
            await _PermissionsCollection.InsertOneAsync(newNotification);
        public async Task<Permissions?> GetAsync(string id) =>
            await _PermissionsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task UpdateAsync(string id, Permissions updatedBook) =>
            await _PermissionsCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _PermissionsCollection.DeleteOneAsync(x => x.Id == id);
    }
}
