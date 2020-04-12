using SuperShop.BLL.Abstraction;
using SuperShop.BLL.Abstraction.Base;
using SuperShop.Models;
using SuperShop.Repositories;
using SuperShop.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperShop.BLL
{
    public class CustomerManager: Manager<Customer>,ICustomerManager
    {
        ICustomerRepositories _customerRepositories;
        public CustomerManager(ICustomerRepositories customerManager):base(customerManager)
        {
            _customerRepositories = customerManager;
        }

        public Customer GetById(int? id)
        {
            if (id != null)
            {
                return _customerRepositories.GetById(id);
            }
            return null;
        }

    }
}
