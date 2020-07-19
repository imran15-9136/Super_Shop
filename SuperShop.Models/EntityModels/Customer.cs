using SuperShop.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Models
{
    public class Customer: IDelatable
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage ="Maximum Length is 50")]
        public string Name { get; set; }
        [Required]
        [MaxLength(15,ErrorMessage ="Maximum Lenth is 15")]
        public string Phone { get; set; }
        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$",
                            ErrorMessage = "Invalid Email Format")]
        public string Email { get; set; }
        public string Address { get; set; }
        public bool isDelete { get; set; }
        [Display(Name="Image")]
        public string PhotoPath { get; set; }

        public bool Delete()
        {
            return isDelete = true;
        }
    }
}
