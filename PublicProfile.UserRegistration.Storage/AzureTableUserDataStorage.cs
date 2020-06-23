namespace PublicProfile.UserRegistration.Storage
{
    using Microsoft.Azure.Cosmos.Table;
    using System.Threading.Tasks;

    internal sealed class AzureTableUserDataStorage : IUserDataStorage
    {
        private readonly CloudStorageAccount storageAccount;

        public AzureTableUserDataStorage(string connectionString)
        {
            this.storageAccount = CloudStorageAccount.Parse(connectionString);
        }

        private async Task<CloudTable> GetTable(string name)
        {
            var tableClient = this.storageAccount.CreateCloudTableClient();
            var table = tableClient.GetTableReference(name);
            await table.CreateIfNotExistsAsync();
            return table;
        }
    }
}
