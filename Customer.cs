﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic
{
    internal class Customer
    {
        private int _id;
        private string _name;
        private string _address; 
        
   
    public Customer(int id, string name, string address) 
        { 
            _id = id;
            _name = name;
            _address = address;
        }
        public int GetId() 
        { 
            return _id; 
        }
        public void SetId(int id)
        {
            _id = id;
        }
        public string GetName()
        {
            return _name;
        }
        public void SetName(string name)
        {
            _name = name;
        }
        public string GetAddress()
        {
            return _address;
        }
        public void SetAddress(string address)
        {
            _address = address;
        }


    }


}
