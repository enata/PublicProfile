namespace PublicProfile.UserRegistration.Storage
{
    using Microsoft.AspNet.Identity;
    using Microsoft.Azure.Cosmos.Table;

    public class StoredUser : TableEntity, IUser<string>
    {
        public StoredUser() { }

        public StoredUser(IUser<string> other)
        {
            this.Id = other.Id;
            this.UserName = other.UserName;
        }

        public string Id
        {
            get => this.RowKey;
            set => this.RowKey = value;
        }

        public string UserName 
        { 
            get => this.PartitionKey; 
            set => this.PartitionKey = value; 
        }
    }
}
