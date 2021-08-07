using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IViews_Presenters.frmInfoLateCharge
{
    public interface IInfoCharge
    {
         int CustomerID { get; }
         int DiskID { get; set; }
         List<int> ListDiskID { get;}
    }
}
