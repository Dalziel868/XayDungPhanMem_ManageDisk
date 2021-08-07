using DTO.Charges;
using DTO.Customers;
using IViews_Presenters.Disks;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenters.Disk
{
    public class DiskReturnPresenter
    {
        private ManageDisk _context;
        private readonly IReturnDisk _view;
        private Guid _rowIDBillDetail=Guid.Empty;
        private MessageOnHold _onHoldData;
        public DiskReturnPresenter(IReturnDisk view)
        {
            _context = new ManageDisk();
            _view = view;
        }
        /// <summary>
        /// đã sửa
        /// </summary>
        /// <returns></returns>
        /// 
        public bool OnHoldToDisk()
        {
            int idDisk = _view.DiskId;
            var onHold = from m in _context.MessageOnHolds
                         join t in _context.Titles
                         on m.TitleID equals t.Id
                         where t.C_Disk.Any(tc => tc.Id == idDisk)
                         select m;
            if (onHold.Count() == 0)
                return false;


                C_Disk disk = _context.C_Disk.Find(idDisk);
                disk.C_Status = "onhold";
                _context.C_Disk.Attach(disk);
                _context.Entry(disk).Property(d => d.C_Status).IsModified = true;
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
        public String GetTitleName()
        {
            int titleId = _onHoldData.TitleID;
            var titleName = (from t in _context.Titles
                             where t.Id == titleId
                             select t.Name).FirstOrDefault().ToString();
            return titleName;
        }
        public void removeOnholdToCustomer()
        {
            _context.MessageOnHolds.Remove(_onHoldData);
            _context.SaveChanges();
        }
        /**
         * Phải gọi trước hàm GetTitleName() và removeOnholdToCustomer()
         */
        public CusTomerForRentDiskDto GetCustomerReserve()
        {
            int idDisk = _view.DiskId;
            var onHold = from m in _context.MessageOnHolds
                         join t in _context.Titles
                         on m.TitleID equals t.Id
                         where t.C_Disk.Any(tc => tc.Id == idDisk)
                         orderby m.BookTime ascending
                         select m;
            if (onHold.Count() == 0)
            {
                C_Disk diskData = _context.C_Disk.Find(idDisk);
                diskData.C_Status = "onshelf";
                _context.C_Disk.Attach(diskData);
                _context.Entry(diskData).Property(d => d.C_Status).IsModified = true;
                _context.SaveChanges();
                return null;
            }
                
            MessageOnHold mFirst = onHold.First();
            _onHoldData = mFirst;
            var customerData = _context.Customers.Find(mFirst.CustomerID);
            if(customerData!=null)
            {
                var config = new AutoMapper.MapperConfiguration(cfg =>
                  {
                      cfg.CreateMap<Customer, CusTomerForRentDiskDto>();
                  });
                var mapper = new AutoMapper.Mapper(config);

                CusTomerForRentDiskDto customerDto = mapper.Map<CusTomerForRentDiskDto>(customerData);
                return customerDto;

            }
            return null;
        }

        public int GetIdOfCustomer()
        {
            if(this._rowIDBillDetail!=Guid.Empty)
            {
                var idCustomer = (from bd in _context.BillDetails
                                  join b in _context.Bills
                                  on bd.BillID equals b.Id
                                  join c in _context.Customers
                                  on b.CustomerId equals c.Id
                                  where bd.RowID == this._rowIDBillDetail
                                  select c.Id).FirstOrDefault();
                return idCustomer;
            }
            else
                return -1;
            
            
        }
        /**
         * Auto theem phis neu tre han
         * 
         */
        private decimal AutoAddLateCharge(Guid rowID)
        {
            this._rowIDBillDetail = rowID;
            var inforCharge = (from bd in _context.BillDetails
                              join lc in _context.LateCharges
                              on bd.LateChargeID equals lc.Id
                              join d in _context.C_Disk
                              on bd.DiskID equals d.Id
                              join ct in _context.Categories
                              on d.CategoryId equals ct.Id
                              where bd.RowID == rowID && bd.LateChargeID!=null
                              select new InforToCaculateLateCharge
                              {
                                  ChargePercent = lc.ChargePercent,
                                  UnitPrice = ct.UnitPrice,
                                  LateChargeID=bd.LateChargeID
                              }).FirstOrDefault();
            
            if(inforCharge!=null)
            {
                decimal chargePercent = Convert.ToDecimal(inforCharge.ChargePercent);
                decimal unitPrice = inforCharge.UnitPrice ?? 0;

                decimal lateCharge = chargePercent * unitPrice;
                return lateCharge;
            }
            else
            {
                return 0;
            }
            
        }
        /*Trigger cap nhat LateChargeID neu ReturnDate>DueDate (trong sql)
         * ham cap nhat ReturnDate va goi ham Add latecharge neu ReTurnDate>DueDate
         */
        public decimal ReturnDisk()
        {
            int idDisk = _view.DiskId;
            if (idDisk == -1)
                return -1;
            BillDetail billDetail = (from d in _context.C_Disk
                                     join bd in _context.BillDetails
                                     on d.Id equals bd.DiskID
                                     where d.Id==idDisk && bd.ReturnDate == null && d.C_Status.Equals("rented")
                                     select bd).FirstOrDefault();
            if (billDetail == null)
                return -1;
            billDetail.ReturnDate = DateTime.Now;
            _context.BillDetails.Attach(billDetail);
            _context.Entry(billDetail).Property(bd => bd.ReturnDate).IsModified = true;
            //set onshelf

            C_Disk disk = _context.C_Disk.Find(idDisk);
            if (disk == null)
                return -1;
            disk.C_Status = "onshelf";
            _context.C_Disk.Attach(disk);
            _context.Entry(disk).Property(d => d.C_Status).IsModified = true;
            //
            try
            {
                _context.SaveChanges();
                return AutoAddLateCharge(billDetail.RowID);
            }
            catch (Exception)
            {

                return -1;
            }
        }

    }
}
