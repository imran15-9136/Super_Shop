using System;
using System.Collections.Generic;
using System.Text;

namespace SuperShop.Models.Contracts
{
    public interface IDelatable
    {
        bool Delete();
    }
}
