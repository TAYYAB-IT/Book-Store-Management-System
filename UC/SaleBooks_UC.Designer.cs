
namespace BookStore.UC
{
    partial class SaleBooks_UC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label4 = new System.Windows.Forms.Label();
            this.add_tocart = new System.Windows.Forms.Button();
            this.b_discount = new System.Windows.Forms.TextBox();
            this.b_id = new System.Windows.Forms.TextBox();
            this.b_author = new System.Windows.Forms.TextBox();
            this.b_publisher = new System.Windows.Forms.TextBox();
            this.b_price = new System.Windows.Forms.TextBox();
            this.b_title = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tracking_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Book_title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Net_Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.finalize_order = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.total_amt = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btn_decrement = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_increment = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Teal;
            this.label4.Location = new System.Drawing.Point(218, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "Sell Books";
            // 
            // add_tocart
            // 
            this.add_tocart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.add_tocart.BackColor = System.Drawing.Color.Teal;
            this.add_tocart.FlatAppearance.BorderSize = 0;
            this.add_tocart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_tocart.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_tocart.ForeColor = System.Drawing.Color.White;
            this.add_tocart.Location = new System.Drawing.Point(254, 369);
            this.add_tocart.Name = "add_tocart";
            this.add_tocart.Size = new System.Drawing.Size(138, 38);
            this.add_tocart.TabIndex = 16;
            this.add_tocart.Text = "Add to Cart";
            this.add_tocart.UseVisualStyleBackColor = false;
            this.add_tocart.Click += new System.EventHandler(this.add_tocart_Click);
            // 
            // b_discount
            // 
            this.b_discount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.b_discount.Location = new System.Drawing.Point(425, 288);
            this.b_discount.Name = "b_discount";
            this.b_discount.Size = new System.Drawing.Size(179, 20);
            this.b_discount.TabIndex = 10;
            this.b_discount.Text = "0";
            this.b_discount.TextChanged += new System.EventHandler(this.b_discount_TextChanged);
            // 
            // b_id
            // 
            this.b_id.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.b_id.Location = new System.Drawing.Point(117, 153);
            this.b_id.Name = "b_id";
            this.b_id.Size = new System.Drawing.Size(487, 20);
            this.b_id.TabIndex = 11;
            this.b_id.TextChanged += new System.EventHandler(this.b_id_TextChanged);
            // 
            // b_author
            // 
            this.b_author.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.b_author.Location = new System.Drawing.Point(423, 203);
            this.b_author.Name = "b_author";
            this.b_author.ReadOnly = true;
            this.b_author.Size = new System.Drawing.Size(179, 20);
            this.b_author.TabIndex = 12;
            // 
            // b_publisher
            // 
            this.b_publisher.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.b_publisher.Location = new System.Drawing.Point(117, 245);
            this.b_publisher.Name = "b_publisher";
            this.b_publisher.ReadOnly = true;
            this.b_publisher.Size = new System.Drawing.Size(487, 20);
            this.b_publisher.TabIndex = 13;
            // 
            // b_price
            // 
            this.b_price.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.b_price.Location = new System.Drawing.Point(117, 291);
            this.b_price.Name = "b_price";
            this.b_price.ReadOnly = true;
            this.b_price.Size = new System.Drawing.Size(179, 20);
            this.b_price.TabIndex = 14;
            // 
            // b_title
            // 
            this.b_title.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.b_title.Location = new System.Drawing.Point(117, 203);
            this.b_title.Name = "b_title";
            this.b_title.ReadOnly = true;
            this.b_title.Size = new System.Drawing.Size(179, 20);
            this.b_title.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Teal;
            this.label10.Location = new System.Drawing.Point(341, 289);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 19);
            this.label10.TabIndex = 3;
            this.label10.Text = "Discount:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Teal;
            this.label5.Location = new System.Drawing.Point(10, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tracking ID:";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Teal;
            this.label8.Location = new System.Drawing.Point(27, 243);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 19);
            this.label8.TabIndex = 5;
            this.label8.Text = "Publisher:";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Teal;
            this.label9.Location = new System.Drawing.Point(58, 291);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 19);
            this.label9.TabIndex = 6;
            this.label9.Text = "Price:";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Teal;
            this.label7.Location = new System.Drawing.Point(353, 198);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 19);
            this.label7.TabIndex = 7;
            this.label7.Text = "Author:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Teal;
            this.label6.Location = new System.Drawing.Point(25, 201);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 19);
            this.label6.TabIndex = 8;
            this.label6.Text = "Book Title:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Location = new System.Drawing.Point(640, -15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(382, 604);
            this.panel1.TabIndex = 17;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tracking_id,
            this.Book_title,
            this.Qty,
            this.discount,
            this.Net_Amount,
            this.Total_amount});
            this.dataGridView1.Location = new System.Drawing.Point(0, 15);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(291, 252);
            this.dataGridView1.TabIndex = 19;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // tracking_id
            // 
            this.tracking_id.HeaderText = "Tracking ID";
            this.tracking_id.Name = "tracking_id";
            this.tracking_id.ReadOnly = true;
            // 
            // Book_title
            // 
            this.Book_title.HeaderText = "Book Title";
            this.Book_title.Name = "Book_title";
            this.Book_title.ReadOnly = true;
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            // 
            // discount
            // 
            this.discount.HeaderText = "D/B";
            this.discount.Name = "discount";
            this.discount.ReadOnly = true;
            // 
            // Net_Amount
            // 
            this.Net_Amount.HeaderText = "Net Amount";
            this.Net_Amount.Name = "Net_Amount";
            this.Net_Amount.ReadOnly = true;
            // 
            // Total_amount
            // 
            this.Total_amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Total_amount.HeaderText = "Total Amount";
            this.Total_amount.Name = "Total_amount";
            this.Total_amount.ReadOnly = true;
            this.Total_amount.Width = 95;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Info;
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Controls.Add(this.finalize_order);
            this.panel5.Controls.Add(this.button6);
            this.panel5.Controls.Add(this.total_amt);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Location = new System.Drawing.Point(2, 273);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(289, 178);
            this.panel5.TabIndex = 18;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Teal;
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 44);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(289, 7);
            this.panel8.TabIndex = 5;
            // 
            // finalize_order
            // 
            this.finalize_order.BackColor = System.Drawing.Color.SeaGreen;
            this.finalize_order.FlatAppearance.BorderSize = 0;
            this.finalize_order.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.finalize_order.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finalize_order.ForeColor = System.Drawing.Color.White;
            this.finalize_order.Location = new System.Drawing.Point(167, 111);
            this.finalize_order.Name = "finalize_order";
            this.finalize_order.Size = new System.Drawing.Size(92, 42);
            this.finalize_order.TabIndex = 2;
            this.finalize_order.Text = "Finish";
            this.finalize_order.UseVisualStyleBackColor = false;
            this.finalize_order.Click += new System.EventHandler(this.finalize_order_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Red;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(167, 57);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(92, 42);
            this.button6.TabIndex = 2;
            this.button6.Text = "Clear";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // total_amt
            // 
            this.total_amt.AutoSize = true;
            this.total_amt.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total_amt.Location = new System.Drawing.Point(68, 120);
            this.total_amt.Name = "total_amt";
            this.total_amt.Size = new System.Drawing.Size(32, 23);
            this.total_amt.TabIndex = 0;
            this.total_amt.Text = "00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Total Bill (Rs.):";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btn_decrement);
            this.panel7.Controls.Add(this.btn_delete);
            this.panel7.Controls.Add(this.btn_increment);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 7);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(289, 37);
            this.panel7.TabIndex = 4;
            // 
            // btn_decrement
            // 
            this.btn_decrement.BackColor = System.Drawing.Color.OrangeRed;
            this.btn_decrement.FlatAppearance.BorderSize = 0;
            this.btn_decrement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_decrement.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_decrement.ForeColor = System.Drawing.Color.White;
            this.btn_decrement.Location = new System.Drawing.Point(52, 3);
            this.btn_decrement.Name = "btn_decrement";
            this.btn_decrement.Size = new System.Drawing.Size(33, 31);
            this.btn_decrement.TabIndex = 2;
            this.btn_decrement.Text = "-";
            this.btn_decrement.UseVisualStyleBackColor = false;
            this.btn_decrement.Click += new System.EventHandler(this.btn_decrement_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.Color.OrangeRed;
            this.btn_delete.FlatAppearance.BorderSize = 0;
            this.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delete.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.ForeColor = System.Drawing.Color.White;
            this.btn_delete.Location = new System.Drawing.Point(167, 3);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(77, 31);
            this.btn_delete.TabIndex = 2;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_increment
            // 
            this.btn_increment.BackColor = System.Drawing.Color.Teal;
            this.btn_increment.FlatAppearance.BorderSize = 0;
            this.btn_increment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_increment.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_increment.ForeColor = System.Drawing.Color.White;
            this.btn_increment.Location = new System.Drawing.Point(101, 3);
            this.btn_increment.Name = "btn_increment";
            this.btn_increment.Size = new System.Drawing.Size(33, 31);
            this.btn_increment.TabIndex = 2;
            this.btn_increment.Text = "+";
            this.btn_increment.UseVisualStyleBackColor = false;
            this.btn_increment.Click += new System.EventHandler(this.btn_increment_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Teal;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(289, 7);
            this.panel6.TabIndex = 4;
            // 
            // SaleBooks_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.add_tocart);
            this.Controls.Add(this.b_discount);
            this.Controls.Add(this.b_id);
            this.Controls.Add(this.b_author);
            this.Controls.Add(this.b_publisher);
            this.Controls.Add(this.b_price);
            this.Controls.Add(this.b_title);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Name = "SaleBooks_UC";
            this.Size = new System.Drawing.Size(934, 445);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button add_tocart;
        private System.Windows.Forms.TextBox b_discount;
        private System.Windows.Forms.TextBox b_id;
        private System.Windows.Forms.TextBox b_author;
        private System.Windows.Forms.TextBox b_publisher;
        private System.Windows.Forms.TextBox b_price;
        private System.Windows.Forms.TextBox b_title;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button finalize_order;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label total_amt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btn_decrement;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_increment;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tracking_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Book_title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Net_Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total_amount;
    }
}
