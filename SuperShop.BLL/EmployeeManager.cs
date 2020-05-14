using SuperShop.BLL.Abstraction;
using SuperShop.BLL.Abstraction.Base;
using SuperShop.Models.EntityModels;
using SuperShop.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperShop.BLL
{
    public class EmployeeManager:Manager<Employee>, IEmployeeManager
    {
        IEmployeeRepositories _employeeRepository;
        public EmployeeManager(IEmployeeRepositories employee):base(employee)
        {
            _employeeRepository = employee;
        }

        public Employee GetById(int? id)
        {
            if (id != null)
            {
                return _employeeRepository.GetbyId(id);
            }
            return null;
        }
    }
}
