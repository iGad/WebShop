using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebShop.Models
{
    public class BuyerModel 
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string CardType { get; set; }
        public long CardNumber { get; set; }
        public int CVV { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

    }
}
