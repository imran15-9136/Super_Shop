using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SuperShop.Models.EntityModels
{
    public class ProductCatagory
    {
        public int Id{ get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
