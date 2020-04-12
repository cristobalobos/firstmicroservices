using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Lil.Search.Models;
using Newtonsoft.Json;

namespace Lil.Search.Services
{
    public class SalesService : Lil.Search.Interfaces.ISalesService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public SalesService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<ICollection<Order>> GetAsync(string customerId)
        {           
            // implmementamos funcionalidad para implementar el servicio del startUp 
            var client = httpClientFactory.CreateClient("salesService");

            var response = await client.GetAsync($"api/sales/{customerId}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var orders = JsonConvert.DeserializeObject<ICollection<Order>>(content);
                return orders;
            }

            return null;
        }
    }
}
