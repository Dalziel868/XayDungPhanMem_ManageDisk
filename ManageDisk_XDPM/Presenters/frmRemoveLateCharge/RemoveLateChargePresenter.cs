using AutoMapper;
using DTO.BillDetails;
using DTO.Customers;
using IViews_Presenters.frmRemoveLateCharge;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenters.frmRemoveLateCharge
{
    public class RemoveLateChargePresenter
    {
        private readonly ManageDisk _context;
        private readonly IRemoveLateCharge _view;
        public RemoveLateChargePresenter(IRemoveLateCharge view)
        {
            _view = view;
            _context = new ManageDisk();
        }

        public IEnumerable<BillDetailForRemoveLateCharge> GetListLateChargeOfOneCustomer()
        {
           
            int customerId = _view.CustomerID;
            if (customerId == -1)
                throw new Exception("ID Khách Hàng không được bỏ trống");

            var listCharge = from c in _context.Customers
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
                             select new BillDetailForRemoveLateCharge
                             {
                                 RowID=bd.RowID,
                                 DiskName = d.Name,
                                 DueDate = bd.DueDate,
                                 ReturnDate = bd.ReturnDate,
                                 UnitPrice = ct.UnitPrice ?? 0,
                                 ChargePercent = lc.ChargePercent
                             };
            return listCharge;
        }
        public CustomerToCancelReservation GetCustomer()
        {
            int customerId = _view.CustomerID;
            if (customerId == -1)
                return null;
            var customerData = _context.Customers.Find(customerId);
            if (customerData != null)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Customer, CustomerToCancelReservation>());
                var mapper = new Mapper(config);

                CustomerToCancelReservation dto = mapper.Map<CustomerToCancelReservation>(customerData);
                return dto;
            }
            return null;

        }

        public bool DeleteLateCharge()
        {
            List<Guid> listRowid = _view.ListRowID;
            if (listRowid.Count == 0)
                return false;
            foreach (Guid item in listRowid)
            {
                var billDetail = _context.BillDetails.Find(item);
                billDetail.LateChargeID = null;
                _context.BillDetails.Attach(billDetail);
                _context.Entry(billDetail).Property(bd => bd.LateChargeID).IsModified = true;
            }
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateException)
            {

                return false;
            }
           
        }

    }
}
