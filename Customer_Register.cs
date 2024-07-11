using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace Restaurant_M_S
{
    public partial class Customer_Register : Form
    {
        public Customer_Register()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer_login frm = new Customer_login();
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                /*FileStream fs = new FileStream("Customer_Login.txt", FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(textBox1.Text);
                sw.Write("\t");
                sw.Write(textBox2.Text);
                sw.Write("\t");
                sw.Write(textBox3.Text);
                sw.Write("\t");
                sw.WriteLine(textBox4.Text);
                sw.Close();
                fs.Close();
                this.Hide();
                Customer1 cc = new Customer1();
                cc.ShowDialog();*/
            string Name = "";
            string Phone = "";
            string Password = "";
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox4.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Your data !!");
            }
            else
            {
                FileStream fs = new FileStream("Customer_Login.txt", FileMode.Append);
                BinaryFormatter bf = new BinaryFormatter();
                Name = textBox1.Text;
                Phone = textBox2.Text;
                Password = textBox4.Text;
                Customer cust = new Customer(Name, Phone, Password);
                bf.Serialize(fs, cust);
                fs.Close();
                this.Hide();
                Customer1 cc = new Customer1();
                cc.ShowDialog();
            }
        }
    }
}
