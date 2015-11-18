
using System;

namespace WebAPI.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool Gold { get; set; }
        public DateTime Joined { get; set; }
    }
}