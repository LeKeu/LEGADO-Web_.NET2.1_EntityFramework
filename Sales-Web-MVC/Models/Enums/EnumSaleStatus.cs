using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales_Web_MVC.Models.Enums
{
    public enum EnumSaleStatus : int
    {
        Pending = 0,
        Billed = 1,
        Cancelled = 2
    }
}
