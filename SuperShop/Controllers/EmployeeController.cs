using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperShop.BLL.Abstraction;
using SuperShop.Models;
using SuperShop.Models.EntityModels;

namespace SuperShop.Controllers
{
    public class EmployeeController : Controller
    {
        public IEmployeeManager _employeeManagerl;
        IMapper _maper;
        public EmployeeController(IEmployeeManager employeeManager, IMapper mapper)
        {
            _employeeManagerl = employeeManager;
            _maper = mapper;
        }
        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeCreateViewModel model, List<IFormFile> Image)
        {
            Employee employee = _maper.Map<Employee>(model);

            if (ModelState.IsValid)
            {
                foreach (var item in Image)
                {
                    if (item.Length > 0)
                    {
                        using (MemoryStream stream = new MemoryStream())
                        {
                            await item.CopyToAsync(stream);
                            employee.Image = stream.ToArray();
                        }
                    }
                }
                bool isvalid = _employeeManagerl.Add(employee);
                return RedirectToAction("List");
            }
            return View();
        }

        public IActionResult List()
        {
            ICollection<Employee> employees= _employeeManagerl.GetAll();
            return View(employees);
        }

        public IActionResult Edit(int? id)
        {
            if(id!=null && id > 0)
            {
                Employee existingemployee = _employeeManagerl.GetById(id);
                if (existingemployee != null)
                {
                    return View(existingemployee);
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            bool isSave = _employeeManagerl.Update(employee);
            if (isSave)
            {
                return RedirectToAction("List");
            }
            return View(employee);
        }

        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                Employee employee = _employeeManagerl.GetById(id);
                bool isValid = _employeeManagerl.Remove(employee);
                if (isValid)
                {
                    RedirectToAction("List");
                }
            }
            return RedirectToAction("List");
        }
    }
}