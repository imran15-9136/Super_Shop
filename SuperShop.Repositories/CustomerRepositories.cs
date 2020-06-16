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
            var result = _db.Customers.AsQueryable();
            
            if(customer != null)
            {
                return result.ToList();
            }

            if(customer.Id > 0)
            {
                result = result.Where(c => c.Id == customer.Id);
            }

            if (!string.IsNullOrEmpty(customer.Name))
            {
                result = result.Where(c => c.Name.ToLower().Contains(customer.Name.ToLower()));
            }

            if(customer.isDelete != null)
            {
                result = result.Where(c => c.isDelete == customer.isDelete);
            }

            if (!string.IsNullOrEmpty(customer.Address))
            {
                result = result.Where(c => c.Address.ToLower().Contains(customer.Address.ToLower()));
            }

            if (!string.IsNullOrEmpty(customer.Phone))
            {
                result = result.Where(c => c.Phone.ToLower().Equals(customer.Phone.ToLower()));
            }

            return result.ToList();
        }
    }
}
