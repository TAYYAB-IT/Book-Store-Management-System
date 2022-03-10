using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookStore.Forms;
using System.Data.SqlClient;
namespace BookStore.UC
{
    public partial class Stock_UC : UserControl
    {
        DataTable table1 = new DataTable();
       
        SqlConnection conn;
        SqlCommand cmd;
        int selected_row = -1;
        public Stock_UC()
        {
            InitializeComponent();
            
            table1.Columns.Add("Tracking ID");
            table1.Columns.Add("Book Title");
            table1.Columns.Add("Author");
            table1.Columns.Add("Category");
            table1.Columns.Add("Publisher");
            table1.Columns.Add("Quantity");
            table1.Columns.Add("Cost Price");
            table1.Columns.Add("Selling Price");
            table1.Columns.Add("Description");

            dataGridView1.DataSource = this.table1;

            try
            {
                conn = new SqlConnection(@"Data Source=DESKTOP-OGKQFUH\SQLEXPRESS;Initial Catalog=BookStore;Integrated Security=true");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnAddNewBooks_Click(object sender, EventArgs e)
        {
            Add_Book add_book = new Add_Book();
            add_book.ShowDialog();
            read_data();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Add_Stock add_Stock = new Add_Stock();
            add_Stock.ShowDialog();
            read_data();
        }

        //Read Books Data From DB
        private void read_data()
        {
            try
            {
                this.table1.Rows.Clear();
                conn.Open();
                cmd = new SqlCommand("Select Book.B_id,Book.B_title,Book.B_Author,Category.C_name,Publisher.P_name,Book.B_stock,Book.B_costprice,Book.B_sellingprice,Book.B_description From ((Book inner join Category on Category.C_Name=Book.B_category) inner join Publisher on Publisher.P_name=Book.B_publisher)", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DataRow row = this.table1.NewRow();
                    row["Tracking ID"] = reader.GetValue(0);
                    row["Book Title"] = reader.GetValue(1);
                    row["Author"] = reader.GetValue(2);
                    row["Category"] = reader.GetValue(3);
                    row["Publisher"] = reader.GetValue(4);
                    row["Quantity"] = reader.GetValue(5);
                    row["Cost Price"] = reader.GetValue(6);
                    row["Selling Price"] = reader.GetValue(7);
                    row["Description"] = reader.GetValue(8);
                    this.table1.Rows.Add(row);
                }
                
                
                dataGridView1.Refresh();
                conn.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                conn.Close();
            }
        }
        //
        private void read_selective()
        {
            //All
            if (comboBox2.SelectedIndex == 0)
            {
                //cmd = new SqlCommand("Select Book.B_id,Book.B_title,Book.B_Author,Category.C_name,Publisher.P_name,Book.B_stock,Book.B_costprice,Book.B_sellingprice From ((Book inner join Category on Category.C_Name=Book.B_category) inner join Publisher on Publisher.P_name=Book.B_publisher)", conn);
                read_data();

            }

            if (!string.IsNullOrWhiteSpace(textBox7.Text))
            {
                int n;

                switch (comboBox2.SelectedIndex)
                {


                    // BY Tracking ID
                    case 1:
                        
                        if (Int32.TryParse(textBox7.Text, out n))
                        {
                            try
                            {
                               
                                cmd = new SqlCommand($"Select Book.B_id,Book.B_title,Book.B_Author,Category.C_name,Publisher.P_name,Book.B_stock,Book.B_costprice,Book.B_sellingprice From ((Book inner join Category on Category.C_Name=Book.B_category) inner join Publisher on Publisher.P_name=Book.B_publisher) where Book.B_id={n}", conn);
                               

                            }
                            catch (Exception err)
                            {
                                MessageBox.Show(err.Message);
                            }
                        }

                        break;

                    // By Book Title
                    case 2:
                        try
                        {
                            
                           
                            cmd = new SqlCommand($"Select Book.B_id,Book.B_title,Book.B_Author,Category.C_name,Publisher.P_name,Book.B_stock,Book.B_costprice,Book.B_sellingprice From ((Book inner join Category on Category.C_Name=Book.B_category) inner join Publisher on Publisher.P_name=Book.B_publisher) where Book.B_title='{textBox7.Text}'", conn);


                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message);
                        }
                        break;

                    //By Author Name
                    case 3:
                        try
                        {
                           
                            
                            cmd = new SqlCommand($"Select Book.B_id,Book.B_title,Book.B_Author,Category.C_name,Publisher.P_name,Book.B_stock,Book.B_costprice,Book.B_sellingprice From ((Book inner join Category on Category.C_Name=Book.B_category) inner join Publisher on Publisher.P_name=Book.B_publisher) where Book.B_Author='{textBox7.Text}'", conn);


                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message);
                        }
                        break;
                    //By Publisher
                    case 4:
                        try
                        {
                            
                           
                            cmd = new SqlCommand($"Select Book.B_id,Book.B_title,Book.B_Author,Category.C_name,Publisher.P_name,Book.B_stock,Book.B_costprice,Book.B_sellingprice From ((Book inner join Category on Category.C_Name=Book.B_category) inner join Publisher on Publisher.P_name=Book.B_publisher) where Publisher.P_name='{textBox7.Text}'", conn);


                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message);
                        }
                        break;
                    //By Category
                    case 5:
                        try
                        {
                            
                           
                            cmd = new SqlCommand($"Select Book.B_id,Book.B_title,Book.B_Author,Category.C_name,Publisher.P_name,Book.B_stock,Book.B_costprice,Book.B_sellingprice From ((Book inner join Category on Category.C_Name=Book.B_category) inner join Publisher on Publisher.P_name=Book.B_publisher) where Category.C_Name='{textBox7.Text}'", conn);


                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message);
                        }
                        break;
                    default:
                        
                        cmd = new SqlCommand("Select Book.B_id,Book.B_title,Book.B_Author,Category.C_name,Publisher.P_name,Book.B_stock,Book.B_costprice,Book.B_sellingprice From ((Book inner join Category on Category.C_Name=Book.B_category) inner join Publisher on Publisher.P_name=Book.B_publisher)", conn);

                        break;
                }
                try
                {


                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    this.table1.Rows.Clear();
                    while (reader.Read())
                    {
                        DataRow row = this.table1.NewRow();
                        row["Tracking ID"] = reader.GetValue(0);
                        row["Book Title"] = reader.GetValue(1);
                        row["Author"] = reader.GetValue(2);
                        row["Category"] = reader.GetValue(3);
                        row["Publisher"] = reader.GetValue(4);
                        row["Quantity"] = reader.GetValue(5);
                        row["Cost Price"] = reader.GetValue(6);
                        row["Selling Price"] = reader.GetValue(7);
                        this.table1.Rows.Add(row);
                    }


                    dataGridView1.Refresh();
                    conn.Close();

                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                    conn.Close();
                }

            }
        }
        private void Stock_UC_Load(object sender, EventArgs e)
        {
            
            read_data();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            read_selective();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            read_selective();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (selected_row == -1)
            {
                MessageBox.Show("Select First!");
            }
            else
            {
                Update_Book frm = new Update_Book(dataGridView1.Rows[selected_row].Cells[0].Value.ToString(), dataGridView1.Rows[selected_row].Cells[1].Value.ToString(), dataGridView1.Rows[selected_row].Cells[2].Value.ToString(), dataGridView1.Rows[selected_row].Cells[5].Value.ToString(), dataGridView1.Rows[selected_row].Cells[4].Value.ToString(), dataGridView1.Rows[selected_row].Cells[3].Value.ToString(), dataGridView1.Rows[selected_row].Cells[6].Value.ToString(), dataGridView1.Rows[selected_row].Cells[7].Value.ToString(), dataGridView1.Rows[selected_row].Cells[8].Value.ToString());

                frm.ShowDialog();
                selected_row = -1;
              
                read_data();
              
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White;
            }

            selected_row = e.RowIndex;
            dataGridView1.Rows[selected_row].DefaultCellStyle.BackColor = Color.Teal;

        }
    }
}
