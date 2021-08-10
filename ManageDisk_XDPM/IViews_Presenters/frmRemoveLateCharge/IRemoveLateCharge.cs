using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IViews_Presenters.frmRemoveLateCharge
{
    public interface IRemoveLateCharge
    {
        int CustomerID { get; }
        List<Guid> ListRowID { get; }
    }
}
