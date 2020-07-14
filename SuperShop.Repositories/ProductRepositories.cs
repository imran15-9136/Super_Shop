using Microsoft.EntityFrameworkCore;
using SuperShop.Database;
using SuperShop.Models.EntityModels;
using SuperShop.Repositories.Abstraction;
using SuperShop.Repositories.Abstraction.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperShop.Repositories
{
    public class ProductRepositories : Repository<Product>, IProductRepositories
    {
        SuperShopDbContext _db;
        public ProductRepositories(DbContext db):base(db)
        {
            _db = (SuperShopDbContext)db;
        }

        public override ICollection<Product> GetAll()
        {
            return _db.Products.Include(c => c.Category).ToList();
        }
        public Product GetById(int? id)
        {
            if (id != null)
            {
                return GetFirstorDefault(product => product.Id == id);
            }
            return null;
        }
    }
}
