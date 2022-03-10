using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BookStore.Forms
{
    public partial class Report : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        public Report()
        {
            InitializeComponent();
            try
            {
                conn = new SqlConnection(@"Data Source=DESKTOP-OGKQFUH\SQLEXPRESS;Initial Catalog=BookStore;Integrated Security=true");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label3.Text = $"Month: {DateTime.Now.Month}-{DateTime.Now.Year}";
            SE_month_year(DateTime.Now.Month, DateTime.Now.Year);
            PL_month_year(DateTime.Now.Month, DateTime.Now.Year);
            cmd = new SqlCommand($"Select  distinct Year(S_date) As year from Sale Union Select distinct Year(E_date) As year from Expense", conn);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                   // MessageBox.Show($"{reader.GetValue(0)}");
                    Year.Items.Add(reader.GetValue(0).ToString());
                }
                conn.Close();
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
                conn.Close();
            }
        }
        //Sale-Expense chart by Month-year
        private void SE_month_year(int month,int year)
        {
            try
            {
                cmd = new SqlCommand($"Select sum(net_amount-net_discount)  from Sale where YEAR(S_date)={year} and MONTH(S_date)={month};",conn);
                conn.Open();
                var obj = cmd.ExecuteScalar();
                conn.Close();
                sal.Visible = true;
                if (obj != null && !string.IsNullOrWhiteSpace(obj.ToString()))
                {
                    sal.Text = $"{(int)obj} PKR";
                }
                else
                {
                    sal.Text = $"{00} PKR";
                }
                cmd = new SqlCommand($"Select Sum(E_amount) as Expense from Expense where Year(E_date)={year} AND MONTH(E_date)={month};", conn);
                conn.Open();
                 obj = cmd.ExecuteScalar();
                conn.Close();
                exp.Visible = true;
                if (obj != null && !string.IsNullOrWhiteSpace(obj.ToString()))
                {
                    exp.Text = $"{(int)obj} PKR";
                }
                else
                {
                    exp.Text = $"{00} PKR";
                }
                se_chart.Series["Sale"].Points.Clear();
                se_chart.Series["Expense"].Points.Clear();
                se_chart.ChartAreas[0].AxisX.Title = "Date";
                string q = $"Select Day(S_date) as Date,Sum(net_amount-net_discount) as Sale from Sale where Year(S_date)={year} AND Month(S_date)={month} group by S_date";
                cmd = new SqlCommand(q, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    se_chart.Series["Sale"].Points.AddXY(reader.GetValue(0), reader.GetValue(1));
                }
                conn.Close();
                 q = $"Select Day(E_date) as Date,Sum(E_amount) as Expense from Expense where Year(E_date)={year} AND Month(E_date)={month} group by E_date";
                cmd = new SqlCommand(q, conn);
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    se_chart.Series["Expense"].Points.AddXY(reader.GetValue(0), reader.GetValue(1));
                }
                conn.Close();


            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
                conn.Close();
            }
        }


        //Profit-Loss chart by Month-year
        private void PL_month_year(int month,int year)
        {
            DataTable table1 = new DataTable();
            DataTable table2 = new DataTable();
            string q;
            SqlDataReader reader;
            try
            {
                 cmd = new SqlCommand($"Select sum(net_amount-net_discount-actual_cost)-(Select sum(E_amount) from Expense where Year(E_date)={year} and Month(E_date)={month}) as res from Sale where YEAR(S_date)={year} and Month(S_date)={month};",conn);
                conn.Open();
                var obj =cmd.ExecuteScalar();
                conn.Close();
                
                if (obj != null && !string.IsNullOrWhiteSpace(obj.ToString()))
                {
                    pl.Visible = true;
                    if (Int32.Parse(obj.ToString()) > 0)
                    {
                        pl.ForeColor = Color.GreenYellow;
                        pl.Text = $"Profit={obj.ToString()} PKR";
                    }
                    else
                    {
                        pl.ForeColor = Color.Red;
                        pl.Text = $"Loss={Math.Abs((int)obj)} PKR";
                    }
                }
                else
                {
                    pl.Visible = false;
                }
                
                pl_chart.Series["Profit"].Points.Clear();
                pl_chart.Series["Loss"].Points.Clear();
                pl_chart.ChartAreas[0].AxisX.Title = "Date";
                
                 q = $"Select Day(S_date) as Date,SUM((net_amount-net_discount)-actual_cost) as Sale from Sale where Year(S_date)={year} AND Month(S_date)={month} group by Day(S_date )";
                cmd = new SqlCommand(q, conn);
                conn.Open();
                reader = cmd.ExecuteReader();
                table1.Load(reader); //Sales Load
                conn.Close();
                //
                
                q = $"Select Day(E_date) as Date,SUM(E_amount) as Expense  from Expense where Year(E_date)={year} AND Month(E_date)={month} group by Day(E_date) ";
                cmd = new SqlCommand(q, conn);
                conn.Open();
                reader = cmd.ExecuteReader();
                table2.Load(reader); //Expenses Load
                conn.Close();

                //
               
                if (table1.Rows.Count >= table2.Rows.Count)
                    
                {
                    bool chk_i = false;
                    foreach (DataRow row in table1.Rows)
                    {
                        int sal = 0, exp = 0;
                        
                        bool chk = false;
                        sal = Int32.Parse(row["Sale"].ToString());
                        foreach (DataRow row2 in table2.Rows)
                        {

                            exp = Int32.Parse(row2["Expense"].ToString());
                           
                            if (Int32.Parse(row["Date"].ToString()) == Int32.Parse(row2["Date"].ToString()))
                            {
                               
                                if (sal > exp)
                                {
                                    pl_chart.Series["Profit"].Points.AddXY(row["Date"], sal - exp);
                                }
                                else
                                {
                                    pl_chart.Series["Loss"].Points.AddXY(row["Date"], exp-sal);
                                    
                                }
                                chk = true;
                            }
                            else if(!chk_i)
                            {
                                bool i = false;
                                foreach (DataRow record in table1.Rows)
                                {
                                    if (Int32.Parse(record["Date"].ToString()) != Int32.Parse(row2["Date"].ToString()))
                                    {
                                        i = true;
                                        break;
                                    }
                                    
                                }
                                if (!i)
                                {
                                    pl_chart.Series["Loss"].Points.AddXY(row2["Date"], exp);
                                }
                                
                            }
                            
                        }
                        chk_i = true;
                        if (!chk)
                        {

                            pl_chart.Series["Profit"].Points.AddXY(row["Date"], sal);
                        }
                    }
                }
                else
                {
                    bool chk_i = false;
                    foreach (DataRow row in table2.Rows) //Expenses
                    {
                        int sal = 0, exp = 0;
                        bool chk = false;
                        exp = Int32.Parse(row["Expense"].ToString());
                        foreach (DataRow row2 in table1.Rows)  //Sales
                        {
                            sal = Int32.Parse(row2["Sale"].ToString());
                            if (Int32.Parse(row["Date"].ToString()) == Int32.Parse(row2["Date"].ToString()))
                            {
                                //MessageBox.Show($"Here {row["Expense"]} and {row2["Sale"]}");
                                if (sal >= exp)
                                {
                                    pl_chart.Series["Profit"].Points.AddXY(row2["Date"], sal - exp);
                                }
                                else
                                {
                                    
                                    pl_chart.Series["Loss"].Points.AddXY(row["Date"], exp - sal);
                                }
                                chk = true;
                            }
                            else if(!chk_i)
                            {
                                bool i = false;
                                foreach (DataRow record in table1.Rows)
                                {
                                    if (Int32.Parse(record["Date"].ToString()) != Int32.Parse(row2["Date"].ToString()))
                                    {
                                        i = true;
                                        break;
                                    }

                                }
                                if (!i)
                                {
                                    pl_chart.Series["Loss"].Points.AddXY(row2["Date"], exp);
                                }
                            }

                        }
                        chk_i = true;
                        if (!chk)
                        {
                            pl_chart.Series["Loss"].Points.AddXY(row["Date"], exp);
                        }
                    }
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
                conn.Close();
            }
        }


        //Sale_Expense By Year
        private void SE_month_year( int year)
        {
            try
            {
                cmd = new SqlCommand($"Select sum(net_amount-net_discount) as Sale from Sale where YEAR(S_date)={year} ;", conn);
                conn.Open();
                var obj = cmd.ExecuteScalar();
                conn.Close();
                sal.Visible = true;
                if (obj != null && !string.IsNullOrWhiteSpace(obj.ToString()))
                {
                    sal.Text = $"{(int)obj} PKR";
                }
                else
                {
                    sal.Text = $"{00} PKR";
                }
                cmd = new SqlCommand($"Select Sum(E_amount) as Expense from Expense where Year(E_date)={year} ;", conn);
                conn.Open();
                obj = cmd.ExecuteScalar();
                conn.Close();
                exp.Visible = true;
                if (obj != null && !string.IsNullOrWhiteSpace(obj.ToString()))
                {
                    exp.Text = $"{(int)obj} PKR";
                }
                else
                {
                    exp.Text = $"{00} PKR";
                }
                se_chart.Series["Sale"].Points.Clear();
                se_chart.Series["Expense"].Points.Clear();
                se_chart.ChartAreas[0].AxisX.Title = "Month";
                string q = $"Select Month(S_date) as Month,Sum(net_amount-net_discount) as Sale from Sale where Year(S_date)={year}group by Month(S_date)";
                cmd = new SqlCommand(q, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    se_chart.Series["Sale"].Points.AddXY(reader.GetValue(0), reader.GetValue(1));
                }
                conn.Close();
                q = $"Select Month(E_date) as Month,Sum(E_amount) as Expense from Expense where Year(E_date)={year}  group by Month(E_date)";
                cmd = new SqlCommand(q, conn);
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    se_chart.Series["Expense"].Points.AddXY(reader.GetValue(0), reader.GetValue(1));
                }
                conn.Close();


            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                conn.Close();
            }
        }

        //Profit-Loss chart by year
        private void PL_month_year(int year)
        {
            
            DataTable table1 = new DataTable();
            DataTable table2 = new DataTable();
            string q;
            SqlDataReader reader;
            try
            {
                cmd = new SqlCommand($"Select sum(net_amount-net_discount-actual_cost)-(Select sum(E_amount) from Expense where Year(E_date)={year}) as res from Sale where YEAR(S_date)={year};",conn);
                conn.Open();
                var obj =cmd.ExecuteScalar();
                conn.Close();
                
                if (obj != null && !string.IsNullOrWhiteSpace(obj.ToString()))
                {
                    pl.Visible = true;
                    if (Int32.Parse(obj.ToString()) > 0)
                    {
                        pl.ForeColor = Color.GreenYellow;
                        pl.Text = $"Profit={obj.ToString()} PKR";
                    }
                    else
                    {
                        pl.ForeColor = Color.Red;
                        pl.Text = $"Loss={Math.Abs((int)obj)} PKR";
                    }
                }
                 else
                {
                    pl.Visible = false;
                }
                pl_chart.Series["Profit"].Points.Clear();
                pl_chart.Series["Loss"].Points.Clear();
                pl_chart.ChartAreas[0].AxisX.Title = "Month";

                q = $"Select Month(S_date) as Month,SUM((net_amount-net_discount)-actual_cost) as Sale from Sale where Year(S_date)={year}  group by Month(S_date)";
                cmd = new SqlCommand(q, conn);
                conn.Open();
                reader = cmd.ExecuteReader();
                table1.Load(reader); //Sales Load
                conn.Close();
                //

                q = $"Select Month(E_date) as Month,SUM(E_amount) as Expense  from Expense where Year(E_date)={year} group by Month(E_date) ";
                cmd = new SqlCommand(q, conn);
                conn.Open();
                reader = cmd.ExecuteReader();
                table2.Load(reader); //Expenses Load
                conn.Close();

                //

                if (table1.Rows.Count >= table2.Rows.Count)

                {
                    bool chk_i = false;
                    foreach (DataRow row in table1.Rows)
                    {
                        int sal = 0, exp = 0;

                        bool chk = false;
                        sal = Int32.Parse(row["Sale"].ToString());
                        foreach (DataRow row2 in table2.Rows)
                        {

                            exp = Int32.Parse(row2["Expense"].ToString());

                            if (Int32.Parse(row["Month"].ToString()) == Int32.Parse(row2["Month"].ToString()))
                            {

                                if (sal > exp)
                                {
                                    pl_chart.Series["Profit"].Points.AddXY(row["Month"], sal - exp);
                                }
                                else
                                {
                                    pl_chart.Series["Loss"].Points.AddXY(row["Month"], exp - sal);

                                }
                                chk = true;
                            }
                            else if (!chk_i)
                            {
                                bool i = false;
                                foreach (DataRow record in table1.Rows)
                                {
                                    if (Int32.Parse(record["Month"].ToString()) == Int32.Parse(row2["Month"].ToString()))
                                    {
                                        i = true;
                                        break;
                                    }

                                }
                                if (!i)
                                {
                                    pl_chart.Series["Loss"].Points.AddXY(row2["Month"], exp);
                                }

                            }

                        }
                        chk_i = true;
                        if (!chk)
                        {

                            pl_chart.Series["Profit"].Points.AddXY(row["Month"], sal);
                        }
                    }
                }
                else
                {
                    bool chk_i = false;
                    foreach (DataRow row in table2.Rows) //Expenses
                    {
                        int sal = 0, exp = 0;
                        bool chk = false;
                        exp = Int32.Parse(row["Expense"].ToString());
                        foreach (DataRow row2 in table1.Rows)  //Sales
                        {
                            sal = Int32.Parse(row2["Sale"].ToString());
                            if (Int32.Parse(row["Month"].ToString()) == Int32.Parse(row2["Month"].ToString()))
                            {
                                //MessageBox.Show($"Here {row["Expense"]} and {row2["Sale"]}");
                                if (sal >= exp)
                                {
                                    pl_chart.Series["Profit"].Points.AddXY(row2["Month"], sal - exp);
                                }
                                else
                                {

                                    pl_chart.Series["Loss"].Points.AddXY(row["Month"], exp - sal);
                                }
                                chk = true;
                            }
                            else if (!chk_i)
                            {
                                bool i = false;
                                foreach (DataRow record in table1.Rows)
                                {
                                    if (Int32.Parse(record["Month"].ToString()) == Int32.Parse(row2["Month"].ToString()))
                                    {
                                        i = true;
                                        break;
                                    }

                                }
                                if (!i)
                                {
                                    pl_chart.Series["Loss"].Points.AddXY(row2["Month"], exp);
                                }
                            }

                        }
                        chk_i = true;
                        if (!chk)
                        {
                            pl_chart.Series["Loss"].Points.AddXY(row["Month"], exp);
                        }
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void rad_year_CheckedChanged(object sender, EventArgs e)
        {
            if (rad_year.Checked)
            {
                Month.Visible = false;
                label1.Visible = false;

                handle_year();
            }
            else
            {
                Month.Visible = true;
                label1.Visible = true;

                handle_monthyear();
            }
        }

        //handle Year
        private void handle_year()
        {
            sal.Visible = exp.Visible = pl.Visible = false;
            if (Year.SelectedItem != null)
            {
                label3.Text = $"Year:{Year.SelectedItem}";
                SE_month_year(Int32.Parse(Year.Text));
                PL_month_year(Int32.Parse(Year.Text));
            }
            else
            {
                se_chart.Series["Sale"].Points.Clear();
                se_chart.Series["Expense"].Points.Clear();
                pl_chart.Series["Profit"].Points.Clear();
                pl_chart.Series["Loss"].Points.Clear();
            }
        }
        //handle month-year
        private void handle_monthyear()
        {
            sal.Visible = exp.Visible = pl.Visible = false;
            if (Month.SelectedItem!=null && Year.SelectedItem != null)
            {
                label3.Text = $"Month:{Month.SelectedItem}-{Year.SelectedItem}";
                SE_month_year(Int32.Parse(Month.Text),Int32.Parse(Year.Text));
                PL_month_year(Int32.Parse(Month.Text), Int32.Parse(Year.Text));
            }
            else
            {
                se_chart.Series["Sale"].Points.Clear();
                se_chart.Series["Expense"].Points.Clear();
                pl_chart.Series["Profit"].Points.Clear();
                pl_chart.Series["Loss"].Points.Clear();
            }
        }

        private void rad_month_CheckedChanged(object sender, EventArgs e)
        {
            if (rad_month.Checked) {

                handle_monthyear();
            }
        }

        private void Year_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rad_month.Checked)
            {
                handle_monthyear();
            }
            else
            {
                handle_year();
            }
        }

        private void Month_SelectedIndexChanged(object sender, EventArgs e)
        {
            handle_monthyear();
        }
    }
}
