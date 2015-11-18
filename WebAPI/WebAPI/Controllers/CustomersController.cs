using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [RoutePrefix("v1/customers")]
    public class CustomersController : ApiController
    {
        private readonly DataContext _context;

        public CustomersController()
        {
            _context = new DataContext();
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<Customer> ListCustomers()
        {
            return _context.Customers;
        }

        [Route("")]
        [HttpPost]
        public Customer CreateCustomer([FromBody]CreateCustomer value)
        {
            Customer customer = new Customer
            {
                Name = value.Name,
                Gold = value.Gold,
                Joined = DateTime.Now
            };

            customer = _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        [Route("{id}")]
        [HttpGet]
        public Customer GetCustomer(int id)
        {
            return _context.Customers.Find(id);
        }


        [Route("{id}")]
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
             var customer = _context.Customers.Find(id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}
