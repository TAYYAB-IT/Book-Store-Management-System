
namespace BookStore.Forms
{
    partial class Report
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series16 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Year = new System.Windows.Forms.ComboBox();
            this.Month = new System.Windows.Forms.ComboBox();
            this.rad_month = new System.Windows.Forms.RadioButton();
            this.rad_year = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.se_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label3 = new System.Windows.Forms.Label();
            this.pl_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.sal = new System.Windows.Forms.Label();
            this.exp = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.se_chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pl_chart)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Teal;
            this.label4.Location = new System.Drawing.Point(341, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(247, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "RAJUSKO Book Store, Gujrat";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Teal;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 729);
            this.panel2.TabIndex = 47;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Teal;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.panel4.Location = new System.Drawing.Point(943, 10);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 729);
            this.panel4.TabIndex = 48;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Teal;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 739);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(953, 10);
            this.panel3.TabIndex = 49;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(953, 10);
            this.panel1.TabIndex = 46;
            // 
            // Year
            // 
            this.Year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Year.FormattingEnabled = true;
            this.Year.Location = new System.Drawing.Point(372, 102);
            this.Year.Name = "Year";
            this.Year.Size = new System.Drawing.Size(121, 21);
            this.Year.TabIndex = 50;
            this.Year.SelectedIndexChanged += new System.EventHandler(this.Year_SelectedIndexChanged);
            // 
            // Month
            // 
            this.Month.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Month.FormattingEnabled = true;
            this.Month.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.Month.Location = new System.Drawing.Point(521, 102);
            this.Month.Name = "Month";
            this.Month.Size = new System.Drawing.Size(121, 21);
            this.Month.TabIndex = 51;
            this.Month.SelectedIndexChanged += new System.EventHandler(this.Month_SelectedIndexChanged);
            // 
            // rad_month
            // 
            this.rad_month.AutoSize = true;
            this.rad_month.Checked = true;
            this.rad_month.Location = new System.Drawing.Point(261, 83);
            this.rad_month.Name = "rad_month";
            this.rad_month.Size = new System.Drawing.Size(55, 17);
            this.rad_month.TabIndex = 52;
            this.rad_month.TabStop = true;
            this.rad_month.Text = "Month";
            this.rad_month.UseVisualStyleBackColor = true;
            this.rad_month.CheckedChanged += new System.EventHandler(this.rad_month_CheckedChanged);
            // 
            // rad_year
            // 
            this.rad_year.AutoSize = true;
            this.rad_year.Location = new System.Drawing.Point(261, 106);
            this.rad_year.Name = "rad_year";
            this.rad_year.Size = new System.Drawing.Size(47, 17);
            this.rad_year.TabIndex = 53;
            this.rad_year.Text = "Year";
            this.rad_year.UseVisualStyleBackColor = true;
            this.rad_year.CheckedChanged += new System.EventHandler(this.rad_year_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(565, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "Month";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(422, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 55;
            this.label2.Text = "Year";
            // 
            // se_chart
            // 
            chartArea7.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea7.AxisY.Title = "Amount [PKR]";
            chartArea7.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea7.Name = "ChartArea1";
            this.se_chart.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            this.se_chart.Legends.Add(legend7);
            this.se_chart.Location = new System.Drawing.Point(175, 170);
            this.se_chart.Name = "se_chart";
            this.se_chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series13.ChartArea = "ChartArea1";
            series13.Legend = "Legend1";
            series13.Name = "Sale";
            series13.YValuesPerPoint = 2;
            series14.ChartArea = "ChartArea1";
            series14.Legend = "Legend1";
            series14.Name = "Expense";
            series14.YValuesPerPoint = 4;
            this.se_chart.Series.Add(series13);
            this.se_chart.Series.Add(series14);
            this.se_chart.Size = new System.Drawing.Size(594, 215);
            this.se_chart.TabIndex = 56;
            this.se_chart.Text = "chart1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Teal;
            this.label3.Location = new System.Drawing.Point(434, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 57;
            this.label3.Text = "Month";
            // 
            // pl_chart
            // 
            chartArea8.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea8.AxisY.Title = "Amount [PKR]";
            chartArea8.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea8.Name = "ChartArea1";
            this.pl_chart.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.pl_chart.Legends.Add(legend8);
            this.pl_chart.Location = new System.Drawing.Point(175, 406);
            this.pl_chart.Name = "pl_chart";
            this.pl_chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            series15.ChartArea = "ChartArea1";
            series15.Legend = "Legend1";
            series15.Name = "Profit";
            series16.ChartArea = "ChartArea1";
            series16.Legend = "Legend1";
            series16.Name = "Loss";
            this.pl_chart.Series.Add(series15);
            this.pl_chart.Series.Add(series16);
            this.pl_chart.Size = new System.Drawing.Size(594, 212);
            this.pl_chart.TabIndex = 58;
            this.pl_chart.Text = "chart1";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(888, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 30);
            this.button1.TabIndex = 59;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(843, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 17);
            this.label5.TabIndex = 60;
            this.label5.Text = "Sale";
            // 
            // sal
            // 
            this.sal.AutoSize = true;
            this.sal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sal.ForeColor = System.Drawing.Color.Green;
            this.sal.Location = new System.Drawing.Point(843, 222);
            this.sal.Name = "sal";
            this.sal.Size = new System.Drawing.Size(40, 17);
            this.sal.TabIndex = 61;
            this.sal.Text = "Sale";
            // 
            // exp
            // 
            this.exp.AutoSize = true;
            this.exp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exp.ForeColor = System.Drawing.Color.Green;
            this.exp.Location = new System.Drawing.Point(843, 312);
            this.exp.Name = "exp";
            this.exp.Size = new System.Drawing.Size(69, 17);
            this.exp.TabIndex = 63;
            this.exp.Text = "Expense";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(843, 278);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 17);
            this.label7.TabIndex = 62;
            this.label7.Text = "Expense";
            // 
            // pl
            // 
            this.pl.AutoSize = true;
            this.pl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pl.ForeColor = System.Drawing.Color.Green;
            this.pl.Location = new System.Drawing.Point(813, 443);
            this.pl.Name = "pl";
            this.pl.Size = new System.Drawing.Size(32, 17);
            this.pl.TabIndex = 64;
            this.pl.Text = "P/L";
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 749);
            this.ControlBox = false;
            this.Controls.Add(this.pl);
            this.Controls.Add(this.exp);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.sal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pl_chart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.se_chart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rad_year);
            this.Controls.Add(this.rad_month);
            this.Controls.Add(this.Month);
            this.Controls.Add(this.Year);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Name = "Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.se_chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pl_chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox Year;
        private System.Windows.Forms.ComboBox Month;
        private System.Windows.Forms.RadioButton rad_month;
        private System.Windows.Forms.RadioButton rad_year;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart se_chart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart pl_chart;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label sal;
        private System.Windows.Forms.Label exp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label pl;
    }
}