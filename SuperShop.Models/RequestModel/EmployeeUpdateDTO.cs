using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SuperShop.Models.RequestModel
{
    public class EmployeeUpdateDTO
    {
        [Required]
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] Image { get; set; }
        public int DepartmentId { get; set; }
    }
}
