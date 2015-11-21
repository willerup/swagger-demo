using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IO.Swagger.Model;
using WebAPI.Models.Business;
using Customer = WebAPI.Models.Customer;

namespace WebAPI.Controllers
{
    [RoutePrefix("v2/customers")]
    public class Customers2Controller : ApiController
    {
        private readonly ICustomerRepository _customers;

        public Customers2Controller()
        {
            _customers = new DataContextCustomerRepository();
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<CustomerSummary> ListCustomers()
        {
            return _customers.List();
        }

        [Route("")]
        [HttpPost]
        public CustomerDetail CreateCustomer([FromBody]CustomerCreate customer)
        {
            return _customers.Create(customer);
        }

        [Route("{id}")]
        [HttpGet]
        public CustomerDetail GetCustomer(int id)
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
