using System;
using System.Collections.Generic;
using System.Text;

namespace SuperShop.Models.ResponseModel
{
    public class ProductResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Quantity { get; set; }
        public string Price { get; set; }
    }
}
