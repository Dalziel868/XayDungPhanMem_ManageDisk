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
using System.Data.Entity.Infrastructure;
using IViews_Presenters.frmInsertDisk;
using DTO.Disks;

namespace Presenters.frmInsertDisk
{
    public class InsertDiskPresenter
    {
        private readonly IInsertDisk _view;
        private readonly ManageDisk _context;
        public InsertDiskPresenter(IInsertDisk view)
        {
            _view = view;
            _context = new ManageDisk();
        }

        //Lấy danh sách tiêu đề theo loại
        public List<string> getTitleByCategory(string cate)
        {
            int cateID;
            if (cate == "Game")
                cateID = 1;
            else cateID = 2;
            var listTitle = from a in _context.Titles
                            join b in _context.C_Disk
                            on a.Id equals b.TitleID
                            where b.CategoryId == cateID
                            select a.Name;
            List<string> list = new List<string>();
            foreach (var item in listTitle)
                list.Add(item);
            return list;

        }
        //insert đĩa mới
        public int InsertNewDisk(string cate, string title)
        {
            Category c = _context.Categories.Where(x => x.Name == cate).FirstOrDefault();
            Title t = _context.Titles.Where(x => x.Name == title).FirstOrDefault();

            C_Disk d = new C_Disk();
            d.TitleID = t.Id;
            d.CategoryId = c.Id;
            d.C_Status = "onshelf";
            _context.C_Disk.Add(d);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            var ds = from a in _context.C_Disk
                     orderby a.Id descending
                     select a;
            return ds.First().Id;
        }

        //Lấy danh sách đĩa
        public IEnumerable<ListDisk> getAllDisk()
        {
            var listDisk = from a in _context.C_Disk
                           join b in _context.Titles
                           on a.TitleID equals b.Id
                           join c in _context.Categories
                           on a.CategoryId equals c.Id
                           where a.C_Status != "deleted"
                           select new ListDisk{
                               DiskID = a.Id,
                               TieuDe = b.Name,
                               TheLoai = c.Name,
                               TrangThai = a.C_Status
                            };
            return listDisk;
        }

        //Xóa đĩa
        public int RemoveDisk(string madia)
        {
            int id = Int32.Parse(madia);
            C_Disk c = _context.C_Disk.Where(x => x.Id == id && x.C_Status == "onshelf").FirstOrDefault();
            if (c == null)
                return 0;
            else
            {
                c.C_Status = "deleted";
                _context.SaveChanges();
                return 1;
            }    
        }
    }
}
