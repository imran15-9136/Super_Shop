using Microsoft.AspNetCore.Mvc.Rendering;
using SuperShop.Models.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Models
{
    public class ProductCreateViewModel
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public int Quantity { get; set; }
        public string Code { get; set; }
        public int? CategoryId { get; set; }
        public ICollection<ProductResponseModel> Products { get; set; }
        public ICollection<SelectListItem> ProductCatagoryItem { get; set; }
    }
}
