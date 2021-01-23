using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Models
{
    public class UserRoleViewModel
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        public bool IsSelected { get; set; }
    }
}
