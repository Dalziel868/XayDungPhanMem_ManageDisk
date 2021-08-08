using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IViews_Presenters.frmReserveDisk
{
    public interface IReserveDisk
    {
         string TitleName { get; set; }
          int CustomerID { get; set; }
        List<int> ListTitleID { get;}
    }
}
