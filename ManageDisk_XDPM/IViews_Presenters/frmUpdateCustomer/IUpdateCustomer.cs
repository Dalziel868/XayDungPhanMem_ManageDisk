using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Customers;

namespace IViews_Presenters
{
    public interface IUpdateCustomer
    {
        CustomerForUpdateDTO CustomerDto { get; set; }
    }
}
