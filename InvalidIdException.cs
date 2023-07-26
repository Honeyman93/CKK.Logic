using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Exceptions
{
    public class InvalidIdException : Exception
    {
        public InvalidIdException()  
        { 
        }
        public InvalidIdException(string message) : base(message)
        {
        }
        public InvalidIdException(string message,  Exception innerException) : base(message, innerException) { }

    }
}
