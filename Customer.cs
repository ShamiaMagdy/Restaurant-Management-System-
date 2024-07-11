using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurant_M_S
{
    [Serializable]
    class Customer
    {
        public string name;//{set ;get;}
        public string phone ;//{ set; get; }
        public string password ;//{ set; get; }
        //public List<string> food;
        public Customer(string name,string phone,string password)
        {
            this.name = name;
            this.phone = phone;
            this.password = password;
        }
       
    }
}
