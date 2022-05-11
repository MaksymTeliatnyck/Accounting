namespace Accounting
{
    partial class invoiceRequirementMaterialsFm
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
            this.invoiceRequirementMaterialsGrid = new DevExpress.XtraGrid.GridControl();
            this.invoiceRequirementMaterialsGridView = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand_OC = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.InventoryNumberColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.InventoryNameColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.GROUP_NAMEColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.SUPPLIER_FIAColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.DescriptionColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand_TP = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.RECEIPT_NUMColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.NOMENCLATUREColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.NOMENCLATURE_NAMEColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.BALANCE_ACCOUNTColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.NUMBERColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.DATEColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.SUPPLIER_IROColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.QUANTITYColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.UNIT_PRICEColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.TOTAL_PRICEColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.CREDIT_ACCOUNTColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.printBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceRequirementMaterialsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceRequirementMaterialsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // invoiceRequirementMaterialsGrid
            // 
            this.invoiceRequirementMaterialsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.invoiceRequirementMaterialsGrid.Location = new System.Drawing.Point(-1, 1);
            this.invoiceRequirementMaterialsGrid.MainView = this.invoiceRequirementMaterialsGridView;
            this.invoiceRequirementMaterialsGrid.Name = "invoiceRequirementMaterialsGrid";
            this.invoiceRequirementMaterialsGrid.Size = new System.Drawing.Size(1333, 549);
            this.invoiceRequirementMaterialsGrid.TabIndex = 0;
            this.invoiceRequirementMaterialsGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.invoiceRequirementMaterialsGridView});
            // 
            // invoiceRequirementMaterialsGridView
            // 
            this.invoiceRequirementMaterialsGridView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand_OC,
            this.gridBand_TP});
            this.invoiceRequirementMaterialsGridView.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.InventoryNumberColumn,
            this.InventoryNameColumn,
            this.GROUP_NAMEColumn,
            this.SUPPLIER_FIAColumn,
            this.DescriptionColumn,
            this.RECEIPT_NUMColumn,
            this.NOMENCLATUREColumn,
            this.NOMENCLATURE_NAMEColumn,
            this.BALANCE_ACCOUNTColumn,
            this.NUMBERColumn,
            this.DATEColumn,
            this.SUPPLIER_IROColumn,
            this.QUANTITYColumn,
            this.UNIT_PRICEColumn,
            this.TOTAL_PRICEColumn,
            this.CREDIT_ACCOUNTColumn});
            this.invoiceRequirementMaterialsGridView.GridControl = this.invoiceRequirementMaterialsGrid;
            this.invoiceRequirementMaterialsGridView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.invoiceRequirementMaterialsGridView.Name = "invoiceRequirementMaterialsGridView";
            this.invoiceRequirementMaterialsGridView.OptionsBehavior.Editable = false;
            this.invoiceRequirementMaterialsGridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.invoiceRequirementMaterialsGridView.OptionsView.ShowAutoFilterRow = true;
            this.invoiceRequirementMaterialsGridView.OptionsView.ShowFooter = true;
            this.invoiceRequirementMaterialsGridView.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            // 
            // gridBand_OC
            // 
            this.gridBand_OC.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gridBand_OC.AppearanceHeader.Options.UseFont = true;
            this.gridBand_OC.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand_OC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand_OC.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridBand_OC.Caption = "Основное средство";
            this.gridBand_OC.Columns.Add(this.InventoryNumberColumn);
            this.gridBand_OC.Columns.Add(this.InventoryNameColumn);
            this.gridBand_OC.Columns.Add(this.GROUP_NAMEColumn);
            this.gridBand_OC.Columns.Add(this.SUPPLIER_FIAColumn);
            this.gridBand_OC.Columns.Add(this.DescriptionColumn);
            this.gridBand_OC.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.gridBand_OC.Name = "gridBand_OC";
            this.gridBand_OC.Width = 550;
            // 
            // InventoryNumberColumn
            // 
            this.InventoryNumberColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.InventoryNumberColumn.AppearanceHeader.Options.UseFont = true;
            this.InventoryNumberColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.InventoryNumberColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.InventoryNumberColumn.Caption = "Инвентарный ОС";
            this.InventoryNumberColumn.FieldName = "InventoryNumber";
            this.InventoryNumberColumn.Name = "InventoryNumberColumn";
            this.InventoryNumberColumn.Visible = true;
            this.InventoryNumberColumn.Width = 70;
            // 
            // InventoryNameColumn
            // 
            this.InventoryNameColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.InventoryNameColumn.AppearanceHeader.Options.UseFont = true;
            this.InventoryNameColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.InventoryNameColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.InventoryNameColumn.Caption = "Наименование ОС";
            this.InventoryNameColumn.FieldName = "InventoryName";
            this.InventoryNameColumn.Name = "InventoryNameColumn";
            this.InventoryNameColumn.Visible = true;
            this.InventoryNameColumn.Width = 140;
            // 
            // GROUP_NAMEColumn
            // 
            this.GROUP_NAMEColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.GROUP_NAMEColumn.AppearanceHeader.Options.UseFont = true;
            this.GROUP_NAMEColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.GROUP_NAMEColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GROUP_NAMEColumn.Caption = "Группа ОС";
            this.GROUP_NAMEColumn.FieldName = "GroupName";
            this.GROUP_NAMEColumn.Name = "GROUP_NAMEColumn";
            this.GROUP_NAMEColumn.Visible = true;
            this.GROUP_NAMEColumn.Width = 99;
            // 
            // SUPPLIER_FIAColumn
            // 
            this.SUPPLIER_FIAColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.SUPPLIER_FIAColumn.AppearanceHeader.Options.UseFont = true;
            this.SUPPLIER_FIAColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.SUPPLIER_FIAColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SUPPLIER_FIAColumn.Caption = "Ответственное лицо";
            this.SUPPLIER_FIAColumn.FieldName = "FixedSupplierFullName";
            this.SUPPLIER_FIAColumn.Name = "SUPPLIER_FIAColumn";
            this.SUPPLIER_FIAColumn.Visible = true;
            this.SUPPLIER_FIAColumn.Width = 140;
            // 
            // DescriptionColumn
            // 
            this.DescriptionColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.DescriptionColumn.AppearanceHeader.Options.UseFont = true;
            this.DescriptionColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.DescriptionColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DescriptionColumn.Caption = "Описание";
            this.DescriptionColumn.FieldName = "Description";
            this.DescriptionColumn.Name = "DescriptionColumn";
            this.DescriptionColumn.Visible = true;
            this.DescriptionColumn.Width = 101;
            // 
            // gridBand_TP
            // 
            this.gridBand_TP.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gridBand_TP.AppearanceHeader.Options.UseFont = true;
            this.gridBand_TP.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand_TP.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand_TP.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridBand_TP.Caption = "Требование";
            this.gridBand_TP.Columns.Add(this.RECEIPT_NUMColumn);
            this.gridBand_TP.Columns.Add(this.NOMENCLATUREColumn);
            this.gridBand_TP.Columns.Add(this.NOMENCLATURE_NAMEColumn);
            this.gridBand_TP.Columns.Add(this.BALANCE_ACCOUNTColumn);
            this.gridBand_TP.Columns.Add(this.NUMBERColumn);
            this.gridBand_TP.Columns.Add(this.DATEColumn);
            this.gridBand_TP.Columns.Add(this.SUPPLIER_IROColumn);
            this.gridBand_TP.Columns.Add(this.QUANTITYColumn);
            this.gridBand_TP.Columns.Add(this.UNIT_PRICEColumn);
            this.gridBand_TP.Columns.Add(this.TOTAL_PRICEColumn);
            this.gridBand_TP.Columns.Add(this.CREDIT_ACCOUNTColumn);
            this.gridBand_TP.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.gridBand_TP.Name = "gridBand_TP";
            this.gridBand_TP.Width = 748;
            // 
            // RECEIPT_NUMColumn
            // 
            this.RECEIPT_NUMColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.RECEIPT_NUMColumn.AppearanceHeader.Options.UseFont = true;
            this.RECEIPT_NUMColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.RECEIPT_NUMColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.RECEIPT_NUMColumn.Caption = "Ном. прих";
            this.RECEIPT_NUMColumn.FieldName = "ReceiptNum";
            this.RECEIPT_NUMColumn.Name = "RECEIPT_NUMColumn";
            this.RECEIPT_NUMColumn.Visible = true;
            this.RECEIPT_NUMColumn.Width = 58;
            // 
            // NOMENCLATUREColumn
            // 
            this.NOMENCLATUREColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.NOMENCLATUREColumn.AppearanceHeader.Options.UseFont = true;
            this.NOMENCLATUREColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.NOMENCLATUREColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NOMENCLATUREColumn.Caption = "Номенкл. номер";
            this.NOMENCLATUREColumn.FieldName = "Nomenclature";
            this.NOMENCLATUREColumn.Name = "NOMENCLATUREColumn";
            this.NOMENCLATUREColumn.Visible = true;
            this.NOMENCLATUREColumn.Width = 58;
            // 
            // NOMENCLATURE_NAMEColumn
            // 
            this.NOMENCLATURE_NAMEColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.NOMENCLATURE_NAMEColumn.AppearanceHeader.Options.UseFont = true;
            this.NOMENCLATURE_NAMEColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.NOMENCLATURE_NAMEColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NOMENCLATURE_NAMEColumn.Caption = "Наименование";
            this.NOMENCLATURE_NAMEColumn.FieldName = "NomenclatureName";
            this.NOMENCLATURE_NAMEColumn.Name = "NOMENCLATURE_NAMEColumn";
            this.NOMENCLATURE_NAMEColumn.Visible = true;
            this.NOMENCLATURE_NAMEColumn.Width = 149;
            // 
            // BALANCE_ACCOUNTColumn
            // 
            this.BALANCE_ACCOUNTColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BALANCE_ACCOUNTColumn.AppearanceHeader.Options.UseFont = true;
            this.BALANCE_ACCOUNTColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.BALANCE_ACCOUNTColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.BALANCE_ACCOUNTColumn.Caption = "Бал. счёт";
            this.BALANCE_ACCOUNTColumn.FieldName = "BalanceAccountNum";
            this.BALANCE_ACCOUNTColumn.Name = "BALANCE_ACCOUNTColumn";
            this.BALANCE_ACCOUNTColumn.Visible = true;
            this.BALANCE_ACCOUNTColumn.Width = 52;
            // 
            // NUMBERColumn
            // 
            this.NUMBERColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.NUMBERColumn.AppearanceHeader.Options.UseFont = true;
            this.NUMBERColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.NUMBERColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NUMBERColumn.Caption = "Ном.";
            this.NUMBERColumn.FieldName = "Number";
            this.NUMBERColumn.Name = "NUMBERColumn";
            this.NUMBERColumn.Visible = true;
            this.NUMBERColumn.Width = 52;
            // 
            // DATEColumn
            // 
            this.DATEColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.DATEColumn.AppearanceHeader.Options.UseFont = true;
            this.DATEColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.DATEColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DATEColumn.Caption = "Дата";
            this.DATEColumn.FieldName = "Date";
            this.DATEColumn.Name = "DATEColumn";
            this.DATEColumn.Visible = true;
            this.DATEColumn.Width = 52;
            // 
            // SUPPLIER_IROColumn
            // 
            this.SUPPLIER_IROColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.SUPPLIER_IROColumn.AppearanceHeader.Options.UseFont = true;
            this.SUPPLIER_IROColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.SUPPLIER_IROColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SUPPLIER_IROColumn.Caption = "Ответственное лицо";
            this.SUPPLIER_IROColumn.FieldName = "InvoiceSupplierFullName";
            this.SUPPLIER_IROColumn.Name = "SUPPLIER_IROColumn";
            this.SUPPLIER_IROColumn.Visible = true;
            this.SUPPLIER_IROColumn.Width = 149;
            // 
            // QUANTITYColumn
            // 
            this.QUANTITYColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.QUANTITYColumn.AppearanceHeader.Options.UseFont = true;
            this.QUANTITYColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.QUANTITYColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.QUANTITYColumn.Caption = "Кол-во";
            this.QUANTITYColumn.FieldName = "Quantity";
            this.QUANTITYColumn.Name = "QUANTITYColumn";
            this.QUANTITYColumn.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QUANTITY", "{0:### ### ##0.00}")});
            this.QUANTITYColumn.Visible = true;
            this.QUANTITYColumn.Width = 39;
            // 
            // UNIT_PRICEColumn
            // 
            this.UNIT_PRICEColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.UNIT_PRICEColumn.AppearanceHeader.Options.UseFont = true;
            this.UNIT_PRICEColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.UNIT_PRICEColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.UNIT_PRICEColumn.Caption = "Цена";
            this.UNIT_PRICEColumn.DisplayFormat.FormatString = "### ### ##0.00";
            this.UNIT_PRICEColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.UNIT_PRICEColumn.FieldName = "UnitPrice";
            this.UNIT_PRICEColumn.Name = "UNIT_PRICEColumn";
            this.UNIT_PRICEColumn.Visible = true;
            this.UNIT_PRICEColumn.Width = 39;
            // 
            // TOTAL_PRICEColumn
            // 
            this.TOTAL_PRICEColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.TOTAL_PRICEColumn.AppearanceHeader.Options.UseFont = true;
            this.TOTAL_PRICEColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.TOTAL_PRICEColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TOTAL_PRICEColumn.Caption = "Сумма";
            this.TOTAL_PRICEColumn.DisplayFormat.FormatString = "### ### ##0.00";
            this.TOTAL_PRICEColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TOTAL_PRICEColumn.FieldName = "TotalPrice";
            this.TOTAL_PRICEColumn.Name = "TOTAL_PRICEColumn";
            this.TOTAL_PRICEColumn.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOTAL_PRICE", "{0:### ### ##0.00}")});
            this.TOTAL_PRICEColumn.Visible = true;
            this.TOTAL_PRICEColumn.Width = 39;
            // 
            // CREDIT_ACCOUNTColumn
            // 
            this.CREDIT_ACCOUNTColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.CREDIT_ACCOUNTColumn.AppearanceHeader.Options.UseFont = true;
            this.CREDIT_ACCOUNTColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.CREDIT_ACCOUNTColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CREDIT_ACCOUNTColumn.Caption = "Кредит счёт";
            this.CREDIT_ACCOUNTColumn.FieldName = "CreditAccountNum";
            this.CREDIT_ACCOUNTColumn.Name = "CREDIT_ACCOUNTColumn";
            this.CREDIT_ACCOUNTColumn.Visible = true;
            this.CREDIT_ACCOUNTColumn.Width = 61;
            // 
            // printBtn
            // 
            this.printBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.printBtn.Image = global::Accounting.Properties.Resources.PrintFixedAssetsCard;
            this.printBtn.Location = new System.Drawing.Point(1210, 1);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(101, 32);
            this.printBtn.TabIndex = 587;
            this.printBtn.Text = "Печать";
            this.printBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.printBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // invoiceRequirementMaterialsFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1331, 562);
            this.Controls.Add(this.printBtn);
            this.Controls.Add(this.invoiceRequirementMaterialsGrid);
            this.Name = "invoiceRequirementMaterialsFm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Требования";
            ((System.ComponentModel.ISupportInitialize)(this.invoiceRequirementMaterialsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceRequirementMaterialsGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl invoiceRequirementMaterialsGrid;
        private System.Windows.Forms.Button printBtn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView invoiceRequirementMaterialsGridView;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn InventoryNumberColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn InventoryNameColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn GROUP_NAMEColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn SUPPLIER_FIAColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn DescriptionColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn RECEIPT_NUMColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn NOMENCLATUREColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn NOMENCLATURE_NAMEColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn BALANCE_ACCOUNTColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn NUMBERColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn DATEColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn SUPPLIER_IROColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn QUANTITYColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn UNIT_PRICEColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn TOTAL_PRICEColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn CREDIT_ACCOUNTColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand_OC;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand_TP;
    }
}