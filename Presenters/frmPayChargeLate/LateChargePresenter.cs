using DTO.Customers;
using IViews_Presenters.Charges;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DTO.Charges;

namespace Presenters.Charges
{
    public class LateChargePresenter
    {
        private readonly ICaculateLateCharge _view;
        private ManageDisk _context;
        
        public LateChargePresenter(ICaculateLateCharge view)
        {
            _view = view;
            _context = new ManageDisk();
        }
        /**
         * Lấy thông tin khách hàng để hiển thị lên frmPayChargeLate
         */
        public CustomerLateCharge GetOneCustomer()
        {
            int customerID = _view.CustomerID;
            var customerData = _context.Customers.Find(customerID);
            if(customerData!=null)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Customer,CustomerLateCharge>());
                var mapper = new Mapper(config);

                var customerDto = mapper.Map<CustomerLateCharge>(customerData);
                return customerDto;
            }
            return null;
        }
        /**
         * Hàm thanh toán phí trễ. set null ở cột latechargeID trong bảng BillDetail
         * 
         */
        public bool PayLateCharge()
        {
            List<Guid> listBillDetailID = _view.ListBillDetailID;
            if(listBillDetailID.Count==0)
            {
                return false;
            }
            foreach (var item in listBillDetailID)
            {
                BillDetail billDetail = _context.BillDetails.Find(item);
                billDetail.LateChargeID = null;
                _context.BillDetails.Attach(billDetail);
                _context.Entry(billDetail).Property(b => b.LateChargeID).IsModified = true;

            }
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        /**
         * 
         * Hiển thị danh sách phí trễ và số ngày trễ của 1 khách hàng
         */
        public IEnumerable<ChargeToPay> GetListChargeOfCusTomer()
        {
            int customerId = _view.CustomerID;
            var listInforCharge = from c in _context.Customers
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
                             where c.Id == customerId && bd.ReturnDate!=null && bd.LateChargeID!=null
                             select new InforChargeToPay
                             {
                                 ChargePercent=lc.ChargePercent,
                                 DueDate=bd.DueDate,
                                 UnitPrice=ct.UnitPrice,
                                 RowID=bd.RowID,
                                 ReturnDate=bd.ReturnDate??DateTime.Now
                             };
            List<ChargeToPay> listChargeToPay = new List<ChargeToPay>();

           
            foreach (var item in listInforCharge)
            {
                ChargeToPay charge = new ChargeToPay();
                charge.LateCharge = (Convert.ToDecimal(item.ChargePercent) * item.UnitPrice??0);
                TimeSpan span = item.ReturnDate.Subtract(item.DueDate);
                charge.NumberOfDaysLate = span.Days;
                charge.RowID = item.RowID;
                listChargeToPay.Add(charge);
            }
            return listChargeToPay;

        }

    }
}
