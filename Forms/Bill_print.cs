using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace BookStore.Forms
{
    public partial class Bill_print : Form
    {
        private DataGridView grid;
        public Bill_print(DataGridView grid)
        {
            InitializeComponent();
            this.grid = grid;

        }

        private void Bill_print_Load(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            DataSet1 ds = new DataSet1();
            foreach (DataGridViewColumn col in grid.Columns)
            {
                dt.Columns.Add(col.Name);
            }

            foreach (DataGridViewRow row in grid.Rows)
            {
                DataRow dRow = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                dt.Rows.Add(dRow);
            }


            ds.Tables.Add(dt.Copy());
            ds.Tables[1].TableName = "DataSet1";
            
            ReportDataSource rds = new ReportDataSource(ds.Tables[1].TableName, ds.Tables[1]);
            //MessageBox.Show($"{ds.Tables[1].Rows.Count}");
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }
    }
}
