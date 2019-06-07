namespace toolsRental
{
    partial class AddLoanForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CategoriesList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ToolsListPanel = new System.Windows.Forms.Panel();
            this.AddToCartButton = new System.Windows.Forms.Button();
            this.ToolsList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CartPanel = new System.Windows.Forms.Panel();
            this.DiscountSum = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.PriceSum = new System.Windows.Forms.Label();
            this.LoanButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AdvanceAmount = new System.Windows.Forms.NumericUpDown();
            this.Cart = new System.Windows.Forms.DataGridView();
            this.loanDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Return = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ToolsError = new System.Windows.Forms.ErrorProvider(this.components);
            this.CartError = new System.Windows.Forms.ErrorProvider(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.ToolsListPanel.SuspendLayout();
            this.CartPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AdvanceAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToolsError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CartError)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.ToolsListPanel);
            this.flowLayoutPanel1.Controls.Add(this.CartPanel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CategoriesList);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(15, 10, 15, 0);
            this.panel1.Size = new System.Drawing.Size(219, 54);
            this.panel1.TabIndex = 0;
            // 
            // CategoriesList
            // 
            this.CategoriesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CategoriesList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoriesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.CategoriesList.FormattingEnabled = true;
            this.CategoriesList.Location = new System.Drawing.Point(15, 30);
            this.CategoriesList.Name = "CategoriesList";
            this.CategoriesList.Size = new System.Drawing.Size(189, 24);
            this.CategoriesList.TabIndex = 1;
            this.CategoriesList.SelectedIndexChanged += new System.EventHandler(this.CategoriesList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F);
            this.label1.Location = new System.Drawing.Point(15, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kategorie:";
            // 
            // ToolsListPanel
            // 
            this.ToolsListPanel.Controls.Add(this.AddToCartButton);
            this.ToolsListPanel.Controls.Add(this.ToolsList);
            this.ToolsListPanel.Controls.Add(this.label2);
            this.ToolsListPanel.Location = new System.Drawing.Point(228, 3);
            this.ToolsListPanel.Name = "ToolsListPanel";
            this.ToolsListPanel.Padding = new System.Windows.Forms.Padding(15, 10, 15, 0);
            this.ToolsListPanel.Size = new System.Drawing.Size(219, 97);
            this.ToolsListPanel.TabIndex = 2;
            // 
            // AddToCartButton
            // 
            this.AddToCartButton.Enabled = false;
            this.AddToCartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.AddToCartButton.Location = new System.Drawing.Point(15, 60);
            this.AddToCartButton.Name = "AddToCartButton";
            this.AddToCartButton.Size = new System.Drawing.Size(189, 38);
            this.AddToCartButton.TabIndex = 2;
            this.AddToCartButton.Text = "Dodaj do koszyka";
            this.AddToCartButton.UseVisualStyleBackColor = true;
            this.AddToCartButton.Click += new System.EventHandler(this.AddToCartButton_Click);
            // 
            // ToolsList
            // 
            this.ToolsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ToolsList.Enabled = false;
            this.ToolsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ToolsList.FormattingEnabled = true;
            this.ToolsList.Location = new System.Drawing.Point(15, 30);
            this.ToolsList.Name = "ToolsList";
            this.ToolsList.Size = new System.Drawing.Size(189, 24);
            this.ToolsList.TabIndex = 1;
            this.ToolsList.SelectedIndexChanged += new System.EventHandler(this.ToolsList_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F);
            this.label2.Location = new System.Drawing.Point(15, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Narzędzia:";
            // 
            // CartPanel
            // 
            this.CartPanel.Controls.Add(this.DiscountSum);
            this.CartPanel.Controls.Add(this.label6);
            this.CartPanel.Controls.Add(this.PriceSum);
            this.CartPanel.Controls.Add(this.LoanButton);
            this.CartPanel.Controls.Add(this.label5);
            this.CartPanel.Controls.Add(this.label4);
            this.CartPanel.Controls.Add(this.label3);
            this.CartPanel.Controls.Add(this.AdvanceAmount);
            this.CartPanel.Controls.Add(this.Cart);
            this.CartPanel.Location = new System.Drawing.Point(453, 3);
            this.CartPanel.Name = "CartPanel";
            this.CartPanel.Padding = new System.Windows.Forms.Padding(15, 10, 15, 0);
            this.CartPanel.Size = new System.Drawing.Size(300, 243);
            this.CartPanel.TabIndex = 3;
            // 
            // DiscountSum
            // 
            this.DiscountSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.DiscountSum.Location = new System.Drawing.Point(198, 171);
            this.DiscountSum.Name = "DiscountSum";
            this.DiscountSum.Size = new System.Drawing.Size(52, 20);
            this.DiscountSum.TabIndex = 14;
            this.DiscountSum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label6.Location = new System.Drawing.Point(18, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 18);
            this.label6.TabIndex = 11;
            this.label6.Text = "Suma:";
            // 
            // PriceSum
            // 
            this.PriceSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.PriceSum.Location = new System.Drawing.Point(147, 171);
            this.PriceSum.Name = "PriceSum";
            this.PriceSum.Size = new System.Drawing.Size(50, 20);
            this.PriceSum.TabIndex = 5;
            this.PriceSum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LoanButton
            // 
            this.LoanButton.Enabled = false;
            this.LoanButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.LoanButton.Location = new System.Drawing.Point(15, 205);
            this.LoanButton.Name = "LoanButton";
            this.LoanButton.Size = new System.Drawing.Size(118, 38);
            this.LoanButton.TabIndex = 10;
            this.LoanButton.Text = "Wypożycz";
            this.LoanButton.UseVisualStyleBackColor = true;
            this.LoanButton.Click += new System.EventHandler(this.LoanButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F);
            this.label5.Location = new System.Drawing.Point(15, 30);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label5.Size = new System.Drawing.Size(68, 30);
            this.label5.TabIndex = 9;
            this.label5.Text = "Koszyk:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F);
            this.label4.Location = new System.Drawing.Point(139, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "zł";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F);
            this.label3.Location = new System.Drawing.Point(15, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Zaliczka";
            // 
            // AdvanceAmount
            // 
            this.AdvanceAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AdvanceAmount.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.AdvanceAmount.Location = new System.Drawing.Point(89, 10);
            this.AdvanceAmount.Maximum = new decimal(new int[] {
            13500,
            0,
            0,
            0});
            this.AdvanceAmount.Name = "AdvanceAmount";
            this.AdvanceAmount.Size = new System.Drawing.Size(44, 23);
            this.AdvanceAmount.TabIndex = 6;
            // 
            // Cart
            // 
            this.Cart.AllowUserToAddRows = false;
            this.Cart.AllowUserToDeleteRows = false;
            this.Cart.AllowUserToOrderColumns = true;
            this.Cart.AllowUserToResizeRows = false;
            this.Cart.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.Cart.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.Cart.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Cart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Cart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.loanDate,
            this.Price,
            this.Discount,
            this.Return});
            this.Cart.Enabled = false;
            this.Cart.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Cart.Location = new System.Drawing.Point(15, 60);
            this.Cart.MultiSelect = false;
            this.Cart.Name = "Cart";
            this.Cart.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Cart.RowHeadersVisible = false;
            this.Cart.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Cart.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.Cart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.Cart.Size = new System.Drawing.Size(270, 108);
            this.Cart.TabIndex = 5;
            this.Cart.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Cart_CellClick);
            this.Cart.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Cart_CellValueChanged);
            // 
            // loanDate
            // 
            this.loanDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.loanDate.FillWeight = 159.3909F;
            this.loanDate.HeaderText = "Nazwa";
            this.loanDate.Name = "loanDate";
            this.loanDate.ReadOnly = true;
            this.loanDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Price
            // 
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.Price.DefaultCellStyle = dataGridViewCellStyle4;
            this.Price.HeaderText = "Cena(zł)";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Price.Width = 50;
            // 
            // Discount
            // 
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = "0";
            this.Discount.DefaultCellStyle = dataGridViewCellStyle5;
            this.Discount.HeaderText = "Rabat(%)";
            this.Discount.MaxInputLength = 2;
            this.Discount.Name = "Discount";
            this.Discount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Discount.Width = 53;
            // 
            // Return
            // 
            this.Return.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Return.FillWeight = 40.60914F;
            this.Return.HeaderText = "";
            this.Return.Name = "Return";
            this.Return.ReadOnly = true;
            this.Return.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Return.Width = 35;
            // 
            // ToolsError
            // 
            this.ToolsError.ContainerControl = this;
            // 
            // CartError
            // 
            this.CartError.ContainerControl = this;
            // 
            // AddLoanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "AddLoanForm";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ToolsListPanel.ResumeLayout(false);
            this.ToolsListPanel.PerformLayout();
            this.CartPanel.ResumeLayout(false);
            this.CartPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AdvanceAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToolsError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CartError)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox CategoriesList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel ToolsListPanel;
        private System.Windows.Forms.ComboBox ToolsList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AddToCartButton;
        private System.Windows.Forms.Panel CartPanel;
        private System.Windows.Forms.DataGridView Cart;
        private System.Windows.Forms.NumericUpDown AdvanceAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button LoanButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ErrorProvider ToolsError;
        private System.Windows.Forms.ErrorProvider CartError;
        private System.Windows.Forms.DataGridViewTextBoxColumn loanDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discount;
        private System.Windows.Forms.DataGridViewButtonColumn Return;
        private System.Windows.Forms.Label PriceSum;
        private System.Windows.Forms.Label DiscountSum;
    }
}