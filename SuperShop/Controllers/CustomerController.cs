using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IHostingEnvironment hostingEnvironment;
        IMapper _mapper;
        public CustomerController(ICustomerManager customerManager, IMapper mapper, IHostingEnvironment hostingEnvironment)
        {
            _customerManager = customerManager;
            _mapper = mapper;
            this.hostingEnvironment = hostingEnvironment;
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
            if (ModelState.IsValid)
            {
                string uniqueFilename = ProcessUploadFile(model);
                Customer customer = new Customer
                {
                    Name = model.Name,
                    Email = model.Email,
                    Phone = model.Phone,
                    Address = model.Address,
                    PhotoPath = uniqueFilename
                };

                bool isAdd = _customerManager.Add(customer);
                if (isAdd)
                {
                    return RedirectToAction("Details", new { id = customer.Id});
                }
                else
                {
                    return View();
                }
            }
            return View();
        }

        //Customer/Details
        public IActionResult Details(int? id)
        {
            Customer customer = _customerManager.GetById(id.Value);
            if (customer == null)
            {
                Response.StatusCode = 404;
                return View("CustomerNotFound", id.Value);
            }

            if (id != null)
            {
                return View(customer);
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
        public IActionResult GetbyRequest([FromQuery]CustomerRequestModel customer)
        {
            var customerEntity =  _customerManager.GetbyRequest(customer);
            if(customerEntity == null)
            {
                return View("Customer Not Found");
            }
            return View(customerEntity);
        }

        //Customer/Edit/id
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id!=null && id > 0)
            {
                Customer extingCustomer = _customerManager.GetById(id);
                if (extingCustomer != null)
                {
                    CustomerEditViewModel editViewModel = new CustomerEditViewModel
                    {
                        Id = extingCustomer.Id,
                        Name = extingCustomer.Name,
                        Email = extingCustomer.Email,
                        Phone = extingCustomer.Phone,
                        Address = extingCustomer.Address,
                        ExistingPhoto = extingCustomer.PhotoPath
                    };
                    return View(editViewModel);
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(CustomerEditViewModel model)
        {
            Customer customer = _customerManager.GetById(model.Id);
            customer.Id = model.Id;
            customer.Name = model.Name;
            customer.Email = model.Email;
            customer.Phone = model.Phone;
            customer.Address = model.Address;
            if (model.Photo != null)
            {
                if(model.ExistingPhoto != null)
                {
                    string filePath = Path.Combine(hostingEnvironment.WebRootPath, "img", model.ExistingPhoto);
                    System.IO.File.Delete(filePath);
                }
                customer.PhotoPath = ProcessUploadFile(model);
            }
            bool isUpdate = _customerManager.Update(customer);
            if (isUpdate)
            {
                return RedirectToAction("List");
            }
            return View();
        }

        private string ProcessUploadFile(CustomerCreateViewModel model)
        {
            string uniqueFilename = null;
            if (model.Photo != null)
            {
                string uploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "img");
                uniqueFilename = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadFolder, uniqueFilename);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }
            return uniqueFilename;
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
