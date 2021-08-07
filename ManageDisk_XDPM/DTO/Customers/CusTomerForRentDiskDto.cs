using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Customers
{
    public class CusTomerForRentDiskDto
    {
        [StringLength(300)]
        public string FullName { get; set; }

        [StringLength(11)]
        public string Phone { get; set; }
    }
}
