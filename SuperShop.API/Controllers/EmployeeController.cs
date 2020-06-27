using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperShop.BLL.Abstraction;
using SuperShop.Models.EntityModels;
using SuperShop.Models.RequestModel;

namespace SuperShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeManager _employeeManager;
        IMapper _mapper;
        public EmployeeController(IEmployeeManager employeeManager, IMapper mapper)
        {
            _employeeManager = employeeManager;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetEmployee([FromQuery] EmployeeRequestModel employee)
        {
            var employeeEntity = _employeeManager.GetByRequest(employee);
            if (employee == null)
            {
                return BadRequest("Employee Not Found");
            }
            return Ok(employee);
        }

        [HttpGet("id")]
        public IActionResult GeteEmployee(int id)
        {
            if (id == null)
            {
                return BadRequest("Employee Not Found");
            }
            var employee = _employeeManager.GetById(id);
            if(employee == null)
            {
                return BadRequest("Employee Not Found");
            }
            return Ok(employee);
        }

         [HttpPost]
        public IActionResult AddEmployee([FromBody]EmployeeCreateDTO employee)
        {
            if (ModelState.IsValid)
            {
                var employeeEntity = _mapper.Map<Employee>(employee);
                bool isSaved = _employeeManager.Add(employeeEntity);
                
                if (isSaved)
                {
                    employeeEntity.Id = employee.Id;
                    return Ok(employeeEntity);
                }
                else
                {
                    return BadRequest("customer is invalid");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}