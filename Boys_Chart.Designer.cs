namespace Restaurant_M_S
{
    partial class Boys_Chart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chart_boys = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart_boys)).BeginInit();
            this.SuspendLayout();
            // 
            // chart_boys
            // 
            this.chart_boys.BackColor = System.Drawing.Color.Peru;
            this.chart_boys.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chart_boys.BackImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            chartArea1.Name = "ChartArea1";
            chartArea1.ShadowColor = System.Drawing.Color.Gray;
            this.chart_boys.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_boys.Legends.Add(legend1);
            this.chart_boys.Location = new System.Drawing.Point(63, 32);
            this.chart_boys.Name = "chart_boys";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Area";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Orders";
            this.chart_boys.Series.Add(series1);
            this.chart_boys.Series.Add(series2);
            this.chart_boys.Size = new System.Drawing.Size(614, 347);
            this.chart_boys.TabIndex = 0;
            this.chart_boys.Text = "Boys_Chart";
            title1.Name = "Delivery Boys";
            this.chart_boys.Titles.Add(title1);
            // 
            // Boys_Chart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Restaurant_M_S.Properties.Resources.restaurant;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(729, 411);
            this.Controls.Add(this.chart_boys);
            this.Name = "Boys_Chart";
            this.Text = "Boys_Chart";
            this.Load += new System.EventHandler(this.Boys_Chart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart_boys)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_boys;
    }
}