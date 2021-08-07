using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Disks
{
    public class DiskForRent
    {
        public int Id { get; set; }

        [StringLength(350)]
        public string Name { get; set; }

        [StringLength(10)]
        public string CategoryName { get; set; }
        public decimal? UnitPrice { get; set; }

        public int? RentTime { get; set; }
    }
}
