using SuperShop.BLL.Abstraction.Base;
using SuperShop.Models;
using SuperShop.Models.RequestModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperShop.BLL.Abstraction
{
    public interface ICustomerManager:IManager<Customer>
    {
        Customer GetById(int? id);
        ICollection<Customer> GetbyRequest(CustomerRequestModel customer);
    }
}
