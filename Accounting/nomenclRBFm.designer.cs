namespace Accounting
{
    partial class nomenclRBFm
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
            this.nomenclGrid = new DevExpress.XtraGrid.GridControl();
            this.nomenclGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.nomenclatureColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nameColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.measureColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.balanceColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.measureTBox = new System.Windows.Forms.TextBox();
            this.nomenclNameTBox = new System.Windows.Forms.TextBox();
            this.nomenclatureTBox = new System.Windows.Forms.TextBox();
            this.okBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.applyBtn = new System.Windows.Forms.Button();
            this.balanceTBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nomenclGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nomenclGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // nomenclGrid
            // 
            this.nomenclGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.nomenclGrid.Location = new System.Drawing.Point(0, 0);
            this.nomenclGrid.MainView = this.nomenclGridView;
            this.nomenclGrid.Name = "nomenclGrid";
            this.nomenclGrid.Size = new System.Drawing.Size(884, 467);
            this.nomenclGrid.TabIndex = 0;
            this.nomenclGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.nomenclGridView});
            // 
            // nomenclGridView
            // 
            this.nomenclGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.nomenclatureColumn,
            this.nameColumn,
            this.measureColumn,
            this.balanceColumn});
            this.nomenclGridView.GridControl = this.nomenclGrid;
            this.nomenclGridView.Name = "nomenclGridView";
            this.nomenclGridView.OptionsView.ShowAutoFilterRow = true;
            this.nomenclGridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.nomenclGridView.OptionsView.ShowGroupPanel = false;
            this.nomenclGridView.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.nomenclGridView_RowClick);
            // 
            // nomenclatureColumn
            // 
            this.nomenclatureColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nomenclatureColumn.AppearanceHeader.Options.UseFont = true;
            this.nomenclatureColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.nomenclatureColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.nomenclatureColumn.Caption = "Ном. номер";
            this.nomenclatureColumn.FieldName = "NOMENCLATURE";
            this.nomenclatureColumn.MaxWidth = 100;
            this.nomenclatureColumn.MinWidth = 100;
            this.nomenclatureColumn.Name = "nomenclatureColumn";
            this.nomenclatureColumn.OptionsColumn.AllowEdit = false;
            this.nomenclatureColumn.OptionsColumn.AllowFocus = false;
            this.nomenclatureColumn.OptionsColumn.AllowMove = false;
            this.nomenclatureColumn.OptionsColumn.AllowSize = false;
            this.nomenclatureColumn.Visible = true;
            this.nomenclatureColumn.VisibleIndex = 0;
            this.nomenclatureColumn.Width = 100;
            // 
            // nameColumn
            // 
            this.nameColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameColumn.AppearanceHeader.Options.UseFont = true;
            this.nameColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.nameColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.nameColumn.Caption = "Наименование";
            this.nameColumn.FieldName = "NAME";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.OptionsColumn.AllowEdit = false;
            this.nameColumn.OptionsColumn.AllowFocus = false;
            this.nameColumn.OptionsColumn.AllowMove = false;
            this.nameColumn.OptionsColumn.AllowSize = false;
            this.nameColumn.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.nameColumn.Visible = true;
            this.nameColumn.VisibleIndex = 1;
            this.nameColumn.Width = 563;
            // 
            // measureColumn
            // 
            this.measureColumn.AppearanceCell.Options.UseTextOptions = true;
            this.measureColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.measureColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.measureColumn.AppearanceHeader.Options.UseFont = true;
            this.measureColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.measureColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.measureColumn.Caption = "Ед. измер.";
            this.measureColumn.FieldName = "MEASURE";
            this.measureColumn.MaxWidth = 90;
            this.measureColumn.MinWidth = 90;
            this.measureColumn.Name = "measureColumn";
            this.measureColumn.OptionsColumn.AllowEdit = false;
            this.measureColumn.OptionsColumn.AllowFocus = false;
            this.measureColumn.OptionsColumn.AllowMove = false;
            this.measureColumn.OptionsColumn.AllowSize = false;
            this.measureColumn.Visible = true;
            this.measureColumn.VisibleIndex = 2;
            this.measureColumn.Width = 90;
            // 
            // balanceColumn
            // 
            this.balanceColumn.AppearanceCell.Options.UseTextOptions = true;
            this.balanceColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.balanceColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.balanceColumn.AppearanceHeader.Options.UseFont = true;
            this.balanceColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.balanceColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.balanceColumn.Caption = "Бал. счёт";
            this.balanceColumn.FieldName = "NUM";
            this.balanceColumn.MaxWidth = 85;
            this.balanceColumn.MinWidth = 85;
            this.balanceColumn.Name = "balanceColumn";
            this.balanceColumn.OptionsColumn.AllowEdit = false;
            this.balanceColumn.OptionsColumn.AllowFocus = false;
            this.balanceColumn.Visible = true;
            this.balanceColumn.VisibleIndex = 3;
            this.balanceColumn.Width = 85;
            // 
            // measureTBox
            // 
            this.measureTBox.Location = new System.Drawing.Point(694, 473);
            this.measureTBox.MaxLength = 10;
            this.measureTBox.Name = "measureTBox";
            this.measureTBox.Size = new System.Drawing.Size(84, 20);
            this.measureTBox.TabIndex = 3;
            this.measureTBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.measureTBox_KeyPress);
            // 
            // nomenclNameTBox
            // 
            this.nomenclNameTBox.Location = new System.Drawing.Point(120, 473);
            this.nomenclNameTBox.MaxLength = 200;
            this.nomenclNameTBox.Name = "nomenclNameTBox";
            this.nomenclNameTBox.Size = new System.Drawing.Size(568, 20);
            this.nomenclNameTBox.TabIndex = 2;
            this.nomenclNameTBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nomenclNameTBox_KeyPress);
            this.nomenclNameTBox.Validated += new System.EventHandler(this.nomenclatureTBox_Validated);
            // 
            // nomenclatureTBox
            // 
            this.nomenclatureTBox.Location = new System.Drawing.Point(12, 473);
            this.nomenclatureTBox.MaxLength = 12;
            this.nomenclatureTBox.Name = "nomenclatureTBox";
            this.nomenclatureTBox.Size = new System.Drawing.Size(102, 20);
            this.nomenclatureTBox.TabIndex = 1;
            this.nomenclatureTBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nomenclatureTBox_KeyPress);
            this.nomenclatureTBox.Validated += new System.EventHandler(this.nomenclatureTBox_Validated);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(12, 499);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(115, 23);
            this.okBtn.TabIndex = 5;
            this.okBtn.Text = "Сохранить и &выйти";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(716, 499);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 6;
            this.addBtn.Text = "&Добавить";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(797, 499);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteBtn.TabIndex = 7;
            this.deleteBtn.Text = "&Удалить";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // applyBtn
            // 
            this.applyBtn.Location = new System.Drawing.Point(133, 499);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(75, 23);
            this.applyBtn.TabIndex = 4;
            this.applyBtn.Text = "&Сохранить";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // balanceTBox
            // 
            this.balanceTBox.Location = new System.Drawing.Point(784, 473);
            this.balanceTBox.Name = "balanceTBox";
            this.balanceTBox.ReadOnly = true;
            this.balanceTBox.Size = new System.Drawing.Size(88, 20);
            this.balanceTBox.TabIndex = 100;
            // 
            // nomenclRBFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 534);
            this.Controls.Add(this.balanceTBox);
            this.Controls.Add(this.applyBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.nomenclatureTBox);
            this.Controls.Add(this.nomenclNameTBox);
            this.Controls.Add(this.measureTBox);
            this.Controls.Add(this.nomenclGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "nomenclRBFm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справочник - \"Материалы\"";
            ((System.ComponentModel.ISupportInitialize)(this.nomenclGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nomenclGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl nomenclGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView nomenclGridView;
        private System.Windows.Forms.TextBox measureTBox;
        private System.Windows.Forms.TextBox nomenclNameTBox;
        private System.Windows.Forms.TextBox nomenclatureTBox;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button deleteBtn;
        private DevExpress.XtraGrid.Columns.GridColumn nomenclatureColumn;
        private DevExpress.XtraGrid.Columns.GridColumn nameColumn;
        private DevExpress.XtraGrid.Columns.GridColumn measureColumn;
        private System.Windows.Forms.Button applyBtn;
        private DevExpress.XtraGrid.Columns.GridColumn balanceColumn;
        private System.Windows.Forms.TextBox balanceTBox;

    }
}