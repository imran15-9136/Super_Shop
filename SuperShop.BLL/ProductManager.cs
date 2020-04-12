using SuperShop.BLL.Abstraction;
using SuperShop.BLL.Abstraction.Base;
using SuperShop.Models.EntityModels;
using SuperShop.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SuperShop.BLL
{
    public class ProductManager : Manager<Product>, IProductManager
    {
        IProductRepositories _productRespsitories;
        public ProductManager(IProductRepositories productRepositories):base(productRepositories)
        {
            _productRespsitories = productRepositories;
        }
        public Product GetbById(int? id)
        {
            return _productRespsitories.GetById(id);
        }
    }
}
