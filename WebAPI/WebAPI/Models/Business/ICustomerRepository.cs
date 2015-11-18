using System;
using System.Collections.Generic;

namespace WebAPI.Models.Business
{
    public interface ICustomerRepository
    {
        IList<Customer> List();
        Customer Create(Customer create);
        void Delete(int id);
        Customer Get(int id);
    }
}
