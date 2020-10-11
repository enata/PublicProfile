namespace PublicProfile.UserRegistration.Storage
{
    using Microsoft.AspNet.Identity;
    using Microsoft.Azure.Cosmos.Table;
    using System.Threading.Tasks;

    internal sealed class AzureTableUserDataStorage : IUserDataStorage
    {
        private readonly CloudStorageAccount storageAccount;
        private readonly string userTableName;

        public AzureTableUserDataStorage(string connectionString, string userTableName)
        {
            this.storageAccount = CloudStorageAccount.Parse(connectionString);
            this.userTableName = userTableName;
        }

        public async Task Store(IUser<string> user)
        {
            var userTable = await this.GetUserTable();
            var operation = PrepareStoreOperationFor(user);
            await userTable.ExecuteAsync(operation);
        }

        public async Task<IUser<string>> GetUserById(string id)
        {
            var userTable = await this.GetUserTable();
            var operation = TableOperation.Retrieve<StoredUser>(id, id);
            var result = await userTable.ExecuteAsync(operation);
            return result.Result as StoredUser;
        }

        public async Task Delete(string userId)
        {
            var userTable = await this.GetUserTable();
            var operation = PrepareDeleteOperationFor(userId);
            await userTable.ExecuteAsync(operation);
        }

        private TableOperation PrepareDeleteOperationFor(string userId)
        {
            var userToDelete = new StoredUser { UserName = userId };
            return TableOperation.Delete(userToDelete);
        }

        private TableOperation PrepareStoreOperationFor(IUser<string> user)
        {
            var userToStore = new StoredUser(user);
            return TableOperation.InsertOrMerge(userToStore);
        }

        private Task<CloudTable> GetUserTable()
        {
            return this.GetTable(this.userTableName);
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
