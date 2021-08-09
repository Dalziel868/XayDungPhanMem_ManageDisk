using DTO.Titles;
using IViews_Presenters.frmReserveDisk;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenters.frmReserveDisk
{
    public class ReserveDiskPresenter
    {
        private ManageDisk _context;
        private readonly IReserveDisk _view;
        public ReserveDiskPresenter(IReserveDisk view)
        {
            _context = new ManageDisk();
            _view = view;
        }
        public IEnumerable<TitleToReserveDto> SearchForTitles()
        {
            string titleName = _view.TitleName;
            var listTitleName = from t in _context.Titles
                                where t.Name.Contains(titleName)
                                select new TitleToReserveDto
                                {
                                    Id=t.Id,
                                    Name=t.Name
                                };
            return listTitleName;
        }
        public bool ReserveDisks()
        {
            if (_view.ListTitleID.Count == 0 || _view.CustomerID == 0)
                return false;
            List<int> listIdOfDisk = _view.ListTitleID; 
            int cusId = _view.CustomerID;
            foreach (var item in listIdOfDisk)
            {
                _context.MessageOnHolds.Add(new MessageOnHold() { TitleID = item, CustomerID = cusId, BookTime = DateTime.Now });
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
