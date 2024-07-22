using ERP_Project.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ERP_Project.Services
{
    public class OrganizationsService
    {
        private readonly IMongoCollection<Organizations> _OrganizationsCollection;



        public OrganizationsService(
            IOptions<NotificationDatabaseSettings> NotificationDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                NotificationDatabaseSettings.Value.ConnectionStrings);

            var mongoDatabase = mongoClient.GetDatabase(
                NotificationDatabaseSettings.Value.DatabaseName);

            _OrganizationsCollection = mongoDatabase.GetCollection<Organizations>(
                NotificationDatabaseSettings.Value.Organizations);
        }
        public async Task<List<Organizations>> GetAsync() =>
            await _OrganizationsCollection.Find(_ => true).ToListAsync();

        public async Task CreateAsync(Organizations newNotification) =>
            await _OrganizationsCollection.InsertOneAsync(newNotification);
        public async Task<Organizations?> GetAsync(string id) =>
            await _OrganizationsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task<Organizations?> GetOrgIdAsync(string orgId) =>
            await _OrganizationsCollection.Find(x => x.Organization_ID == orgId).FirstOrDefaultAsync();
        ////
        public async Task<Organizations?> GetLicenseIdAsync(string License_ID) =>
            await _OrganizationsCollection.Find(x => x.License_ID.Equals(License_ID)).FirstOrDefaultAsync();

        public async Task UpdateAsync(string id, Organizations updatedBook) =>
            await _OrganizationsCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _OrganizationsCollection.DeleteOneAsync(x => x.Id == id);
    }
}
