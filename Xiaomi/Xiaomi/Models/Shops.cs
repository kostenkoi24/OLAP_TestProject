using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xiaomi.Models
{
    //[Keyless]
    public class Shops
    {
        public string ShopCode { get; set; }

        public string XiaomiCode { get; set; }

        public int Id { get; set; }
    }
}
