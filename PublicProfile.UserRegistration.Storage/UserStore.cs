namespace PublicProfile.UserRegistration.Storage
{
    using Microsoft.AspNet.Identity;
    using System.Threading.Tasks;

    public class UserStore : IUserStore<User>
    {
        private readonly IUserDataStorage userDataStorage;

        public UserStore(IUserDataStorage storage)
        {
            this.userDataStorage = storage;
        }

        public async Task CreateAsync(User user)
        {
            await this.userDataStorage.Store(user);
        }

        public Task DeleteAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose() { }

        public async Task<User> FindByIdAsync(string userId)
        {
            var storedUser = await userDataStorage.GetUserById(userId);
            return new User(storedUser);
        }

        public async Task<User> FindByNameAsync(string userName)
        {
            return await this.FindByIdAsync(userName);
        }

        public async Task UpdateAsync(User user)
        {
            await userDataStorage.Store(user);
        }
    }
}
