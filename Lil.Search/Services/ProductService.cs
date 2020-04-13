using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Lil.Search.Models;
using Newtonsoft.Json;

namespace Lil.Search.Services
{

    public class ProductService : Lil.Search.Interfaces.IProductsService
    {
        private readonly IHttpClientFactory httpClientFactory;
        public ProductService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Establecemos comunicación Http entre el servicio de busqueda con el productos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Product> GetAsync(string id)
        {
            // implmementamos funcionalidad para implementar el servicio del startUp 
            var client = httpClientFactory.CreateClient("productsService");

            var response = await client.GetAsync($"api/products/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<Product>(content);
                return product;
            }

            return null;
        }
    }
}
