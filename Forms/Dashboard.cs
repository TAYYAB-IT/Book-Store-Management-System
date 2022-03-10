using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookStore.UC;
namespace BookStore.Forms
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            moveSidePanel(btnHome);
            Home_UC uc = new Home_UC();
            AddControlsToPanel(uc);
        }

      
        //Dispose Button
        private void button9_Click(object sender, EventArgs e)

        {
            Login_Page lg = new Login_Page();
            lg.Show();
            this.Dispose();
        }
        //Slider To represent active menu
        private void moveSidePanel(Control btn)
        {
            panel_bar.Top = btn.Top;
            panel_bar.Height = btn.Height;
        }
        //Add UC controls To PanalControl
        private void AddControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panel_cng.Controls.Clear();
            panel_cng.Controls.Add(c);
        }

        //Home Button
        private void btnHome_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnHome);
            Home_UC uc = new Home_UC();
            AddControlsToPanel(uc);
        }

        //Sale Book
        private void btnSaleBooks_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnSaleBooks);
            SaleBooks_UC uc = new SaleBooks_UC();
            AddControlsToPanel(uc);
        }
        //Stock Button
        private void btnStock_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnStock);
            Stock_UC uc = new Stock_UC();
            AddControlsToPanel(uc);
        }

        //Expenses Button
        private void btnExpense_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnExpense);
            Expenses_UC uc = new Expenses_UC();
            AddControlsToPanel(uc);
        }

        //View Sale Button
        private void btnViewSales_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnViewSales);
            ViewSales_UC uc = new ViewSales_UC();
            AddControlsToPanel(uc);
        }

        //Logout Button
        private void logout_button_Click(object sender, EventArgs e)
        {
            Confirm_logout fm = new Confirm_logout();
            fm.ShowDialog();
            if (!fm.IsDisposed)
            {
                Login_Page lg_page = new Login_Page();
                lg_page.Show();
                this.Dispose();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            timer1.Enabled=timer2 .Enabled= true;
            timer1.Interval =timer2.Interval= 1000;
           
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            labelDate.Text = DateTime.Now.ToString("d");
        }

        private void btn_changepass_Click(object sender, EventArgs e)
        {
            ChangePass frm = new ChangePass();
            frm.ShowDialog();
           
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            Report rp_frm = new Report();
            rp_frm.ShowDialog();
        }
    }
}
