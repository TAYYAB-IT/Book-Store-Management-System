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
    public partial class Add_Stock : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        public Add_Stock()
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

        private void b_id_TextChanged(object sender, EventArgs e)
        {
            dynamic_check();
        }
        private void dynamic_check()
        {
            if (string.IsNullOrWhiteSpace(b_id.Text))
            {
                btnsave.Enabled = false;
               b_title.Text= e_stock.Text = t_stock.Text = "";
            }
            else
            {
                cmd = new SqlCommand($"Select count(*) from Book where B_id={b_id.Text}", conn);
                try
                {
                    conn.Open();
                    var obj = cmd.ExecuteScalar();
                    conn.Close();
                    bool res = (obj != null && !string.IsNullOrWhiteSpace(obj.ToString()) && (int)obj != 0) ? true : false;
                    if (!res)
                    {
                        b_id.ForeColor = Color.Red;
                        btnsave.Enabled = false;
                        e_stock.Text = t_stock.Text = "";
                    }
                    else
                    {
                        b_id.ForeColor = Color.Black;
                        btnsave.Enabled = true;
                        cmd = new SqlCommand($"Select B_stock,B_title from Book where B_id={b_id.Text}", conn);
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            e_stock.Text = reader.GetValue(0).ToString();
                            b_title.Text = reader.GetValue(1).ToString();
                            if (!string.IsNullOrWhiteSpace(n_stock.Text))
                            {
                                t_stock.Text = $"{Int32.Parse(e_stock.Text) + Int32.Parse(n_stock.Text)}";
                               
                            }
                        }
                        conn.Close();
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                    conn.Close();
                }
            }
        }

        private void n_stock_TextChanged(object sender, EventArgs e)
        {
            dynamic_check();
        }

        private void btnsave_Click(object sender, EventArgs e)

        {
            int o, p;
            if (string.IsNullOrWhiteSpace(b_id.Text) || string.IsNullOrWhiteSpace(n_stock.Text) || string.IsNullOrWhiteSpace(b_cost.Text) || string.IsNullOrWhiteSpace(b_sell.Text))
            {
                MessageBox.Show("Something is Missing!");
            }
            else if (Int32.TryParse(b_sell.Text, out o))
            {
                if (o <= 0) { MessageBox.Show("Selling Price is invalid!"); }
                else if (Int32.TryParse(b_cost.Text, out p))
                {
                    if (p <= 0) { MessageBox.Show("Cost Price is invalid!"); }
                    else if (p > Int32.Parse(b_sell.Text)) { MessageBox.Show("Cost Price is Greater than Selling Price"); }
                    else
                    {
                        cmd = new SqlCommand($"update  Book set B_stock={t_stock.Text} where B_id={b_id.Text}",conn);
                        try
                        {
                            conn.Open();
                            SqlDataAdapter adapter = new SqlDataAdapter();
                            adapter.UpdateCommand = cmd;
                            int res = adapter.UpdateCommand.ExecuteNonQuery();
                            conn.Close();
                            MessageBox.Show($"{res} Existing Book Stock Added..");
                            b_id.Text =b_title.Text= b_sell.Text = b_cost.Text = t_stock.Text = e_stock.Text = n_stock.Text = "";
                        }
                        catch(Exception err)
                        {
                            MessageBox.Show(err.Message);
                            conn.Close();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Selling Price is invalid!");
            }
        }
    }
}
