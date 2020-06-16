using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SuperShop.BLL.Abstraction;
using SuperShop.Database;
using SuperShop.Models;
using SuperShop.Models.RequestModel;
using SuperShop.Models.ResponseModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SuperShop.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerManager _customerManager;
        IMapper _mapper;
        public CustomerController(ICustomerManager customerManager, IMapper mapper)
        {
            _customerManager = customerManager;
            _mapper = mapper;
        }
        // GET: /<controller>/

        
        public IActionResult Index()
        {
            return View();
        }

        //Customer/Create
        public IActionResult Create()
        {
            CustomerCreateViewModel customer = new CustomerCreateViewModel();
            //customer.CustomerList = _customerManager
            //                        .GetAll()
            //                        .Select(c => _mapper.Map<CustomerResponseModel>(c)).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerCreateViewModel model)
        {
            Customer customer = _mapper.Map<Customer>(model);
            if(ModelState.IsValid)
            {
                bool isSave=_customerManager.Add(customer);
                if (isSave)
                {
                    return RedirectToAction("List","Customer",null);
                }
            }
            return View();
        }

        //Customer/List
        public IActionResult List()
        {

            ICollection<Customer> customer = _customerManager.GetAll();
            return View(customer);
        }

        //Customer/List/[Filturing]
        //public IActionResult GetbyRequest([FromQuery]CustomerRequestModel customer)
        //{
        //    return _customerManager.GetbyRequest(customer);
        //}S

        //Customer/Edit/id
        public IActionResult Edit(int? id)
        {
            if (id!=null && id > 0)
            {
                Customer extingCustomer = _customerManager.GetById(id);
                if (extingCustomer != null)
                {
                    return View(extingCustomer);
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            bool isSave = _customerManager.Update(customer);
                if (isSave)
                {
                    return RedirectToAction("List");
                }
            return View(customer);
         }

        //Customer/Delete/id
        public IActionResult Delete(int? id)
        {
            if (id != null && id > 0)
            {
                Customer customer = _customerManager.GetById(id);
                bool isSave = _customerManager.Remove(customer);
                if (isSave)
                {
                    return RedirectToAction("List");
                }
            }
            return RedirectToAction("List");
        }
    }
}
