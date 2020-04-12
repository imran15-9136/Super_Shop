using SuperShop.BLL.Abstraction.Base;
using SuperShop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperShop.BLL.Abstraction
{
    public interface ICustomerManager:IManager<Customer>
    {
        Customer GetById(int? id);
    }
}
