using System;
using System.Collections.Generic;
using System.Text;

namespace SuperShop.Models.RequestModel
{
    public class CustomerRequestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool isDelete { get; set; }
    }
}
