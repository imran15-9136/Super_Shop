using Microsoft.EntityFrameworkCore;
using SuperShop.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperShop.Database
{
    public static class ModelBuilderExtention
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Name = "Imran Khan",
                    Email = "imran_bof@live.com",
                    Password = "12345",
                    Designation = "Software Engineer",
                    DepartmentId = 2
                },
                new Employee
                {
                    Id=2,
                    Name="Sabit Khan",
                    Email="sabit@mail.com",
                    Password="12345",
                    Designation="Software Engineer",
                    DepartmentId=2
                });
        }
    }
}
