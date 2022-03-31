using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BookStore.Forms
{
    public partial class ChangePass : Form
    {
        public ChangePass()
        {
            InitializeComponent();
        }

        private void btnconfirm_Click(object sender, EventArgs e)
        {
            string user_name = "", pass = "";
            string path = Directory.GetCurrentDirectory() + @"\admin.txt";
            try
            {
                if (File.Exists(path))
                {
                    FileStream fs = File.Open(path, FileMode.Open);
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        while (!sr.EndOfStream)
                        {

                            user_name = sr.ReadLine();
                            pass = sr.ReadLine();
                        }
                    }
                    fs.Close();
                }
                if (old_pass.Text == pass)
                {
                    if (new_pass.Text.Trim().Length >=5)
                    {
                        if (File.Exists(path))
                        {
                            File.Delete(path);
                        }
                       FileStream fs = File.Open(path, FileMode.Create);
                        using(StreamWriter sw =new StreamWriter(fs))
                        {
                            sw.WriteLine("admin");
                            sw.WriteLine($"{new_pass.Text.Trim()}");
                        }
                        fs.Close();

                        MessageBox.Show($"Password Changed Successfully...");
                        old_pass.Text = new_pass.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Password must contain At least 5 Charcters ");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid OLD Password !");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
    }
