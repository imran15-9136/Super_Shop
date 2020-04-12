﻿using SuperShop.Models.Contracts;
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
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool isDelete { get; set; }

        public bool Delete()
        {
            return isDelete = true;
        }
    }
}
