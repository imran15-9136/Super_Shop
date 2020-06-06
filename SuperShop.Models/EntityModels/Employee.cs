using System;
using System.Collections.Generic;
using System.Text;

namespace SuperShop.Models.EntityModels
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] Image { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        //public ICollection<SelectListItem> DepartmentItems { get; set; }
    }
}
