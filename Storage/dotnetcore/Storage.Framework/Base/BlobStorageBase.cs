using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Storage.Framework
{
    public abstract class BlobStorageBase : AzureStorageBase
    {

        protected BlobStorageBase(IConfiguration configuration) : base(configuration) { }

        public CloudBlobClient GetBlobClient()
        {
            return cloudStorageAccount.CreateCloudBlobClient();
        }
    }
}
