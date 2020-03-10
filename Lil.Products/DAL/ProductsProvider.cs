using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lil.Products.Controllers.Models;

namespace Lil.Products.DAL
{
    public class ProductsProvider : IProductsProvider
    {
        /// <summary>
        /// Esta va a tener la funcionalidad definida para acceder a una BD
        /// </summary>
        private List<Product> repo = new List<Product>();

        public ProductsProvider()
        {
            for (int i = 0; i < 100; i++)
            {
                //datos dummys
                repo.Add(new Product()
                {
                    Id = (i + 1).ToString(),
                    Name = $"Producto {i + 1}",
                    Price = (double)i * 3.14
                });
            }
        }
        public Task<Product> GetAsync(string id)
        {
            var product = repo.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(product);
        }
    }
}
