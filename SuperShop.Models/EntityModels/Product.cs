﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SuperShop.Models.EntityModels
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Price { get; set; }
        public int Quantity { get; set; }
        public string Code { get; set; }
        public byte[] Image { get; set; }
        public int? CategoryId { get; set; }
        //[ForeignKey("CategoryId")]
        public ProductCatagory Category { get; set; }
    }
}
