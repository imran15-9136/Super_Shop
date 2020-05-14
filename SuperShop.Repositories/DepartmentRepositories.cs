using Microsoft.EntityFrameworkCore;
using SuperShop.Database;
using SuperShop.Models.EntityModels;
using SuperShop.Repositories.Abstraction;
using SuperShop.Repositories.Abstraction.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperShop.Repositories
{
    public class DepartmentRepositories : Repository<Department>, IDepartmentRepositories
    {

        SuperShopDbContext _superShopDbContext;
        public DepartmentRepositories(DbContext db):base(db)
        {
            _superShopDbContext = (SuperShopDbContext)db;
        }

        public Department GetById(int? id)
        {
            if (id != null)
            {
                return GetFirstorDefault(dept => dept.Id == id);
            }
            return null;
        }



    }
}
