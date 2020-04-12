using SuperShop.BLL.Abstraction;
using SuperShop.BLL.Abstraction.Base;
using SuperShop.Models.EntityModels;
using SuperShop.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperShop.BLL
{
    public class ProductCatagoryManager : Manager<ProductCatagory>, IProductCatagoryManager
    {
        IProductCatagoryRepositories _ProductCatagoryRepositories;
        public ProductCatagoryManager(IProductCatagoryRepositories productCatagory):base(productCatagory)
        {
            _ProductCatagoryRepositories = productCatagory;
        }

        public ProductCatagory GetById(int? id)
        {
            return _ProductCatagoryRepositories.GetbyId(id);
        }
    }
}
