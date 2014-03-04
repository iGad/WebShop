using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;

namespace WebShop.Models
{
    public class VacuumCleaner
    {
        public int id { get; set; }
        public string model { get; set; }
        public int consumerId { get; set; }
        public string type { get; set; }
        public string harvestingType { get; set; }
        public string powerType { get; set; }
        public int consumePower { get; set; }
        public int suckPower { get; set; }
        public int noise { get; set; }
        public string stackType { get; set; }
        public float cordLength { get; set; }
        public int capCount { get; set; }
        public float weigth { get; set; }
        public string barCode { get; set; }
        public int battery { get; set; }
        public string description { get; set; }
        public Image image { get; set; }
        public decimal price { get; set; }
    }

    public class VacuumCleanerDBContex : DbContext
    {
        
        public DbSet<VacuumCleaner> VacuumCleaners { get; set; } 
    }
}