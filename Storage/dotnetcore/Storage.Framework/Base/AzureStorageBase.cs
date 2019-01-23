using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;

namespace Storage.Framework
{
    public abstract class AzureStorageBase
    {
        protected readonly CloudStorageAccount cloudStorageAccount;

        protected AzureStorageBase(IConfiguration configuration)
        {
            this.cloudStorageAccount = CloudStorageAccount.Parse(configuration["AzureStorageConnectionString"]);
        }
    }
}
