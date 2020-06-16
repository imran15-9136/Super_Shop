using Microsoft.AspNetCore.Mvc.Rendering;
using SuperShop.Models.ResponseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Models
{
    public class EmployeeCreateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public byte[] Image { get; set; }
        public int DepartmentId { get; set; }
        public bool isDelete { get; set; }
        public ICollection<EmployeeResponseModel> EmployeeList { get; set; }
        public ICollection<SelectListItem> DepartmentItems { get; set; }
    }
}
