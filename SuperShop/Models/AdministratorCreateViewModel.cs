using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Models
{
    public class AdministratorCreateViewModel
    {
        [Required(ErrorMessage ="Role Name is Required")]
        public string RoleName { get; set; }
    }
}
