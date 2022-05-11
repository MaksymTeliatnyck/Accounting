namespace Accounting
{
    partial class StockBalanceFM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockBalanceFM));
            this.label8 = new System.Windows.Forms.Label();
            this.gridStockBalance = new DevExpress.XtraGrid.GridControl();
            this.gridStockBalanceView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.NomenclatureColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NameColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ReceiptNumColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OrderDateColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MeasureColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RemainsQuantityColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UnitPriceColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Remains_SumColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Total_PriceColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DebitNumColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.N1Column1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dateStockBalance = new DevExpress.XtraEditors.DateEdit();
            this.showStockBalancBtn = new DevExpress.XtraEditors.SimpleButton();
            this.tofileBtn = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridStockBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridStockBalanceView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStockBalance.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStockBalance.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(4, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 14);
            this.label8.TabIndex = 605;
            this.label8.Text = "Дата";
            // 
            // gridStockBalance
            // 
            this.gridStockBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridStockBalance.Location = new System.Drawing.Point(7, 34);
            this.gridStockBalance.MainView = this.gridStockBalanceView;
            this.gridStockBalance.Name = "gridStockBalance";
            this.gridStockBalance.Size = new System.Drawing.Size(1309, 604);
            this.gridStockBalance.TabIndex = 615;
            this.gridStockBalance.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridStockBalanceView});
            // 
            // gridStockBalanceView
            // 
            this.gridStockBalanceView.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridStockBalanceView.AppearancePrint.FooterPanel.Options.UseFont = true;
            this.gridStockBalanceView.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridStockBalanceView.AppearancePrint.HeaderPanel.Options.UseFont = true;
            this.gridStockBalanceView.AppearancePrint.Lines.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridStockBalanceView.AppearancePrint.Lines.Options.UseFont = true;
            this.gridStockBalanceView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.NomenclatureColumn,
            this.NameColumn,
            this.ReceiptNumColumn1,
            this.OrderDateColumn,
            this.MeasureColumn,
            this.RemainsQuantityColumn,
            this.UnitPriceColumn,
            this.Remains_SumColumn,
            this.Total_PriceColumn,
            this.DebitNumColumn,
            this.N1Column1});
            this.gridStockBalanceView.GridControl = this.gridStockBalance;
            this.gridStockBalanceView.GroupCount = 1;
            this.gridStockBalanceView.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "REMAINS_QUANTITY", null, "Кол-во записей - {0:### ### ##0}", "Кол-во"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "REMAINS_QUANTITY", null, "Остаток, кол-во - {0:### ### ##0.00}", "Остаток, кол-во"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "REMAINS_SUM", null, "Сумма остатков - {0:### ### ##0.00}", "Сумма остатков")});
            this.gridStockBalanceView.Name = "gridStockBalanceView";
            this.gridStockBalanceView.OptionsPrint.ExpandAllDetails = true;
            this.gridStockBalanceView.OptionsView.ShowAutoFilterRow = true;
            this.gridStockBalanceView.OptionsView.ShowFooter = true;
            this.gridStockBalanceView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.N1Column1, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // NomenclatureColumn
            // 
            this.NomenclatureColumn.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.NomenclatureColumn.AppearanceCell.Options.UseFont = true;
            this.NomenclatureColumn.AppearanceCell.Options.UseTextOptions = true;
            this.NomenclatureColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NomenclatureColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.NomenclatureColumn.AppearanceHeader.Options.UseFont = true;
            this.NomenclatureColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.NomenclatureColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NomenclatureColumn.Caption = "Номенклатурный номер";
            this.NomenclatureColumn.FieldName = "NOMENCLATURE";
            this.NomenclatureColumn.Name = "NomenclatureColumn";
            this.NomenclatureColumn.OptionsColumn.AllowEdit = false;
            this.NomenclatureColumn.Visible = true;
            this.NomenclatureColumn.VisibleIndex = 0;
            // 
            // NameColumn
            // 
            this.NameColumn.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.NameColumn.AppearanceCell.Options.UseFont = true;
            this.NameColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.NameColumn.AppearanceHeader.Options.UseFont = true;
            this.NameColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.NameColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NameColumn.Caption = "Наименование";
            this.NameColumn.FieldName = "NAME";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.OptionsColumn.AllowEdit = false;
            this.NameColumn.Visible = true;
            this.NameColumn.VisibleIndex = 1;
            this.NameColumn.Width = 157;
            // 
            // ReceiptNumColumn1
            // 
            this.ReceiptNumColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.ReceiptNumColumn1.AppearanceHeader.Options.UseFont = true;
            this.ReceiptNumColumn1.Caption = "Номер прихода";
            this.ReceiptNumColumn1.FieldName = "RECEIPT_NUM";
            this.ReceiptNumColumn1.Name = "ReceiptNumColumn1";
            this.ReceiptNumColumn1.OptionsColumn.AllowEdit = false;
            this.ReceiptNumColumn1.Visible = true;
            this.ReceiptNumColumn1.VisibleIndex = 2;
            // 
            // OrderDateColumn
            // 
            this.OrderDateColumn.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.OrderDateColumn.AppearanceCell.Options.UseFont = true;
            this.OrderDateColumn.AppearanceCell.Options.UseTextOptions = true;
            this.OrderDateColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.OrderDateColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.OrderDateColumn.AppearanceHeader.Options.UseFont = true;
            this.OrderDateColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.OrderDateColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.OrderDateColumn.Caption = "Дата";
            this.OrderDateColumn.FieldName = "ORDER_DATE";
            this.OrderDateColumn.Name = "OrderDateColumn";
            this.OrderDateColumn.OptionsColumn.AllowEdit = false;
            this.OrderDateColumn.Visible = true;
            this.OrderDateColumn.VisibleIndex = 3;
            // 
            // MeasureColumn
            // 
            this.MeasureColumn.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.MeasureColumn.AppearanceCell.Options.UseFont = true;
            this.MeasureColumn.AppearanceCell.Options.UseTextOptions = true;
            this.MeasureColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.MeasureColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.MeasureColumn.AppearanceHeader.Options.UseFont = true;
            this.MeasureColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.MeasureColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.MeasureColumn.Caption = "Ед. Изм.";
            this.MeasureColumn.FieldName = "MEASURE";
            this.MeasureColumn.Name = "MeasureColumn";
            this.MeasureColumn.OptionsColumn.AllowEdit = false;
            this.MeasureColumn.Visible = true;
            this.MeasureColumn.VisibleIndex = 4;
            this.MeasureColumn.Width = 77;
            // 
            // RemainsQuantityColumn
            // 
            this.RemainsQuantityColumn.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.RemainsQuantityColumn.AppearanceCell.Options.UseFont = true;
            this.RemainsQuantityColumn.AppearanceCell.Options.UseTextOptions = true;
            this.RemainsQuantityColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.RemainsQuantityColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.RemainsQuantityColumn.AppearanceHeader.Options.UseFont = true;
            this.RemainsQuantityColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.RemainsQuantityColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.RemainsQuantityColumn.Caption = "Остаток, кол-во";
            this.RemainsQuantityColumn.FieldName = "REMAINS_QUANTITY";
            this.RemainsQuantityColumn.Name = "RemainsQuantityColumn";
            this.RemainsQuantityColumn.OptionsColumn.AllowEdit = false;
            this.RemainsQuantityColumn.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "REMAINS_QUANTITY", "{0:### ### ##0.00}")});
            this.RemainsQuantityColumn.Visible = true;
            this.RemainsQuantityColumn.VisibleIndex = 5;
            this.RemainsQuantityColumn.Width = 77;
            // 
            // UnitPriceColumn
            // 
            this.UnitPriceColumn.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.UnitPriceColumn.AppearanceCell.Options.UseFont = true;
            this.UnitPriceColumn.AppearanceCell.Options.UseTextOptions = true;
            this.UnitPriceColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.UnitPriceColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.UnitPriceColumn.AppearanceHeader.Options.UseFont = true;
            this.UnitPriceColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.UnitPriceColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.UnitPriceColumn.Caption = "Цена за ед.";
            this.UnitPriceColumn.DisplayFormat.FormatString = "### ### ##0.00";
            this.UnitPriceColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.UnitPriceColumn.FieldName = "UNIT_PRICE";
            this.UnitPriceColumn.Name = "UnitPriceColumn";
            this.UnitPriceColumn.OptionsColumn.AllowEdit = false;
            this.UnitPriceColumn.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "UNIT_PRICE", "{0:### ### ##0.00}")});
            this.UnitPriceColumn.Visible = true;
            this.UnitPriceColumn.VisibleIndex = 6;
            this.UnitPriceColumn.Width = 132;
            // 
            // Remains_SumColumn
            // 
            this.Remains_SumColumn.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Remains_SumColumn.AppearanceCell.Options.UseFont = true;
            this.Remains_SumColumn.AppearanceCell.Options.UseTextOptions = true;
            this.Remains_SumColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Remains_SumColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Remains_SumColumn.AppearanceHeader.Options.UseFont = true;
            this.Remains_SumColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.Remains_SumColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Remains_SumColumn.Caption = "Сумма остатка";
            this.Remains_SumColumn.DisplayFormat.FormatString = "### ### ##0.00";
            this.Remains_SumColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.Remains_SumColumn.FieldName = "REMAINS_SUM";
            this.Remains_SumColumn.Name = "Remains_SumColumn";
            this.Remains_SumColumn.OptionsColumn.AllowEdit = false;
            this.Remains_SumColumn.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "REMAINS_SUM", "{0:### ### ##0.00}")});
            this.Remains_SumColumn.Visible = true;
            this.Remains_SumColumn.VisibleIndex = 7;
            this.Remains_SumColumn.Width = 132;
            // 
            // Total_PriceColumn
            // 
            this.Total_PriceColumn.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Total_PriceColumn.AppearanceCell.Options.UseFont = true;
            this.Total_PriceColumn.AppearanceCell.Options.UseTextOptions = true;
            this.Total_PriceColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Total_PriceColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Total_PriceColumn.AppearanceHeader.Options.UseFont = true;
            this.Total_PriceColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.Total_PriceColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Total_PriceColumn.Caption = "Сумма прихода";
            this.Total_PriceColumn.DisplayFormat.FormatString = "### ### ##0.00";
            this.Total_PriceColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.Total_PriceColumn.FieldName = "TOTAL_PRICE";
            this.Total_PriceColumn.Name = "Total_PriceColumn";
            this.Total_PriceColumn.OptionsColumn.AllowEdit = false;
            this.Total_PriceColumn.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOTAL_PRICE", "{0:### ### ##0.00}")});
            this.Total_PriceColumn.Visible = true;
            this.Total_PriceColumn.VisibleIndex = 8;
            this.Total_PriceColumn.Width = 132;
            // 
            // DebitNumColumn
            // 
            this.DebitNumColumn.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.DebitNumColumn.AppearanceCell.Options.UseFont = true;
            this.DebitNumColumn.AppearanceCell.Options.UseTextOptions = true;
            this.DebitNumColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DebitNumColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.DebitNumColumn.AppearanceHeader.Options.UseFont = true;
            this.DebitNumColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.DebitNumColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DebitNumColumn.Caption = "Дебет";
            this.DebitNumColumn.FieldName = "DEBIT_NUM";
            this.DebitNumColumn.Name = "DebitNumColumn";
            this.DebitNumColumn.OptionsColumn.AllowEdit = false;
            this.DebitNumColumn.Visible = true;
            this.DebitNumColumn.VisibleIndex = 9;
            this.DebitNumColumn.Width = 97;
            // 
            // N1Column1
            // 
            this.N1Column1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.N1Column1.AppearanceHeader.Options.UseFont = true;
            this.N1Column1.AppearanceHeader.Options.UseTextOptions = true;
            this.N1Column1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.N1Column1.Caption = " ";
            this.N1Column1.FieldName = "N1";
            this.N1Column1.Name = "N1Column1";
            this.N1Column1.Visible = true;
            this.N1Column1.VisibleIndex = 10;
            // 
            // dateStockBalance
            // 
            this.dateStockBalance.EditValue = null;
            this.dateStockBalance.Location = new System.Drawing.Point(48, 8);
            this.dateStockBalance.Name = "dateStockBalance";
            this.dateStockBalance.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateStockBalance.Properties.Appearance.Options.UseFont = true;
            this.dateStockBalance.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateStockBalance.Properties.AppearanceDropDown.Options.UseFont = true;
            this.dateStockBalance.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.dateStockBalance.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateStockBalance.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateStockBalance.Size = new System.Drawing.Size(140, 20);
            this.dateStockBalance.TabIndex = 617;
            // 
            // showStockBalancBtn
            // 
            this.showStockBalancBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.showStockBalancBtn.Appearance.Options.UseFont = true;
            this.showStockBalancBtn.Location = new System.Drawing.Point(194, 5);
            this.showStockBalancBtn.Name = "showStockBalancBtn";
            this.showStockBalancBtn.Size = new System.Drawing.Size(75, 23);
            this.showStockBalancBtn.TabIndex = 618;
            this.showStockBalancBtn.Text = "Показать";
            this.showStockBalancBtn.Click += new System.EventHandler(this.showStockBalancBtn_Click);
            // 
            // tofileBtn
            // 
            this.tofileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tofileBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tofileBtn.Appearance.Options.UseFont = true;
            this.tofileBtn.Image = global::Accounting.Properties.Resources.PrintFixedAssetsCard;
            this.tofileBtn.Location = new System.Drawing.Point(1213, 5);
            this.tofileBtn.Name = "tofileBtn";
            this.tofileBtn.Size = new System.Drawing.Size(103, 23);
            this.tofileBtn.TabIndex = 619;
            this.tofileBtn.Text = "Печать";
            this.tofileBtn.Click += new System.EventHandler(this.tofileBtn_Click);
            // 
            // StockBalanceFM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1328, 641);
            this.Controls.Add(this.tofileBtn);
            this.Controls.Add(this.showStockBalancBtn);
            this.Controls.Add(this.dateStockBalance);
            this.Controls.Add(this.gridStockBalance);
            this.Controls.Add(this.label8);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StockBalanceFM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Остатки по складу";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StockBalanceFM_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.gridStockBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridStockBalanceView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStockBalance.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStockBalance.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private DevExpress.XtraGrid.GridControl gridStockBalance;
        private DevExpress.XtraGrid.Views.Grid.GridView gridStockBalanceView;
        private DevExpress.XtraEditors.DateEdit dateStockBalance;
        private DevExpress.XtraGrid.Columns.GridColumn NomenclatureColumn;
        private DevExpress.XtraGrid.Columns.GridColumn NameColumn;
        private DevExpress.XtraGrid.Columns.GridColumn OrderDateColumn;
        private DevExpress.XtraGrid.Columns.GridColumn RemainsQuantityColumn;
        private DevExpress.XtraGrid.Columns.GridColumn MeasureColumn;
        private DevExpress.XtraGrid.Columns.GridColumn UnitPriceColumn;
        private DevExpress.XtraGrid.Columns.GridColumn Remains_SumColumn;
        private DevExpress.XtraGrid.Columns.GridColumn Total_PriceColumn;
        private DevExpress.XtraGrid.Columns.GridColumn DebitNumColumn;
        private DevExpress.XtraEditors.SimpleButton showStockBalancBtn;
        private DevExpress.XtraEditors.SimpleButton tofileBtn;
        private DevExpress.XtraGrid.Columns.GridColumn ReceiptNumColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn N1Column1;
    }
}