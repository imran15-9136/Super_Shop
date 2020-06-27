using AutoMapper;
using SuperShop.Models;
using SuperShop.Models.EntityModels;
using SuperShop.Models.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.API.AutoMapperProfile
{
    public class SuperShopAPIAutoMapperProfile: Profile
    {
        public SuperShopAPIAutoMapperProfile()
        {
            CreateMap<CustomerCreateDTO, Customer>();
            CreateMap<EmployeeCreateDTO, Employee>();
        }
    }
}
