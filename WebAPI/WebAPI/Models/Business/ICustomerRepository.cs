using System;
using System.Collections.Generic;
using IO.Swagger.Model;

namespace WebAPI.Models.Business
{
    public interface ICustomerRepository
    {
        IEnumerable<CustomerSummary> List();
        CustomerDetail Create(CustomerCreate create);
        void Delete(int id);
        CustomerDetail Get(int id);
    }
}
