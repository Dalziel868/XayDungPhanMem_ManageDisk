using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IViews_Presenters.Customers
{
    public interface ICustomerForRentDisk
    {
         int CustomerID { get; set; }
         string DiskID { get;}
         List<int> ListDiskId { get;}
    }
}
