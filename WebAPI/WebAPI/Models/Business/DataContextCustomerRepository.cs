using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IO.Swagger.Model;

namespace WebAPI.Models.Business
{
    public class DataContextCustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;

        public DataContextCustomerRepository()
        {
            _context = new DataContext();
        }

        public IEnumerable<CustomerSummary> List()
        {
            return _context.Customers.ToList().Select(Summary);
        }

        public CustomerDetail Create(CustomerCreate create)
        {
            Customer customer = new Customer
            {
                Name = create.Name,
                Gold = create.Gold ?? false,
                Joined = DateTime.Now
            };

            customer = _context.Customers.Add(customer);
            _context.SaveChanges();
            return Detail(customer);
        }
        

        public void Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        public CustomerDetail Get(int id)
        {
            return Detail(_context.Customers.Find(id));
        }

        private CustomerSummary Summary(Customer customer)
        {
            return new CustomerSummary
            {
                Id = customer.Id.ToString(),
                Name = customer.Name
            };
        }

        private CustomerDetail Detail(Customer customer)
        {
            return new CustomerDetail
            {
                Id = customer.Id.ToString(),
                Name = customer.Name,
                Gold = customer.Gold,
                Joined = customer.Joined
            };

        }
    }
}