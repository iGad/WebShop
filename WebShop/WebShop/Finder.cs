using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop
{
    public partial class Finder
    {
        public string searchString { get; set; }
        public string consumerName { get; set; }
        public string cleanerType { get; set; }
        public string powerType { get; set; }
        public string stackType { get; set; }
        public string harvestingType { get; set; }
        public Finder()
        {
            searchString = consumerName = cleanerType = powerType = stackType = harvestingType = "";
        }
    }
}