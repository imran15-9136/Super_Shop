using System;
using System.Collections.Generic;
using System.Text;

namespace SuperShop.Models.ResponseModel
{
    public class EmployeeResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] Image { get; set; }
    }
}
