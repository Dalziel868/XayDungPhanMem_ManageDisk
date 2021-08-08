namespace Presenters.Customers
{
    using AutoMapper;
    using DTO.Customers;
    using DTO.Disks;
    using IViews_Presenters.Customers;
    using Models.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.SqlClient;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="CustomerForRentDiskPresenter" />.
    /// </summary>
    public class CustomerForRentDiskPresenter
    {
        /// <summary>
        /// Defines the _context.
        /// </summary>
        private ManageDisk _context;

        /// <summary>
        /// Defines the _view.
        /// </summary>
        private ICustomerForRentDisk _view;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerForRentDiskPresenter"/> class.
        /// </summary>
        /// <param name="view">The view<see cref="ICustomerForRentDisk"/>.</param>
        public CustomerForRentDiskPresenter(ICustomerForRentDisk view)
        {
            _context = new ManageDisk();
            _view = view;
        }

        /// <summary>
        /// The GetCustomerToRentDisk.
        /// </summary>
        /// <returns>The <see cref="CusTomerForRentDiskDto"/>.</returns>
        public CusTomerForRentDiskDto GetCustomerToRentDisk()
        {

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Customer, CusTomerForRentDiskDto>());
            var mapper = new Mapper(config);

            var cusData = _context.Customers.FirstOrDefault(c => c.Id == _view.CustomerID);

            var customerDto = mapper.Map<CusTomerForRentDiskDto>(cusData);
            return customerDto;
        }

        /// <summary>
        /// The GetDiskToRent.
        /// Lấy đĩa dựa vào mã đĩa ở UI
        /// </summary>
        /// <returns>The <see cref="DiskForRent"/>.</returns>
        public DiskForRent GetDiskToRent()
        {
            if (!string.IsNullOrEmpty(_view.DiskID))
            {
                //int diskId = int.Parse(_view.DiskID);
                //var diskData = (from d in _context.C_Disk
                //                join c in _context.Categories
                //                on d.CategoryId equals c.Id
                //                where d.C_Status.Equals("onshelf") && d.Id == diskId
                //                select new DiskForRent
                //                {
                //                    Id = d.Id,
                //                    Name = d.Name,
                //                    CategoryName = c.Name,
                //                    UnitPrice = c.UnitPrice,
                //                    RentTime = c.RentTime
                //                }).AsNoTracking().FirstOrDefault();
                //return diskData;
                int diskId = int.Parse(_view.DiskID);
                int customerID = _view.CustomerID;

                object[] sqlParams =
                {
                    new SqlParameter("@cusId",customerID),
                    new SqlParameter("@diskId",diskId)
                };



                var result = _context.Database.SqlQuery<DiskForRent>("GetDiskToRent @cusId, @diskId", sqlParams).SingleOrDefault();
                
                if(result==null)
                {
                    return null;
                }
                else
                {
                    return result;
                }


            }
            return null;
            
        }

        /// <summary>
        /// The GetAllIdOfDiskToSelect.
        /// Lấy danh sách mã đĩa onshelf để thực hiện autocomplete ở UI
        /// </summary>
        /// <returns>The <see cref="List{string}"/>.</returns>
        public List<string> GetAllIdOfDiskToSelect()
        {

            var idDisks = (from d in _context.C_Disk
                           where d.C_Status.Equals("onshelf") || d.C_Status.Equals("onhold")
                           select d.Id.ToString()
                            ).AsNoTracking().ToList();

            return idDisks;
        }
        /**
         * Chức năng dùng để tính tổng phí trễ nếu có của khách hàng thuê đĩa
         */
        public decimal GetTotalLateCharge()
        {
            var lateCharge = from c in _context.Customers
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
                             where c.Id == _view.CustomerID && bd.ReturnDate!=null && bd.LateChargeID!=null
                             select new DiskToCheckLateCharge
                             {
                                 ChargePercent=lc.ChargePercent,
                                 UnitPrice=ct.UnitPrice
                             };
            decimal sumOfLateCharge = 0;
            if(lateCharge.Count()>0)
            {
                foreach (var item in lateCharge)
                {
                    sumOfLateCharge += (Convert.ToDecimal(item.ChargePercent) * item.UnitPrice ?? 0);
                }
            }
            return sumOfLateCharge;

        }
        /**
         * Hàm thuê đĩa: thêm hóa đơn, chi tiết hóa đơn,cập nhật trạng thái đĩa từ onshelf to rented
         * 
         * 
         */
        public bool ProcedureToRentDisk()
        {
            
                DateTime date = DateTime.Now;
                int customerID = _view.CustomerID;
                List<int> listIDOfDisk = _view.ListDiskId;
                Bill bill = new Bill();
                bill.CustomerId = customerID;
                bill.CreateDate = date;

                //List<BillDetail> billDetails = new List<BillDetail>();

                foreach (int idDisk in listIDOfDisk)
                {
                    int rentTime = (from d in _context.C_Disk
                                    join ct in _context.Categories
                                    on d.CategoryId equals ct.Id
                                    where d.Id == idDisk
                                    select ct.RentTime).FirstOrDefault() ?? 0;

                    BillDetail billDetail = new BillDetail();
                    billDetail.RowID = Guid.NewGuid();
                    billDetail.DiskID = idDisk;
                    billDetail.DueDate = date.AddDays(rentTime);
                    bill.BillDetails.Add(billDetail);
               
                    C_Disk disk = _context.C_Disk.Find(idDisk);
                    disk.C_Status = "rented";
                    _context.C_Disk.Attach(disk);
                    _context.Entry(disk).Property(d => d.C_Status).IsModified = true;
                    
                }
                _context.Bills.Add(bill);
            
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
        
    }
}
