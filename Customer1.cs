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
    public partial class Customer1 : Form
    {
        public Customer1()
        {
            InitializeComponent();
        }

        private void Customer1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer_login cust = new Customer_login();
            cust.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer_2 cs = new Customer_2();
            cs.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //panel1.Top=1;
            panel1.Visible = true;
            dataGridView1.Show();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("Customer_Login.txt", FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Phone");
            dt.Columns.Add("Password");
            while (fs.Position < fs.Length)
            {
                Customer cst = (Customer)bf.Deserialize(fs);
                if (cst.name==textBox1.Text)
                {
                    dt.Rows.Add(cst.name, cst.phone,cst.password);
                }
            }
            dataGridView1.DataSource = dt;
           // this.dataGridView1.Rows[1].Cells[0].Value = "new Value";
            fs.Close(); 
        }

      
    }
}
