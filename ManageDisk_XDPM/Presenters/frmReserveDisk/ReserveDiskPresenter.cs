using DTO.Titles;
using IViews_Presenters.frmReserveDisk;
using Models.Models;
using System;
using System.Collections.Generic;
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
            List<int> listIdOfDisk = _view.ListTitleID;
            int titleId = _view.CustomerID;
            return true;
        }
    }
}
