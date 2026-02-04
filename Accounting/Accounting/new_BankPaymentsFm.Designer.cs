namespace Accounting
{
    partial class new_BankPaymentsFm
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
            this.toExcelBtn = new System.Windows.Forms.Button();
            this.monthEndCBox = new System.Windows.Forms.ComboBox();
            this.yearEndCBox = new System.Windows.Forms.ComboBox();
            this.monthBeginCBox = new System.Windows.Forms.ComboBox();
            this.yearBeginCBox = new System.Windows.Forms.ComboBox();
            this.bankPaymentsGrid = new DevExpress.XtraGrid.GridControl();
            this.bankPaymentsGridView = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.partnerSrnColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.partnerNameColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.customerOrderColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.paymentDateColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.paymentDocumentColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.paymentAccountColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.purposeAccountColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.debitColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.debitPriceCurrencyColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.creditColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.creditPriceCurrencyColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.currencyNameColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.rateColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand7 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.purposeColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.closeMonthChBox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.addBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.importBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bankPaymentsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankPaymentsGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toExcelBtn
            // 
            this.toExcelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toExcelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toExcelBtn.Image = global::Accounting.Properties.Resources.PrintFixedAssetsCard;
            this.toExcelBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toExcelBtn.Location = new System.Drawing.Point(1348, 87);
            this.toExcelBtn.Name = "toExcelBtn";
            this.toExcelBtn.Size = new System.Drawing.Size(143, 24);
            this.toExcelBtn.TabIndex = 27;
            this.toExcelBtn.Text = "Сформувати звіт";
            this.toExcelBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toExcelBtn.UseVisualStyleBackColor = true;
            this.toExcelBtn.Click += new System.EventHandler(this.toExcelBtn_Click);
            // 
            // monthEndCBox
            // 
            this.monthEndCBox.DisplayMember = "MonthText";
            this.monthEndCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.monthEndCBox.FormattingEnabled = true;
            this.monthEndCBox.Items.AddRange(new object[] {
            "01 Січень",
            "02 Лютий",
            "03 Березень",
            "04 Квітень",
            "05 Травень",
            "06 Червень",
            "07 Липень",
            "08 Серпень",
            "09 Вересень",
            "10 Жовтень",
            "11 Листопад",
            "12 Грудень"});
            this.monthEndCBox.Location = new System.Drawing.Point(588, 13);
            this.monthEndCBox.Name = "monthEndCBox";
            this.monthEndCBox.Size = new System.Drawing.Size(93, 21);
            this.monthEndCBox.TabIndex = 20;
            this.monthEndCBox.ValueMember = "Month";
            // 
            // yearEndCBox
            // 
            this.yearEndCBox.DisplayMember = "YearText";
            this.yearEndCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearEndCBox.FormattingEnabled = true;
            this.yearEndCBox.Items.AddRange(new object[] {
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026"});
            this.yearEndCBox.Location = new System.Drawing.Point(441, 14);
            this.yearEndCBox.Name = "yearEndCBox";
            this.yearEndCBox.Size = new System.Drawing.Size(93, 21);
            this.yearEndCBox.TabIndex = 19;
            this.yearEndCBox.ValueMember = "Year";
            // 
            // monthBeginCBox
            // 
            this.monthBeginCBox.DisplayMember = "MonthText";
            this.monthBeginCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.monthBeginCBox.FormattingEnabled = true;
            this.monthBeginCBox.Items.AddRange(new object[] {
            "01 Січень",
            "02 Лютий",
            "03 Березень",
            "04 Квітень",
            "05 Травень",
            "06 Червень",
            "07 Липень",
            "08 Серпень",
            "09 Вересень",
            "10 Жовтень",
            "11 Листопад",
            "12 Грудень"});
            this.monthBeginCBox.Location = new System.Drawing.Point(244, 14);
            this.monthBeginCBox.Name = "monthBeginCBox";
            this.monthBeginCBox.Size = new System.Drawing.Size(93, 21);
            this.monthBeginCBox.TabIndex = 18;
            this.monthBeginCBox.ValueMember = "Month";
            // 
            // yearBeginCBox
            // 
            this.yearBeginCBox.DisplayMember = "YearText";
            this.yearBeginCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearBeginCBox.FormattingEnabled = true;
            this.yearBeginCBox.Items.AddRange(new object[] {
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026"});
            this.yearBeginCBox.Location = new System.Drawing.Point(97, 14);
            this.yearBeginCBox.Name = "yearBeginCBox";
            this.yearBeginCBox.Size = new System.Drawing.Size(93, 21);
            this.yearBeginCBox.TabIndex = 17;
            this.yearBeginCBox.ValueMember = "Year";
            // 
            // bankPaymentsGrid
            // 
            this.bankPaymentsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bankPaymentsGrid.Location = new System.Drawing.Point(12, 117);
            this.bankPaymentsGrid.MainView = this.bankPaymentsGridView;
            this.bankPaymentsGrid.Name = "bankPaymentsGrid";
            this.bankPaymentsGrid.Size = new System.Drawing.Size(1479, 576);
            this.bankPaymentsGrid.TabIndex = 0;
            this.bankPaymentsGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bankPaymentsGridView});
            // 
            // bankPaymentsGridView
            // 
            this.bankPaymentsGridView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bankPaymentsGridView.Appearance.FooterPanel.Options.UseFont = true;
            this.bankPaymentsGridView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand6,
            this.gridBand5,
            this.gridBand2,
            this.gridBand3,
            this.gridBand4,
            this.gridBand7});
            this.bankPaymentsGridView.ColumnPanelRowHeight = 40;
            this.bankPaymentsGridView.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.partnerSrnColumn,
            this.partnerNameColumn,
            this.paymentDateColumn,
            this.paymentDocumentColumn,
            this.paymentAccountColumn,
            this.purposeAccountColumn,
            this.debitColumn,
            this.debitPriceCurrencyColumn,
            this.creditColumn,
            this.creditPriceCurrencyColumn,
            this.purposeColumn,
            this.currencyNameColumn,
            this.rateColumn,
            this.customerOrderColumn});
            this.bankPaymentsGridView.GridControl = this.bankPaymentsGrid;
            this.bankPaymentsGridView.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DEBIT_PRICECURRENCY", this.debitPriceCurrencyColumn, "")});
            this.bankPaymentsGridView.Name = "bankPaymentsGridView";
            this.bankPaymentsGridView.OptionsPrint.AutoWidth = false;
            this.bankPaymentsGridView.OptionsSelection.MultiSelect = true;
            this.bankPaymentsGridView.OptionsView.ColumnAutoWidth = true;
            this.bankPaymentsGridView.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.bankPaymentsGridView.OptionsView.ShowAutoFilterRow = true;
            this.bankPaymentsGridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.bankPaymentsGridView.OptionsView.ShowFooter = true;
            this.bankPaymentsGridView.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.bankPaymentsGridView_RowStyle);
            this.bankPaymentsGridView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.bankPaymentsGridView_KeyUp);
            this.bankPaymentsGridView.DoubleClick += new System.EventHandler(this.bankPaymentsGridView_DoubleClick);
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand1.AppearanceHeader.Options.UseFont = true;
            this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand1.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridBand1.Caption = "Контрагент/працівник";
            this.gridBand1.Columns.Add(this.partnerSrnColumn);
            this.gridBand1.Columns.Add(this.partnerNameColumn);
            this.gridBand1.Columns.Add(this.customerOrderColumn);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 503;
            // 
            // partnerSrnColumn
            // 
            this.partnerSrnColumn.AppearanceCell.Options.UseTextOptions = true;
            this.partnerSrnColumn.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.partnerSrnColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.partnerSrnColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.partnerSrnColumn.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.partnerSrnColumn.Caption = "ЄДРПОУ/ Таб.номер";
            this.partnerSrnColumn.FieldName = "PARTNERSRN";
            this.partnerSrnColumn.MinWidth = 78;
            this.partnerSrnColumn.Name = "partnerSrnColumn";
            this.partnerSrnColumn.OptionsColumn.AllowEdit = false;
            this.partnerSrnColumn.OptionsColumn.AllowFocus = false;
            this.partnerSrnColumn.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "PARTNERSRN", "Всього:  {0}")});
            this.partnerSrnColumn.Visible = true;
            this.partnerSrnColumn.Width = 78;
            // 
            // partnerNameColumn
            // 
            this.partnerNameColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.partnerNameColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.partnerNameColumn.Caption = "Найменування";
            this.partnerNameColumn.FieldName = "PARTNERNAME";
            this.partnerNameColumn.Name = "partnerNameColumn";
            this.partnerNameColumn.OptionsColumn.AllowEdit = false;
            this.partnerNameColumn.OptionsColumn.AllowFocus = false;
            this.partnerNameColumn.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.partnerNameColumn.Visible = true;
            this.partnerNameColumn.Width = 350;
            // 
            // customerOrderColumn
            // 
            this.customerOrderColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.customerOrderColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.customerOrderColumn.Caption = "Заказ";
            this.customerOrderColumn.FieldName = "OrderNumber";
            this.customerOrderColumn.Name = "customerOrderColumn";
            this.customerOrderColumn.OptionsColumn.AllowEdit = false;
            this.customerOrderColumn.OptionsColumn.AllowFocus = false;
            this.customerOrderColumn.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.customerOrderColumn.Visible = true;
            // 
            // gridBand6
            // 
            this.gridBand6.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand6.AppearanceHeader.Options.UseFont = true;
            this.gridBand6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand6.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridBand6.Caption = "Платіжний документ";
            this.gridBand6.Columns.Add(this.paymentDateColumn);
            this.gridBand6.Columns.Add(this.paymentDocumentColumn);
            this.gridBand6.Name = "gridBand6";
            this.gridBand6.VisibleIndex = 1;
            this.gridBand6.Width = 170;
            // 
            // paymentDateColumn
            // 
            this.paymentDateColumn.AppearanceCell.Options.UseTextOptions = true;
            this.paymentDateColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.paymentDateColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.paymentDateColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.paymentDateColumn.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.paymentDateColumn.Caption = "Дата";
            this.paymentDateColumn.DisplayFormat.FormatString = "d";
            this.paymentDateColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.paymentDateColumn.FieldName = "Payment_Date";
            this.paymentDateColumn.MinWidth = 75;
            this.paymentDateColumn.Name = "paymentDateColumn";
            this.paymentDateColumn.OptionsColumn.AllowEdit = false;
            this.paymentDateColumn.OptionsColumn.AllowFocus = false;
            this.paymentDateColumn.Visible = true;
            // 
            // paymentDocumentColumn
            // 
            this.paymentDocumentColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.paymentDocumentColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.paymentDocumentColumn.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.paymentDocumentColumn.Caption = "Номер ";
            this.paymentDocumentColumn.FieldName = "Payment_Document";
            this.paymentDocumentColumn.MinWidth = 95;
            this.paymentDocumentColumn.Name = "paymentDocumentColumn";
            this.paymentDocumentColumn.OptionsColumn.AllowEdit = false;
            this.paymentDocumentColumn.OptionsColumn.AllowFocus = false;
            this.paymentDocumentColumn.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.paymentDocumentColumn.Visible = true;
            this.paymentDocumentColumn.Width = 95;
            // 
            // gridBand5
            // 
            this.gridBand5.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand5.AppearanceHeader.Options.UseFont = true;
            this.gridBand5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand5.Caption = "Рахунки";
            this.gridBand5.Columns.Add(this.paymentAccountColumn);
            this.gridBand5.Columns.Add(this.purposeAccountColumn);
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.VisibleIndex = 2;
            this.gridBand5.Width = 180;
            // 
            // paymentAccountColumn
            // 
            this.paymentAccountColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.paymentAccountColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.paymentAccountColumn.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.paymentAccountColumn.Caption = "Рахунок банку";
            this.paymentAccountColumn.FieldName = "BANK_ACCOUNT_NUM";
            this.paymentAccountColumn.MinWidth = 90;
            this.paymentAccountColumn.Name = "paymentAccountColumn";
            this.paymentAccountColumn.OptionsColumn.AllowEdit = false;
            this.paymentAccountColumn.OptionsColumn.AllowFocus = false;
            this.paymentAccountColumn.Visible = true;
            this.paymentAccountColumn.Width = 90;
            // 
            // purposeAccountColumn
            // 
            this.purposeAccountColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.purposeAccountColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.purposeAccountColumn.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.purposeAccountColumn.Caption = "Рахунок призначення";
            this.purposeAccountColumn.FieldName = "PURPOSE_ACCOUNT_NUM";
            this.purposeAccountColumn.MinWidth = 90;
            this.purposeAccountColumn.Name = "purposeAccountColumn";
            this.purposeAccountColumn.OptionsColumn.AllowEdit = false;
            this.purposeAccountColumn.OptionsColumn.AllowFocus = false;
            this.purposeAccountColumn.Visible = true;
            this.purposeAccountColumn.Width = 90;
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand2.AppearanceHeader.Options.UseFont = true;
            this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand2.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridBand2.Caption = "Дебет";
            this.gridBand2.Columns.Add(this.debitColumn);
            this.gridBand2.Columns.Add(this.debitPriceCurrencyColumn);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 3;
            this.gridBand2.Width = 200;
            // 
            // debitColumn
            // 
            this.debitColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.debitColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.debitColumn.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.debitColumn.Caption = "Сума у гривні";
            this.debitColumn.DisplayFormat.FormatString = "### ### ##0.00";
            this.debitColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.debitColumn.FieldName = "DEBIT_PRICE";
            this.debitColumn.MinWidth = 100;
            this.debitColumn.Name = "debitColumn";
            this.debitColumn.OptionsColumn.AllowEdit = false;
            this.debitColumn.OptionsColumn.AllowFocus = false;
            this.debitColumn.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DEBIT_PRICE", "{0:### ### ##0.00}")});
            this.debitColumn.Visible = true;
            this.debitColumn.Width = 100;
            // 
            // debitPriceCurrencyColumn
            // 
            this.debitPriceCurrencyColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.debitPriceCurrencyColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.debitPriceCurrencyColumn.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.debitPriceCurrencyColumn.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.debitPriceCurrencyColumn.Caption = "Сума у валюті";
            this.debitPriceCurrencyColumn.DisplayFormat.FormatString = "### ### ##0.00";
            this.debitPriceCurrencyColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.debitPriceCurrencyColumn.FieldName = "DEBIT_PRICECURRENCY";
            this.debitPriceCurrencyColumn.MinWidth = 100;
            this.debitPriceCurrencyColumn.Name = "debitPriceCurrencyColumn";
            this.debitPriceCurrencyColumn.OptionsColumn.AllowEdit = false;
            this.debitPriceCurrencyColumn.OptionsColumn.AllowFocus = false;
            this.debitPriceCurrencyColumn.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DEBIT_PRICECURRENCY", "{0:### ### ##0.00}")});
            this.debitPriceCurrencyColumn.Visible = true;
            this.debitPriceCurrencyColumn.Width = 100;
            // 
            // gridBand3
            // 
            this.gridBand3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand3.AppearanceHeader.Options.UseFont = true;
            this.gridBand3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand3.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridBand3.Caption = "Кредит";
            this.gridBand3.Columns.Add(this.creditColumn);
            this.gridBand3.Columns.Add(this.creditPriceCurrencyColumn);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 4;
            this.gridBand3.Width = 200;
            // 
            // creditColumn
            // 
            this.creditColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.creditColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.creditColumn.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.creditColumn.Caption = "Сума у гривні";
            this.creditColumn.DisplayFormat.FormatString = "### ### ##0.00";
            this.creditColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.creditColumn.FieldName = "CREDIT_PRICE";
            this.creditColumn.MinWidth = 100;
            this.creditColumn.Name = "creditColumn";
            this.creditColumn.OptionsColumn.AllowEdit = false;
            this.creditColumn.OptionsColumn.AllowFocus = false;
            this.creditColumn.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CREDIT_PRICE", "{0:### ### ##0.00}")});
            this.creditColumn.Visible = true;
            this.creditColumn.Width = 100;
            // 
            // creditPriceCurrencyColumn
            // 
            this.creditPriceCurrencyColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.creditPriceCurrencyColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.creditPriceCurrencyColumn.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.creditPriceCurrencyColumn.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.creditPriceCurrencyColumn.Caption = "Сума у валюті";
            this.creditPriceCurrencyColumn.DisplayFormat.FormatString = "### ### ##0.00";
            this.creditPriceCurrencyColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.creditPriceCurrencyColumn.FieldName = "CREDIT_PRICECURRENCY";
            this.creditPriceCurrencyColumn.MinWidth = 100;
            this.creditPriceCurrencyColumn.Name = "creditPriceCurrencyColumn";
            this.creditPriceCurrencyColumn.OptionsColumn.AllowEdit = false;
            this.creditPriceCurrencyColumn.OptionsColumn.AllowFocus = false;
            this.creditPriceCurrencyColumn.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CREDIT_PRICECURRENCY", "{0:### ### ##0.00}")});
            this.creditPriceCurrencyColumn.Visible = true;
            this.creditPriceCurrencyColumn.Width = 100;
            // 
            // gridBand4
            // 
            this.gridBand4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand4.AppearanceHeader.Options.UseFont = true;
            this.gridBand4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand4.Caption = "Валюта";
            this.gridBand4.Columns.Add(this.currencyNameColumn);
            this.gridBand4.Columns.Add(this.rateColumn);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.VisibleIndex = 5;
            this.gridBand4.Width = 135;
            // 
            // currencyNameColumn
            // 
            this.currencyNameColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.currencyNameColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.currencyNameColumn.Caption = "Код";
            this.currencyNameColumn.FieldName = "CURRENCYNAME";
            this.currencyNameColumn.MinWidth = 55;
            this.currencyNameColumn.Name = "currencyNameColumn";
            this.currencyNameColumn.OptionsColumn.AllowEdit = false;
            this.currencyNameColumn.OptionsColumn.AllowFocus = false;
            this.currencyNameColumn.Visible = true;
            this.currencyNameColumn.Width = 55;
            // 
            // rateColumn
            // 
            this.rateColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.rateColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.rateColumn.Caption = "Курс";
            this.rateColumn.DisplayFormat.FormatString = "### ### ##0.000000";
            this.rateColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.rateColumn.FieldName = "Rate";
            this.rateColumn.Name = "rateColumn";
            this.rateColumn.OptionsColumn.AllowEdit = false;
            this.rateColumn.OptionsColumn.AllowFocus = false;
            this.rateColumn.Visible = true;
            this.rateColumn.Width = 80;
            // 
            // gridBand7
            // 
            this.gridBand7.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand7.AppearanceHeader.Options.UseFont = true;
            this.gridBand7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand7.Caption = "Додатково";
            this.gridBand7.Columns.Add(this.purposeColumn);
            this.gridBand7.Name = "gridBand7";
            this.gridBand7.VisibleIndex = 6;
            this.gridBand7.Width = 300;
            // 
            // purposeColumn
            // 
            this.purposeColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.purposeColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.purposeColumn.Caption = "Призначення платежу";
            this.purposeColumn.FieldName = "Purpose";
            this.purposeColumn.Name = "purposeColumn";
            this.purposeColumn.OptionsColumn.AllowEdit = false;
            this.purposeColumn.OptionsColumn.AllowFocus = false;
            this.purposeColumn.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.purposeColumn.Visible = true;
            this.purposeColumn.Width = 300;
            // 
            // closeMonthChBox
            // 
            this.closeMonthChBox.AutoSize = true;
            this.closeMonthChBox.Location = new System.Drawing.Point(9, 46);
            this.closeMonthChBox.Name = "closeMonthChBox";
            this.closeMonthChBox.Size = new System.Drawing.Size(103, 17);
            this.closeMonthChBox.TabIndex = 148;
            this.closeMonthChBox.Text = "&Закрити період";
            this.closeMonthChBox.UseVisualStyleBackColor = true;
            this.closeMonthChBox.CheckedChanged += new System.EventHandler(this.closeMonthChBox_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.closeMonthChBox);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.yearBeginCBox);
            this.groupBox2.Controls.Add(this.monthBeginCBox);
            this.groupBox2.Controls.Add(this.monthEndCBox);
            this.groupBox2.Controls.Add(this.yearEndCBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1479, 69);
            this.groupBox2.TabIndex = 149;
            this.groupBox2.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(6, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 137;
            this.label7.Text = "Період з:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(540, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 141;
            this.label8.Text = "Місяць";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(343, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 142;
            this.label9.Text = "Період по:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(413, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 13);
            this.label10.TabIndex = 140;
            this.label10.Text = "Рік";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(69, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(22, 13);
            this.label11.TabIndex = 138;
            this.label11.Text = "Рік";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(196, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 13);
            this.label12.TabIndex = 139;
            this.label12.Text = "Місяць";
            // 
            // addBtn
            // 
            this.addBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.addBtn.Image = global::Accounting.Properties.Resources.Edit_Add;
            this.addBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addBtn.Location = new System.Drawing.Point(12, 87);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(143, 24);
            this.addBtn.TabIndex = 155;
            this.addBtn.Text = "&Додати";
            this.addBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.Image = global::Accounting.Properties.Resources.Edit_Update;
            this.editBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.editBtn.Location = new System.Drawing.Point(161, 87);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(143, 24);
            this.editBtn.TabIndex = 154;
            this.editBtn.Text = "Редагувати";
            this.editBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Image = global::Accounting.Properties.Resources.Edit_Delete;
            this.deleteBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.deleteBtn.Location = new System.Drawing.Point(310, 87);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(143, 24);
            this.deleteBtn.TabIndex = 153;
            this.deleteBtn.Text = "Видалити";
            this.deleteBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // importBtn
            // 
            this.importBtn.Image = global::Accounting.Properties.Resources.Import;
            this.importBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.importBtn.Location = new System.Drawing.Point(459, 87);
            this.importBtn.Name = "importBtn";
            this.importBtn.Size = new System.Drawing.Size(143, 24);
            this.importBtn.TabIndex = 156;
            this.importBtn.Text = "Імпорт платежів";
            this.importBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.importBtn.UseVisualStyleBackColor = true;
            this.importBtn.Click += new System.EventHandler(this.importBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(7, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 157;
            this.label1.Text = "          ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 13);
            this.label2.TabIndex = 158;
            this.label2.Text = "- Додана сума конвертації валюти";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Linen;
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.labelControl2);
            this.groupBox1.Controls.Add(this.labelControl1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 699);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1479, 35);
            this.groupBox1.TabIndex = 150;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(444, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 163;
            this.label5.Text = "- видалити запис";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(295, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 13);
            this.label4.TabIndex = 162;
            this.label4.Text = "- додати новий запис";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Location = new System.Drawing.Point(423, 13);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(18, 13);
            this.labelControl2.TabIndex = 161;
            this.labelControl2.Text = "Del";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(274, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(18, 13);
            this.labelControl1.TabIndex = 160;
            this.labelControl1.Text = "Ins";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(260, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 159;
            // 
            // new_BankPaymentsFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1503, 746);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.importBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.bankPaymentsGrid);
            this.Controls.Add(this.toExcelBtn);
            this.Name = "new_BankPaymentsFm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Банк";
            ((System.ComponentModel.ISupportInitialize)(this.bankPaymentsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankPaymentsGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button toExcelBtn;
        private System.Windows.Forms.ComboBox monthEndCBox;
        private System.Windows.Forms.ComboBox yearEndCBox;
        private System.Windows.Forms.ComboBox monthBeginCBox;
        private System.Windows.Forms.ComboBox yearBeginCBox;
        private DevExpress.XtraGrid.GridControl bankPaymentsGrid;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView bankPaymentsGridView;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn partnerSrnColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn partnerNameColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn paymentDateColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn paymentDocumentColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn paymentAccountColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn purposeAccountColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn debitColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn creditColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn purposeColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn currencyNameColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn rateColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn debitPriceCurrencyColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn creditPriceCurrencyColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn customerOrderColumn;
        private System.Windows.Forms.CheckBox closeMonthChBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button importBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand6;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand7;
    }
}