using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Disks
{
    public class Disk_Title
    {
        public int DiskID { get; set; }

        [StringLength(350)]
        public string Name { get; set; }
        public ICollection<string> TitleNames { get; set; }

    }
}
