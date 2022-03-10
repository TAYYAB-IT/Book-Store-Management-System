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
    public partial class Home_UC : UserControl
    {
        SqlConnection conn;
        SqlCommand cmd;
        public Home_UC()
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

        private void Home_UC_Load(object sender, EventArgs e)
        {

            string str;
            
            try
            {
                conn.Open();
                //Total Sold Books
                str = "Select SUM(book_quantity) From Sale";
                cmd = new SqlCommand(str, conn);
                var obj = cmd.ExecuteScalar();
                int result= (obj != null && !string.IsNullOrWhiteSpace(obj.ToString())) ?(int)obj :0;
                sold_books.Text = result.ToString();

                //Total Purchased Books
                str = "Select SUM(B_stock) From Book";
                cmd = new SqlCommand(str, conn);
                obj = cmd.ExecuteScalar();
                result += (obj != null && !string.IsNullOrWhiteSpace(obj.ToString())) ? (int)obj : 0;
                purchased_books.Text = result.ToString();

                //Total Customers
                str = "Select COUNT(S_id) From Sale";
                cmd = new SqlCommand(str, conn);
                 obj = cmd.ExecuteScalar();
                customers.Text = (obj != null && !string.IsNullOrWhiteSpace(obj.ToString())) ? obj.ToString() : "0";

                //This Month Sale
                int this_month = DateTime.Now.Month;
                int this_year = DateTime.Now.Year;
                str = $"Select SUM(net_amount-net_discount) from Sale Where(MONTH(S_date)={this_month} AND YEAR(S_date)={this_year})";
                cmd = new SqlCommand(str, conn);
                obj = cmd.ExecuteScalar();
               
                this_monthsale.Text = (obj != null && !string.IsNullOrWhiteSpace(obj.ToString())) ? obj.ToString() : "0";
                this_monthsale.Text += "  PKR";
                

                //This Month Expenses
                str = $"Select SUM(E_amount) from Expense Where(MONTH(E_date)={this_month} AND YEAR(E_date)={this_year})";
                cmd = new SqlCommand(str, conn);
                obj = cmd.ExecuteScalar();

                this_monthexpense.Text = (obj != null && !string.IsNullOrWhiteSpace(obj.ToString())) ? obj.ToString() : "0";
                this_monthexpense.Text += "  PKR";
                conn.Close();

            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
                conn.Close();
            }
        }

       
    }
}
