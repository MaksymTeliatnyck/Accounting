namespace Accounting
{
    partial class periodsFm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.applyBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.periodsGrid = new System.Windows.Forms.DataGridView();
            this.yearDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.periodsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.accountingDS = new Accounting.AccountingDS();
            this.periodsTableAdapter = new Accounting.AccountingDSTableAdapters.PeriodsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.periodsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.periodsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingDS)).BeginInit();
            this.SuspendLayout();
            // 
            // applyBtn
            // 
            this.applyBtn.Location = new System.Drawing.Point(133, 293);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(75, 23);
            this.applyBtn.TabIndex = 2;
            this.applyBtn.Text = "&Сохранить";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(12, 293);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(115, 23);
            this.okBtn.TabIndex = 3;
            this.okBtn.Text = "Сохранить и &выйти";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(475, 293);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 1;
            this.addBtn.Text = "&Добавить";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(556, 293);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteBtn.TabIndex = 4;
            this.deleteBtn.Text = "&Удалить";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // periodsGrid
            // 
            this.periodsGrid.AllowUserToAddRows = false;
            this.periodsGrid.AllowUserToDeleteRows = false;
            this.periodsGrid.AllowUserToResizeColumns = false;
            this.periodsGrid.AllowUserToResizeRows = false;
            this.periodsGrid.AutoGenerateColumns = false;
            this.periodsGrid.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.periodsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.periodsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.periodsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.yearDataGridViewTextBoxColumn,
            this.monthDataGridViewTextBoxColumn,
            this.stateDataGridViewTextBoxColumn});
            this.periodsGrid.DataSource = this.periodsBindingSource;
            this.periodsGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.periodsGrid.Location = new System.Drawing.Point(0, 0);
            this.periodsGrid.MultiSelect = false;
            this.periodsGrid.Name = "periodsGrid";
            this.periodsGrid.ReadOnly = true;
            this.periodsGrid.RowHeadersWidth = 24;
            this.periodsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.periodsGrid.Size = new System.Drawing.Size(643, 287);
            this.periodsGrid.TabIndex = 0;
            this.periodsGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.periodsGrid_CellFormatting);
            // 
            // yearDataGridViewTextBoxColumn
            // 
            this.yearDataGridViewTextBoxColumn.DataPropertyName = "Year";
            this.yearDataGridViewTextBoxColumn.HeaderText = "Год";
            this.yearDataGridViewTextBoxColumn.Name = "yearDataGridViewTextBoxColumn";
            this.yearDataGridViewTextBoxColumn.ReadOnly = true;
            this.yearDataGridViewTextBoxColumn.Width = 200;
            // 
            // monthDataGridViewTextBoxColumn
            // 
            this.monthDataGridViewTextBoxColumn.DataPropertyName = "Month";
            this.monthDataGridViewTextBoxColumn.HeaderText = "Месяц";
            this.monthDataGridViewTextBoxColumn.Name = "monthDataGridViewTextBoxColumn";
            this.monthDataGridViewTextBoxColumn.ReadOnly = true;
            this.monthDataGridViewTextBoxColumn.Width = 200;
            // 
            // stateDataGridViewTextBoxColumn
            // 
            this.stateDataGridViewTextBoxColumn.DataPropertyName = "State";
            this.stateDataGridViewTextBoxColumn.HeaderText = "Статус";
            this.stateDataGridViewTextBoxColumn.Name = "stateDataGridViewTextBoxColumn";
            this.stateDataGridViewTextBoxColumn.ReadOnly = true;
            this.stateDataGridViewTextBoxColumn.Width = 200;
            // 
            // periodsBindingSource
            // 
            this.periodsBindingSource.DataMember = "Periods";
            this.periodsBindingSource.DataSource = this.accountingDS;
            // 
            // accountingDS
            // 
            this.accountingDS.DataSetName = "AccountingDS";
            this.accountingDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // periodsTableAdapter
            // 
            this.periodsTableAdapter.ClearBeforeFill = true;
            // 
            // periodsFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 328);
            this.Controls.Add(this.periodsGrid);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.applyBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "periodsFm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справочник - \"Периоды\"";
            this.Load += new System.EventHandler(this.periodsFm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.periodsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.periodsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingDS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.DataGridView periodsGrid;
        private AccountingDS accountingDS;
        private System.Windows.Forms.BindingSource periodsBindingSource;
        private AccountingDSTableAdapters.PeriodsTableAdapter periodsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn yearDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn monthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stateDataGridViewTextBoxColumn;
    }
}