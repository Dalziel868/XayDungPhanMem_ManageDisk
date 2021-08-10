using DTO.Customers;
using IViews_Presenters.frmCancelReservation;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DTO.Titles;
using System.Data.Entity.Infrastructure;

namespace Presenters.frmCancelReservation
{
    public class CancelReservationPresenter
    {
        private readonly ManageDisk _context;
        private readonly ICancelReservation _view;
        public CancelReservationPresenter(ICancelReservation view)
        {
            _context = new ManageDisk();
            _view = view;
        }

        public CustomerToCancelReservation GetCustomer()
        {
            int customerId = _view.CustomerID;
            if (customerId == -1)
                return null;
            var customerData = _context.Customers.Find(customerId);
            if(customerData!=null)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Customer, CustomerToCancelReservation>());
                var mapper = new Mapper(config);

                CustomerToCancelReservation dto = mapper.Map<CustomerToCancelReservation>(customerData);
                return dto;
            }
            return null;
            
        }
        /**
         * xóa data trong bảng MessageOnhold
         */
        public bool CancelReservation()
        {
            int customerId = _view.CustomerID;
            int titleId = _view.TitleID;
            if (customerId == -1 || titleId == -1)
                return false;
            var messageOnhold = _context.MessageOnHolds.FirstOrDefault(m => m.CustomerID == customerId && m.TitleID == titleId);
            _context.MessageOnHolds.Remove(messageOnhold);
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

        public IEnumerable<TitleToReserveDto> GetListTitleReserved()
        {
            int customerId = _view.CustomerID;
            if (customerId == -1)
                return new List<TitleToReserveDto>();
            var listTitle = from m in _context.MessageOnHolds
                            join t in _context.Titles
                            on m.TitleID equals t.Id
                            where m.CustomerID == customerId
                            select new TitleToReserveDto
                            {
                                Id=t.Id,
                                Name=t.Name
                            };
            return listTitle;

        }
    }
}
