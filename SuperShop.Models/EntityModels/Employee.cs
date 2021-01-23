using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SuperShop.Models.EntityModels
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public byte[] Image { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public bool isDelete { get; set; }
        public bool Delete()
        {
            return isDelete = true;
        }
    }
}
