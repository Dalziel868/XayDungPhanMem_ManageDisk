using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IViews_Presenters.frmCancelReservation
{
    public interface ICancelReservation
    {
        int CustomerID { get;}
        int TitleID { get; }
    }
}
