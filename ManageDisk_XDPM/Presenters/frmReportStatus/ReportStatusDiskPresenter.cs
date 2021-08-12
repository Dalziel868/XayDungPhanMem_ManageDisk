using DTO.Disks;
using IViews_Presenters.frmReportStatus;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenters.frmReportStatus
{
    public class ReportStatusDiskPresenter
    {
        private readonly ManageDisk _context;
        private readonly IReportStatus _view;
        public ReportStatusDiskPresenter(IReportStatus view)
        {
            _context = new ManageDisk();
            _view = view;
        }
        private DISK_STATUS checkStatusOfDisk(int diskId)
        {
            
            C_Disk disk = _context.C_Disk.Find(diskId);
            if(disk!=null)
            {
                if (disk.C_Status.Equals("onshelf"))
                    return DISK_STATUS.Onshelf;
                else if (disk.C_Status.Equals("rented"))
                    return DISK_STATUS.Rented;
                else if (disk.C_Status.Equals("onhold"))
                    return DISK_STATUS.Onhold;
            }
            return DISK_STATUS.Deleted;
        }
        public DiskDto GetInfoOfDisk()
        {
            int diskId = _view.DiskID;
            if (diskId == -1)
                return null;
            DISK_STATUS status = checkStatusOfDisk(diskId);
            if (status == DISK_STATUS.Onshelf)
            {
                var diskData = (from d in _context.C_Disk
                                join t in _context.Titles
                                on d.TitleID equals t.Id
                                where d.Id == diskId && d.C_Status.Equals("onshelf")
                                select new DiskOnshelfDto
                                {
                                    Name = t.Name,
                                    C_Status = d.C_Status
                                }).FirstOrDefault();
                return diskData;
            }
            else if (status == DISK_STATUS.Rented)
            {
                var diskData = (from d in _context.C_Disk
                                join t in _context.Titles
                                on d.TitleID equals t.Id
                                join bd in _context.BillDetails
                                on d.Id equals bd.DiskID
                                join b in _context.Bills
                                on bd.BillID equals b.Id
                                join c in _context.Customers
                                on b.CustomerId equals c.Id
                                where d.Id == diskId && bd.ReturnDate == null && d.C_Status.Equals("rented")
                                select new DiskRentedDto
                                {
                                    Name = t.Name,
                                    C_Status = d.C_Status,
                                    Id = c.Id,
                                    FullName = c.FullName,
                                    Phone = c.Phone,
                                    DueDate = bd.DueDate

                                }).FirstOrDefault();
                return diskData;
            }
            else if (status == DISK_STATUS.Onhold)
            {
                var diskData = (from d in _context.C_Disk
                                join t in _context.Titles
                                on d.TitleID equals t.Id
                                join ms in _context.MessageOnHolds
                                on t.Id equals ms.TitleID
                                join c in _context.Customers
                                on ms.CustomerID equals c.Id
                                where d.Id == diskId && d.C_Status.Equals("onhold")
                                orderby ms.BookTime ascending
                                select new DiskOnHoldDto
                                {
                                    Name = t.Name,
                                    C_Status = d.C_Status,
                                    Id = c.Id,
                                    FullName = c.FullName,
                                    Phone = c.Phone,


                                }).FirstOrDefault();
                return diskData;
            }
            else
                return null;
        }


    }
    public enum DISK_STATUS
    {
        Onshelf,
        Rented,
        Onhold,
        Deleted
    }
}
