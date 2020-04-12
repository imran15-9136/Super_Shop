using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuperShop.Models;
using SuperShop.Models.ResponseModel;

namespace SuperShop.AutoMapperProfile
{
    public class SuperShopAutoMapperProfile:Profile
    {
        public SuperShopAutoMapperProfile()
        {
            CreateMap<CustomerCreateViewModel, Customer>();
            CreateMap<Customer, CustomerCreateViewModel>();
            CreateMap<Customer, CustomerResponseModel>();
        }
    }
}
