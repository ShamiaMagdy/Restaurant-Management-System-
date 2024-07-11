using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurant_M_S
{
    public class Area
    {
        public string Name { set; get; }
        public List<Boy> boy { set; get; }
        public Area()
        {
            boy = new List<Boy>();
        }
    }
    public class Boy
    {
       public  int ID { set; get; }
       public  int No_ofOrders { set; get; }
    }
}
