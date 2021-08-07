namespace Presenters
{
    using AutoMapper;
    using DTO.Customers;
    using IViews_Presenters;
    using IViews_Presenters.Customers;
    using Models.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="CustomerForCreatePresenter" />.
    /// </summary>
    public class CustomerForCreatePresenter
    {


        /// <summary>
        /// Defines the _manageDb.
        /// </summary>
        private ManageDisk _context;

        /// <summary>
        /// Defines the _addCustomer.
        /// </summary>
        private IAddCustomer _view;
        

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerForCreatePresenter"/> class.
        /// </summary>
        /// <param name="addCustomer">The addCustomer<see cref="IAddCustomer"/>.</param>
        public CustomerForCreatePresenter(IAddCustomer addCustomer)
        {
            _context = new ManageDisk();
            _view = addCustomer;

        }



        /// <summary>
        /// The addCustomer.
        /// </summary>
        /// _addCustomer
        /// <returns>The <see cref="bool"/>.</returns>
        public int addCustomer()
        {
            if (_view.CustomerDto==null|| string.IsNullOrEmpty(_view.CustomerDto.Phone) || string.IsNullOrEmpty(_view.CustomerDto.FullName))
                return 0;

            try
            {

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CustomerForCreateDto, Customer>();
                });
                var mapper = new Mapper(config);
                
                

                var customerData = mapper.Map<Customer>(_view.CustomerDto);
                Customer cus= _context.Customers.Add(customerData);
                _context.SaveChanges();
                return cus.Id;
            }
            catch (Exception)
            {

                return 0;
            }
        }

      
       
    }
}
