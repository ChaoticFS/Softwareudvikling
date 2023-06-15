using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CustomerApi.Controllers
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
    }

    public class CustomersController : ApiController
    {
        private static List<Customer> customers = new List<Customer>
        {
            new Customer { Id = 1, Name = "Magnus cocksucker", Email = "suck@cock.com", Type = "privat" },
            new Customer { Id = 2, Name = "fed benny", Email = "fed@tyksak.com", Type = "erhverv" },
            new Customer { Id = 3, Name = "Bob Johnson", Email = "bob@asshole.com", Type = "privat" }
        };

        // GET /api/kunder
        public IHttpActionResult GetCustomers()
        {
            return Ok(customers);
        }

        // GET /api/kunder/{id}
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        // POST /api/kunder
        public IHttpActionResult PostCustomer(Customer customer)
        {
            customer.Id = customers.Max(c => c.Id) + 1;
            customers.Add(customer);

            return CreatedAtRoute("DefaultApi", new { id = customer.Id }, customer);
        }

        // DELETE /api/kunder/{id}
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();

            customers.Remove(customer);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET /api/emails/{type}
        [Route("api/emails/{type}")]
        public IHttpActionResult GetEmailsByType(string type)
        {
            var emails = customers.Where(c => c.Type.Equals(type, StringComparison.OrdinalIgnoreCase))
                                 .Select(c => c.Email)
                                 .ToList();

            return Ok(emails);
        }
    }
}
