using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Restaurant_M_S
{
    public class Customer_1
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Area { get; set; }
        public int NO_ofOrders { get; set; }
        public double Total_Purchase { get; set; }
        public double Discount { get; set; }
        public Customer_1()
        {    
        }
    }
       public class Food
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
    }
}
