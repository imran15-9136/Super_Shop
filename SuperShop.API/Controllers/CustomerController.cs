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
        [HttpGet("{id}", Name = "GetbyId")]
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

                    return CreatedAtRoute("GetbyId", new { id = customer.Id}, customer);
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

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody] CustomerUpdateDTO customerDTO)
        {
            try
            {
                var existingCustomer = _customerManager.GetById(id);
                if (existingCustomer == null)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Customer Not Found");
                }

                var customer = _mapper.Map(customerDTO, existingCustomer);
                bool isUpdate = _customerManager.Update(customer);

                if (isUpdate)
                {
                    return Ok(customer);
                }
                else
                {
                    return BadRequest("Update Failed");
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}