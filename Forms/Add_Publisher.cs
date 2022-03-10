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
    public partial class Add_Publisher : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        public Add_Publisher()
        {
            InitializeComponent();
            btn_save.Enabled = false;
            try
            {
                conn = new SqlConnection(@"Data Source=DESKTOP-OGKQFUH\SQLEXPRESS;Initial Catalog=BookStore;Integrated Security=true");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text) || textBox2.Text.Length < 6)
            {
                MessageBox.Show("Publisher Name Must be at least of 6 Length!");
            }
            else
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(richTextBox1.Text))
                    {
                        cmd = new SqlCommand($"Insert into Publisher(P_name,P_details) values ('{textBox2.Text}',NULL)", conn);
                    }
                    else
                    {
                        cmd = new SqlCommand($"Insert into Publisher(P_name,P_details) values ('{textBox2.Text}','{richTextBox1.Text}')", conn);

                    }
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.InsertCommand = cmd;
                    MessageBox.Show(adapter.InsertCommand.ExecuteNonQuery().ToString() + "new Record is Added!");
                    conn.Close();
                    textBox2.Text = richTextBox1.Text = "";
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                    conn.Close();
                }
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            cmd = new SqlCommand($"Select count(*) from Publisher where P_name='{textBox2.Text}'", conn);
            try
            {
                conn.Open();
                var obj = cmd.ExecuteScalar();
                bool result = (obj != null && !string.IsNullOrWhiteSpace(obj.ToString()) && Int32.Parse(obj.ToString()) != 0) ? true : false;
                if (result)
                {
                    msg.Visible = true;
                    btn_save.Enabled = false;
                }
                else
                {
                    msg.Visible = false;
                    btn_save.Enabled = true;
                }
                conn.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                conn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }

}
