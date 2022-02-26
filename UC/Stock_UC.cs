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
namespace BookStore.UC
{
    public partial class Stock_UC : UserControl
    {
        public Stock_UC()
        {
            InitializeComponent();
        }

        private void btnAddNewBooks_Click(object sender, EventArgs e)
        {
            Add_Book add_book = new Add_Book();
            add_book.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Add_Stock add_Stock = new Add_Stock();
            add_Stock.ShowDialog();
        }
    }
}
