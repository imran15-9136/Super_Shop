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
        [Required]
        [MaxLength(50,ErrorMessage ="Maximum Length is 50")]
        public string Name { get; set; }
        [Required]
        public string Designation { get; set; }
        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$",
                            ErrorMessage = "Invalid Email Format")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public byte[] Image { get; set; }
        public int DepartmentId { get; set; }
        public bool isDelete { get; set; }
        public ICollection<EmployeeResponseModel> EmployeeList { get; set; }
        public ICollection<SelectListItem> DepartmentItems { get; set; }
    }
}
