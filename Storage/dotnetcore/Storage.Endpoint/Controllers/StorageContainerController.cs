using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Storage.Framework;

namespace Storage.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageContainerController : ControllerBase
    {
        private readonly IBlobStorage blobStorage;

        public StorageContainerController(IBlobStorage blobStorage)
        {
            this.blobStorage = blobStorage;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await blobStorage.ListContainersAsync());
        }
        [HttpGet]
        [Route("{name}")]
        public async Task<IActionResult> GetAsync(string name)
        {
            return Ok();
        }
    }
}