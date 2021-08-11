using AutoMapper;
using DTO.Customers;
using IViews_Presenters;
using IViews_Presenters.Customers;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Presenters.frmUpdateCustomer
{
    public class CustomerForUpdatePresenter
    {

        /// <summary>
        /// Defines the _manageDb.
        /// </summary>
        private readonly ManageDisk _context;

      
        private readonly IUpdateCustomer _view;


       
        public CustomerForUpdatePresenter(IUpdateCustomer view )
        {
            _context = new ManageDisk();
            _view = view;

        }
  

        public IEnumerable<CustomerForUpdateDTO> GetListCustomer()
        {
            var listCustomer = from m in _context.Customers
                               select new CustomerForUpdateDTO
                               {
                                   Id = m.Id,
                                   FullName = m.FullName,
                                   Phone = m.Phone,
                                   HouseNumber_StreetName = m.HouseNumber_StreetName,
                                   Ward = m.Ward,
                                   District = m.District,
                                   City = m.City
                            };
            List<CustomerForUpdateDTO> listCutomers = new List<CustomerForUpdateDTO>();
            return listCustomer;

        }


        /// <summary>
        /// The addCustomer.
        /// </summary>
        /// _addCustomer
        /// <returns>The <see cref="bool"/>.</returns>
        public int updateCustomer()
        {
            if (_view.CustomerDto == null || string.IsNullOrEmpty(_view.CustomerDto.Phone) || string.IsNullOrEmpty(_view.CustomerDto.FullName))
                return 0;

            try
            {

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CustomerForUpdateDTO, Customer>();
                });
                var mapper = new Mapper(config);



                var customerData = mapper.Map<Customer>(_view.CustomerDto);
                Customer cus = _context.Customers.Find(_view.CustomerDto.Id);
                cus.FullName = customerData.FullName;
                cus.Phone = customerData.Phone;
                cus.HouseNumber_StreetName = customerData.HouseNumber_StreetName;
                cus.Ward = customerData.Ward;
                cus.District = customerData.District;
                cus.City = customerData.City;
                
                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public int deleteCustomer()
        {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CustomerForUpdateDTO, Customer>();
                });
                var mapper = new Mapper(config);



                var customerData = mapper.Map<Customer>(_view.CustomerDto);
               

      

            var cus = _context.Customers.FirstOrDefault(m => m.Id == _view.CustomerDto.Id);
            _context.Customers.Remove(cus);
            try
            {
                _context.SaveChanges();
                return 1;
            }
            catch (DbUpdateException)
            {

                return 2;
            }


        }

    }
   
}
