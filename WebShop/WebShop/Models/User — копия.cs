using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop.Models
{
    public class User
    {
        public int id { get; set; }
        public string login { get; set; }
        public string pass { get; set; }
        public int type { get; set; }
        public int buyCount { get; set; }
        public decimal buySumm { get; set; }
        public string creditCard { get; set; }
    }
}