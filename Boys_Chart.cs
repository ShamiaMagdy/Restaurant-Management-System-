using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace Restaurant_M_S
{
    public partial class Boys_Chart : Form
    {
        List<Area> arealst = new List<Area>();
        public Boys_Chart()
        {
            InitializeComponent();
            if (File.Exists("Area.xml"))
            {
                XmlSerializer xs = new XmlSerializer(arealst.GetType());
                FileStream fs = new FileStream("Area.xml", FileMode.Open);
                arealst = (List<Area>)xs.Deserialize(fs);
                fs.Close();
            }
        }

        private void Boys_Chart_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < arealst.Count; i++)
            {
                List<Boy> bb = new List<Boy>();
                bb = arealst[i].boy;
                int min = bb[0].No_ofOrders;
                bb = arealst[i].boy;
                int sum = 0;
                for (int j = 0; j < bb.Count; j++)
                {
                    sum += bb[j].No_ofOrders;
                }
                this.chart_boys.Series["Area"].Points.AddXY(arealst[i].Name, sum);
            }
            //this.chart_boys.Series["Boy 1"].Points.AddXY("Boy 1", 20);
            //this.chart_boys.Series["Boy 2"].Points.AddXY("Boy 2", 30);
            //this.chart_boys.Series["Boy 3"].Points.AddXY("Boy 3", 40);
            //this.chart_boys.Series["Boy 4"].Points.AddXY("Boy 4", 10);
            //this.chart_boys.Series["Boy 5"].Points.AddXY("Boy 5", 25);
        }
    }
}
