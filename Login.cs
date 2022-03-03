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
using System.IO;
namespace BookStore
{
    public partial class Login_Page : Form
    {
        string path; 
        public Login_Page()
        {
            InitializeComponent();
            try
            {
                path = Directory.GetCurrentDirectory() + @"\admin.txt";

                if (!File.Exists(path))
                {
                    MessageBox.Show("created");
                    FileStream fs = File.Open(path, FileMode.Create);
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine("admin");
                        sw.WriteLine("admin");
                    }

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (show_pass.Checked)
            {
                password.UseSystemPasswordChar = false;
            }
            else
            {
                password.UseSystemPasswordChar = true;
            }
        }

        private void login_Click(object sender, EventArgs e)
        {
            string user_name = "", pass = "";
            try {
                FileStream fs = File.Open(path, FileMode.Open);
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {

                        user_name = sr.ReadLine();
                        pass = sr.ReadLine();
                    }
                }
                if (username.Text == user_name)
                {
                    if (password.Text == pass)
                    {
                        msg.Visible = false;
                        Dashboard dash = new Dashboard();
                        dash.Show();
                        this.Hide();

                    }
                    else
                    {
                        password.Focus();
                        msg.Text = "Invalid Password";
                        msg.Visible = true;
                    }
                }
                else
                {
                    username.Focus();
                    msg.Text = "Invalid Username";
                    msg.Visible = true;
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }

     }
       
    }
}
