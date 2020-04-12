using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SuperShop.Models.ResponseModel
{
    public class ProductCatagoryResponseModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
