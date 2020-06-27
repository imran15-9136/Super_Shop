using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperShop.BLL.Abstraction;
using SuperShop.Models;
using SuperShop.Models.RequestModel;

namespace SuperShop.API.Controllers
{
    [Route("api/[controller]")]
    //[Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerManager _customerManager;
        IMapper _mapper;

        public CustomerController(ICustomerManager customer, IMapper mapper)
        {
            _customerManager = customer;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCustomers([FromQuery]CustomerRequestModel customer)
        {
            var result = _customerManager.GetbyRequest(customer);
            if (result == null)
            {
                return BadRequest("Customer Not Found");
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

        [HttpPost]
        public IActionResult AddCustomer([FromBody]CustomerCreateDTO customer)
        {
            if (ModelState.IsValid)
            {
                var customerEntity = _mapper.Map<Customer>(customer);

                bool isSaved = _customerManager.Add(customerEntity);

                if (isSaved)
                {
                    customer.Id = customerEntity.Id;

                    return Ok(customer);
                }
                else
                {
                    return BadRequest("Customer is Invalid");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
            
        }
    }
}