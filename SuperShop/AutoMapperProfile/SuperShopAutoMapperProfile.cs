using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuperShop.Models;
using SuperShop.Models.ResponseModel;
using SuperShop.Models.EntityModels;

namespace SuperShop.AutoMapperProfile
{
    public class SuperShopAutoMapperProfile:Profile
    {
        public SuperShopAutoMapperProfile()
        {
            CreateMap<CustomerCreateViewModel, Customer>();
            CreateMap<Customer, CustomerCreateViewModel>();
            CreateMap<Customer, CustomerResponseModel>();
            CreateMap<EmployeeCreateViewModel, Employee>();
            CreateMap<Employee, EmployeeCreateViewModel>();
            CreateMap<Employee, EmployeeResponseModel>();
        }
    }
}
