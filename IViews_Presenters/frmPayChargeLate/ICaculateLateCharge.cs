using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IViews_Presenters.Charges
{
    public interface ICaculateLateCharge
    {
        int CustomerID { get; }
        List<Guid> ListBillDetailID { get; }
    }
}
