namespace Users_mongodb_mar17.Models
{
    public class UserStoreSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;

        public string UserDatabaseCollectionName { get; set; } = string.Empty;

    }
}
