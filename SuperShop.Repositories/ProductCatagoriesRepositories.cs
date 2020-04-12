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
    public class ProductCatagoriesRepositories : Repository<ProductCatagory>, IProductCatagoryRepositories
    {
        SuperShopDbContext _db;
        public ProductCatagoriesRepositories(DbContext db):base(db)
        {
            _db = (SuperShopDbContext)db;
        }
        public ProductCatagory GetbyId(int? id)
        {
            return GetFirstorDefault(catagory => catagory.Id == id);
        }
    }
}
