using Microsoft.EntityFrameworkCore;
using SuperShop.Models;
using SuperShop.Models.EntityModels;
using SuperShop.Models.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Database
{
    public class SuperShopDbContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCatagory> ProductCatagories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string connectionString = "Server=DESKTOP-6HU487U; Database=SuperShop; Integrated Security=true";
            optionsBuilder.UseSqlServer(connectionString); 
        }
    }
}
