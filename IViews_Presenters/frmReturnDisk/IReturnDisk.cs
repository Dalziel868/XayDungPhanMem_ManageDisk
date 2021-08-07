using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IViews_Presenters.Disks
{
    public interface IReturnDisk
    {
        int DiskId { get; }
        int ListOrderOnHold { get; }
    }
}
