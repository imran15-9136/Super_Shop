using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperShop.BLL.Abstraction;
using SuperShop.Models;
using SuperShop.Models.RequestModel;

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
        public ICollection<Customer> GetCustomers(CustomerRequestModel customer)
        {
            return _customerManager.GetbyRequest(customer);
        }

        //api/customer/id
        [HttpGet("{id}")]
        public IActionResult GetCustomers(int id)
        {
            if (id == null)
            {
                return BadRequest("Id Not Found");
            }
            var customer = _customerManager.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }
    }
}