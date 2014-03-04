using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop.Models
{
    public class Consumer
    {
        public int id { get; set; }
        public string name { get; set; }
        public virtual Country country { get; set; }
    }
}