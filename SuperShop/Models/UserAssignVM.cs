using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Models
{
    public class UserAssignVM
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string RoleId { get; set; }
        public ICollection<SelectListItem> UserList { get; set; }
        public ICollection<SelectListItem> RoleList { get; set; }
    }
}
