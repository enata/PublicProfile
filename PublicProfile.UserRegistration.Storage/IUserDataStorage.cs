using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace PublicProfile.UserRegistration.Storage
{
    internal interface IUserDataStorage
    {
        Task Store(IUser<string> user);
    }
}
