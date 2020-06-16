using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SuperShop.BLL;
using SuperShop.BLL.Abstraction;
using SuperShop.Database;
using SuperShop.Repositories;
using SuperShop.Repositories.Abstraction;
using System;

namespace SuperShop.Configuration
{
    public static class ConfigureServices
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<ICustomerManager, CustomerManager>();
            services.AddTransient<ICustomerRepositories, CustomerRepositories>();

            services.AddTransient<IProductManager, ProductManager>();
            services.AddTransient<IProductRepositories, ProductRepositories>();

            services.AddTransient<IProductCatagoryManager, ProductCatagoryManager>();
            services.AddTransient<IProductCatagoryRepositories, ProductCatagoriesRepositories>();

            services.AddTransient<IEmployeeManager, EmployeeManager>();
            services.AddTransient<IEmployeeRepositories, EmployeeRepositories>();

            services.AddTransient<IDepartmentManager, DepartmentManager>();
            services.AddTransient<IDepartmentRepositories, DepartmentRepositories>();

            services.AddTransient<DbContext, SuperShopDbContext>();
        }

    }
}
