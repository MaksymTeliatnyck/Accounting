namespace Accounting
{
    partial class deliveryFm
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
            this.deliveryGrid = new DevExpress.XtraGrid.GridControl();
            this.deliveryGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.orderDeliveryTTNColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.orderDeliveryNameColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.orderDeliveryDateColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.orderDeliveryPriceColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.orderPriceTypaNameCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.vendorCodeColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.vendorNameColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.receiptNumColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.orderDateCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.invoiceDateCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.orderDeliveryPriceTBox = new System.Windows.Forms.TextBox();
            this.deliveryPaymentTypeCBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.invoiceDeliveryDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label24 = new System.Windows.Forms.Label();
            this.ttnTBox = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.deliveryCBox = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.addTtnBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.printBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // deliveryGrid
            // 
            this.deliveryGrid.Location = new System.Drawing.Point(12, 43);
            this.deliveryGrid.MainView = this.deliveryGridView;
            this.deliveryGrid.Name = "deliveryGrid";
            this.deliveryGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.deliveryGrid.Size = new System.Drawing.Size(1456, 482);
            this.deliveryGrid.TabIndex = 1;
            this.deliveryGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.deliveryGridView});
            // 
            // deliveryGridView
            // 
            this.deliveryGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.orderDeliveryTTNColumn,
            this.orderDeliveryNameColumn,
            this.orderDeliveryDateColumn,
            this.orderDeliveryPriceColumn,
            this.orderPriceTypaNameCol,
            this.vendorCodeColumn,
            this.vendorNameColumn,
            this.receiptNumColumn,
            this.orderDateCol,
            this.invoiceDateCol});
            this.deliveryGridView.GridControl = this.deliveryGrid;
            this.deliveryGridView.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QUANTITY", null, "(Количество -{0:### ### ##0.###})"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOTAL_PRICE", null, "(Сумма -{0:### ### ##0.##})"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOTAL_CURRENCY", null, "(Сумма -{0:### ### ##0.##})")});
            this.deliveryGridView.Name = "deliveryGridView";
            this.deliveryGridView.OptionsView.AllowCellMerge = true;
            this.deliveryGridView.OptionsView.ShowAutoFilterRow = true;
            this.deliveryGridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.deliveryGridView.OptionsView.ShowFooter = true;
            this.deliveryGridView.CellMerge += new DevExpress.XtraGrid.Views.Grid.CellMergeEventHandler(this.deliveryGridView_CellMerge);
            this.deliveryGridView.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.deliveryGridView_RowCellStyle);
            // 
            // orderDeliveryTTNColumn
            // 
            this.orderDeliveryTTNColumn.AppearanceCell.Options.UseTextOptions = true;
            this.orderDeliveryTTNColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.orderDeliveryTTNColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.orderDeliveryTTNColumn.AppearanceHeader.Options.UseFont = true;
            this.orderDeliveryTTNColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.orderDeliveryTTNColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.orderDeliveryTTNColumn.Caption = "ТТН";
            this.orderDeliveryTTNColumn.FieldName = "TTN";
            this.orderDeliveryTTNColumn.MaxWidth = 130;
            this.orderDeliveryTTNColumn.MinWidth = 80;
            this.orderDeliveryTTNColumn.Name = "orderDeliveryTTNColumn";
            this.orderDeliveryTTNColumn.OptionsColumn.AllowEdit = false;
            this.orderDeliveryTTNColumn.OptionsColumn.AllowFocus = false;
            this.orderDeliveryTTNColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.orderDeliveryTTNColumn.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.orderDeliveryTTNColumn.Visible = true;
            this.orderDeliveryTTNColumn.VisibleIndex = 0;
            this.orderDeliveryTTNColumn.Width = 130;
            // 
            // orderDeliveryNameColumn
            // 
            this.orderDeliveryNameColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.orderDeliveryNameColumn.AppearanceHeader.Options.UseFont = true;
            this.orderDeliveryNameColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.orderDeliveryNameColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.orderDeliveryNameColumn.Caption = "Перевізник";
            this.orderDeliveryNameColumn.FieldName = "DeliveryName";
            this.orderDeliveryNameColumn.Name = "orderDeliveryNameColumn";
            this.orderDeliveryNameColumn.OptionsColumn.AllowEdit = false;
            this.orderDeliveryNameColumn.OptionsColumn.AllowFocus = false;
            this.orderDeliveryNameColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.orderDeliveryNameColumn.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.orderDeliveryNameColumn.Visible = true;
            this.orderDeliveryNameColumn.VisibleIndex = 1;
            this.orderDeliveryNameColumn.Width = 188;
            // 
            // orderDeliveryDateColumn
            // 
            this.orderDeliveryDateColumn.AppearanceCell.Options.UseTextOptions = true;
            this.orderDeliveryDateColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.orderDeliveryDateColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.orderDeliveryDateColumn.AppearanceHeader.Options.UseFont = true;
            this.orderDeliveryDateColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.orderDeliveryDateColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.orderDeliveryDateColumn.Caption = "Дата ТТН";
            this.orderDeliveryDateColumn.FieldName = "OrderDate";
            this.orderDeliveryDateColumn.Name = "orderDeliveryDateColumn";
            this.orderDeliveryDateColumn.OptionsColumn.AllowEdit = false;
            this.orderDeliveryDateColumn.OptionsColumn.AllowFocus = false;
            this.orderDeliveryDateColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.orderDeliveryDateColumn.Visible = true;
            this.orderDeliveryDateColumn.VisibleIndex = 2;
            this.orderDeliveryDateColumn.Width = 90;
            // 
            // orderDeliveryPriceColumn
            // 
            this.orderDeliveryPriceColumn.AppearanceCell.Options.UseTextOptions = true;
            this.orderDeliveryPriceColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.orderDeliveryPriceColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.orderDeliveryPriceColumn.AppearanceHeader.Options.UseFont = true;
            this.orderDeliveryPriceColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.orderDeliveryPriceColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.orderDeliveryPriceColumn.Caption = "Сума (грн)";
            this.orderDeliveryPriceColumn.DisplayFormat.FormatString = "### ### ##0.00";
            this.orderDeliveryPriceColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.orderDeliveryPriceColumn.FieldName = "Price";
            this.orderDeliveryPriceColumn.Name = "orderDeliveryPriceColumn";
            this.orderDeliveryPriceColumn.OptionsColumn.AllowEdit = false;
            this.orderDeliveryPriceColumn.OptionsColumn.AllowFocus = false;
            this.orderDeliveryPriceColumn.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Price", "Всього:      {0}")});
            this.orderDeliveryPriceColumn.Visible = true;
            this.orderDeliveryPriceColumn.VisibleIndex = 3;
            this.orderDeliveryPriceColumn.Width = 130;
            // 
            // orderPriceTypaNameCol
            // 
            this.orderPriceTypaNameCol.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.orderPriceTypaNameCol.AppearanceHeader.Options.UseFont = true;
            this.orderPriceTypaNameCol.AppearanceHeader.Options.UseTextOptions = true;
            this.orderPriceTypaNameCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.orderPriceTypaNameCol.Caption = "Вид платежу";
            this.orderPriceTypaNameCol.FieldName = "DeliveryPaymentName";
            this.orderPriceTypaNameCol.Name = "orderPriceTypaNameCol";
            this.orderPriceTypaNameCol.OptionsColumn.AllowEdit = false;
            this.orderPriceTypaNameCol.OptionsColumn.AllowFocus = false;
            this.orderPriceTypaNameCol.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.orderPriceTypaNameCol.Visible = true;
            this.orderPriceTypaNameCol.VisibleIndex = 4;
            this.orderPriceTypaNameCol.Width = 140;
            // 
            // vendorCodeColumn
            // 
            this.vendorCodeColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.vendorCodeColumn.AppearanceHeader.Options.UseFont = true;
            this.vendorCodeColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.vendorCodeColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.vendorCodeColumn.Caption = "Код";
            this.vendorCodeColumn.FieldName = "ContractorCode";
            this.vendorCodeColumn.MaxWidth = 140;
            this.vendorCodeColumn.MinWidth = 140;
            this.vendorCodeColumn.Name = "vendorCodeColumn";
            this.vendorCodeColumn.OptionsColumn.AllowEdit = false;
            this.vendorCodeColumn.OptionsColumn.AllowFocus = false;
            this.vendorCodeColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.vendorCodeColumn.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.vendorCodeColumn.Visible = true;
            this.vendorCodeColumn.VisibleIndex = 5;
            this.vendorCodeColumn.Width = 140;
            // 
            // vendorNameColumn
            // 
            this.vendorNameColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.vendorNameColumn.AppearanceHeader.Options.UseFont = true;
            this.vendorNameColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.vendorNameColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.vendorNameColumn.Caption = "Постачальник";
            this.vendorNameColumn.FieldName = "Contractorname";
            this.vendorNameColumn.MaxWidth = 250;
            this.vendorNameColumn.MinWidth = 250;
            this.vendorNameColumn.Name = "vendorNameColumn";
            this.vendorNameColumn.OptionsColumn.AllowEdit = false;
            this.vendorNameColumn.OptionsColumn.AllowFocus = false;
            this.vendorNameColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.vendorNameColumn.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.vendorNameColumn.Visible = true;
            this.vendorNameColumn.VisibleIndex = 6;
            this.vendorNameColumn.Width = 250;
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
            this.receiptNumColumn.FieldName = "ReceiptNum";
            this.receiptNumColumn.MaxWidth = 120;
            this.receiptNumColumn.MinWidth = 100;
            this.receiptNumColumn.Name = "receiptNumColumn";
            this.receiptNumColumn.OptionsColumn.AllowEdit = false;
            this.receiptNumColumn.OptionsColumn.AllowFocus = false;
            this.receiptNumColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.receiptNumColumn.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.receiptNumColumn.Visible = true;
            this.receiptNumColumn.VisibleIndex = 7;
            this.receiptNumColumn.Width = 120;
            // 
            // orderDateCol
            // 
            this.orderDateCol.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.orderDateCol.AppearanceHeader.Options.UseFont = true;
            this.orderDateCol.AppearanceHeader.Options.UseTextOptions = true;
            this.orderDateCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.orderDateCol.Caption = "Дата ордер";
            this.orderDateCol.FieldName = "ORDER_DATE";
            this.orderDateCol.MaxWidth = 90;
            this.orderDateCol.Name = "orderDateCol";
            this.orderDateCol.OptionsColumn.AllowEdit = false;
            this.orderDateCol.OptionsColumn.AllowFocus = false;
            this.orderDateCol.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.orderDateCol.Visible = true;
            this.orderDateCol.VisibleIndex = 8;
            this.orderDateCol.Width = 89;
            // 
            // invoiceDateCol
            // 
            this.invoiceDateCol.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.invoiceDateCol.AppearanceHeader.Options.UseFont = true;
            this.invoiceDateCol.AppearanceHeader.Options.UseTextOptions = true;
            this.invoiceDateCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.invoiceDateCol.Caption = "Дата накладної";
            this.invoiceDateCol.FieldName = "InvoiceDate";
            this.invoiceDateCol.MaxWidth = 90;
            this.invoiceDateCol.Name = "invoiceDateCol";
            this.invoiceDateCol.OptionsColumn.AllowEdit = false;
            this.invoiceDateCol.OptionsColumn.AllowFocus = false;
            this.invoiceDateCol.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.invoiceDateCol.Visible = true;
            this.invoiceDateCol.VisibleIndex = 9;
            this.invoiceDateCol.Width = 90;
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
            // orderDeliveryPriceTBox
            // 
            this.orderDeliveryPriceTBox.Location = new System.Drawing.Point(534, 544);
            this.orderDeliveryPriceTBox.MaxLength = 12;
            this.orderDeliveryPriceTBox.Name = "orderDeliveryPriceTBox";
            this.orderDeliveryPriceTBox.Size = new System.Drawing.Size(178, 20);
            this.orderDeliveryPriceTBox.TabIndex = 577;
            this.orderDeliveryPriceTBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.orderDeliveryPriceTBox_KeyPress);
            // 
            // deliveryPaymentTypeCBox
            // 
            this.deliveryPaymentTypeCBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.deliveryPaymentTypeCBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.deliveryPaymentTypeCBox.FormattingEnabled = true;
            this.deliveryPaymentTypeCBox.Location = new System.Drawing.Point(928, 544);
            this.deliveryPaymentTypeCBox.Name = "deliveryPaymentTypeCBox";
            this.deliveryPaymentTypeCBox.Size = new System.Drawing.Size(201, 21);
            this.deliveryPaymentTypeCBox.TabIndex = 579;
            this.deliveryPaymentTypeCBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.deliveryPaymentTypeCBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(925, 528);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 583;
            this.label1.Text = "Тип платежа";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(718, 528);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(58, 13);
            this.label23.TabIndex = 582;
            this.label23.Text = "Дата ТТН";
            // 
            // invoiceDeliveryDatePicker
            // 
            this.invoiceDeliveryDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.invoiceDeliveryDatePicker.Location = new System.Drawing.Point(718, 544);
            this.invoiceDeliveryDatePicker.Name = "invoiceDeliveryDatePicker";
            this.invoiceDeliveryDatePicker.Size = new System.Drawing.Size(204, 20);
            this.invoiceDeliveryDatePicker.TabIndex = 578;
            this.invoiceDeliveryDatePicker.Value = new System.DateTime(2012, 6, 18, 0, 0, 0, 0);
            this.invoiceDeliveryDatePicker.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.invoiceDeliveryDatePicker_KeyPress);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(534, 528);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(44, 13);
            this.label24.TabIndex = 581;
            this.label24.Text = "Сумма ";
            // 
            // ttnTBox
            // 
            this.ttnTBox.Location = new System.Drawing.Point(12, 545);
            this.ttnTBox.MaxLength = 20;
            this.ttnTBox.Name = "ttnTBox";
            this.ttnTBox.Size = new System.Drawing.Size(245, 20);
            this.ttnTBox.TabIndex = 575;
            this.ttnTBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ttnTBox_KeyPress);
            this.ttnTBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ttnTBox_KeyUp);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(24, 528);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(29, 13);
            this.label22.TabIndex = 580;
            this.label22.Text = "ТТН";
            // 
            // deliveryCBox
            // 
            this.deliveryCBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.deliveryCBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.deliveryCBox.FormattingEnabled = true;
            this.deliveryCBox.Location = new System.Drawing.Point(263, 544);
            this.deliveryCBox.Name = "deliveryCBox";
            this.deliveryCBox.Size = new System.Drawing.Size(265, 21);
            this.deliveryCBox.TabIndex = 576;
            this.deliveryCBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.deliveryCBox_KeyPress);
            this.deliveryCBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.deliveryCBox_KeyUp);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(260, 528);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(68, 13);
            this.label21.TabIndex = 579;
            this.label21.Text = "Перевозчик";
            // 
            // deleteBtn
            // 
            this.deleteBtn.Image = global::Accounting.Properties.Resources.Edit_Delete;
            this.deleteBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.deleteBtn.Location = new System.Drawing.Point(166, 13);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(167, 24);
            this.deleteBtn.TabIndex = 585;
            this.deleteBtn.Text = "&Видалити";
            this.deleteBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // addTtnBtn
            // 
            this.addTtnBtn.Image = global::Accounting.Properties.Resources.Edit_Add;
            this.addTtnBtn.Location = new System.Drawing.Point(12, 13);
            this.addTtnBtn.Name = "addTtnBtn";
            this.addTtnBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.addTtnBtn.Size = new System.Drawing.Size(148, 24);
            this.addTtnBtn.TabIndex = 587;
            this.addTtnBtn.Text = "&Додати";
            this.addTtnBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addTtnBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addTtnBtn.UseVisualStyleBackColor = true;
            this.addTtnBtn.Click += new System.EventHandler(this.addTtnBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Image = global::Accounting.Properties.Resources.Save_go;
            this.okBtn.Location = new System.Drawing.Point(1237, 544);
            this.okBtn.Name = "okBtn";
            this.okBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.okBtn.Size = new System.Drawing.Size(111, 24);
            this.okBtn.TabIndex = 580;
            this.okBtn.Text = "&Зберегти";
            this.okBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.okBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Image = global::Accounting.Properties.Resources.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(1354, 545);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cancelBtn.Size = new System.Drawing.Size(115, 24);
            this.cancelBtn.TabIndex = 581;
            this.cancelBtn.Text = "&Відмінити";
            this.cancelBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cancelBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // printBtn
            // 
            this.printBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.printBtn.Image = global::Accounting.Properties.Resources.PrintFixedAssetsCard;
            this.printBtn.Location = new System.Drawing.Point(1318, 12);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(150, 23);
            this.printBtn.TabIndex = 2;
            this.printBtn.Text = "Друк ТТН";
            this.printBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.printBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // deliveryFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1480, 585);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.addTtnBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.orderDeliveryPriceTBox);
            this.Controls.Add(this.deliveryPaymentTypeCBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.invoiceDeliveryDatePicker);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.ttnTBox);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.deliveryCBox);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.printBtn);
            this.Controls.Add(this.deliveryGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "deliveryFm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Товарно транспортні документи";
            ((System.ComponentModel.ISupportInitialize)(this.deliveryGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl deliveryGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView deliveryGridView;
        private DevExpress.XtraGrid.Columns.GridColumn vendorCodeColumn;
        private DevExpress.XtraGrid.Columns.GridColumn vendorNameColumn;
        private DevExpress.XtraGrid.Columns.GridColumn receiptNumColumn;
        private DevExpress.XtraGrid.Columns.GridColumn orderDeliveryTTNColumn;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn orderDeliveryNameColumn;
        private DevExpress.XtraGrid.Columns.GridColumn orderDeliveryDateColumn;
        private DevExpress.XtraGrid.Columns.GridColumn orderDeliveryPriceColumn;
        private DevExpress.XtraGrid.Columns.GridColumn orderPriceTypaNameCol;
        private DevExpress.XtraGrid.Columns.GridColumn orderDateCol;
        private DevExpress.XtraGrid.Columns.GridColumn invoiceDateCol;
        private System.Windows.Forms.TextBox orderDeliveryPriceTBox;
        private System.Windows.Forms.ComboBox deliveryPaymentTypeCBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DateTimePicker invoiceDeliveryDatePicker;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox ttnTBox;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox deliveryCBox;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button addTtnBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button printBtn;
    }
}