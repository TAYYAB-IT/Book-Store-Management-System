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
    public partial class SaleBooks_UC : UserControl
    {
        SqlConnection conn;
        SqlCommand cmd;
        int selected_row=-1;
        int price;
        public SaleBooks_UC()
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

        private void finalize_order_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                Finalize_Order fin_order = new Finalize_Order(Int32.Parse(this.total_amt.Text), net_amount());
                fin_order.ShowDialog();

                if (fin_order.IsDisposed)
                {
                    SqlDataAdapter adapter;
                    int actual_cost = 0;
                  
                    try
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            int b_id = Int32.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                            int qt = Int32.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()); ;
                            cmd = new SqlCommand($"Update Book Set B_stock=B_stock-{qt} Where B_id={b_id}", conn);
                            conn.Open();

                            adapter = new SqlDataAdapter();
                            adapter.InsertCommand = cmd;
                            adapter.InsertCommand.ExecuteNonQuery();
                            //Add Actual_cost
                            cmd = new SqlCommand($"Select SUM(B_costprice*{qt}) from Book where B_id={b_id}", conn);
                            var obj = cmd.ExecuteScalar();
                            actual_cost += (obj != null && !string.IsNullOrWhiteSpace(obj.ToString())) ? Int32.Parse(obj.ToString()) : 0;
                            conn.Close();

                        }
                        
                        conn.Open();
                        int net_amt = net_amount();
                        cmd = new SqlCommand($"Insert into Sale(net_amount,net_discount,S_date,book_quantity,actual_cost) values({net_amt},{net_amt - Int32.Parse(total_amt.Text)},'{DateTime.Now.ToString("G")}',{total_quantity()},{actual_cost})", conn);
                        adapter = new SqlDataAdapter();
                        adapter.InsertCommand = cmd;
                        adapter.InsertCommand.ExecuteNonQuery();
                        conn.Close();
                        dataGridView1.Rows.Clear();
                        this.total_amt.Text = "00";
                        b_id.Text = b_author.Text = b_price.Text = b_publisher.Text = b_title.Text = "";
                        b_discount.Text = "0";
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                        conn.Close();
                    }

                }
            }
            else
            {
                MessageBox.Show("No Book in Cart");
            }
        }

        //Handle text changes
        private void handle_changes()
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
                    add_tocart.Enabled = false;
                    b_author.Text = b_price.Text = b_publisher.Text = b_title.Text = "";
                }

                else
                {
                    cmd = new SqlCommand($"Select B_stock from Book where B_id={b_id.Text}", conn);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    int stk = -1;
                    while (reader.Read())
                    {
                        stk = (int)reader.GetValue(0);
                    }
                    conn.Close();
                    if (stk == 0)
                    {
                        b_id.ForeColor = Color.Red;
                        add_tocart.Enabled = false;
                    }
                    else
                    {
                        b_id.ForeColor = Color.Black;
                        add_tocart.Enabled = true;
                        cmd = new SqlCommand($"Select B_title,B_author,B_publisher,B_sellingprice,B_costprice from Book where B_id={b_id.Text}", conn);
                        conn.Open();
                        reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            b_title.Text = reader.GetValue(0).ToString();
                            b_author.Text = reader.GetValue(1).ToString();
                            b_publisher.Text = reader.GetValue(2).ToString();
                            b_price.Text = reader.GetValue(3).ToString();
                            if (!string.IsNullOrWhiteSpace(b_discount.Text))
                            {
                                if (Int32.Parse(b_discount.Text) >=(int)reader.GetValue(3)-(int)reader.GetValue(4))
                                {
                                    b_discount.ForeColor = Color.Red;
                                    add_tocart.Enabled = false;
                                }
                                else
                                {
                                    add_tocart.Enabled = true;
                                    b_discount.ForeColor = Color.Black;
                                }
                            }
                            else
                            {
                                b_discount.Text = "0";
                            }
                        }
                        conn.Close();

                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                conn.Close();
            }
        }

        private void b_id_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(b_id.Text))
            {
                handle_changes();
            }
            else
            {
                b_author.Text = b_price.Text = b_publisher.Text = b_title.Text = "";
                b_discount .Text= "0";
            }
        }

        private void b_discount_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(b_discount.Text) &&!string.IsNullOrWhiteSpace(b_title.Text))
            {
                handle_changes();
            }
           /* else
            {
                b_discount.Text = "0";

            }*/
        }

        private void add_tocart_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(b_id.Text)){
                if (string.IsNullOrWhiteSpace(b_discount.Text))
                {
                    b_discount.Text = "0";

                }
                dataGridView1.Rows.Add(b_id.Text,b_title.Text,1,b_discount.Text,b_price.Text,Int32.Parse(b_price.Text)-Int32.Parse(b_discount.Text));
                this.price = Int32.Parse(b_price.Text);
                b_id.Text=b_author.Text = b_price.Text = b_publisher.Text = b_title.Text = "";
                b_discount.Text = "0";
                total_amount();
            }
            else
            {
                MessageBox.Show("Something Missing!");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White;
            }
            this.selected_row = e.RowIndex;
            dataGridView1.Rows[this.selected_row].DefaultCellStyle.BackColor = Color.Teal;
           
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (this.selected_row != -1)
            {
                dataGridView1.Rows.RemoveAt(this.selected_row);
                this.selected_row = -1;
                total_amount();
            }
            else
            {
                MessageBox.Show("Select One!!!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            total_amount();
        }

        //total books quantity
        private int total_quantity()
        {
            int total_qty = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                total_qty += Int32.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
            }
            return total_qty;
        }

        //Total amount counter
        private void total_amount()
        {
            int total_amount = 0;
           for(int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                total_amount +=Int32.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
            }
            total_amt.Text = total_amount.ToString();
        }

        private int net_amount()
        {
            int amount = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
               amount += Int32.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
            }
            return amount;
        }
        private void btn_increment_Click(object sender, EventArgs e)
        {
            if (this.selected_row != -1)

            {
                try {
                    conn.Open();
                    cmd = new SqlCommand($"Select B_stock from Book where B_id={dataGridView1.Rows[this.selected_row].Cells[0].Value}",conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int stock =Int32.Parse( reader.GetValue(0).ToString());
                        int qty = Int32.Parse(dataGridView1.Rows[this.selected_row].Cells[2].Value.ToString());
                        if (qty + 1 > stock)
                        {
                            MessageBox.Show($"{dataGridView1.Rows[this.selected_row].Cells[0].Value} is OutOF Stock");
                        }
                        else
                        {
                            ++qty;
                            dataGridView1.Rows[this.selected_row].Cells[2].Value = qty;
                            int disc = Int32.Parse(dataGridView1.Rows[this.selected_row].Cells[3].Value.ToString());
                            int net_am= Int32.Parse(dataGridView1.Rows[this.selected_row].Cells[4].Value.ToString());
                            int total_am= Int32.Parse(dataGridView1.Rows[this.selected_row].Cells[5].Value.ToString());

                            net_am = qty * this.price;
                            total_am = net_am - (qty * disc);
                            dataGridView1.Rows[this.selected_row].Cells[4].Value=net_am;
                            dataGridView1.Rows[this.selected_row].Cells[5].Value = total_am;
                            total_amount();
                        }
                    }
                    conn.Close();

                }
                catch(Exception err)
                {
                    MessageBox.Show(err.Message);
                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show("Select One!");
            }
        }

        private void btn_decrement_Click(object sender, EventArgs e)
        {
            if (this.selected_row != -1)
            {
                int qty = Int32.Parse(dataGridView1.Rows[this.selected_row].Cells[2].Value.ToString());
                if (qty > 1)
                {
                    --qty;
                    dataGridView1.Rows[this.selected_row].Cells[2].Value = qty;
                    int disc =Int32.Parse( dataGridView1.Rows[this.selected_row].Cells[3].Value.ToString());
                    int net_am = Int32.Parse(dataGridView1.Rows[this.selected_row].Cells[4].Value.ToString());
                    int total_am = Int32.Parse(dataGridView1.Rows[this.selected_row].Cells[5].Value.ToString());
                    net_am = qty * this.price;
                    total_am = net_am - (qty * disc);
                    dataGridView1.Rows[this.selected_row].Cells[4].Value = net_am;
                    dataGridView1.Rows[this.selected_row].Cells[5].Value = total_am;
                    total_amount();
                }
                else
                {
                    MessageBox.Show("Kindly,Delete Book By Clicking Delete Button!!!!!");
                }
            }
            else
            {
                MessageBox.Show("Select One!");
            }
        }
    }
}
