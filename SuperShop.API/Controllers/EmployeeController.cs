using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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
                return NotFound("Employee Not Found");
            }
            var employee = _employeeManager.GetById(id);
            if (employee == null)
            {
                return NotFound("Employee Not Found");
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

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody]EmployeeUpdateDTO employeeUpdate)
        {
            try
            {
                var existingEmployee = _employeeManager.GetById(id);
                if (existingEmployee == null)
                {
                    return NotFound();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var employee = _mapper.Map(employeeUpdate, existingEmployee);
                bool isUpdate = _employeeManager.Update(employee);
                if (isUpdate)
                {
                    return Ok(employee);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPatch("{id}")]
        public IActionResult PatchEmployee(int id, [FromBody] JsonPatchDocument<EmployeeUpdateDTO> employeeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var existingEmployee = _employeeManager.GetById(id);
            if(existingEmployee == null)
            {
                return NotFound();
            }

            var employee = _mapper.Map<EmployeeUpdateDTO>(existingEmployee);
            employeeDTO.ApplyTo(employee);

            _mapper.Map(employee, existingEmployee);

            bool isUpdate = _employeeManager.Update(existingEmployee);
            if (isUpdate)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee([FromQuery] int id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var employee = _employeeManager.GetById(id);
                bool isDelete = _employeeManager.Remove(employee);
                if (isDelete)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}