using Microsoft.EntityFrameworkCore;
using SuperShop.Database;
using SuperShop.Models;
using SuperShop.Models.RequestModel;
using SuperShop.Repositories.Abstraction;
using SuperShop.Repositories.Abstraction.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperShop.Repositories
{
    public class CustomerRepositories: Repository<Customer>, ICustomerRepositories
    {
        SuperShopDbContext _db;
        public CustomerRepositories(DbContext db):base(db)
        {
            _db = (SuperShopDbContext)db;
        }

        

        public override ICollection<Customer> GetAll()
        {
            return _db.Customers.Where(c => c.isDelete == false).ToList();
        }

        public Customer GetById(int? id)
        {
            if (id != null)
            {
                return GetFirstorDefault(customer=> customer.Id == id);
            }
            return null;
        }

        public ICollection<Customer> GetbyRequest(CustomerRequestModel customer)
        {
            return _db.GetbyRequest(customer);
        }
    }
}
