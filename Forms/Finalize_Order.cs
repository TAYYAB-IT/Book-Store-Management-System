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
    public partial class Finalize_Order : Form
    {
        
        public Finalize_Order(int total_amount,int net_amount)
        {
            InitializeComponent();
           
            this.total_amount.Text = total_amount.ToString();
            this.net_amount.Text = net_amount.ToString();
            this.net_discount.Text = $"{net_amount-total_amount}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
