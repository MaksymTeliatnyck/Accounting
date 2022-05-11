namespace Accounting
{
    partial class accountsRBFm
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
            this.applyBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.accountNumTBox = new System.Windows.Forms.TextBox();
            this.accountsGrid = new System.Windows.Forms.DataGridView();
            this.numColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.accountsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // applyBtn
            // 
            this.applyBtn.Location = new System.Drawing.Point(133, 495);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(75, 23);
            this.applyBtn.TabIndex = 17;
            this.applyBtn.Text = "Сохранить";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(12, 495);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(115, 23);
            this.okBtn.TabIndex = 16;
            this.okBtn.Text = "Сохранить и выйти";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // accountNumTBox
            // 
            this.accountNumTBox.Location = new System.Drawing.Point(12, 469);
            this.accountNumTBox.MaxLength = 8;
            this.accountNumTBox.Name = "accountNumTBox";
            this.accountNumTBox.Size = new System.Drawing.Size(660, 20);
            this.accountNumTBox.TabIndex = 13;
            this.accountNumTBox.Validated += new System.EventHandler(this.accountNumTBox_Validated);
            // 
            // accountsGrid
            // 
            this.accountsGrid.AllowUserToAddRows = false;
            this.accountsGrid.AllowUserToDeleteRows = false;
            this.accountsGrid.AllowUserToResizeColumns = false;
            this.accountsGrid.AllowUserToResizeRows = false;
            this.accountsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.accountsGrid.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.accountsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.accountsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.accountsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numColumn});
            this.accountsGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.accountsGrid.Location = new System.Drawing.Point(0, 0);
            this.accountsGrid.MultiSelect = false;
            this.accountsGrid.Name = "accountsGrid";
            this.accountsGrid.ReadOnly = true;
            this.accountsGrid.RowHeadersWidth = 25;
            this.accountsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.accountsGrid.Size = new System.Drawing.Size(684, 463);
            this.accountsGrid.TabIndex = 12;
            this.accountsGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.accountsGrid_CellDoubleClick);
            // 
            // numColumn
            // 
            this.numColumn.DataPropertyName = "Num";
            this.numColumn.HeaderText = "Номер";
            this.numColumn.Name = "numColumn";
            this.numColumn.ReadOnly = true;
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(597, 495);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteBtn.TabIndex = 15;
            this.deleteBtn.Text = "Удалить";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(516, 495);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 14;
            this.addBtn.Text = "Добавить";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // accountsRBFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 530);
            this.Controls.Add(this.applyBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.accountNumTBox);
            this.Controls.Add(this.accountsGrid);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.addBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "accountsRBFm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справочник - \"Счета\"";
            ((System.ComponentModel.ISupportInitialize)(this.accountsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.TextBox accountNumTBox;
        private System.Windows.Forms.DataGridView accountsGrid;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numColumn;
    }
}