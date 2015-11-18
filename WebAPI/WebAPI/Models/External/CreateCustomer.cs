using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class CreateCustomer
    {
        public string Name { get; set; }

        public bool Gold { get; set; }
    }
}