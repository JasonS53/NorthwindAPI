using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProduceAPIwDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        [HttpGet()]
        public List<Customer> GetAllCustomers()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Customers.ToList();
            }
        }

        [HttpGet("country")]
        public List<Customer> SearchByType(string country)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                List<Customer> result = context.Customers.ToList().Where(p => p.Country.ToLower() == country.ToLower()).ToList();
                return result;
            }
        }

        [HttpPost("AddCustomer")]
        public Customer AddCustomer(string customerId, string companyName, string contactName, string contactTitle, string address, string city, string region, string postalCode, string country, string phone, string fax)
        {
            Customer customer = new Customer();

            customer.CustomerId = customerId;
            customer.CompanyName = companyName;
            customer.ContactName = contactName;
            customer.ContactTitle = contactTitle;
            customer.Address = address;
            customer.City = city;
            customer.Region = region;
            customer.PostalCode = postalCode;
            customer.Country = country;
            customer.Phone = phone;
            customer.Fax = fax;

            using (NorthwindContext context = new NorthwindContext())
            {
                context.Customers.Add(customer);
                context.SaveChanges();
            }
            return customer;
        }   
    }
}
