using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Disks
{
    public abstract class DiskDto
    {
        [StringLength(500)]
        public string Name { get; set; }
        [StringLength(15)]
        public string C_Status { get; set; }
    }
}
