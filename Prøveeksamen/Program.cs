using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApi.Controllers
{
    [ApiController] // Angiver, at denne controller er en API-controller
    [Route("api/[controller]")] // Angiver rutepræfikset for alle handlinger i denne controller. [controller] erstattes med controllerens navn ("Customers").
    public class CustomersController : ControllerBase
    {
        // Simuleret liste over kunder (erstattes normalt af en database)
        private static List<Customer> customers = new List<Customer>
        {
            new Customer { Id = 1, Name = "John Doe", Email = "john@example.com", Type = "privat" },
            new Customer { Id = 2, Name = "Jane Smith", Email = "jane@example.com", Type = "erhverv" },
            new Customer { Id = 3, Name = "Bob Johnson", Email = "bob@example.com", Type = "privat" }
        };

        // GET /api/customers
        [HttpGet]
        public IActionResult GetCustomers()
        {
            return Ok(customers); // Returnerer alle kunder
        }

        // GET /api/customers/{id}
        [HttpGet("{id}")]
        public IActionResult GetCustomer(int id)
        {
            var customer = customers.FirstOrDefault(c => c.Id == id); // Finder kunden med den angivne id
            if (customer == null)
                return NotFound(); // Hvis kunden ikke findes, returneres en NotFound-fejl

            return Ok(customer); // Returnerer den fundne kunde
        }

        // POST /api/customers
        [HttpPost]
        public IActionResult PostCustomer([FromBody] Customer customer)
        {
            customer.Id = customers.Max(c => c.Id) + 1; // Genererer en ny id til den nye kunde
            customers.Add(customer); // Tilføjer den nye kunde til listen

            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
            // Returnerer en Created-respons med en URL til den nye kunde og kunden selv
        }

        // DELETE /api/customers/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = customers.FirstOrDefault(c => c.Id == id); // Finder kunden med den angivne id
            if (customer == null)
                return NotFound(); // Hvis kunden ikke findes, returneres en NotFound-fejl

            customers.Remove(customer); // Fjerner kunden fra listen
            return NoContent(); // Returnerer en NoContent-respons for at indikere, at handlingen er lykkedes
        }

        // GET /api/emails/{type}
        [HttpGet("emails/{type}")]
        public IActionResult GetEmailsByType(string type)
        {
            var emails = customers.Where(c => c.Type.Equals(type, StringComparison.OrdinalIgnoreCase))
                                 .Select(c => c.Email)
                                 .ToList(); // Filtrer og udvælg e-mailadresser baseret på den angivne type

            return Ok(emails); // Returnerer listen over e-mailadresser
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
    }
}
