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
    public partial class bill_Form : Form
    {
        ComboBox cB;
        Customer_2 customer;
        public bill_Form(Customer_2 frm,ComboBox cb)
        {
            InitializeComponent();
            this.customer = frm;
            cB = cb;
            cb.Text.ToString();
        }
        public List<data> values { set; get; }
        public void AddToGrid(List<data>val)
        {
            if(val!=null)
            {
                foreach(data item in val)
                {
                    int n = dataGridView3.Rows.Add();
                    dataGridView3.Rows[n].Cells[0].Value = item.name;
                    dataGridView3.Rows[n].Cells[1].Value = item.price;
                    dataGridView3.Rows[n].Cells[2].Value = item.quantity;
                    dataGridView3.Rows[n].Cells[3].Value = item.subTotal;
                }
            }
        }
        private void bill_Form_Load(object sender, EventArgs e)
        {
            lblName.Text = customer.textBox1.Text;
            lblAddress.Text = customer.textBox3.Text;
            lblphone.Text = customer.textBox2.Text;
            lblArea.Text = cB.Text.ToString();
            AddToGrid(values);

            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                row.Cells[dataGridView3.Columns["colsubtotal"].Index].Value = (Convert.ToDouble(row.Cells[dataGridView3.Columns["pricecol"].Index].Value) * Convert.ToDouble(row.Cells[dataGridView3.Columns["qtycol"].Index].Value));
            }
            dataGridView3.Columns[1].DefaultCellStyle.ForeColor = Color.Red;
            dataGridView3.Columns[3].DefaultCellStyle.ForeColor = Color.DarkGreen;
            double new_total = 0.0;
            //int quantity = 0;
            foreach (DataGridViewRow r in dataGridView3.Rows)
            {
                new_total += Convert.ToDouble(r.Cells["colsubtotal"].Value);
                //quantity += Convert.ToInt32(r.Cells["qtycol"].Value);
            }
            txt_total.Text = (new_total).ToString();
            // ----------------------------------------------------------------
           /* if (dataGridView3.Rows.Count >= 2)
            {
                 int total = 0;
                 double d;
                 total = int.Parse(txt_total.Text);
                 d = double.Parse(txtDiscount.Text);
                 double discount = total * d;
                 txt_discount.Text = discount.ToString();
            }*/
            txt_discount.Text = customer.textBox4.Text;
            textBox1.Text = customer.textBox5.Text;
           /* cust.Name = customer.textBox1.Text;
            cust.Phone = customer.textBox2.Text;
            cust.Address = customer.textBox3.Text;
            //cust.Area =customer.comboBox1.SelectedItem.ToString();
            cust.Total_Purchase += new_total;
            cust.NO_ofOrders += quantity;*/
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            ((Form)printPreviewDialog1).WindowState = FormWindowState.Maximized;
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
             float margin = 40;
            Font f = new Font("Arial", 18, FontStyle.Bold);
            string strNo = "#No " + txtBillNum.Text;
           // string strDate = "Date: " + txtDate.Text;
            string strName = "Customer Name: " + lblName.Text;
            SizeF fontsizeNo = e.Graphics.MeasureString(strNo, f);
           // SizeF fontsizeDate = e.Graphics.MeasureString(strDate, f);
            SizeF fontsizeName = e.Graphics.MeasureString(strName, f);
            e.Graphics.DrawImage(Properties.Resources.logo2, 550, 10, 200, 200);
            e.Graphics.DrawString(strNo, f, Brushes.Red, (e.PageBounds.Width - 2*fontsizeNo.Width) / 2, margin);
           // e.Graphics.DrawString(strDate, f, Brushes.Black, margin, margin + fontsizeNo.Height+30);
            e.Graphics.DrawString(strName, f, Brushes.Black, margin, margin + /*fontsizeDate.Height +*/ fontsizeNo.Height + 45);
            float preHeights = margin + fontsizeNo.Height + /*fontsizeDate.Height +*/ fontsizeName.Height;
            e.Graphics.DrawRectangle(Pens.Black, margin, preHeights+127, e.PageBounds.Width - margin * 2, e.PageBounds.Height - 84 -2*preHeights);
            float colHeight = 60;
            float col1Width = 300;
            float col2Width = 125 + col1Width;
            float col3Width = 125 + col2Width;
            float col4Width = 125 + col3Width;
            e.Graphics.DrawLine(Pens.Black, margin, 2*preHeights + colHeight-margin, e.PageBounds.Width - margin, 2*preHeights + colHeight-margin);
            e.Graphics.DrawString("Food Name", f, Brushes.Black, (margin * 2)-2,(6* margin)+2 );
            e.Graphics.DrawLine(Pens.Black, (margin * 7)+15 , 3 * preHeights - 2*margin, (margin * 7)+15 , e.PageBounds.Height - margin -  preHeights + 88);
            e.Graphics.DrawString("Quantity", f, Brushes.Black, (margin * 8) , (6 * margin) + 2);
            e.Graphics.DrawLine(Pens.Black, (margin * 11) + 5, 3 * preHeights - 2*margin, (margin * 11) + 5, e.PageBounds.Height - margin - preHeights + 88);
            e.Graphics.DrawString("Unit Price", f, Brushes.Black, (margin * 11)+12, (6 * margin) + 2);
            e.Graphics.DrawLine(Pens.Black, (margin * 15) + 5, 3* preHeights - 2*margin, (margin * 15) + 5, e.PageBounds.Height - margin - preHeights + 88);
            e.Graphics.DrawString("SubTotal", f, Brushes.Black, (margin * 16), (6 * margin) + 2);
            e.Graphics.DrawLine(Pens.Black, (margin * 15) + 5, 3 * preHeights - 2* margin, (margin * 15) + 5, e.PageBounds.Height - margin - preHeights + 88);
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            float rowsHeight = 60;
            for(int x=0;x<dataGridView3.Rows.Count;x++)
            {
                e.Graphics.DrawString(dataGridView3.Rows[x].Cells[0].Value.ToString(), f, Brushes.Navy, margin*2,preHeights+rowsHeight+2*colHeight);
                e.Graphics.DrawString(dataGridView3.Rows[x].Cells[1].Value.ToString(), f, Brushes.Navy, margin * 9, preHeights + rowsHeight + 2 * colHeight);
                e.Graphics.DrawString(dataGridView3.Rows[x].Cells[2].Value.ToString(), f, Brushes.Navy, (margin * 13)-6, preHeights + rowsHeight + 2 * colHeight);
                e.Graphics.DrawString(dataGridView3.Rows[x].Cells[3].Value.ToString(), f, Brushes.Navy, margin * 17, preHeights + rowsHeight + 2 * colHeight);
                e.Graphics.DrawLine(Pens.Black, margin, margin+preHeights+rowsHeight+colHeight+60, e.PageBounds.Width - margin, margin+preHeights+rowsHeight+colHeight+60);
                rowsHeight += 60;
            }
            e.Graphics.DrawString("Total: ", f, Brushes.Red, (margin * 12)+4 , preHeights + rowsHeight + 2 * colHeight);
            e.Graphics.DrawString(txt_total.Text, f, Brushes.DarkGreen, margin * 17, preHeights + rowsHeight + 2 * colHeight);
            e.Graphics.DrawLine(Pens.Black, margin, margin + preHeights + rowsHeight + colHeight + 60, e.PageBounds.Width - margin, margin + preHeights + rowsHeight + colHeight + 60);
            e.Graphics.DrawString("Discount: ", f, Brushes.Red, (margin * 12)-2 , preHeights + rowsHeight + 3 * colHeight);
            e.Graphics.DrawString(txt_discount.Text, f, Brushes.DarkGreen, margin * 17, preHeights + rowsHeight + 3 * colHeight);
            e.Graphics.DrawLine(Pens.Black, margin, margin + preHeights + rowsHeight + colHeight + 125, e.PageBounds.Width - margin, margin + preHeights + rowsHeight + colHeight + 125);
        }

        private void dataGridView3_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            /*foreach(DataGridViewRow row in dataGridView3.Rows)
            {
                row.Cells[dataGridView3.Columns["colsubtotal"].Index].Value = (Convert.ToDouble(row.Cells[dataGridView3.Columns["pricecol"].Index].Value) * Convert.ToDouble(row.Cells[dataGridView3.Columns["qtycol"].Index].Value));
            }
             */
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_discount_TextChanged(object sender, EventArgs e)
        {

        }
        
    }
}
