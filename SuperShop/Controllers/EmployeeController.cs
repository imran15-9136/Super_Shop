using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SuperShop.BLL.Abstraction;
using SuperShop.Models;
using SuperShop.Models.EntityModels;

namespace SuperShop.Controllers
{
    public class EmployeeController : Controller
    {
        public IEmployeeManager _employeeManagerl;
        public IDepartmentManager _departmentManager;
        IMapper _maper;
        public EmployeeController(IEmployeeManager employeeManager, IMapper mapper, IDepartmentManager departmentManager)
        {
            _employeeManagerl = employeeManager;
            _maper = mapper;
            _departmentManager = departmentManager;
        }
        public IActionResult Create()
        {
            EmployeeCreateViewModel employee = new EmployeeCreateViewModel();
            employee.DepartmentItems = _departmentManager.GetAll()
                                                        .Select(Department => new SelectListItem()
                                                        {
                                                            Text = Department.Name,
                                                            Value = Department.Id.ToString()
                                                        }).ToList();
            return View(employee);
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeCreateViewModel model, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                Employee employee = _maper.Map<Employee>(model);
                if (Image.Length > 0)
                    {
                        using (MemoryStream stream = new MemoryStream())
                        {
                            await Image.CopyToAsync(stream);
                            employee.Image = stream.ToArray();
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

        public IActionResult Details(int? id)
        {
            if (id != null)
            {
                Employee employee = _employeeManagerl.GetById(id);
                return View(employee);
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