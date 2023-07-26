

using CKK.Logic.Interfaces;
using System.Net;

namespace CKK.Logic.Models
{
     public class Product : Entity
    {
        private decimal price;
       
        public decimal Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("ArgumentOutOfRangeException");
                }
                price = value;
            }
        }

        

        
    }
}
