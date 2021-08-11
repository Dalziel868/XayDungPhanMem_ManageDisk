using DTO.Customers;
using IViews_Presenters.frmInfoLateCharge;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DTO.Disks;
using DTO.BillDetails;

namespace Presenters.frmInfoLateCharge
{
    public class InfoLateChargePresenter
    {
        private readonly ManageDisk _context;
        private readonly IInfoCharge _view;
        public InfoLateChargePresenter(IInfoCharge view)
        {
            _context = new ManageDisk();
            _view = view;
            
        }
        /**
         * Lấy thông tin khách hàng để hiển thị trong form InforLateCharge
         */
        public CustomerInfoLateCharge GetCustomerInInfoCharge()
        {
            int customerID = _view.CustomerID;
            var customerData = _context.Customers.Find(customerID);
            if (customerData == null)
                return null;
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Customer,CustomerInfoLateCharge>());
            var mapper = new Mapper(config);
            CustomerInfoLateCharge customerDto = mapper.Map<CustomerInfoLateCharge>(customerData);

            return customerDto;

        }
        /**
         * Trả về thông tin danh sách đĩa và title của đĩa mà khách hàng đang thiếu nợ
         */
        public IEnumerable<Disk_Title> GetDiskAndTitle()
        {
            int customerID = _view.CustomerID;
            var diskTitles = from c in _context.Customers
                             join b in _context.Bills
                             on c.Id equals b.CustomerId
                             join bd in _context.BillDetails
                             on b.Id equals bd.BillID
                             join d in _context.C_Disk
                             on bd.DiskID equals d.Id
                             join t in _context.Titles
                             on d.TitleID equals t.Id
                             where c.Id == customerID  && bd.LateChargeID != null
                             select new Disk_Title
                             {
                                 DiskID=d.Id,
                                 Name = t.Name,

                             };
            return diskTitles;
        }
        /**
         * Lay Info cua 1 Disk
         */
        public IEnumerable<BillDetailInfoLateCharge> ListBillDetailInfoCharge()
        {
            int diskID = _view.DiskID;
            int customerID = _view.CustomerID;
            var infoLateCharge = from c in _context.Customers
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
                                 join t in _context.Titles
                                 on d.TitleID equals t.Id
                                 where c.Id == customerID && d.Id == diskID
                                 select new BillDetailInfoLateCharge
                                 {
                                     DiskName=t.Name,
                                     DueDate=bd.DueDate,
                                     ReturnDate=bd.ReturnDate,
                                     UnitPrice=ct.UnitPrice??0,
                                     ChargePercent=lc.ChargePercent

                                 };

            return infoLateCharge;

        }
        /**
         * 
         * Lay info cua nhieu Disk
         */
        public IEnumerable<BillDetailInfoLateCharge> ListInfoWithListDiskId()
        {
            List<int> listDiskId = _view.ListDiskID;
            int customerID = _view.CustomerID;
            var infoLateCharge = from c in _context.Customers
                                 join b in _context.Bills
                                 on c.Id equals b.CustomerId
                                 join bd in _context.BillDetails
                                 on b.Id equals bd.BillID
                                 join lc in _context.LateCharges
                                 on bd.LateChargeID equals lc.Id
                                 join d in _context.C_Disk
                                 on bd.DiskID equals d.Id
                                 join d2 in listDiskId
                                 on d.Id equals d2
                                 join ct in _context.Categories
                                 on d.CategoryId equals ct.Id
                                 join t in _context.Titles
                                 on d.TitleID equals t.Id
                                 where c.Id == customerID
                                 select new BillDetailInfoLateCharge
                                 {
                                     DiskName = t.Name,
                                     DueDate = bd.DueDate,
                                     ReturnDate = bd.ReturnDate,
                                     UnitPrice = ct.UnitPrice ?? 0,
                                     ChargePercent = lc.ChargePercent

                                 };

            return infoLateCharge;

        }

    }
}
