using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lil.Customers.Models;

namespace Lil.Customers.DAL
{
    public class CustomersProvider : ICustomersProvider
    {
        private readonly List<Customer> repo = new List<Customer>();
        public CustomersProvider()
        {
            repo.Add(new Customer() { Id = "1", Name = "Rodrigo", City = "Ciudad de Mexico" });
            repo.Add(new Customer() { Id = "2", Name = "Renata", City = "Madrid" });
            repo.Add(new Customer() { Id = "3", Name = "Raul", City = "Valparaiso" });
            repo.Add(new Customer() { Id = "4", Name = "Raquel", City = "Santiago" });
        }
        public Task<Customer> GetAsync(string id)
        {
            var customer = repo.FirstOrDefault(c => c.Id == id);
            return Task.FromResult(customer);
        }
    }
}
