namespace PublicProfile.UserRegistration.Storage
{
    using Microsoft.Extensions.DependencyInjection;

    public static class UserRegistrationStorageExtension
    {
        public static IServiceCollection AddAzureTablesBasedUserStore(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddScoped<IUserDataStorage>(sp => new AzureTableUserDataStorage(connectionString));

            return serviceCollection;
        }
    }
}
