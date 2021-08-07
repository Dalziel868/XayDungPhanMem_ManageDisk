using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Customers
{
    public class CustomerLateCharge
    {
        [StringLength(300)]
        public string FullName { get; set; }

        [StringLength(11)]
        public string Phone { get; set; }

        [StringLength(300)]
        public string HouseNumber_StreetName { get; set; }

        [StringLength(300)]
        public string Ward { get; set; }

        [StringLength(300)]
        public string District { get; set; }

        [StringLength(300)]
        public string City { get; set; }


    }
}
