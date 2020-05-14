using SuperShop.BLL.Abstraction.Base;
using SuperShop.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperShop.BLL.Abstraction
{
    public interface IEmployeeManager:IManager<Employee>
    {
        Employee GetById(int?id);
    }
}
