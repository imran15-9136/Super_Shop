using SuperShop.Models.EntityModels;
using SuperShop.Repositories.Abstraction.Base;
using System;
using System.Collections.Generic;
using System.Text;
using SuperShop.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;
using SuperShop.Database;
using System.Linq;

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
    }
}
