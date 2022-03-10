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

namespace BookStore.UC
{
    public partial class ViewSales_UC : UserControl
    {
        SqlConnection conn;
        SqlCommand cmd;
        public ViewSales_UC()
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

        private void ViewSales_UC_Load(object sender, EventArgs e)
        {
            read_expenses();
        }
        //Read From Database
        private void read_expenses()
        {
            int n = 0;
            try
            {
                conn.Open();
                cmd = new SqlCommand("Select S_id,net_amount,net_discount,net_amount-net_discount AS total_amount,S_date From Sale Order BY S_date desc ", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(4));
                    n += Int32.Parse(reader.GetValue(3).ToString());
                }
                conn.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                conn.Close();
            }
            label1.Text = $"Total Sale: {n} PKR";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            dateTimePicker1.Visible=false;
            dataGridView1.Rows.Clear();
            read_expenses();

        }

        //Read expense from Database by Date
        private void read_expenses(string date)
        {
            int n = 0;
            try
            {
                dataGridView1.Rows.Clear();
                conn.Open();
                cmd = new SqlCommand($"Select S_id,net_amount,net_discount,net_amount-net_discount AS total_amount,S_date From Sale Where S_date='{date}'", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(4));
                    n += Int32.Parse(reader.GetValue(3).ToString());
                }
                conn.Close();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                conn.Close();
            }
            label1.Text = $"Total Sale: {n} PKR";
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                dateTimePicker1.Visible = false;
                dataGridView1.Rows.Clear();
                read_expenses();
            }
            else
            {
                dateTimePicker1.Visible = true;

                DateTime dt = dateTimePicker1.Value;
                read_expenses(dt.ToString("d"));
                
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt = dateTimePicker1.Value;
            read_expenses(dt.ToString("d"));
        }
    }
}
