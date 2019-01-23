using Storage.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Linq;

namespace Storage.Framework
{
    public class BlobStorage : BlobStorageBase, IBlobStorage
    {
        public BlobStorage(IConfiguration configuration) : base(configuration) { }
        public async Task<IEnumerable<string>> ListContainersAsync()
        {
            try
            {
                var containerList = new List<string>();
                BlobContinuationToken continuationToken = null;
                do
                {
                    var containers = await GetBlobClient().ListContainersSegmentedAsync(continuationToken);
                    continuationToken = containers.ContinuationToken;
                    foreach (var item in containers.Results)
                    {
                        containerList.Add(item.Name);
                    }
                } while (continuationToken != null);
                return containerList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
