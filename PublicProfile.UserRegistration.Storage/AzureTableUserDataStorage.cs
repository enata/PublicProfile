namespace PublicProfile.UserRegistration.Storage
{
    using Microsoft.Azure.Cosmos.Table;

    internal sealed class AzureTableUserDataStorage : IUserDataStorage
    {
        private readonly CloudStorageAccount storageAccount;

        public AzureTableUserDataStorage(string connectionString)
        {
            this.storageAccount = CloudStorageAccount.Parse(connectionString);
        }
    }
}
