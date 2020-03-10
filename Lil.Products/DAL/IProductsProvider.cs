using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lil.Products.Controllers.Models;

namespace Lil.Products.DAL
{
    //implementar todas las abstracciones para este probedor de datos
    public interface IProductsProvider
    {
        //nos devuelve de forma asincronia un producto
        Task<Product> GetAsync(string id);
    }
}
