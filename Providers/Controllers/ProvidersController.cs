using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Providers.Models;

namespace Providers.Controllers
{
    public class ProvidersController : ApiController
    {
        Provider[] providers = new Provider[]
       {
            new Provider { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Provider { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Provider { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
       };

        public IEnumerable<Provider> GetAllProviders()
        {
            // return providers;
            ProviderHandler ph = new ProviderHandler();
            List<Provider> prv = ph.retrieveAllProviders();
            return prv;
        }

        public IHttpActionResult GetProvider(int id)
        {
            ProviderHandler ph = new ProviderHandler();
            Provider prv = ph.retrieveProivder(id);
           
            if (prv == null)
            {
                return NotFound();
           }
            return Ok(prv);
        }
    }
}
