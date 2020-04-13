using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lil.Search.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace Lil.Search.Services 
{
    public class CustomersService : Lil.Search.Interfaces.ICustomersService
    {
        private readonly IHttpClientFactory httpClientFactory;
        public CustomersService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Establecemos comunicación Http entre el servicio de busqueda con el empleados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Customer> GetAsync(string id)
        {
            // implmementamos funcionalidad para implementar el servicio del startUp 
            var client = httpClientFactory.CreateClient("customersService");

            var response = await client.GetAsync($"api/customers/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var customer = JsonConvert.DeserializeObject<Customer>(content);
                return customer;
            }

            return null;

        } 
    }
}
