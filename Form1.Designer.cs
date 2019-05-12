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
            this.ClientsLabel = new System.Windows.Forms.Label();
            this.ClientsList = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ClientsLabel
            // 
            this.ClientsLabel.AutoSize = true;
            this.ClientsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F);
            this.ClientsLabel.Location = new System.Drawing.Point(65, 55);
            this.ClientsLabel.Name = "ClientsLabel";
            this.ClientsLabel.Size = new System.Drawing.Size(64, 20);
            this.ClientsLabel.TabIndex = 0;
            this.ClientsLabel.Text = "Klienci:";
            // 
            // ClientsList
            // 
            this.ClientsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ClientsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ClientsList.FormattingEnabled = true;
            this.ClientsList.Location = new System.Drawing.Point(69, 78);
            this.ClientsList.Name = "ClientsList";
            this.ClientsList.Size = new System.Drawing.Size(162, 24);
            this.ClientsList.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ClientsList);
            this.Controls.Add(this.ClientsLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ClientsLabel;
        private System.Windows.Forms.ComboBox ClientsList;
    }
}

