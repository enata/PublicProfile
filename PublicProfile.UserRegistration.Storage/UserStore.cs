namespace PublicProfile.UserRegistration.Storage
{
    using Microsoft.AspNet.Identity;
    using System.Threading.Tasks;

    public class UserStore<TUser> : IUserStore<TUser> where TUser : class, IUser<string>
    {
        public Task CreateAsync(TUser user)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(TUser user)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public Task<TUser> FindByIdAsync(string userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<TUser> FindByNameAsync(string userName)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(TUser user)
        {
            throw new System.NotImplementedException();
        }
    }
}
