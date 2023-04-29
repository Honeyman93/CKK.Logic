
using System.Security.Cryptography.X509Certificates;

namespace CKK.Logic.Models
{
    public class ShoppingCart
    {
        private Customer _Customer;
        private ShoppingCartItem _product1;
        private ShoppingCartItem _product2;
        private ShoppingCartItem _product3;

        public ShoppingCart(Customer cust)
        {
            _Customer = cust;
        }
        public int GetCustomerId()
        {
            return _Customer.GetId();
        }
        public ShoppingCartItem GetProductById(int id)
         {
            if (_product1 != null && _product1.GetProduct().GetId() == id)
            {
                return _product1;
            }
            else if (_product2 != null && _product2.GetProduct().GetId() == id)
            {
                return _product2;
            }
            else if (_product3 != null && _product3.GetProduct().GetId() == id)
            {
                return _product3;
            }
            else
            {
                return null;
            }

         }
         public ShoppingCartItem AddProduct(Product prod)
         {
            return AddProduct(prod, 1);
         }
         public ShoppingCartItem AddProduct(Product prod, int quantity)
         {
            if (quantity <= 0)
            {
                throw new ArgumentException("Product must be greater than zero");
            }
                if (_product1 == null)
                {
                    _product1 = new ShoppingCartItem(prod, quantity);
                    return _product1;
                }
                else if (_product1.GetProduct().GetId() == prod.GetId())
                {
                    _product1.SetQuantity(_product1.GetQuantity() + quantity);
                    return _product1;
                }
                else if (_product2 == null)
                {
                    _product2 = new ShoppingCartItem(prod, quantity);
                    return _product2;
                }
                else if (_product2.GetProduct().GetId() == prod.GetId())
                {
                    _product2.SetQuantity(_product2.GetQuantity() + quantity);
                    return _product2;
                }
                else if (_product3 == null)
                {
                    _product3 = new ShoppingCartItem(prod, quantity);
                    return _product3;
                }
                else if (_product3.GetProduct().GetId() == prod.GetId())
                {
                    _product3.SetQuantity(_product3.GetQuantity() + quantity);
                    return _product3;
                }
                else { throw new ArgumentException("Product is already in the shopping cart"); }

             ShoppingCartItem RemoveProduct(Product prod, int id)
             {
                if (_product1 != null && _product1.GetProduct().GetId() == id)
                {
                    var removedItem = _product1;
                    _product1 = null;
                    return removedItem;
                }
                else if (_product2 != null && _product2.GetProduct().GetId() == id)
                {
                    var removedItem = _product2;
                    _product2 = null;
                    return removedItem;
                }
                else if (_product3 != null && _product3.GetProduct().GetId() == id)
                {
                    var removedItem = _product3;
                    _product3 = null;
                    return removedItem;
                }
                else
                {
                    return null;
                }
                
             }
            

         }
        public decimal GetTotal()
        {
            decimal total = 0;
            if (_product1 != null)
            {
                total += _product1.GetProduct().GetPrice() * _product1.GetQuantity();
            }
            if (_product2 != null)
            {
                total += _product2.GetProduct().GetPrice() * _product2.GetQuantity();
            }
            if (_product3 != null)
            {
                total += _product3.GetProduct().GetPrice() * _product3.GetQuantity();
            }
            return total;
        }
        ShoppingCartItem GetProduct(int prodNum)
        {
            if (prodNum == 1)
            {
                return _product1;
            }
            else if (prodNum == 2)
            {
                return _product2;
            }
            else if (prodNum == 3)
            {
                return _product3;
            }
            else
            {
                return null;
            }
        }
    }
}   
