using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IViews_Presenters.frmInsertDisk
{
    public interface IInsertDisk
    {
        int ID { get; }
        string Status { get; set; }
        int CategoryID { get; set; }
        int TitleID { get; set; }
    }
}
