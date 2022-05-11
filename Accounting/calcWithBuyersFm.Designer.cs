namespace Accounting
{
    partial class calcWithBuyersFm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.closeMonthChBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.monthEndCBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.yearEndCBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.monthBeginCBox = new System.Windows.Forms.ComboBox();
            this.yearBeginCBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.calcGrid = new DevExpress.XtraGrid.GridControl();
            this.calcGridView = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.buyersNumColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.buyersNameColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.orderNumberColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.documentDateColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.documentNameColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.balanceNumColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.purposeNumColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.paymentDebetColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.paymentDebetCurrencyColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.paymentCreditColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.paymentCreditCurrencyColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand7 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.currencyNameColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.currencyRateColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.commentColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.addBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.toExcelBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calcGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.closeMonthChBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.monthEndCBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.yearEndCBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.monthBeginCBox);
            this.groupBox2.Controls.Add(this.yearBeginCBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(13, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1478, 69);
            this.groupBox2.TabIndex = 148;
            this.groupBox2.TabStop = false;
            // 
            // closeMonthChBox
            // 
            this.closeMonthChBox.AutoSize = true;
            this.closeMonthChBox.Location = new System.Drawing.Point(9, 46);
            this.closeMonthChBox.Name = "closeMonthChBox";
            this.closeMonthChBox.Size = new System.Drawing.Size(103, 17);
            this.closeMonthChBox.TabIndex = 147;
            this.closeMonthChBox.Text = "&Закрити період";
            this.closeMonthChBox.UseVisualStyleBackColor = true;
            this.closeMonthChBox.CheckedChanged += new System.EventHandler(this.closeMonthChBox_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(6, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 137;
            this.label5.Text = "Період з:";
            // 
            // monthEndCBox
            // 
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
            this.monthEndCBox.Location = new System.Drawing.Point(658, 14);
            this.monthEndCBox.Name = "monthEndCBox";
            this.monthEndCBox.Size = new System.Drawing.Size(121, 21);
            this.monthEndCBox.TabIndex = 146;
            this.monthEndCBox.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(616, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 141;
            this.label4.Text = "Місяць";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(393, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 142;
            this.label6.Text = "Період по:";
            // 
            // yearEndCBox
            // 
            this.yearEndCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearEndCBox.FormattingEnabled = true;
            this.yearEndCBox.Items.AddRange(new object[] {
            "2004",
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020"});
            this.yearEndCBox.Location = new System.Drawing.Point(490, 14);
            this.yearEndCBox.Name = "yearEndCBox";
            this.yearEndCBox.Size = new System.Drawing.Size(121, 21);
            this.yearEndCBox.TabIndex = 145;
            this.yearEndCBox.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(463, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 140;
            this.label3.Text = "Рік";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 138;
            this.label1.Text = "Рік";
            // 
            // monthBeginCBox
            // 
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
            this.monthBeginCBox.Location = new System.Drawing.Point(265, 14);
            this.monthBeginCBox.Name = "monthBeginCBox";
            this.monthBeginCBox.Size = new System.Drawing.Size(121, 21);
            this.monthBeginCBox.TabIndex = 144;
            this.monthBeginCBox.TabStop = false;
            // 
            // yearBeginCBox
            // 
            this.yearBeginCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearBeginCBox.FormattingEnabled = true;
            this.yearBeginCBox.Items.AddRange(new object[] {
            "2004",
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020"});
            this.yearBeginCBox.Location = new System.Drawing.Point(95, 14);
            this.yearBeginCBox.Name = "yearBeginCBox";
            this.yearBeginCBox.Size = new System.Drawing.Size(121, 21);
            this.yearBeginCBox.TabIndex = 143;
            this.yearBeginCBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 139;
            this.label2.Text = "Місяць";
            // 
            // calcGrid
            // 
            this.calcGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.calcGrid.Location = new System.Drawing.Point(19, 110);
            this.calcGrid.MainView = this.calcGridView;
            this.calcGrid.Name = "calcGrid";
            this.calcGrid.Size = new System.Drawing.Size(1479, 583);
            this.calcGrid.TabIndex = 149;
            this.calcGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.calcGridView});
            // 
            // calcGridView
            // 
            this.calcGridView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.calcGridView.Appearance.FooterPanel.Options.UseFont = true;
            this.calcGridView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand4,
            this.gridBand3,
            this.gridBand5,
            this.gridBand1,
            this.gridBand6,
            this.gridBand7,
            this.gridBand2});
            this.calcGridView.ColumnPanelRowHeight = 40;
            this.calcGridView.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.documentNameColumn,
            this.documentDateColumn,
            this.buyersNumColumn,
            this.buyersNameColumn,
            this.paymentDebetColumn,
            this.balanceNumColumn,
            this.purposeNumColumn,
            this.paymentDebetCurrencyColumn,
            this.currencyRateColumn,
            this.currencyNameColumn,
            this.commentColumn,
            this.paymentCreditColumn,
            this.paymentCreditCurrencyColumn,
            this.orderNumberColumn});
            this.calcGridView.GridControl = this.calcGrid;
            this.calcGridView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.calcGridView.Name = "calcGridView";
            this.calcGridView.OptionsView.ShowAutoFilterRow = true;
            this.calcGridView.OptionsView.ShowFooter = true;
            this.calcGridView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.calcGridView_KeyUp);
            this.calcGridView.DoubleClick += new System.EventHandler(this.calcGridView_DoubleClick);
            // 
            // gridBand4
            // 
            this.gridBand4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand4.AppearanceHeader.Options.UseFont = true;
            this.gridBand4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand4.Caption = "Покупці/Замовники";
            this.gridBand4.Columns.Add(this.buyersNumColumn);
            this.gridBand4.Columns.Add(this.buyersNameColumn);
            this.gridBand4.Columns.Add(this.orderNumberColumn);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.Width = 341;
            // 
            // buyersNumColumn
            // 
            this.buyersNumColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.buyersNumColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.buyersNumColumn.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.buyersNumColumn.Caption = "ЄДРПОУ/ Таб.номер";
            this.buyersNumColumn.FieldName = "Contractor_Srn";
            this.buyersNumColumn.Name = "buyersNumColumn";
            this.buyersNumColumn.OptionsColumn.AllowEdit = false;
            this.buyersNumColumn.OptionsColumn.AllowFocus = false;
            this.buyersNumColumn.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Contractor_Srn", "Всього:   {0}")});
            this.buyersNumColumn.Visible = true;
            this.buyersNumColumn.Width = 90;
            // 
            // buyersNameColumn
            // 
            this.buyersNameColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.buyersNameColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.buyersNameColumn.Caption = "Найменування";
            this.buyersNameColumn.FieldName = "Contractor_Name";
            this.buyersNameColumn.Name = "buyersNameColumn";
            this.buyersNameColumn.OptionsColumn.AllowEdit = false;
            this.buyersNameColumn.OptionsColumn.AllowFocus = false;
            this.buyersNameColumn.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.buyersNameColumn.Visible = true;
            this.buyersNameColumn.Width = 175;
            // 
            // orderNumberColumn
            // 
            this.orderNumberColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.orderNumberColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.orderNumberColumn.Caption = "Заказ";
            this.orderNumberColumn.FieldName = "OrderNumber";
            this.orderNumberColumn.Name = "orderNumberColumn";
            this.orderNumberColumn.OptionsColumn.AllowEdit = false;
            this.orderNumberColumn.OptionsColumn.AllowFocus = false;
            this.orderNumberColumn.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.orderNumberColumn.Visible = true;
            this.orderNumberColumn.Width = 76;
            // 
            // gridBand3
            // 
            this.gridBand3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand3.AppearanceHeader.Options.UseFont = true;
            this.gridBand3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand3.Caption = "Документ";
            this.gridBand3.Columns.Add(this.documentDateColumn);
            this.gridBand3.Columns.Add(this.documentNameColumn);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.Width = 177;
            // 
            // documentDateColumn
            // 
            this.documentDateColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.documentDateColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.documentDateColumn.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.documentDateColumn.Caption = "Дата";
            this.documentDateColumn.FieldName = "DocumentDate";
            this.documentDateColumn.Name = "documentDateColumn";
            this.documentDateColumn.OptionsColumn.AllowEdit = false;
            this.documentDateColumn.OptionsColumn.AllowFocus = false;
            this.documentDateColumn.Visible = true;
            this.documentDateColumn.Width = 72;
            // 
            // documentNameColumn
            // 
            this.documentNameColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.documentNameColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.documentNameColumn.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.documentNameColumn.Caption = "Номер";
            this.documentNameColumn.FieldName = "DocumentName";
            this.documentNameColumn.Name = "documentNameColumn";
            this.documentNameColumn.OptionsColumn.AllowEdit = false;
            this.documentNameColumn.OptionsColumn.AllowFocus = false;
            this.documentNameColumn.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.documentNameColumn.Visible = true;
            this.documentNameColumn.Width = 105;
            // 
            // gridBand5
            // 
            this.gridBand5.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand5.AppearanceHeader.Options.UseFont = true;
            this.gridBand5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand5.Caption = "Рахунки";
            this.gridBand5.Columns.Add(this.balanceNumColumn);
            this.gridBand5.Columns.Add(this.purposeNumColumn);
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.Width = 146;
            // 
            // balanceNumColumn
            // 
            this.balanceNumColumn.AppearanceCell.Options.UseTextOptions = true;
            this.balanceNumColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.balanceNumColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.balanceNumColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.balanceNumColumn.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.balanceNumColumn.Caption = "Балансовий рахунок";
            this.balanceNumColumn.FieldName = "BalanceNum";
            this.balanceNumColumn.Name = "balanceNumColumn";
            this.balanceNumColumn.OptionsColumn.AllowEdit = false;
            this.balanceNumColumn.OptionsColumn.AllowFocus = false;
            this.balanceNumColumn.Visible = true;
            this.balanceNumColumn.Width = 71;
            // 
            // purposeNumColumn
            // 
            this.purposeNumColumn.AppearanceCell.Options.UseTextOptions = true;
            this.purposeNumColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.purposeNumColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.purposeNumColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.purposeNumColumn.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.purposeNumColumn.Caption = "Рахунок призначення";
            this.purposeNumColumn.FieldName = "PurposeNum";
            this.purposeNumColumn.Name = "purposeNumColumn";
            this.purposeNumColumn.OptionsColumn.AllowEdit = false;
            this.purposeNumColumn.OptionsColumn.AllowFocus = false;
            this.purposeNumColumn.Visible = true;
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand1.AppearanceHeader.Options.UseFont = true;
            this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand1.Caption = "Дебет";
            this.gridBand1.Columns.Add(this.paymentDebetColumn);
            this.gridBand1.Columns.Add(this.paymentDebetCurrencyColumn);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.Width = 192;
            // 
            // paymentDebetColumn
            // 
            this.paymentDebetColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.paymentDebetColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.paymentDebetColumn.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.paymentDebetColumn.Caption = "Сума у гривні";
            this.paymentDebetColumn.DisplayFormat.FormatString = "### ### ##0.00";
            this.paymentDebetColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.paymentDebetColumn.FieldName = "PaymentDebet";
            this.paymentDebetColumn.Name = "paymentDebetColumn";
            this.paymentDebetColumn.OptionsColumn.AllowEdit = false;
            this.paymentDebetColumn.OptionsColumn.AllowFocus = false;
            this.paymentDebetColumn.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PaymentDebet", "{0:### ### ##0.00}")});
            this.paymentDebetColumn.Visible = true;
            this.paymentDebetColumn.Width = 96;
            // 
            // paymentDebetCurrencyColumn
            // 
            this.paymentDebetCurrencyColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.paymentDebetCurrencyColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.paymentDebetCurrencyColumn.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.paymentDebetCurrencyColumn.Caption = "Сума у валюті";
            this.paymentDebetCurrencyColumn.DisplayFormat.FormatString = "### ### ##0.00";
            this.paymentDebetCurrencyColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.paymentDebetCurrencyColumn.FieldName = "PaymentDebetCurrency";
            this.paymentDebetCurrencyColumn.Name = "paymentDebetCurrencyColumn";
            this.paymentDebetCurrencyColumn.OptionsColumn.AllowEdit = false;
            this.paymentDebetCurrencyColumn.OptionsColumn.AllowFocus = false;
            this.paymentDebetCurrencyColumn.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PaymentDebetCurrency", "{0:### ### ##0.00}")});
            this.paymentDebetCurrencyColumn.Visible = true;
            this.paymentDebetCurrencyColumn.Width = 96;
            // 
            // gridBand6
            // 
            this.gridBand6.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand6.AppearanceHeader.Options.UseFont = true;
            this.gridBand6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand6.Caption = "Кредит";
            this.gridBand6.Columns.Add(this.paymentCreditColumn);
            this.gridBand6.Columns.Add(this.paymentCreditCurrencyColumn);
            this.gridBand6.Name = "gridBand6";
            this.gridBand6.Width = 192;
            // 
            // paymentCreditColumn
            // 
            this.paymentCreditColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.paymentCreditColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.paymentCreditColumn.Caption = "Сума у гривні";
            this.paymentCreditColumn.DisplayFormat.FormatString = "### ### ##0.00";
            this.paymentCreditColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.paymentCreditColumn.FieldName = "PaymentCredit";
            this.paymentCreditColumn.Name = "paymentCreditColumn";
            this.paymentCreditColumn.OptionsColumn.AllowEdit = false;
            this.paymentCreditColumn.OptionsColumn.AllowFocus = false;
            this.paymentCreditColumn.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PaymentCredit", "{0:### ### ##0.00}")});
            this.paymentCreditColumn.Visible = true;
            this.paymentCreditColumn.Width = 96;
            // 
            // paymentCreditCurrencyColumn
            // 
            this.paymentCreditCurrencyColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.paymentCreditCurrencyColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.paymentCreditCurrencyColumn.Caption = "Сума у валюті";
            this.paymentCreditCurrencyColumn.DisplayFormat.FormatString = "### ### ##0.00";
            this.paymentCreditCurrencyColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.paymentCreditCurrencyColumn.FieldName = "PaymentCreditCurrency";
            this.paymentCreditCurrencyColumn.Name = "paymentCreditCurrencyColumn";
            this.paymentCreditCurrencyColumn.OptionsColumn.AllowEdit = false;
            this.paymentCreditCurrencyColumn.OptionsColumn.AllowFocus = false;
            this.paymentCreditCurrencyColumn.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PaymentCreditCurrency", "{0:### ### ##0.00}")});
            this.paymentCreditCurrencyColumn.Visible = true;
            this.paymentCreditCurrencyColumn.Width = 96;
            // 
            // gridBand7
            // 
            this.gridBand7.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand7.AppearanceHeader.Options.UseFont = true;
            this.gridBand7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand7.Caption = "Валюта";
            this.gridBand7.Columns.Add(this.currencyNameColumn);
            this.gridBand7.Columns.Add(this.currencyRateColumn);
            this.gridBand7.Name = "gridBand7";
            this.gridBand7.Width = 96;
            // 
            // currencyNameColumn
            // 
            this.currencyNameColumn.AppearanceCell.Options.UseTextOptions = true;
            this.currencyNameColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.currencyNameColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.currencyNameColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.currencyNameColumn.Caption = "Код";
            this.currencyNameColumn.FieldName = "CurrencyName";
            this.currencyNameColumn.Name = "currencyNameColumn";
            this.currencyNameColumn.OptionsColumn.AllowEdit = false;
            this.currencyNameColumn.OptionsColumn.AllowFocus = false;
            this.currencyNameColumn.Visible = true;
            this.currencyNameColumn.Width = 38;
            // 
            // currencyRateColumn
            // 
            this.currencyRateColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.currencyRateColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.currencyRateColumn.Caption = "Курс";
            this.currencyRateColumn.DisplayFormat.FormatString = "### ### ##0.000000";
            this.currencyRateColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.currencyRateColumn.FieldName = "Rate";
            this.currencyRateColumn.Name = "currencyRateColumn";
            this.currencyRateColumn.OptionsColumn.AllowEdit = false;
            this.currencyRateColumn.OptionsColumn.AllowFocus = false;
            this.currencyRateColumn.Visible = true;
            this.currencyRateColumn.Width = 58;
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand2.AppearanceHeader.Options.UseFont = true;
            this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand2.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridBand2.Caption = "Додатково";
            this.gridBand2.Columns.Add(this.commentColumn);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.Width = 324;
            // 
            // commentColumn
            // 
            this.commentColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.commentColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.commentColumn.Caption = "Коментар";
            this.commentColumn.FieldName = "Comment";
            this.commentColumn.MinWidth = 320;
            this.commentColumn.Name = "commentColumn";
            this.commentColumn.OptionsColumn.AllowEdit = false;
            this.commentColumn.OptionsColumn.AllowFocus = false;
            this.commentColumn.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.commentColumn.Visible = true;
            this.commentColumn.Width = 324;
            // 
            // addBtn
            // 
            this.addBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.addBtn.Image = global::Accounting.Properties.Resources.Edit_Add;
            this.addBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addBtn.Location = new System.Drawing.Point(12, 78);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(143, 24);
            this.addBtn.TabIndex = 152;
            this.addBtn.Text = "&Додати";
            this.addBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.Image = global::Accounting.Properties.Resources.Edit_Update;
            this.editBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.editBtn.Location = new System.Drawing.Point(161, 78);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(143, 24);
            this.editBtn.TabIndex = 151;
            this.editBtn.Text = "Редагувати";
            this.editBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Image = global::Accounting.Properties.Resources.Edit_Delete;
            this.deleteBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.deleteBtn.Location = new System.Drawing.Point(310, 78);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(143, 24);
            this.deleteBtn.TabIndex = 150;
            this.deleteBtn.Text = "Видалити";
            this.deleteBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // toExcelBtn
            // 
            this.toExcelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toExcelBtn.Image = global::Accounting.Properties.Resources.PrintFixedAssetsCard;
            this.toExcelBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toExcelBtn.Location = new System.Drawing.Point(1348, 78);
            this.toExcelBtn.Name = "toExcelBtn";
            this.toExcelBtn.Size = new System.Drawing.Size(143, 24);
            this.toExcelBtn.TabIndex = 153;
            this.toExcelBtn.Text = "Сформувати звіт";
            this.toExcelBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toExcelBtn.UseVisualStyleBackColor = true;
            this.toExcelBtn.Click += new System.EventHandler(this.toExcelBtn_Click);
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
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Location = new System.Drawing.Point(12, 699);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1479, 35);
            this.groupBox1.TabIndex = 154;
            this.groupBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(444, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 163;
            this.label7.Text = "- видалити запис";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(295, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 13);
            this.label8.TabIndex = 162;
            this.label8.Text = "- додати новий запис";
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(260, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 13);
            this.label9.TabIndex = 159;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(7, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 15);
            this.label10.TabIndex = 157;
            this.label10.Text = "          ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(62, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(181, 13);
            this.label11.TabIndex = 158;
            this.label11.Text = "- Додана сума конвертації валюти";
            // 
            // calcWithBuyersFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1503, 746);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toExcelBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.calcGrid);
            this.Controls.Add(this.groupBox2);
            this.Name = "calcWithBuyersFm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Розрахунки з покупцями та замовниками";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.calcWithBuyersFm_FormClosed);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calcGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox monthEndCBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox yearEndCBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox monthBeginCBox;
        private System.Windows.Forms.ComboBox yearBeginCBox;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.GridControl calcGrid;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button deleteBtn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView calcGridView;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn documentNameColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn documentDateColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn buyersNumColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn buyersNameColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn paymentDebetColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn balanceNumColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn purposeNumColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn paymentDebetCurrencyColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn currencyRateColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn currencyNameColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn commentColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn paymentCreditColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn paymentCreditCurrencyColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn orderNumberColumn;
        private System.Windows.Forms.CheckBox closeMonthChBox;
        private System.Windows.Forms.Button toExcelBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand6;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand7;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
    }
}