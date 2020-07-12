using SuperShop.Models.EntityModels;
using SuperShop.Repositories.Abstraction.Base;
using System;
using System.Collections.Generic;
using System.Text;
using SuperShop.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;
using SuperShop.Database;
using System.Linq;
using SuperShop.Models.RequestModel;

namespace SuperShop.Repositories
{
    public class EmployeeRepositories : Repository<Employee>, IEmployeeRepositories
    {
        SuperShopDbContext _db;
        public EmployeeRepositories(DbContext db):base(db)
        {
            _db = (SuperShopDbContext)db;
        }

        public override ICollection<Employee> GetAll()
        {
            return _db.Employees
                .Include(c => c.Department)
                .Where(c => c.isDelete == false).ToList();
        }
        public Employee GetbyId(int? id)
        {
            if(id!= null)
            {
                return GetFirstorDefault(emp => emp.Id == id);
            }
            return null;
        }

        public ICollection<Employee> GetByRequest(EmployeeRequestModel employee)
        {
            var result = _db.Employees.AsQueryable();
            
            if (employee != null)
            {
                return result.ToList();
            }

            if(employee.Id > 0)
            {
                result = result.Where(c => c.Id == employee.Id);
            }

            if (!string.IsNullOrEmpty(employee.Name))
            {
                result = result.Where(c => c.Name.ToLower().Contains(employee.Name.ToLower()));
            }

            if (!string.IsNullOrEmpty(employee.Name))
            {
                result = result.Where(c => c.Email.ToLower().Contains(employee.Email.ToLower()));
            }

            if (!string.IsNullOrEmpty(employee.Designation))
            {
                result = result.Where(c => c.Designation.ToLower().Contains(employee.Designation.ToLower()));
            }

            return result.ToList();
        }
    }
}
