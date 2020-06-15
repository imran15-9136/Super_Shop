using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperShop.BLL.Abstraction;
using SuperShop.Models;

namespace SuperShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerManager _customerManager;

        public CustomerController(ICustomerManager customer)
        {
            _customerManager = customer;
        }
            
        [HttpGet]
        public ICollection<Customer> GetCustomers()
        {
            return _customerManager.GetAll();
        }
    }
}