using System;
using IO.Swagger.Api;
using IO.Swagger.Model;

namespace Demo.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var api = new CustomersApi("http://demo.local");
            var customers = api.CustomersListCustomers();
            foreach (Customer customer in customers)
            {
                System.Console.WriteLine("{0,-20} {1,10} {2,20}", customer.Name, customer.Gold, customer.Joined);
            }
            System.Console.ReadLine();
        }
    }
}
