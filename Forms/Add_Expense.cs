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
    public partial class Add_Expense : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        public Add_Expense()
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void e_title_TextChanged(object sender, EventArgs e)
        {
            if (e_title.Text.Length <= 5 ||e_title.Text.Length>20)
            {
                btnsave.Enabled = false;
                e_title.ForeColor = Color.Red;

            }
            else
            {
                btnsave.Enabled = true;
                e_title.ForeColor = Color.Black;
            }
        }

        private void e_amount_TextChanged(object sender, EventArgs e)
        {
            int n;
            if (!Int32.TryParse(e_amount.Text, out n))
            {
                btnsave.Enabled = false;
                e_amount.ForeColor = Color.Red;
            }
            else
            {
                if (n > 0)
                {
                    btnsave.Enabled = true;
                    e_amount.ForeColor = Color.Black;
                }
                else
                {
                    btnsave.Enabled = false;
                    e_amount.ForeColor = Color.Red;
                }
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(e_title.Text) || string.IsNullOrWhiteSpace(e_amount.Text))
            {
                MessageBox.Show("Something Missing!");
            }
            else 
            {
                e_description.Text = (!string.IsNullOrWhiteSpace(e_description.Text)) ? e_description.Text : "NULL";
                cmd = new SqlCommand($"Insert into Expense(E_title,E_amount,E_date,E_description) values('{e_title.Text}',{e_amount.Text},'{dateTimePicker1.Value.ToString("d")}','{e_description.Text}')",conn);
                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.InsertCommand = cmd;
                    int res = adapter.InsertCommand.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show($"{res} new Expense is Added!");
                    e_title.Text = e_amount.Text = e_description.Text = "";
                    dateTimePicker1.Value = DateTime.Now;
                }
                catch(Exception err)
                {
                    MessageBox.Show(err.Message);
                    conn.Close();
                }
            }
        }
    }
}
