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
        public IActionResult GetCustomers([FromQuery]CustomerRequestModel customer)
        {
            var result = _customerManager.GetbyRequest(customer);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
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