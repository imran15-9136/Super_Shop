using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Models
{
    public class CustomerEditViewModel:CustomerCreateViewModel
    {
        public int Id { get; set; }
        public string ExistingPhoto { get; set; }
    }
}
