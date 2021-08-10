using DTO.Charges;
using IViews_Presenters.frmSearchLateCharge;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenters.frmSearchLateCharge
{
    public class SearchLateChargePresenter
    {
        private readonly ManageDisk _context;
        private readonly ISearchLateCharge _view;
        public SearchLateChargePresenter(ISearchLateCharge view)
        {
            _context = new ManageDisk();
            _view = view;
        }
        public decimal GetTotalLateCharge()
        {
            int customerId = _view.CustomerID;
            if (customerId == -1)
                throw new Exception("Bạn chưa nhập ID Khách hàng");
            var lateChargeData = from c in _context.Customers
                                 join b in _context.Bills
                                 on c.Id equals b.CustomerId
                                 join bd in _context.BillDetails
                                 on b.Id equals bd.BillID
                                 join lc in _context.LateCharges
                                 on bd.LateChargeID equals lc.Id
                                 join d in _context.C_Disk
                                 on bd.DiskID equals d.Id
                                 join ct in _context.Categories
                                 on d.CategoryId equals ct.Id
                                 where c.Id == customerId
                                 select new LateChargeDto
                                 {
                                     ChargePercent=lc.ChargePercent,
                                     UnitPrice=ct.UnitPrice
                                 };
            if(lateChargeData.Count()==0)
            {
                return 0;
            }
            decimal totalLateCharge = 0;
            foreach (var item in lateChargeData)
            {
                totalLateCharge += item.LateCharge;
            }
            return totalLateCharge;
        }

    }
}
