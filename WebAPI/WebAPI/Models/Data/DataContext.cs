using System.Web.Configuration;

namespace WebAPI.Models
{
    using System.Data.Entity;

    public class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
    }

}