using SuperShop.BLL.Abstraction;
using SuperShop.BLL.Abstraction.Base;
using SuperShop.Models.EntityModels;
using SuperShop.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperShop.BLL
{
    public class DepartmentManager : Manager<Department>, IDepartmentManager
    {
        IDepartmentRepositories _departmentRepositories;
        public DepartmentManager(IDepartmentRepositories departmentRepositories):base(departmentRepositories)
        {
            _departmentRepositories = departmentRepositories;
        }
        public Department GetById(int? id)
        {
            if (id != null)
            {
                return _departmentRepositories.GetById(id);
            }
            return null;
        }
    }
}
