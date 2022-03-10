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
    public partial class Expenses_UC : UserControl
    {
        SqlConnection conn;
        SqlCommand cmd;
        int selected_row=-1;
        public Expenses_UC()
        {
            InitializeComponent();
            try
            {
                conn = new SqlConnection(@"Data Source=DESKTOP-OGKQFUH\SQLEXPRESS;Initial Catalog=BookStore;Integrated Security=true");
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
            }

        private void btnAddExpense_Click(object sender, EventArgs e)
        {
            Add_Expense add_exp = new Add_Expense();
            add_exp.ShowDialog();
            dataGridView1.Rows.Clear();
            read_expenses();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            dataGridView1.Rows.Clear();
            read_expenses();
        }

        private void Expenses_UC_Load(object sender, EventArgs e)
        {
            read_expenses();
        }

        //Read From Database

        private void read_expenses()
        {
            try {
                conn.Open();
                cmd = new SqlCommand("Select * From Expense Order BY E_date desc", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(4));
                }
                conn.Close();
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
                conn.Close();
            }
            }

        

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (this.selected_row != -1)
            {
                //MessageBox.Show(dataGridView1.Rows[selected_row].Cells[0].Value.ToString());
                cmd = new SqlCommand($"Delete from Expense where E_id={dataGridView1.Rows[selected_row].Cells[0].Value}", conn);
                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.DeleteCommand = cmd;
                    int res = adapter.DeleteCommand.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show($"{res} Expense Record is Deleted..");
                    this.selected_row = -1;
                    dataGridView1.Rows.Clear();
                    read_expenses();
                }
                catch(Exception err)
                {
                    MessageBox.Show(err.Message);
                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show("Select a Record First!!!");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White;
            }
            this.selected_row = e.RowIndex;
            dataGridView1.Rows[this.selected_row].DefaultCellStyle.BackColor = Color.Teal;
           // MessageBox.Show(this.selected_row.ToString());
        }
    }
}
