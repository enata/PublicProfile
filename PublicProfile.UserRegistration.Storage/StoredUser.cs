namespace PublicProfile.UserRegistration.Storage
{
    using Microsoft.AspNet.Identity;
    using Microsoft.Azure.Cosmos.Table;

    public class StoredUser : TableEntity, IUser<string>
    {
        public StoredUser() { }

        public StoredUser(IUser<string> other)
        {
            this.UserName = other.UserName;
        }

        public string UserName
        {
            get => this.RowKey;
            set 
            { 
                this.RowKey = value;
                this.PartitionKey = value;
            }
        }

        public string Id 
        {
            get => this.UserName;
        }
    }
}
