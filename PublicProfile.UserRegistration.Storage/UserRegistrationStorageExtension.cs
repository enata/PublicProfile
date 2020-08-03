namespace PublicProfile.UserRegistration.Storage
{
    using Microsoft.Extensions.DependencyInjection;

    public static class UserRegistrationStorageExtension
    {
        public static IServiceCollection AddAzureTablesBasedUserStore(
            this IServiceCollection serviceCollection, 
            string connectionString, 
            string userTableName)
        {
            serviceCollection.AddScoped<IUserDataStorage>(sp => new AzureTableUserDataStorage(connectionString, userTableName));

            return serviceCollection;
        }
    }
}
