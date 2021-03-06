﻿using SuperShop.Models.EntityModels;
using SuperShop.Repositories.Abstraction.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperShop.Repositories.Abstraction
{
    public interface IProductRepositories:IRepository<Product>
    {
        Product GetById(int? id);
    }
}
