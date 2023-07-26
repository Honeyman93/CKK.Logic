using CKK.Logic.Exceptions;
using CKK.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Interfaces
{
    public abstract class InventoryItem
    {
        private int quantity;
        private Product product;
        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (value < 0)
                {
                    throw new InventoryItemStockTooLowException("InventoryItemStockTooLowException");
                }
                quantity = value;
                 
            }
        }
        public Product Product { get; set; }

       
    }
}
