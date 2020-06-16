using SuperShop.Models;
using SuperShop.Models.RequestModel;
using SuperShop.Repositories.Abstraction.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperShop.Repositories.Abstraction
{
    public interface ICustomerRepositories:IRepository<Customer>
    {
        Customer GetById(int?id);
        ICollection<Customer> GetbyRequest(CustomerRequestModel customer);
    }
}
