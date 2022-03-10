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
    public partial class Add_Book : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        public Add_Book()
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
            b_title.Text = b_author.Text = b_cost.Text = b_description.Text = b_quantity.Text = b_sell.Text = "";
            comboBox1.SelectedItem = null;
            comboBox3.SelectedItem = null;
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
                            if (!string.IsNullOrWhiteSpace(b_description.Text))
                            {
                                cmd = new SqlCommand("Insert into Book(B_title,B_author,B_publisher,B_category,B_costprice,B_sellingprice,B_stock,B_description)" +
                                    $"values('{b_title.Text}','{b_author.Text}','{comboBox1.SelectedItem}','{comboBox3.SelectedItem}',{b_cost.Text},{b_sell.Text},{b_quantity.Text},'{b_description.Text}')", conn);
                            }
                            else
                            {
                                cmd = new SqlCommand("Insert into Book(B_title,B_author,B_publisher,B_category,B_costprice,B_sellingprice,B_stock,B_description)" +
                                   $"values('{b_title.Text}','{b_author.Text}','{comboBox1.SelectedItem}','{comboBox3.SelectedItem}',{b_cost.Text},{b_sell.Text},{b_quantity.Text},'NULL')", conn);

                            }
                            try
                            {
                                conn.Open();
                                SqlDataAdapter adapter = new SqlDataAdapter();
                                adapter.InsertCommand = cmd;
                                int res = adapter.InsertCommand.ExecuteNonQuery();
                                conn.Close();
                                MessageBox.Show($"{res} New Book is Registered..");

                                
                                
                                cmd = new SqlCommand($"SELECT IDENT_CURRENT('Book')+1", conn);
                                conn.Open();
                                var obj = cmd.ExecuteScalar();
                                conn.Close();
                                b_id.Text = (obj != null && !string.IsNullOrEmpty(obj.ToString())) ? obj.ToString() : "1";
                                b_title.Text = b_author.Text = b_cost.Text = b_description.Text = b_quantity.Text = b_sell.Text = "";
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
        //Add new book Category
        private void button2_Click(object sender, EventArgs e)
        {
            Add_Book_Category bk_cat = new Add_Book_Category();
            bk_cat.ShowDialog();
            read_from_db();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        //Add Publication
        private void button4_Click(object sender, EventArgs e)
        {
            Add_Publisher add_publi = new Add_Publisher();
            add_publi.ShowDialog();
            read_from_db();
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
                    comboBox1.Items.Add(reader.GetValue(0));
                }
                conn.Close();
                //ADD Saved Category in combobox
                cmd = new SqlCommand("Select C_name from Category", conn);
                conn.Open();
                reader = cmd.ExecuteReader();
                comboBox3.Items.Clear();
                while (reader.Read())
                {
                    comboBox3.Items.Add(reader.GetValue(0));
                }
                conn.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                conn.Close();
            }
        }
        private void Add_Book_Load(object sender, EventArgs e)

        {

            read_from_db();
            try
            {
                conn.Open();
                cmd = new SqlCommand($"SELECT IDENT_CURRENT('Book')+1", conn);
                var obj = cmd.ExecuteScalar();
                b_id.Text = (obj != null && !string.IsNullOrEmpty(obj.ToString())) ? obj.ToString() : "1";
                conn.Close();
                b_title.Text = b_author.Text = b_cost.Text = b_description.Text = b_quantity.Text = b_sell.Text = "";
                comboBox1.SelectedItem = null;
                comboBox3.SelectedItem = null;
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
                conn.Close();
            }
           
        }

        private void b_title_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("Select count(*) from Book where B_title='" + b_title.Text+"'", conn);
                conn.Open();
                var obj = cmd.ExecuteScalar();
                bool result = (obj != null && !string.IsNullOrEmpty(obj.ToString()) && (int)obj !=0) ? true :false;
                conn.Close();
                if (result)
                {
                    b_title.ForeColor = Color.Red;
                    save_btn.Enabled = false;
                }
                else
                {
                    b_title.ForeColor = Color.Black;
                    save_btn.Enabled = true;
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
                conn.Close();
            }
        }
    }
}
