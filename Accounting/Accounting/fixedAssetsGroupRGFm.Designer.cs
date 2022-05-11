namespace Accounting
{
    partial class fixedAssetsGroupRGFm
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
            this.contractorsGrid = new DevExpress.XtraGrid.GridControl();
            this.contractorsGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.VendorNameColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AmortizationFactorColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AmortizationFactorTBox = new System.Windows.Forms.TextBox();
            this.NameTBox = new System.Windows.Forms.TextBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.applyBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.contractorsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contractorsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // contractorsGrid
            // 
            this.contractorsGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.contractorsGrid.Location = new System.Drawing.Point(0, 0);
            this.contractorsGrid.MainView = this.contractorsGridView;
            this.contractorsGrid.Name = "contractorsGrid";
            this.contractorsGrid.Size = new System.Drawing.Size(966, 467);
            this.contractorsGrid.TabIndex = 7;
            this.contractorsGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.contractorsGridView});
            // 
            // contractorsGridView
            // 
            this.contractorsGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.VendorNameColumn,
            this.AmortizationFactorColumn});
            this.contractorsGridView.GridControl = this.contractorsGrid;
            this.contractorsGridView.Name = "contractorsGridView";
            this.contractorsGridView.OptionsSelection.MultiSelect = true;
            this.contractorsGridView.OptionsView.ShowAutoFilterRow = true;
            this.contractorsGridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.contractorsGridView.OptionsView.ShowGroupPanel = false;
            // 
            // VendorNameColumn
            // 
            this.VendorNameColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.VendorNameColumn.AppearanceHeader.Options.UseFont = true;
            this.VendorNameColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.VendorNameColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.VendorNameColumn.Caption = "Наименование";
            this.VendorNameColumn.FieldName = "Name";
            this.VendorNameColumn.MaxWidth = 10000;
            this.VendorNameColumn.Name = "VendorNameColumn";
            this.VendorNameColumn.OptionsColumn.AllowEdit = false;
            this.VendorNameColumn.OptionsColumn.AllowFocus = false;
            this.VendorNameColumn.OptionsColumn.AllowMove = false;
            this.VendorNameColumn.OptionsColumn.AllowSize = false;
            this.VendorNameColumn.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.VendorNameColumn.Visible = true;
            this.VendorNameColumn.VisibleIndex = 0;
            this.VendorNameColumn.Width = 20;
            // 
            // AmortizationFactorColumn
            // 
            this.AmortizationFactorColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AmortizationFactorColumn.AppearanceHeader.Options.UseFont = true;
            this.AmortizationFactorColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.AmortizationFactorColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AmortizationFactorColumn.Caption = "Процент аморт., %";
            this.AmortizationFactorColumn.FieldName = "AmortizationFactor";
            this.AmortizationFactorColumn.MaxWidth = 150;
            this.AmortizationFactorColumn.MinWidth = 80;
            this.AmortizationFactorColumn.Name = "AmortizationFactorColumn";
            this.AmortizationFactorColumn.OptionsColumn.AllowEdit = false;
            this.AmortizationFactorColumn.OptionsColumn.AllowFocus = false;
            this.AmortizationFactorColumn.OptionsColumn.AllowMove = false;
            this.AmortizationFactorColumn.OptionsColumn.AllowSize = false;
            this.AmortizationFactorColumn.Width = 150;
            // 
            // AmortizationFactorTBox
            // 
            this.AmortizationFactorTBox.Location = new System.Drawing.Point(671, 501);
            this.AmortizationFactorTBox.MaxLength = 12;
            this.AmortizationFactorTBox.Name = "AmortizationFactorTBox";
            this.AmortizationFactorTBox.Size = new System.Drawing.Size(83, 20);
            this.AmortizationFactorTBox.TabIndex = 9;
            this.AmortizationFactorTBox.Visible = false;
            this.AmortizationFactorTBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AmortizationFactorTBox_KeyPress);
            // 
            // NameTBox
            // 
            this.NameTBox.Location = new System.Drawing.Point(3, 473);
            this.NameTBox.MaxLength = 200;
            this.NameTBox.Name = "NameTBox";
            this.NameTBox.Size = new System.Drawing.Size(960, 20);
            this.NameTBox.TabIndex = 8;
            this.NameTBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nameTBox_Validated);
            // 
            // addBtn
            // 
            this.addBtn.Image = global::Accounting.Properties.Resources.Edit_Add;
            this.addBtn.Location = new System.Drawing.Point(790, 499);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(85, 25);
            this.addBtn.TabIndex = 12;
            this.addBtn.Text = "&Добавить";
            this.addBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Image = global::Accounting.Properties.Resources.Edit_Delete;
            this.deleteBtn.Location = new System.Drawing.Point(878, 499);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(85, 25);
            this.deleteBtn.TabIndex = 13;
            this.deleteBtn.Text = "&Удалить";
            this.deleteBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.deleteBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // applyBtn
            // 
            this.applyBtn.Image = global::Accounting.Properties.Resources.Save;
            this.applyBtn.Location = new System.Drawing.Point(138, 499);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(132, 25);
            this.applyBtn.TabIndex = 10;
            this.applyBtn.Text = "&Сохранить";
            this.applyBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.applyBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Image = global::Accounting.Properties.Resources.Save_go;
            this.okBtn.Location = new System.Drawing.Point(3, 499);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(132, 25);
            this.okBtn.TabIndex = 11;
            this.okBtn.Text = "Сохранить и &выйти";
            this.okBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.okBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // fixedAssetsGroupRGFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 525);
            this.Controls.Add(this.contractorsGrid);
            this.Controls.Add(this.AmortizationFactorTBox);
            this.Controls.Add(this.NameTBox);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.applyBtn);
            this.Controls.Add(this.okBtn);
            this.MaximizeBox = false;
            this.Name = "fixedAssetsGroupRGFm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справочник груп основных средств";
            ((System.ComponentModel.ISupportInitialize)(this.contractorsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contractorsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl contractorsGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView contractorsGridView;
        private DevExpress.XtraGrid.Columns.GridColumn VendorNameColumn;
        private DevExpress.XtraGrid.Columns.GridColumn AmortizationFactorColumn;
        private System.Windows.Forms.TextBox AmortizationFactorTBox;
        private System.Windows.Forms.TextBox NameTBox;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.Button okBtn;
    }
}