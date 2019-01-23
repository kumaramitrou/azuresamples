using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Framework
{
    public interface IBlobStorage
    {
        Task<IEnumerable<string>> ListContainersAsync();
        CloudBlobContainer GetContainerAsync(string name);
    }
}
