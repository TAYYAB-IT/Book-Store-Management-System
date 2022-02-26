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
    public partial class SaleBooks_UC : UserControl
    {
        public SaleBooks_UC()
        {
            InitializeComponent();
        }

        private void finalize_order_Click(object sender, EventArgs e)
        {
            Finalize_Order fin_order = new Finalize_Order();
            fin_order.ShowDialog();
            if (fin_order.IsDisposed)
            {
       
            }
        }
    }
}
