using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string MobileNo { get; set; }
        public string EmailID { get; set; }
    }
}
