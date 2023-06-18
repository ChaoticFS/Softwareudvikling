using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
            return Ok(customers);
        }

        // GET /api/customers/{id}
        [HttpGet("{id}")]
        public IActionResult GetCustomer(int id)
        {
            var customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        // POST /api/customers
        [HttpPost]
        public IActionResult PostCustomer([FromBody] Customer customer)
        {
            customer.Id = customers.Max(c => c.Id) + 1;
            customers.Add(customer);

            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
        }

        // DELETE /api/customers/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();

            customers.Remove(customer);
            return NoContent();
        }

        // GET /api/emails/{type}
        [HttpGet("emails/{type}")]
        public IActionResult GetEmailsByType(string type)
        {
            var emails = customers.Where(c => c.Type.Equals(type, StringComparison.OrdinalIgnoreCase))
                                 .Select(c => c.Email)
                                 .ToList();

            return Ok(emails);
        }

        public static void Main(string[] args)
        {
            // Opret og konfigurer en webhost
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            var app = builder.Build();

            // Tilføj controllers til appen
            app.MapControllers();

            // Start appen
            app.Run();
        }
    }

    // Modelklasse for kunder
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
    }
}


/*
 * Koden definerer en ASP.NET Core Web API-kontroller, CustomersController, som håndterer kundeoplysninger. Her er de vigtigste kommentarer:

customers: Dette er en simuleret liste over kunder, der normalt ville blive erstattet af en database. Den indeholder tre eksempelkunder.
GetCustomers(): En GET-anmodning til /api/customers returnerer alle kunderne i listen som svar.
GetCustomer(int id): En GET-anmodning til /api/customers/{id} returnerer kunden med den specificerede id.
PostCustomer([FromBody] Customer customer): En POST-anmodning til /api/customers tilføjer en ny kunde til listen baseret på det medfølgende customer-objekt.
DeleteCustomer(int id): En DELETE-anmodning til /api/customers/{id} fjerner kunden med den specificerede id fra listen.
GetEmailsByType(string type): En GET-anmodning til /api/emails/{type} returnerer en liste over e-mailadresser for kunder af en bestemt type.
Main(string[] args): Dette er indgangspunktet for applikationen, hvor en webhost oprettes og konfigureres til at køre CustomersController ved hjælp af ASP.NET Core.
Derudover er der en modelklasse Customer, der repræsenterer kundedata med egenskaber som Id, Name, Email og Type.
*/