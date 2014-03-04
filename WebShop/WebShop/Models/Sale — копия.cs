using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop.Models
{
    public class Sale
    {
        public int id { get; set; }
        public decimal price { get; set; }
        public DateTime date { get; set; }
        public virtual User user {get;set;}
        public virtual VacuumCleaner vacuumCleaner { get; set; }
    }
}