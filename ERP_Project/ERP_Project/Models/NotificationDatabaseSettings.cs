namespace ERP_Project.Models
{
    public class NotificationDatabaseSettings
    {
        public string ConnectionStrings { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string Users { get; set; } = null!;
        public string Notifications { get; set; } = null!;
        public string Permissions { get; set; } = null!;
        public string Organizations { get; set; } = null!;
    }
}
