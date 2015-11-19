using System;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Demo.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var api = new PublicApi(new ApiClient("http://demo.local/v2"));
            var customers = api.ListCustomers(null, null);
            foreach (CustomerSummary customer in customers)
            {
                System.Console.WriteLine(customer.Name);
            }
            System.Console.ReadLine();
        }
    }
}
