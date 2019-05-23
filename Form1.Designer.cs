namespace toolsRental
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LoanButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.AddClientButton = new System.Windows.Forms.Button();
            this.RemoveClientButton = new System.Windows.Forms.Button();
            this.ClientsList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AddLoanPanel = new System.Windows.Forms.Panel();
            this.LoansPanel = new System.Windows.Forms.Panel();
            this.ToolsList = new System.Windows.Forms.DataGridView();
            this.tool = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoansGrid = new System.Windows.Forms.DataGridView();
            this.loanDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToPay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Preview = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Return = new System.Windows.Forms.DataGridViewButtonColumn();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.AddLoanPanel.SuspendLayout();
            this.LoansPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToolsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoansGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // LoanButton
            // 
            this.LoanButton.AutoSize = true;
            this.LoanButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoanButton.Enabled = false;
            this.LoanButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.LoanButton.Location = new System.Drawing.Point(15, 10);
            this.LoanButton.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.LoanButton.Name = "LoanButton";
            this.LoanButton.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.LoanButton.Size = new System.Drawing.Size(189, 44);
            this.LoanButton.TabIndex = 2;
            this.LoanButton.Text = "Dodaj wypożyczenie";
            this.LoanButton.UseVisualStyleBackColor = true;
            this.LoanButton.Click += new System.EventHandler(this.LoanButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F);
            this.label1.Location = new System.Drawing.Point(15, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Historia wypożyczeń:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.AddLoanPanel);
            this.flowLayoutPanel1.Controls.Add(this.LoansPanel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.AddClientButton);
            this.panel1.Controls.Add(this.RemoveClientButton);
            this.panel1.Controls.Add(this.ClientsList);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(15, 10, 15, 0);
            this.panel1.Size = new System.Drawing.Size(219, 169);
            this.panel1.TabIndex = 4;
            // 
            // AddClientButton
            // 
            this.AddClientButton.AutoSize = true;
            this.AddClientButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.AddClientButton.Location = new System.Drawing.Point(15, 68);
            this.AddClientButton.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.AddClientButton.Name = "AddClientButton";
            this.AddClientButton.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.AddClientButton.Size = new System.Drawing.Size(189, 44);
            this.AddClientButton.TabIndex = 7;
            this.AddClientButton.Text = "Dodaj klienta";
            this.AddClientButton.UseVisualStyleBackColor = true;
            this.AddClientButton.Click += new System.EventHandler(this.AddClientButton_Click);
            // 
            // RemoveClientButton
            // 
            this.RemoveClientButton.AutoSize = true;
            this.RemoveClientButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.RemoveClientButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.RemoveClientButton.Location = new System.Drawing.Point(15, 125);
            this.RemoveClientButton.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.RemoveClientButton.Name = "RemoveClientButton";
            this.RemoveClientButton.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.RemoveClientButton.Size = new System.Drawing.Size(189, 44);
            this.RemoveClientButton.TabIndex = 6;
            this.RemoveClientButton.Text = "Usuń klienta";
            this.RemoveClientButton.UseVisualStyleBackColor = true;
            this.RemoveClientButton.Click += new System.EventHandler(this.RemoveClientButton_Click);
            // 
            // ClientsList
            // 
            this.ClientsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClientsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ClientsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ClientsList.FormattingEnabled = true;
            this.ClientsList.Location = new System.Drawing.Point(15, 30);
            this.ClientsList.Name = "ClientsList";
            this.ClientsList.Size = new System.Drawing.Size(189, 24);
            this.ClientsList.TabIndex = 5;
            this.ClientsList.SelectedIndexChanged += new System.EventHandler(this.ClientsList_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F);
            this.label2.Location = new System.Drawing.Point(15, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Klienci:";
            // 
            // AddLoanPanel
            // 
            this.AddLoanPanel.AutoSize = true;
            this.AddLoanPanel.Controls.Add(this.LoanButton);
            this.AddLoanPanel.Location = new System.Drawing.Point(228, 3);
            this.AddLoanPanel.Name = "AddLoanPanel";
            this.AddLoanPanel.Padding = new System.Windows.Forms.Padding(15, 10, 15, 0);
            this.AddLoanPanel.Size = new System.Drawing.Size(219, 54);
            this.AddLoanPanel.TabIndex = 7;
            // 
            // LoansPanel
            // 
            this.LoansPanel.Controls.Add(this.ToolsList);
            this.LoansPanel.Controls.Add(this.LoansGrid);
            this.LoansPanel.Controls.Add(this.label1);
            this.LoansPanel.Location = new System.Drawing.Point(453, 3);
            this.LoansPanel.Name = "LoansPanel";
            this.LoansPanel.Padding = new System.Windows.Forms.Padding(15, 10, 15, 0);
            this.LoansPanel.Size = new System.Drawing.Size(270, 300);
            this.LoansPanel.TabIndex = 4;
            this.LoansPanel.TabStop = true;
            // 
            // ToolsList
            // 
            this.ToolsList.AllowUserToAddRows = false;
            this.ToolsList.AllowUserToDeleteRows = false;
            this.ToolsList.AllowUserToOrderColumns = true;
            this.ToolsList.AllowUserToResizeRows = false;
            this.ToolsList.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.ToolsList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.ToolsList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.ToolsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ToolsList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tool});
            this.ToolsList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ToolsList.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ToolsList.Location = new System.Drawing.Point(15, 167);
            this.ToolsList.MultiSelect = false;
            this.ToolsList.Name = "ToolsList";
            this.ToolsList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.ToolsList.RowHeadersVisible = false;
            this.ToolsList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ToolsList.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ToolsList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.ToolsList.Size = new System.Drawing.Size(240, 118);
            this.ToolsList.TabIndex = 5;
            this.ToolsList.Visible = false;
            // 
            // tool
            // 
            this.tool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tool.FillWeight = 159.3909F;
            this.tool.HeaderText = "Nazwa narzędzia";
            this.tool.Name = "tool";
            // 
            // LoansGrid
            // 
            this.LoansGrid.AllowUserToAddRows = false;
            this.LoansGrid.AllowUserToDeleteRows = false;
            this.LoansGrid.AllowUserToOrderColumns = true;
            this.LoansGrid.AllowUserToResizeRows = false;
            this.LoansGrid.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.LoansGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.LoansGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.LoansGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LoansGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.loanDate,
            this.ToPay,
            this.Preview,
            this.Return});
            this.LoansGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.LoansGrid.Enabled = false;
            this.LoansGrid.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LoansGrid.Location = new System.Drawing.Point(15, 30);
            this.LoansGrid.MultiSelect = false;
            this.LoansGrid.Name = "LoansGrid";
            this.LoansGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.LoansGrid.RowHeadersVisible = false;
            this.LoansGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.LoansGrid.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.LoansGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.LoansGrid.Size = new System.Drawing.Size(240, 128);
            this.LoansGrid.TabIndex = 4;
            this.LoansGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LoansGrid_CellClick);
            // 
            // loanDate
            // 
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.loanDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.loanDate.FillWeight = 159.3909F;
            this.loanDate.HeaderText = "Data";
            this.loanDate.Name = "loanDate";
            this.loanDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.loanDate.Width = 60;
            // 
            // ToPay
            // 
            this.ToPay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ToPay.HeaderText = "Do zapłaty";
            this.ToPay.Name = "ToPay";
            this.ToPay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Preview
            // 
            this.Preview.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Preview.HeaderText = "";
            this.Preview.Name = "Preview";
            this.Preview.ReadOnly = true;
            this.Preview.Width = 53;
            // 
            // Return
            // 
            this.Return.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Return.FillWeight = 40.60914F;
            this.Return.HeaderText = "";
            this.Return.Name = "Return";
            this.Return.ReadOnly = true;
            this.Return.Width = 40;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Form1";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.AddLoanPanel.ResumeLayout(false);
            this.AddLoanPanel.PerformLayout();
            this.LoansPanel.ResumeLayout(false);
            this.LoansPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToolsList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoansGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button LoanButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel AddLoanPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ClientsList;
        private System.Windows.Forms.Panel LoansPanel;
        private System.Windows.Forms.DataGridView LoansGrid;
        private System.Windows.Forms.DataGridView ToolsList;
        private System.Windows.Forms.DataGridViewTextBoxColumn tool;
        private System.Windows.Forms.Button RemoveClientButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn loanDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToPay;
        private System.Windows.Forms.DataGridViewButtonColumn Preview;
        private System.Windows.Forms.DataGridViewButtonColumn Return;
        private System.Windows.Forms.Button AddClientButton;
    }
}

