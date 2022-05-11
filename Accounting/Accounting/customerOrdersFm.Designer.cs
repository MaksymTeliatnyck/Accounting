namespace Accounting
{
    partial class customerOrdersFm
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
            DevExpress.XtraGrid.Columns.GridColumn detailsColumn;
            this.customerOrdersGrid = new DevExpress.XtraGrid.GridControl();
            this.customerOrdersGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.orderNumberColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.orderDateColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.orderpriceColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nameColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.currencyNameColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.addBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.printBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.label9 = new System.Windows.Forms.Label();
            this.currencyPriceColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            detailsColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.customerOrdersGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerOrdersGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // detailsColumn
            // 
            detailsColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            detailsColumn.AppearanceHeader.Options.UseFont = true;
            detailsColumn.AppearanceHeader.Options.UseTextOptions = true;
            detailsColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            detailsColumn.Caption = "Додаткова інформація";
            detailsColumn.FieldName = "Details";
            detailsColumn.Name = "detailsColumn";
            detailsColumn.OptionsColumn.AllowEdit = false;
            detailsColumn.OptionsColumn.AllowFocus = false;
            detailsColumn.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            detailsColumn.Visible = true;
            detailsColumn.VisibleIndex = 2;
            detailsColumn.Width = 453;
            // 
            // customerOrdersGrid
            // 
            this.customerOrdersGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customerOrdersGrid.Location = new System.Drawing.Point(12, 42);
            this.customerOrdersGrid.MainView = this.customerOrdersGridView;
            this.customerOrdersGrid.Name = "customerOrdersGrid";
            this.customerOrdersGrid.Size = new System.Drawing.Size(1335, 447);
            this.customerOrdersGrid.TabIndex = 0;
            this.customerOrdersGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.customerOrdersGridView});
            // 
            // customerOrdersGridView
            // 
            this.customerOrdersGridView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.customerOrdersGridView.Appearance.FooterPanel.Options.UseFont = true;
            this.customerOrdersGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.orderNumberColumn,
            this.orderDateColumn,
            detailsColumn,
            this.orderpriceColumn,
            this.currencyPriceColumn,
            this.gridColumn1,
            this.nameColumn,
            this.currencyNameColumn});
            this.customerOrdersGridView.GridControl = this.customerOrdersGrid;
            this.customerOrdersGridView.Name = "customerOrdersGridView";
            this.customerOrdersGridView.OptionsView.ShowAutoFilterRow = true;
            this.customerOrdersGridView.OptionsView.ShowFooter = true;
            this.customerOrdersGridView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.customerOrdersGridView_KeyUp);
            this.customerOrdersGridView.DoubleClick += new System.EventHandler(this.customerOrdersGridView_DoubleClick);
            // 
            // orderNumberColumn
            // 
            this.orderNumberColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.orderNumberColumn.AppearanceHeader.Options.UseFont = true;
            this.orderNumberColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.orderNumberColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.orderNumberColumn.Caption = "Номер";
            this.orderNumberColumn.FieldName = "OrderNumber";
            this.orderNumberColumn.Name = "orderNumberColumn";
            this.orderNumberColumn.OptionsColumn.AllowEdit = false;
            this.orderNumberColumn.OptionsColumn.AllowFocus = false;
            this.orderNumberColumn.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.orderNumberColumn.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "OrderNumber", "Всього:   {0}")});
            this.orderNumberColumn.Visible = true;
            this.orderNumberColumn.VisibleIndex = 0;
            this.orderNumberColumn.Width = 112;
            // 
            // orderDateColumn
            // 
            this.orderDateColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.orderDateColumn.AppearanceHeader.Options.UseFont = true;
            this.orderDateColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.orderDateColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.orderDateColumn.Caption = "Дата";
            this.orderDateColumn.FieldName = "OrderDate";
            this.orderDateColumn.MinWidth = 75;
            this.orderDateColumn.Name = "orderDateColumn";
            this.orderDateColumn.OptionsColumn.AllowEdit = false;
            this.orderDateColumn.OptionsColumn.AllowFocus = false;
            this.orderDateColumn.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.orderDateColumn.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            this.orderDateColumn.Visible = true;
            this.orderDateColumn.VisibleIndex = 1;
            this.orderDateColumn.Width = 84;
            // 
            // orderpriceColumn
            // 
            this.orderpriceColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.orderpriceColumn.AppearanceHeader.Options.UseFont = true;
            this.orderpriceColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.orderpriceColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.orderpriceColumn.Caption = "Сума(грн.)";
            this.orderpriceColumn.DisplayFormat.FormatString = "### ### ##0.00";
            this.orderpriceColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.orderpriceColumn.FieldName = "OrderPrice";
            this.orderpriceColumn.Name = "orderpriceColumn";
            this.orderpriceColumn.OptionsColumn.AllowEdit = false;
            this.orderpriceColumn.OptionsColumn.AllowFocus = false;
            this.orderpriceColumn.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.orderpriceColumn.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OrderPrice", "{0:### ### ##0.00}")});
            this.orderpriceColumn.Visible = true;
            this.orderpriceColumn.VisibleIndex = 3;
            this.orderpriceColumn.Width = 99;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "Номер договору";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 6;
            this.gridColumn1.Width = 96;
            // 
            // nameColumn
            // 
            this.nameColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.nameColumn.AppearanceHeader.Options.UseFont = true;
            this.nameColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.nameColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.nameColumn.Caption = "Контрагент";
            this.nameColumn.FieldName = "Name";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.OptionsColumn.AllowEdit = false;
            this.nameColumn.OptionsColumn.AllowFocus = false;
            this.nameColumn.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.nameColumn.Visible = true;
            this.nameColumn.VisibleIndex = 7;
            this.nameColumn.Width = 332;
            // 
            // currencyNameColumn
            // 
            this.currencyNameColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.currencyNameColumn.AppearanceHeader.Options.UseFont = true;
            this.currencyNameColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.currencyNameColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.currencyNameColumn.Caption = "Валюта";
            this.currencyNameColumn.FieldName = "CurrencyName";
            this.currencyNameColumn.Name = "currencyNameColumn";
            this.currencyNameColumn.OptionsColumn.AllowEdit = false;
            this.currencyNameColumn.OptionsColumn.AllowFocus = false;
            this.currencyNameColumn.Visible = true;
            this.currencyNameColumn.VisibleIndex = 5;
            this.currencyNameColumn.Width = 46;
            // 
            // addBtn
            // 
            this.addBtn.Image = global::Accounting.Properties.Resources.Edit_Add;
            this.addBtn.Location = new System.Drawing.Point(12, 12);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(143, 24);
            this.addBtn.TabIndex = 1;
            this.addBtn.Text = "Додати";
            this.addBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.Image = global::Accounting.Properties.Resources.Edit_Update;
            this.editBtn.Location = new System.Drawing.Point(161, 12);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(143, 24);
            this.editBtn.TabIndex = 2;
            this.editBtn.Text = "Редагувати";
            this.editBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.editBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Image = global::Accounting.Properties.Resources.Edit_Delete;
            this.deleteBtn.Location = new System.Drawing.Point(310, 12);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(143, 24);
            this.deleteBtn.TabIndex = 3;
            this.deleteBtn.Text = "Видалити";
            this.deleteBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.deleteBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // printBtn
            // 
            this.printBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.printBtn.Image = global::Accounting.Properties.Resources.PrintFixedAssetsCard;
            this.printBtn.Location = new System.Drawing.Point(1204, 12);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(143, 24);
            this.printBtn.TabIndex = 611;
            this.printBtn.Text = "&Друк заказу";
            this.printBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.printBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Linen;
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.labelControl2);
            this.groupBox1.Controls.Add(this.labelControl1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(12, 497);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1335, 35);
            this.groupBox1.TabIndex = 612;
            this.groupBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(181, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 163;
            this.label7.Text = "- видалити запис";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 13);
            this.label8.TabIndex = 162;
            this.label8.Text = "- додати новий запис";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Location = new System.Drawing.Point(160, 13);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(18, 13);
            this.labelControl2.TabIndex = 161;
            this.labelControl2.Text = "Del";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(11, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(18, 13);
            this.labelControl1.TabIndex = 160;
            this.labelControl1.Text = "Ins";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(260, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 13);
            this.label9.TabIndex = 159;
            // 
            // currencyPriceColumn
            // 
            this.currencyPriceColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.currencyPriceColumn.AppearanceHeader.Options.UseFont = true;
            this.currencyPriceColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.currencyPriceColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.currencyPriceColumn.Caption = "Сума(валюта)";
            this.currencyPriceColumn.DisplayFormat.FormatString = "### ### ##0.00";
            this.currencyPriceColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.currencyPriceColumn.FieldName = "CurrencyPrice";
            this.currencyPriceColumn.Name = "currencyPriceColumn";
            this.currencyPriceColumn.OptionsColumn.AllowEdit = false;
            this.currencyPriceColumn.OptionsColumn.AllowFocus = false;
            this.currencyPriceColumn.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CurrencyPrice", "{0:### ### ##0.00}")});
            this.currencyPriceColumn.Visible = true;
            this.currencyPriceColumn.VisibleIndex = 4;
            this.currencyPriceColumn.Width = 95;
            // 
            // customerOrdersFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1359, 544);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.printBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.customerOrdersGrid);
            this.Name = "customerOrdersFm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Закази";
            ((System.ComponentModel.ISupportInitialize)(this.customerOrdersGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerOrdersGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl customerOrdersGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView customerOrdersGridView;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button deleteBtn;
        private DevExpress.XtraGrid.Columns.GridColumn orderNumberColumn;
        private DevExpress.XtraGrid.Columns.GridColumn orderDateColumn;
        private DevExpress.XtraGrid.Columns.GridColumn orderpriceColumn;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn nameColumn;
        private DevExpress.XtraGrid.Columns.GridColumn currencyNameColumn;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraGrid.Columns.GridColumn currencyPriceColumn;
    }
}