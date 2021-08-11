using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Disks
{
    public class ListDisk
    {
        public int DiskID { get; set; }
        public string TieuDe { get; set; }
        public string TheLoai { get; set; }
        public string TrangThai { get; set; }
    }
}
