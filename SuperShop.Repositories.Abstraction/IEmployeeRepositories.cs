using SuperShop.Models.EntityModels;
using SuperShop.Models.RequestModel;
using SuperShop.Repositories.Abstraction.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperShop.Repositories.Abstraction
{
    public interface IEmployeeRepositories:IRepository<Employee>
    {
        Employee GetbyId(int? id);
        ICollection<Employee> GetByRequest(EmployeeRequestModel employee);
    }
}
