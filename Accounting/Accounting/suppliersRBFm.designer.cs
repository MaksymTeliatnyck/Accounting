namespace Accounting
{
    partial class suppliersRBFm
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
            this.suppliersGrid = new System.Windows.Forms.DataGridView();
            this.supplierNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ACTIVE = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierNameTBox = new System.Windows.Forms.TextBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.applyBtn = new System.Windows.Forms.Button();
            this.suppliersgroupCB = new System.Windows.Forms.ComboBox();
            this.suppliersactiveCB = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.suppliersGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // suppliersGrid
            // 
            this.suppliersGrid.AllowUserToAddRows = false;
            this.suppliersGrid.AllowUserToDeleteRows = false;
            this.suppliersGrid.AllowUserToResizeColumns = false;
            this.suppliersGrid.AllowUserToResizeRows = false;
            this.suppliersGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.suppliersGrid.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.suppliersGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.suppliersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.suppliersGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.supplierNameColumn,
            this.ACTIVE,
            this.NAME});
            this.suppliersGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.suppliersGrid.Location = new System.Drawing.Point(0, 0);
            this.suppliersGrid.MultiSelect = false;
            this.suppliersGrid.Name = "suppliersGrid";
            this.suppliersGrid.ReadOnly = true;
            this.suppliersGrid.RowHeadersWidth = 25;
            this.suppliersGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.suppliersGrid.Size = new System.Drawing.Size(684, 463);
            this.suppliersGrid.TabIndex = 0;
            this.suppliersGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.suppliersGrid_CellDoubleClick);
            // 
            // supplierNameColumn
            // 
            this.supplierNameColumn.DataPropertyName = "NAME";
            this.supplierNameColumn.FillWeight = 152.2843F;
            this.supplierNameColumn.HeaderText = "Имя";
            this.supplierNameColumn.Name = "supplierNameColumn";
            this.supplierNameColumn.ReadOnly = true;
            // 
            // ACTIVE
            // 
            this.ACTIVE.DataPropertyName = "ACTIVE";
            this.ACTIVE.FalseValue = "0";
            this.ACTIVE.FillWeight = 42.34303F;
            this.ACTIVE.HeaderText = "Активный";
            this.ACTIVE.Name = "ACTIVE";
            this.ACTIVE.ReadOnly = true;
            this.ACTIVE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ACTIVE.TrueValue = "1";
            // 
            // NAME
            // 
            this.NAME.DataPropertyName = "GRNAME";
            this.NAME.FillWeight = 105.3727F;
            this.NAME.HeaderText = "Группа";
            this.NAME.Name = "NAME";
            this.NAME.ReadOnly = true;
            this.NAME.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // supplierNameTBox
            // 
            this.supplierNameTBox.Location = new System.Drawing.Point(12, 466);
            this.supplierNameTBox.MaxLength = 50;
            this.supplierNameTBox.Name = "supplierNameTBox";
            this.supplierNameTBox.Size = new System.Drawing.Size(332, 20);
            this.supplierNameTBox.TabIndex = 1;
            this.supplierNameTBox.Validated += new System.EventHandler(this.supplierNameTBox_Validated);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(516, 495);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 2;
            this.addBtn.Text = "&Добавить";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(597, 495);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteBtn.TabIndex = 3;
            this.deleteBtn.Text = "&Удалить";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(12, 495);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(115, 23);
            this.okBtn.TabIndex = 4;
            this.okBtn.Text = "Сохранить и &выйти";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // applyBtn
            // 
            this.applyBtn.Location = new System.Drawing.Point(133, 495);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(75, 23);
            this.applyBtn.TabIndex = 5;
            this.applyBtn.Text = "&Сохранить";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // suppliersgroupCB
            // 
            this.suppliersgroupCB.FormattingEnabled = true;
            this.suppliersgroupCB.Location = new System.Drawing.Point(470, 468);
            this.suppliersgroupCB.Name = "suppliersgroupCB";
            this.suppliersgroupCB.Size = new System.Drawing.Size(214, 21);
            this.suppliersgroupCB.TabIndex = 6;
            // 
            // suppliersactiveCB
            // 
            this.suppliersactiveCB.AutoSize = true;
            this.suppliersactiveCB.Location = new System.Drawing.Point(367, 470);
            this.suppliersactiveCB.Name = "suppliersactiveCB";
            this.suppliersactiveCB.Size = new System.Drawing.Size(76, 17);
            this.suppliersactiveCB.TabIndex = 7;
            this.suppliersactiveCB.Text = "Активный";
            this.suppliersactiveCB.UseVisualStyleBackColor = true;
            // 
            // suppliersRBFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 530);
            this.Controls.Add(this.suppliersactiveCB);
            this.Controls.Add(this.suppliersgroupCB);
            this.Controls.Add(this.applyBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.supplierNameTBox);
            this.Controls.Add(this.suppliersGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "suppliersRBFm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справочник - \"Ответственные лица\"";
            ((System.ComponentModel.ISupportInitialize)(this.suppliersGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView suppliersGrid;
        private System.Windows.Forms.TextBox supplierNameTBox;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.ComboBox suppliersgroupCB;
        private System.Windows.Forms.CheckBox suppliersactiveCB;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierNameColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ACTIVE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME;
    }
}
