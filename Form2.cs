using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Restaurant_M_S
{
    public partial class Form2 : Form
    {
        System.Timers.Timer t;
        int h, m, s;
        public Form2()
        {
            InitializeComponent();
        }

        private void Timer_TextChanged(object sender, EventArgs e)
        {

        }

        private void Start_Click(object sender, EventArgs e)
        {
            t.Start();
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            t.Stop();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            t.Stop();
            Application.DoEvents();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            t = new System.Timers.Timer();
            t.Interval = 1000; //1s
            t.Elapsed += OnTimerEvent;
        }

        private void OnTimerEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                if (s == 60)
                {
                    s = 0;
                    m += 1;
                }
                if (m == 60)
                {
                    m = 0;
                    h += 1;
                }
                Timer.Text = string.Format("{0}", "{1}", "{2}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));

            }));
        }
    }
}
