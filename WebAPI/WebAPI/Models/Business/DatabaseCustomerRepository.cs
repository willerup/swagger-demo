using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.Business
{
    public class DatabaseCustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;

        public DatabaseCustomerRepository()
        {
            _context = new DataContext();
        }

        public IList<Customer> List()
        {
            return _context.Customers.ToList();
        }

        public Customer Create(CreateCustomer create)
        {
            Customer customer = new Customer
            {
                Name = create.Name,
                Gold = create.Gold,
                Joined = DateTime.Now
            };

            customer = _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        public Customer Create(Customer create)
        {
            return _context.Customers.Add(create);
        }

        public void Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        public Customer Get(int id)
        {
            return _context.Customers.Find(id);
        }
    }
}