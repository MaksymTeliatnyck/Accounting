namespace Accounting
{
    partial class personsRBFm
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
            this.deleteBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.personNameTBox = new System.Windows.Forms.TextBox();
            this.supplierNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personsGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.personsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // applyBtn
            // 
            this.applyBtn.Location = new System.Drawing.Point(93, 444);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(75, 23);
            this.applyBtn.TabIndex = 11;
            this.applyBtn.Text = "Применить";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.applyBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(12, 444);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 10;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(602, 444);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteBtn.TabIndex = 9;
            this.deleteBtn.Text = "Удалить";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(521, 444);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 8;
            this.addBtn.Text = "Добавить";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // personNameTBox
            // 
            this.personNameTBox.Location = new System.Drawing.Point(12, 418);
            this.personNameTBox.Name = "personNameTBox";
            this.personNameTBox.Size = new System.Drawing.Size(665, 20);
            this.personNameTBox.TabIndex = 7;
            // 
            // supplierNameColumn
            // 
            this.supplierNameColumn.DataPropertyName = "Name";
            this.supplierNameColumn.HeaderText = "Имя";
            this.supplierNameColumn.Name = "supplierNameColumn";
            this.supplierNameColumn.ReadOnly = true;
            // 
            // personsGrid
            // 
            this.personsGrid.AllowUserToAddRows = false;
            this.personsGrid.AllowUserToDeleteRows = false;
            this.personsGrid.AllowUserToResizeColumns = false;
            this.personsGrid.AllowUserToResizeRows = false;
            this.personsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.personsGrid.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.personsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.personsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.personsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.supplierNameColumn});
            this.personsGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.personsGrid.Location = new System.Drawing.Point(0, 0);
            this.personsGrid.MultiSelect = false;
            this.personsGrid.Name = "personsGrid";
            this.personsGrid.ReadOnly = true;
            this.personsGrid.RowHeadersWidth = 25;
            this.personsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.personsGrid.Size = new System.Drawing.Size(689, 412);
            this.personsGrid.TabIndex = 6;
            this.personsGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.personsGrid_CellDoubleClick);
            // 
            // personsRBFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 477);
            this.Controls.Add(this.applyBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.personNameTBox);
            this.Controls.Add(this.personsGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "personsRBFm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справочник - \"Материально - ответственные лица\"";
            ((System.ComponentModel.ISupportInitialize)(this.personsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.TextBox personNameTBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierNameColumn;
        private System.Windows.Forms.DataGridView personsGrid;
    }
}