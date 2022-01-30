using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manav_Otomasyonu.Entities
{
    public class Customer
    {
        //select CustomerId, FirstName, LastName, City, Region, Phone from Customers

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Phone { get; set; }
    }
}
