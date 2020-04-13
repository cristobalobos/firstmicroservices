using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lil.Search.Interfaces;

namespace Lil.Search.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ICustomersService customersService;
        private readonly IProductsService productsService;
        private readonly ISalesService salesService;

        public SearchController(ICustomersService customersService, ISalesService salesService, IProductsService productsService)
        {
            this.customersService = customersService;
            this.salesService = salesService;
            this.productsService = productsService;
        }


        [HttpGet("customers/{customerId}")]
        public async Task<IActionResult> SearchAsync(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                return BadRequest();
            }

            try
            {
                var customer = await customersService.GetAsync(customerId);

                var sales = await salesService.GetAsync(customerId);

                //para revolver usamos un objeto dinamico podriamos igual hacer una clase response

                foreach (var sale in sales)
                {
                    foreach (var item in sale.Items)
                    {
                        var product = await productsService.GetAsync(item.ProductId);

                        item.product = product;
                    }
                }

                var result = new
                {
                    Customer = customer,
                    Sales = sales
                };

                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }


        }
    }
}