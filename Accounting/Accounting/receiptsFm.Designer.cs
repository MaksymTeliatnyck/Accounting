namespace Accounting
{
    partial class receiptsFm
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
            this.receiptsGrid = new DevExpress.XtraGrid.GridControl();
            this.receiptsGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.vendorCodeColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.vendorNameColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.receiptNumColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.orderDateColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.invoiceDateColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nomenclatureColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nameColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.measureColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.quantityColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TotalPriceColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.unitPriceColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.totalCurrencyColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.unitCurrencyColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rateColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.debitColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.balanceColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.correctionColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.printBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.receiptsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // receiptsGrid
            // 
            this.receiptsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.receiptsGrid.Location = new System.Drawing.Point(0, 0);
            this.receiptsGrid.MainView = this.receiptsGridView;
            this.receiptsGrid.Name = "receiptsGrid";
            this.receiptsGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.receiptsGrid.Size = new System.Drawing.Size(1484, 462);
            this.receiptsGrid.TabIndex = 0;
            this.receiptsGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.receiptsGridView});
            // 
            // receiptsGridView
            // 
            this.receiptsGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.vendorCodeColumn,
            this.vendorNameColumn,
            this.receiptNumColumn,
            this.orderDateColumn,
            this.invoiceDateColumn,
            this.nomenclatureColumn,
            this.nameColumn,
            this.measureColumn,
            this.quantityColumn,
            this.TotalPriceColumn,
            this.unitPriceColumn,
            this.totalCurrencyColumn,
            this.unitCurrencyColumn,
            this.rateColumn,
            this.debitColumn,
            this.balanceColumn,
            this.correctionColumn});
            this.receiptsGridView.GridControl = this.receiptsGrid;
            this.receiptsGridView.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QUANTITY", null, "(Количество -{0:### ### ##0.###})"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOTAL_PRICE", null, "(Сумма -{0:### ### ##0.##})"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOTAL_CURRENCY", null, "(Сумма -{0:### ### ##0.##})")});
            this.receiptsGridView.Name = "receiptsGridView";
            this.receiptsGridView.OptionsView.ShowAutoFilterRow = true;
            this.receiptsGridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.receiptsGridView.OptionsView.ShowFooter = true;
            this.receiptsGridView.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.receiptsGridView_RowCellStyle);
            // 
            // vendorCodeColumn
            // 
            this.vendorCodeColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.vendorCodeColumn.AppearanceHeader.Options.UseFont = true;
            this.vendorCodeColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.vendorCodeColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.vendorCodeColumn.Caption = "Код";
            this.vendorCodeColumn.FieldName = "Vendor_Srn";
            this.vendorCodeColumn.MaxWidth = 78;
            this.vendorCodeColumn.MinWidth = 78;
            this.vendorCodeColumn.Name = "vendorCodeColumn";
            this.vendorCodeColumn.OptionsColumn.AllowEdit = false;
            this.vendorCodeColumn.OptionsColumn.AllowFocus = false;
            this.vendorCodeColumn.Visible = true;
            this.vendorCodeColumn.VisibleIndex = 0;
            this.vendorCodeColumn.Width = 78;
            // 
            // vendorNameColumn
            // 
            this.vendorNameColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.vendorNameColumn.AppearanceHeader.Options.UseFont = true;
            this.vendorNameColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.vendorNameColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.vendorNameColumn.Caption = "Поставщик";
            this.vendorNameColumn.FieldName = "Vendor_Name";
            this.vendorNameColumn.MinWidth = 120;
            this.vendorNameColumn.Name = "vendorNameColumn";
            this.vendorNameColumn.OptionsColumn.AllowEdit = false;
            this.vendorNameColumn.OptionsColumn.AllowFocus = false;
            this.vendorNameColumn.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.vendorNameColumn.Visible = true;
            this.vendorNameColumn.VisibleIndex = 1;
            this.vendorNameColumn.Width = 125;
            // 
            // receiptNumColumn
            // 
            this.receiptNumColumn.AppearanceCell.Options.UseTextOptions = true;
            this.receiptNumColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.receiptNumColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.receiptNumColumn.AppearanceHeader.Options.UseFont = true;
            this.receiptNumColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.receiptNumColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.receiptNumColumn.Caption = "Ном. прих.";
            this.receiptNumColumn.FieldName = "RECEIPT_NUM";
            this.receiptNumColumn.MaxWidth = 100;
            this.receiptNumColumn.MinWidth = 70;
            this.receiptNumColumn.Name = "receiptNumColumn";
            this.receiptNumColumn.OptionsColumn.AllowEdit = false;
            this.receiptNumColumn.OptionsColumn.AllowFocus = false;
            this.receiptNumColumn.Visible = true;
            this.receiptNumColumn.VisibleIndex = 2;
            this.receiptNumColumn.Width = 72;
            // 
            // orderDateColumn
            // 
            this.orderDateColumn.AppearanceCell.Options.UseTextOptions = true;
            this.orderDateColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.orderDateColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.orderDateColumn.AppearanceHeader.Options.UseFont = true;
            this.orderDateColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.orderDateColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.orderDateColumn.Caption = "Дата орд.";
            this.orderDateColumn.FieldName = "ORDER_DATE";
            this.orderDateColumn.MaxWidth = 100;
            this.orderDateColumn.MinWidth = 80;
            this.orderDateColumn.Name = "orderDateColumn";
            this.orderDateColumn.OptionsColumn.AllowEdit = false;
            this.orderDateColumn.OptionsColumn.AllowFocus = false;
            this.orderDateColumn.Visible = true;
            this.orderDateColumn.VisibleIndex = 3;
            this.orderDateColumn.Width = 83;
            // 
            // invoiceDateColumn
            // 
            this.invoiceDateColumn.AppearanceCell.Options.UseTextOptions = true;
            this.invoiceDateColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.invoiceDateColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.invoiceDateColumn.AppearanceHeader.Options.UseFont = true;
            this.invoiceDateColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.invoiceDateColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.invoiceDateColumn.Caption = "Дата накл.";
            this.invoiceDateColumn.FieldName = "INVOICE_DATE";
            this.invoiceDateColumn.MaxWidth = 100;
            this.invoiceDateColumn.MinWidth = 80;
            this.invoiceDateColumn.Name = "invoiceDateColumn";
            this.invoiceDateColumn.OptionsColumn.AllowEdit = false;
            this.invoiceDateColumn.OptionsColumn.AllowFocus = false;
            this.invoiceDateColumn.Visible = true;
            this.invoiceDateColumn.VisibleIndex = 4;
            this.invoiceDateColumn.Width = 83;
            // 
            // nomenclatureColumn
            // 
            this.nomenclatureColumn.AppearanceCell.Options.UseTextOptions = true;
            this.nomenclatureColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.nomenclatureColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.nomenclatureColumn.AppearanceHeader.Options.UseFont = true;
            this.nomenclatureColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.nomenclatureColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.nomenclatureColumn.Caption = "Ном. номер";
            this.nomenclatureColumn.FieldName = "NOMENCLATURE";
            this.nomenclatureColumn.MaxWidth = 100;
            this.nomenclatureColumn.MinWidth = 80;
            this.nomenclatureColumn.Name = "nomenclatureColumn";
            this.nomenclatureColumn.OptionsColumn.AllowEdit = false;
            this.nomenclatureColumn.OptionsColumn.AllowFocus = false;
            this.nomenclatureColumn.Visible = true;
            this.nomenclatureColumn.VisibleIndex = 5;
            this.nomenclatureColumn.Width = 83;
            // 
            // nameColumn
            // 
            this.nameColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.nameColumn.AppearanceHeader.Options.UseFont = true;
            this.nameColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.nameColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.nameColumn.Caption = "Наименование материала";
            this.nameColumn.FieldName = "NOMENCLATURE_NAME";
            this.nameColumn.MaxWidth = 100;
            this.nameColumn.MinWidth = 100;
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.OptionsColumn.AllowEdit = false;
            this.nameColumn.OptionsColumn.AllowFocus = false;
            this.nameColumn.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.nameColumn.Visible = true;
            this.nameColumn.VisibleIndex = 6;
            this.nameColumn.Width = 100;
            // 
            // measureColumn
            // 
            this.measureColumn.AppearanceCell.Options.UseTextOptions = true;
            this.measureColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.measureColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.measureColumn.AppearanceHeader.Options.UseFont = true;
            this.measureColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.measureColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.measureColumn.Caption = "Ед. измер.";
            this.measureColumn.FieldName = "MEASURE";
            this.measureColumn.MaxWidth = 80;
            this.measureColumn.MinWidth = 80;
            this.measureColumn.Name = "measureColumn";
            this.measureColumn.OptionsColumn.AllowEdit = false;
            this.measureColumn.OptionsColumn.AllowFocus = false;
            this.measureColumn.Visible = true;
            this.measureColumn.VisibleIndex = 7;
            this.measureColumn.Width = 80;
            // 
            // quantityColumn
            // 
            this.quantityColumn.AppearanceCell.Options.UseTextOptions = true;
            this.quantityColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.quantityColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.quantityColumn.AppearanceHeader.Options.UseFont = true;
            this.quantityColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.quantityColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.quantityColumn.Caption = "Количество";
            this.quantityColumn.DisplayFormat.FormatString = "### ### ##0.####";
            this.quantityColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.quantityColumn.FieldName = "QUANTITY";
            this.quantityColumn.MaxWidth = 75;
            this.quantityColumn.MinWidth = 75;
            this.quantityColumn.Name = "quantityColumn";
            this.quantityColumn.OptionsColumn.AllowEdit = false;
            this.quantityColumn.OptionsColumn.AllowFocus = false;
            this.quantityColumn.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QUANTITY", "{0:### ### ##0.####}")});
            this.quantityColumn.Visible = true;
            this.quantityColumn.VisibleIndex = 9;
            // 
            // TotalPriceColumn
            // 
            this.TotalPriceColumn.AppearanceCell.Options.UseTextOptions = true;
            this.TotalPriceColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.TotalPriceColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.TotalPriceColumn.AppearanceHeader.Options.UseFont = true;
            this.TotalPriceColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.TotalPriceColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TotalPriceColumn.Caption = "Сумма (грн.)";
            this.TotalPriceColumn.DisplayFormat.FormatString = "### ### ##0.00";
            this.TotalPriceColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.TotalPriceColumn.FieldName = "TOTAL_PRICE";
            this.TotalPriceColumn.MaxWidth = 100;
            this.TotalPriceColumn.MinWidth = 100;
            this.TotalPriceColumn.Name = "TotalPriceColumn";
            this.TotalPriceColumn.OptionsColumn.AllowEdit = false;
            this.TotalPriceColumn.OptionsColumn.AllowFocus = false;
            this.TotalPriceColumn.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOTAL_PRICE", "{0:### ### ##0.##}")});
            this.TotalPriceColumn.Visible = true;
            this.TotalPriceColumn.VisibleIndex = 11;
            this.TotalPriceColumn.Width = 100;
            // 
            // unitPriceColumn
            // 
            this.unitPriceColumn.AppearanceCell.Options.UseTextOptions = true;
            this.unitPriceColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.unitPriceColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.unitPriceColumn.AppearanceHeader.Options.UseFont = true;
            this.unitPriceColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.unitPriceColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.unitPriceColumn.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.unitPriceColumn.Caption = "Цена за ед. (грн.)";
            this.unitPriceColumn.DisplayFormat.FormatString = "### ### ##0.00";
            this.unitPriceColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.unitPriceColumn.FieldName = "UNIT_PRICE";
            this.unitPriceColumn.MaxWidth = 100;
            this.unitPriceColumn.MinWidth = 100;
            this.unitPriceColumn.Name = "unitPriceColumn";
            this.unitPriceColumn.OptionsColumn.AllowEdit = false;
            this.unitPriceColumn.OptionsColumn.AllowFocus = false;
            this.unitPriceColumn.Visible = true;
            this.unitPriceColumn.VisibleIndex = 10;
            this.unitPriceColumn.Width = 100;
            // 
            // totalCurrencyColumn
            // 
            this.totalCurrencyColumn.AppearanceCell.Options.UseTextOptions = true;
            this.totalCurrencyColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.totalCurrencyColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.totalCurrencyColumn.AppearanceHeader.Options.UseFont = true;
            this.totalCurrencyColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.totalCurrencyColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.totalCurrencyColumn.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.totalCurrencyColumn.Caption = "Сумма (валюта)";
            this.totalCurrencyColumn.DisplayFormat.FormatString = "### ### ##0.00";
            this.totalCurrencyColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.totalCurrencyColumn.FieldName = "TOTAL_CURRENCY";
            this.totalCurrencyColumn.MinWidth = 100;
            this.totalCurrencyColumn.Name = "totalCurrencyColumn";
            this.totalCurrencyColumn.OptionsColumn.AllowEdit = false;
            this.totalCurrencyColumn.OptionsColumn.AllowFocus = false;
            this.totalCurrencyColumn.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOTAL_CURRENCY", "{0:### ### ##0.##}")});
            this.totalCurrencyColumn.Visible = true;
            this.totalCurrencyColumn.VisibleIndex = 13;
            this.totalCurrencyColumn.Width = 122;
            // 
            // unitCurrencyColumn
            // 
            this.unitCurrencyColumn.AppearanceCell.Options.UseTextOptions = true;
            this.unitCurrencyColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.unitCurrencyColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.unitCurrencyColumn.AppearanceHeader.Options.UseFont = true;
            this.unitCurrencyColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.unitCurrencyColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.unitCurrencyColumn.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.unitCurrencyColumn.Caption = "Цена за ед. (валюта)";
            this.unitCurrencyColumn.DisplayFormat.FormatString = "### ### ##0.00";
            this.unitCurrencyColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.unitCurrencyColumn.FieldName = "UNIT_CURRENCY";
            this.unitCurrencyColumn.MinWidth = 100;
            this.unitCurrencyColumn.Name = "unitCurrencyColumn";
            this.unitCurrencyColumn.OptionsColumn.AllowEdit = false;
            this.unitCurrencyColumn.OptionsColumn.AllowFocus = false;
            this.unitCurrencyColumn.Visible = true;
            this.unitCurrencyColumn.VisibleIndex = 12;
            this.unitCurrencyColumn.Width = 107;
            // 
            // rateColumn
            // 
            this.rateColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.rateColumn.AppearanceHeader.Options.UseFont = true;
            this.rateColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.rateColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.rateColumn.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.rateColumn.Caption = "Курс";
            this.rateColumn.DisplayFormat.FormatString = "### ##0.0000";
            this.rateColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.rateColumn.FieldName = "RATE";
            this.rateColumn.MaxWidth = 70;
            this.rateColumn.MinWidth = 70;
            this.rateColumn.Name = "rateColumn";
            this.rateColumn.OptionsColumn.AllowEdit = false;
            this.rateColumn.OptionsColumn.AllowFocus = false;
            this.rateColumn.Visible = true;
            this.rateColumn.VisibleIndex = 14;
            this.rateColumn.Width = 70;
            // 
            // debitColumn
            // 
            this.debitColumn.AppearanceCell.Options.UseTextOptions = true;
            this.debitColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.debitColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.debitColumn.AppearanceHeader.Options.UseFont = true;
            this.debitColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.debitColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.debitColumn.Caption = "Дебет счёт";
            this.debitColumn.FieldName = "DEBIT_ACCOUNT_NUM";
            this.debitColumn.MaxWidth = 100;
            this.debitColumn.MinWidth = 80;
            this.debitColumn.Name = "debitColumn";
            this.debitColumn.OptionsColumn.AllowEdit = false;
            this.debitColumn.OptionsColumn.AllowFocus = false;
            this.debitColumn.Visible = true;
            this.debitColumn.VisibleIndex = 15;
            this.debitColumn.Width = 100;
            // 
            // balanceColumn
            // 
            this.balanceColumn.AppearanceCell.Options.UseTextOptions = true;
            this.balanceColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.balanceColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.balanceColumn.AppearanceHeader.Options.UseFont = true;
            this.balanceColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.balanceColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.balanceColumn.Caption = "Бал. счёт";
            this.balanceColumn.FieldName = "BALANCE_ACCOUNT_NUM";
            this.balanceColumn.MaxWidth = 90;
            this.balanceColumn.MinWidth = 80;
            this.balanceColumn.Name = "balanceColumn";
            this.balanceColumn.OptionsColumn.AllowEdit = false;
            this.balanceColumn.OptionsColumn.AllowFocus = false;
            this.balanceColumn.Visible = true;
            this.balanceColumn.VisibleIndex = 8;
            this.balanceColumn.Width = 83;
            // 
            // correctionColumn
            // 
            this.correctionColumn.AppearanceCell.Options.UseTextOptions = true;
            this.correctionColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.correctionColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.correctionColumn.AppearanceHeader.Options.UseFont = true;
            this.correctionColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.correctionColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.correctionColumn.Caption = "Коррект.";
            this.correctionColumn.ColumnEdit = this.repositoryItemCheckEdit1;
            this.correctionColumn.FieldName = "CORRECTION";
            this.correctionColumn.MaxWidth = 80;
            this.correctionColumn.MinWidth = 70;
            this.correctionColumn.Name = "correctionColumn";
            this.correctionColumn.OptionsColumn.AllowEdit = false;
            this.correctionColumn.OptionsColumn.AllowFocus = false;
            this.correctionColumn.Visible = true;
            this.correctionColumn.VisibleIndex = 16;
            this.correctionColumn.Width = 80;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.DisplayValueChecked = "1";
            this.repositoryItemCheckEdit1.DisplayValueUnchecked = "0";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.ValueChecked = ((short)(1));
            this.repositoryItemCheckEdit1.ValueUnchecked = ((short)(0));
            // 
            // printBtn
            // 
            this.printBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.printBtn.Location = new System.Drawing.Point(1386, 6);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(75, 23);
            this.printBtn.TabIndex = 1;
            this.printBtn.Text = "Печать";
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // receiptsFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 462);
            this.Controls.Add(this.printBtn);
            this.Controls.Add(this.receiptsGrid);
            this.Name = "receiptsFm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Приходы";
            ((System.ComponentModel.ISupportInitialize)(this.receiptsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl receiptsGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView receiptsGridView;
        private DevExpress.XtraGrid.Columns.GridColumn nomenclatureColumn;
        private DevExpress.XtraGrid.Columns.GridColumn nameColumn;
        private DevExpress.XtraGrid.Columns.GridColumn measureColumn;
        private DevExpress.XtraGrid.Columns.GridColumn quantityColumn;
        private DevExpress.XtraGrid.Columns.GridColumn TotalPriceColumn;
        private DevExpress.XtraGrid.Columns.GridColumn unitPriceColumn;
        private DevExpress.XtraGrid.Columns.GridColumn debitColumn;
        private DevExpress.XtraGrid.Columns.GridColumn orderDateColumn;
        private DevExpress.XtraGrid.Columns.GridColumn receiptNumColumn;
        private DevExpress.XtraGrid.Columns.GridColumn balanceColumn;
        private DevExpress.XtraGrid.Columns.GridColumn correctionColumn;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn invoiceDateColumn;
        private DevExpress.XtraGrid.Columns.GridColumn vendorNameColumn;
        private DevExpress.XtraGrid.Columns.GridColumn vendorCodeColumn;
        private System.Windows.Forms.Button printBtn;
        private DevExpress.XtraGrid.Columns.GridColumn totalCurrencyColumn;
        private DevExpress.XtraGrid.Columns.GridColumn unitCurrencyColumn;
        private DevExpress.XtraGrid.Columns.GridColumn rateColumn;
    }
}
