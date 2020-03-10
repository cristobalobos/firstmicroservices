using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lil.Products.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Lil.Customers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsProvider productsProvider;
        public ProductsController(IProductsProvider productsProvider)
        {
            this.productsProvider = productsProvider;
        }

        /// <summary>
        /// Metodo get encargado de obtener los productos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id) 
        {
            var result = await productsProvider.GetAsync(id);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }
    }
}
