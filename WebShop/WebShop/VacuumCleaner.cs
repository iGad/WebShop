//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebShop
{
    using System;
    using System.Collections.Generic;
    
    public partial class VacuumCleaner
    {
        public VacuumCleaner()
        {
            this.Sales = new HashSet<Sale>();
        }
    
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
        public Nullable<double> cordLength { get; set; }
        public Nullable<int> capCount { get; set; }
        public Nullable<double> weigth { get; set; }
        public string barcode { get; set; }
        public Nullable<int> battery { get; set; }
        public string description { get; set; }
        public byte[] image { get; set; }
        public Nullable<decimal> price { get; set; }
        public virtual Consumer Consumers { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}