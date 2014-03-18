using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(VacuumCleaner product, int quantity)
        {
            CartLine line = lineCollection
              .Where(p => p.VacuumCleaner.id == product.id)
              .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    VacuumCleaner = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public void RemoveLine(VacuumCleaner product)
        {
            lineCollection.RemoveAll(l => l.VacuumCleaner.id == product.id);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => (decimal)e.VacuumCleaner.price * e.Quantity);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }

    public class CartLine
    {
        public VacuumCleaner VacuumCleaner { get; set; }
        public int Quantity { get; set; }
    }

}