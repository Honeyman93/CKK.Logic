using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using CKK.Logic.Interfaces;
using CKK.Logic.Exceptions;

namespace CKK.Logic.Models
{
    public class ShoppingCart : IShoppingCart
    {
        public  Customer Customer { get; set; }
       
        public List<ShoppingCartItem> Products;

        public ShoppingCart(Customer cust)
        {
            Customer = cust;
            Products = new List<ShoppingCartItem>();
        }
        public int GetCustomerId()
        {
            return Customer.Id;
        }
       
         public ShoppingCartItem AddProduct(Product prod)
         {
            return AddProduct(prod, 1);
         }
        public ShoppingCartItem AddProduct(Product prod, int quantity)
        {
            if (quantity <= 0)
            {
                throw new InventoryItemStockTooLowException("Invalid quantity, can not be less than 0");
            }

            var existingItem = Products.FirstOrDefault(item => item.Product.Id == prod.Id);    
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
                return existingItem;
            }   
            else
            {
                var newItem = new ShoppingCartItem(prod, quantity);   
                Products.Add(newItem);
                return newItem;
            }
        }
         public ShoppingCartItem RemoveProduct(int id, int quantity)
         {
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException("Quantity can not be less than zero");
            }
            var itemToRemove = Products.FirstOrDefault(item => item.Product.Id == id);
            if (itemToRemove == null)
            {
                throw new ProductDoesNotExistException("Item does not exist in store. ");
            }


            if (itemToRemove.Quantity - quantity <= 0)
            {
                itemToRemove.Quantity = (0);
                Products.Remove(itemToRemove);

            }
            else
            {
                itemToRemove.Quantity -= quantity;

            }
                return itemToRemove;
            
            
           
         }
        public ShoppingCartItem GetProductById(int id)
        {
            if (id < 0)
            {
                throw new InvalidIdException("Invalid Id, cannot be less than 0.");
            }
            return Products.FirstOrDefault(item => item.Product.Id == id);

        }
        public decimal GetTotal()
        {
            return Products.Sum(item => item.Product.Price * item.Quantity);
        }
        public List<ShoppingCartItem> GetProducts()
        {
            return  Products;    
        }
    }
}   
