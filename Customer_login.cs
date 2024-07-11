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
    public partial class Customer_login : Form
    {
        public Customer_login()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer_Register frm = new Customer_Register();
            frm.ShowDialog();        
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("Customer_Login.txt", FileMode.Open,FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();
            List<Customer> c = new List<Customer>();
            while (fs.Position < fs.Length)
            {
                Customer cust = (Customer)bf.Deserialize(fs);
                if (cust.name == textBox1.Text && cust.password==textBox2.Text)
                {
                    c.Add(cust);
                }
            }
            if (c.Count == 1)
            {
                this.Hide();
                Customer1 cs = new Customer1();
                cs.ShowDialog();
            }
            else if (c.Count == 0)
            {
                MessageBox.Show("Please enter the correct name or password !! ");
            }
            fs.Close();
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}
