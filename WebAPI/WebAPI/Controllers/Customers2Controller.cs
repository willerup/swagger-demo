using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using WebAPI.Models.Business;

namespace WebAPI.Controllers
{
    [RoutePrefix("v2/customers")]
    public class Customers2Controller : ApiController
    {
        private readonly ICustomerRepository _customers;

        public Customers2Controller()
        {
            _customers = new DatabaseCustomerRepository();
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<Customer> ListCustomers()
        {
            return _customers.List();
        }

        [Route("")]
        [HttpPost]
        public Customer CreateCustomer([FromBody]Customer customer)
        {
            return _customers.Create(customer);
        }

        [Route("{id}")]
        [HttpGet]
        public Customer GetCustomer(int id)
        {
            return _customers.Get(id);
        }


        [Route("{id}")]
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            _customers.Delete(id);
        }
    }
}
