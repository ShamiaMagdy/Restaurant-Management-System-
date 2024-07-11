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
    public partial class Customer_2 : Form
    {
        List<Food> FoodLst = new List<Food>();
        List<Customer_1> custlst = new List<Customer_1>();
        List<Area> arealst = new List<Area>();
        public Customer_2( )
        {
            InitializeComponent();

            XmlSerializer xs = new XmlSerializer(FoodLst.GetType());
            FileStream fs = new FileStream("food.xml", FileMode.Open);
            if (File.Exists("food.xml"))
           { 
                FoodLst = (List<Food>)xs.Deserialize(fs);
                fs.Close();
                //dataGridView2.DataSource = FoodLst;
                dataGridView2.RowCount = FoodLst.Count;
                for (int i = 0; i < FoodLst.Count; i++)
                {
                    dataGridView2.Rows[i].Cells[1].Value = FoodLst[i].Name;
                    dataGridView2.Rows[i].Cells[2].Value = FoodLst[i].Price;
                
                }
            }

            if (File.Exists("Customer_1.xml"))
            {
                xs = new XmlSerializer(custlst.GetType());
                fs = new FileStream("Customer_1.xml", FileMode.Open);
                custlst = (List<Customer_1>)xs.Deserialize(fs);
                fs.Close();
            }
            if (File.Exists("Area.xml"))
            {
                xs = new XmlSerializer(arealst.GetType());
                fs = new FileStream("Area.xml", FileMode.Open);
                arealst = (List<Area>)xs.Deserialize(fs);
                fs.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer1 ss = new Customer1();
            ss.ShowDialog();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Customer_2_Load(object sender, EventArgs e)
        {
       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customer_1 cust = new Customer_1();
            List<Customer_1> customer = new List<Customer_1>();
            double ttl=0.0;
            int No_ordr = 0;
            cust.Name = textBox1.Text;
            cust.Address = textBox3.Text;
            cust.Phone = textBox2.Text;
            cust.Area = comboBox1.SelectedItem.ToString();
            
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || comboBox1.SelectedItem.Equals(""))
            {
                MessageBox.Show("Please enter Your data !!");
            }
            else
            {

                foreach (DataGridViewRow r in dataGridView2.Rows)
                {
                    int quantity = 0;
                    double total = 0.0;
                    if (Convert.ToBoolean(r.Cells[0].Value))
                    {
                        quantity = Convert.ToInt32(r.Cells[dataGridView2.Columns["Quantity"].Index].Value);
                        total = (Convert.ToDouble(r.Cells[dataGridView2.Columns["Price"].Index].Value) * Convert.ToDouble(r.Cells[dataGridView2.Columns["Quantity"].Index].Value));
                    }
                    ttl += total;
                    No_ordr += quantity;
                }
                for (int i = 0; i < custlst.Count; i++)
                {
                    if (custlst[i].Phone ==textBox2.Text)
                    {
                        custlst[i].NO_ofOrders += No_ordr;
                        if (custlst[i].NO_ofOrders >= 5)
                        {
                            custlst[i].Total_Purchase += (ttl - (ttl * 10 / 100));
                            custlst[i].Discount += (ttl * 10 / 100);
                            textBox4.Text = (ttl - (ttl * 10 / 100)).ToString();
                        }
                        else
                            custlst[i].Total_Purchase += ttl;
                        
                    }
                    else if (custlst[i].Phone != textBox2.Text)
                    {
                        custlst.Add(cust);
                    }
                }
                //Boy area code
                for (int i = 0; i < arealst.Count; i++)
                {
                    if (arealst[i].Name == comboBox1.SelectedItem.ToString())
                    {
                        List<Boy> bb = new List<Boy>();
                        bb = arealst[i].boy;
                        /*int min = bb[0].No_ofOrders;
                        for (int j = 0; j < bb.Count; j++)
                        {
                            if (bb[j].No_ofOrders < min)
                            {
                                min = bb[j].No_ofOrders;
                                bb[j].No_ofOrders = bb[j].No_ofOrders + 1;
                                textBox5.Text = bb[j].ID.ToString();
                            }
                            else if (bb[j].No_ofOrders == min)
                            {
                                min = bb[j].No_ofOrders;
                                bb[j].No_ofOrders = bb[j].No_ofOrders + 1;
                                textBox5.Text = bb[j].ID.ToString();
                            }*/
                            int index = 0;
                            for (int j = 0; j < bb.Count; j++)
                            {
                                int min = bb[index].No_ofOrders;
                                if (bb[j].No_ofOrders < min)
                                {
                                    index = j;
                                }

                            }
                            bb[index].No_ofOrders += 1;
                            textBox5.Text = bb[index].ID.ToString();
                        }
                   // }
                }
              
                XmlSerializer s = new XmlSerializer(custlst.GetType());
                FileStream fstr = new FileStream("Customer_1.xml", FileMode.Create);
                s.Serialize(fstr, custlst);
                fstr.Close();

                s = new XmlSerializer(arealst.GetType());
                fstr = new FileStream("Area.xml", FileMode.Create);
                s.Serialize(fstr, arealst);
                fstr.Close();

                List<data> d = new List<data>();
                foreach (DataGridViewRow item in dataGridView2.Rows)
                {
                    if (Convert.ToBoolean(item.Cells[0].Value))
                    {
                        d.Add(new data
                        {
                            name = item.Cells[1].Value.ToString()
                            ,
                            price = item.Cells[2].Value.ToString()
                            ,
                            quantity = item.Cells[3].Value.ToString()
                        });
                    }
                }

                bill_Form f = new bill_Form(this,comboBox1);
                f.values = d;
                f.Show();
               /* Boys_Chart boy = new Boys_Chart();
                boy.Show();*/

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
                    
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
           
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
