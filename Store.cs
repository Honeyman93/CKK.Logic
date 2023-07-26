using CKK.Logic.Interfaces;
using CKK.Logic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;

namespace CKK.Logic.Models
{
    public class Store : Entity, IStore
    {
        
        
        private List<StoreItem> _storeItem;

        public Store()
        {
          _storeItem = new List<StoreItem>();
        }
    
       
         public StoreItem AddStoreItem(Product prod, int quantity)
         {
            if (quantity <= 0) 
            {
                throw new InventoryItemStockTooLowException("Quantity cannot be less than zero."); 
            }
            var existingItem = _storeItem.FirstOrDefault(item => item.Product.Id == prod.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
                return existingItem;
            }
            else
            {
               var newItem = new StoreItem(prod, quantity);
                _storeItem.Add(newItem);
                return newItem;
            }
         }
        public StoreItem RemoveStoreItem(int id, int quantity)
        {
            if (quantity < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            var existingItem = FindStoreItemById(id);
            if (existingItem != null)
            {
                if (existingItem.Quantity - quantity < 0) 
                {
                    existingItem.Quantity = (0);
                }
                else
                {
                    existingItem.Quantity =  (existingItem.Quantity - quantity);
                }
                return existingItem;
            }
            else
            {
                throw new ProductDoesNotExistException();
            }
          
           
        }
        public List<StoreItem> GetStoreItems()
        {
            return _storeItem;
        }
        public StoreItem FindStoreItemById(int id)
        {
            if (id < 0)
            {
                throw new InvalidIdException("Invalid Id, cannot be less than zero. ");
            }
            return _storeItem.FirstOrDefault(item => item.Product.Id == id); 
        }

        
       
    
    }


}
