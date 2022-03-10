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
    public partial class Update_Book : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        public Update_Book(string b_id,string b_title,string b_author,string b_quantity,string b_pub,string b_cata,string b_cost,string b_price,string desc)
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
            read_from_db(); //publisher
            read_from_db2(); //catagory
            this.b_id.Text = b_id;
            this.b_title.Text = b_title;
            this.b_author.Text = b_author;
            this.b_quantity.Text = b_quantity;
            this.b_sell.Text = b_price;
            this.b_cost .Text= b_cost;
            this.b_description.Text = desc;
            comboBox1.SelectedItem=b_pub.Trim();
            comboBox3.SelectedItem = b_cata.Trim();
           // MessageBox.Show(comboBox1.FindStringExact(b_pub.Trim()) + " & "+comboBox1.SelectedItem);
          
        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void save_btn_Click(object sender, EventArgs e)
        {

            int n, m, o, p;
            if (string.IsNullOrWhiteSpace(b_title.Text) || string.IsNullOrWhiteSpace(b_author.Text) || string.IsNullOrWhiteSpace(b_quantity.Text) || string.IsNullOrWhiteSpace(b_sell.Text) || string.IsNullOrWhiteSpace(b_cost.Text) || comboBox1.SelectedItem == null || comboBox3.SelectedItem == null)
            {
                MessageBox.Show("Something Missing!");
            }
            else if (Int32.TryParse(b_quantity.Text, out n))
            {
                if (n <= 0) { MessageBox.Show("Quantity is invalid!"); }
                else if (Int32.TryParse(b_sell.Text, out o))
                {
                    if (o <= 0) { MessageBox.Show("Selling Price is invalid!"); }
                    else if (Int32.TryParse(b_cost.Text, out p))
                    {
                        if (p <= 0) { MessageBox.Show("Cost Price is invalid!"); }
                        else if (p > Int32.Parse(b_sell.Text)) { MessageBox.Show("Cost Price is Greater than Selling Price"); }
                        else
                        {
                            string q = "";
                            if (!string.IsNullOrWhiteSpace(b_description.Text))
                            {
                                q = $"Update Book Set B_title='{b_title.Text}',B_author='{b_author.Text}',B_publisher='{comboBox1.SelectedItem}',B_category='{comboBox3.SelectedItem}',B_costprice={b_cost.Text},B_sellingprice={b_sell.Text},B_stock={b_quantity.Text},B_description='{b_description.Text}' where B_id={b_id.Text}";
                              
                            }
                            else
                            {
                                q = $"Update Book Set B_title='{b_title.Text}',B_author='{b_author.Text}',B_publisher='{comboBox1.SelectedItem}',B_category='{comboBox3.SelectedItem}',B_costprice={b_cost.Text},B_sellingprice={b_sell.Text},B_stock={b_quantity.Text},B_description='NULL' where B_id={b_id.Text}";
    
                            }
                            try
                            {
                                cmd = new SqlCommand(q, conn);
                               // MessageBox.Show(q);
                                conn.Open();
                                SqlDataAdapter adapter = new SqlDataAdapter();
                                adapter.UpdateCommand = cmd;
                                int res = adapter.UpdateCommand.ExecuteNonQuery();
                                conn.Close();
                                MessageBox.Show($"{res} Book is Updated..");

                               b_id.Text= b_title.Text = b_author.Text = b_cost.Text = b_description.Text = b_quantity.Text = b_sell.Text = "";
                                comboBox1.SelectedItem = null;
                                comboBox3.SelectedItem = null;


                            }
                            catch (Exception err)
                            {
                                MessageBox.Show(err.Message);
                                conn.Close();
                            }
                        }
                    }


                }
            }
            else if (!Int32.TryParse(b_quantity.Text, out m)) { MessageBox.Show("Quantity is invalid!"); }

            //else if (!Int32.TryParse(b_sell.Text, out n)) { MessageBox.Show("Selling Price invalid!"); }

            //  else if (!Int32.TryParse(b_cost.Text, out n)) { MessageBox.Show("Cost Price is invalid!"); }



        }
        //Read Publisher & Category From DB
        private void read_from_db()
        {
            try
            {
                //ADD Saved Publisher in combobox
                cmd = new SqlCommand("Select P_name from Publisher", conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                comboBox1.Items.Clear();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader.GetValue(0).ToString().Trim());
                }
                conn.Close();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                conn.Close();
            }

        }

        //ADD Saved Category in combobox
        private void read_from_db2()
        {
            try
            {
                cmd = new SqlCommand("Select C_name from Category", conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                comboBox3.Items.Clear();
                while (reader.Read())
                {
                    comboBox3.Items.Add(reader.GetValue(0).ToString().Trim());
                }
                conn.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                conn.Close();
            }
        }
        //Add Publisher
        private void button4_Click(object sender, EventArgs e)
        {
            Add_Publisher add_publi = new Add_Publisher();
            add_publi.ShowDialog();
            read_from_db();
        }
        //Add Catagory
        private void button2_Click(object sender, EventArgs e)
        {
            Add_Book_Category bk_cat = new Add_Book_Category();
            bk_cat.ShowDialog();
            read_from_db2();
        }

        


    }
}
