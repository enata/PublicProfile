using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace PublicProfile.UserRegistration.Storage
{
    public interface IUserDataStorage
    {
        Task Store(IUser<string> user);

        Task<IUser<string>> GetUserById(string id);

        Task Delete(string id);
    }
}
