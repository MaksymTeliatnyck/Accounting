namespace Accounting
{
    partial class new_importBankPaymentsFm
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
            this.paymentsGrid = new DevExpress.XtraGrid.GridControl();
            this.importCMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rateMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.privatBankItemCurrency = new System.Windows.Forms.ToolStripMenuItem();
            this.poltavaBankItemCurrency = new System.Windows.Forms.ToolStripMenuItem();
            this.fikBankItemCurrency = new System.Windows.Forms.ToolStripMenuItem();
            this.sberBankItemCurrency = new System.Windows.Forms.ToolStripMenuItem();
            this.BankCreditDneprItemCurrency = new System.Windows.Forms.ToolStripMenuItem();
            this.uahMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.privatBankItem = new System.Windows.Forms.ToolStripMenuItem();
            this.privatBankCardItem = new System.Windows.Forms.ToolStripMenuItem();
            this.poltavaBankItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fikBankItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sberBankItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BankCreditDneprItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentsGridView = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.contractorSrnColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.contractorNameColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.recipientAccountColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.recipientBankMfoColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.recipientBankNameColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.paymentDateColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.paymentDocumentColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.debitColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.debitPriceCurrencyColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.creditColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.creditPriceCurrencyColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand7 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.currencyNameColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.currencyLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rateColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.purposeColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.purposeAccountColumn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.accountsLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.label15 = new System.Windows.Forms.Label();
            this.bankNameLabel = new System.Windows.Forms.Label();
            this.bankAccountCBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.paymentsGrid)).BeginInit();
            this.importCMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paymentsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currencyLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountsLookUpEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // paymentsGrid
            // 
            this.paymentsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paymentsGrid.ContextMenuStrip = this.importCMenu;
            this.paymentsGrid.Location = new System.Drawing.Point(0, 44);
            this.paymentsGrid.MainView = this.paymentsGridView;
            this.paymentsGrid.Name = "paymentsGrid";
            this.paymentsGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.currencyLookUpEdit,
            this.accountsLookUpEdit});
            this.paymentsGrid.Size = new System.Drawing.Size(1826, 612);
            this.paymentsGrid.TabIndex = 1;
            this.paymentsGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.paymentsGridView});
            // 
            // importCMenu
            // 
            this.importCMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMenuItem,
            this.saveMenuItem});
            this.importCMenu.Name = "importCMenu";
            this.importCMenu.Size = new System.Drawing.Size(125, 48);
            this.importCMenu.Opening += new System.ComponentModel.CancelEventHandler(this.importCMenu_Opening);
            // 
            // openMenuItem
            // 
            this.openMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rateMenu,
            this.uahMenu});
            this.openMenuItem.Image = global::Accounting.Properties.Resources.Open;
            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.Size = new System.Drawing.Size(124, 22);
            this.openMenuItem.Text = "Відкрити";
            // 
            // rateMenu
            // 
            this.rateMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.privatBankItemCurrency,
            this.poltavaBankItemCurrency,
            this.fikBankItemCurrency,
            this.sberBankItemCurrency,
            this.BankCreditDneprItemCurrency});
            this.rateMenu.Name = "rateMenu";
            this.rateMenu.Size = new System.Drawing.Size(115, 22);
            this.rateMenu.Text = "Валюта";
            // 
            // privatBankItemCurrency
            // 
            this.privatBankItemCurrency.Name = "privatBankItemCurrency";
            this.privatBankItemCurrency.Size = new System.Drawing.Size(179, 22);
            this.privatBankItemCurrency.Text = "ПриватБанк";
            this.privatBankItemCurrency.Click += new System.EventHandler(this.PrivatBankCurrency_Click);
            // 
            // poltavaBankItemCurrency
            // 
            this.poltavaBankItemCurrency.Name = "poltavaBankItemCurrency";
            this.poltavaBankItemCurrency.Size = new System.Drawing.Size(179, 22);
            this.poltavaBankItemCurrency.Text = "ПолтаваБанк";
            this.poltavaBankItemCurrency.Click += new System.EventHandler(this.PoltavaBankImportCurrency_Click);
            // 
            // fikBankItemCurrency
            // 
            this.fikBankItemCurrency.Name = "fikBankItemCurrency";
            this.fikBankItemCurrency.Size = new System.Drawing.Size(179, 22);
            this.fikBankItemCurrency.Text = "Финансы и Кредит ";
            this.fikBankItemCurrency.Click += new System.EventHandler(this.FIKBankItem_Click);
            // 
            // sberBankItemCurrency
            // 
            this.sberBankItemCurrency.Name = "sberBankItemCurrency";
            this.sberBankItemCurrency.Size = new System.Drawing.Size(179, 22);
            this.sberBankItemCurrency.Text = "СберБанк";
            this.sberBankItemCurrency.Click += new System.EventHandler(this.SberBankItem_Click);
            // 
            // BankCreditDneprItemCurrency
            // 
            this.BankCreditDneprItemCurrency.Name = "BankCreditDneprItemCurrency";
            this.BankCreditDneprItemCurrency.Size = new System.Drawing.Size(179, 22);
            this.BankCreditDneprItemCurrency.Text = "Банк Кредит Днепр";
            this.BankCreditDneprItemCurrency.Click += new System.EventHandler(this.BankCreditDneprItem_Click);
            // 
            // uahMenu
            // 
            this.uahMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.privatBankItem,
            this.privatBankCardItem,
            this.poltavaBankItem,
            this.fikBankItem,
            this.sberBankItem,
            this.BankCreditDneprItem});
            this.uahMenu.Name = "uahMenu";
            this.uahMenu.Size = new System.Drawing.Size(115, 22);
            this.uahMenu.Text = "Гривня";
            // 
            // privatBankItem
            // 
            this.privatBankItem.Name = "privatBankItem";
            this.privatBankItem.Size = new System.Drawing.Size(186, 22);
            this.privatBankItem.Text = "ПриватБанк";
            this.privatBankItem.Click += new System.EventHandler(this.PrivatBankItem_Click);
            // 
            // privatBankCardItem
            // 
            this.privatBankCardItem.Name = "privatBankCardItem";
            this.privatBankCardItem.Size = new System.Drawing.Size(186, 22);
            this.privatBankCardItem.Text = "ПриватБанк(Картки)";
            this.privatBankCardItem.Click += new System.EventHandler(this.privatBankCardItem_Click);
            // 
            // poltavaBankItem
            // 
            this.poltavaBankItem.Name = "poltavaBankItem";
            this.poltavaBankItem.Size = new System.Drawing.Size(186, 22);
            this.poltavaBankItem.Text = "ПолтаваБанк";
            this.poltavaBankItem.Click += new System.EventHandler(this.PoltavaBankItem_Click);
            // 
            // fikBankItem
            // 
            this.fikBankItem.Name = "fikBankItem";
            this.fikBankItem.Size = new System.Drawing.Size(186, 22);
            this.fikBankItem.Text = "Финансы и Кредит ";
            this.fikBankItem.Click += new System.EventHandler(this.FIKBankItem_Click);
            // 
            // sberBankItem
            // 
            this.sberBankItem.Name = "sberBankItem";
            this.sberBankItem.Size = new System.Drawing.Size(186, 22);
            this.sberBankItem.Text = "СберБанк";
            this.sberBankItem.Click += new System.EventHandler(this.SberBankItem_Click);
            // 
            // BankCreditDneprItem
            // 
            this.BankCreditDneprItem.Name = "BankCreditDneprItem";
            this.BankCreditDneprItem.Size = new System.Drawing.Size(186, 22);
            this.BankCreditDneprItem.Text = "Банк Кредит Днепр";
            this.BankCreditDneprItem.Click += new System.EventHandler(this.BankCreditDneprItem_Click);
            // 
            // saveMenuItem
            // 
            this.saveMenuItem.Image = global::Accounting.Properties.Resources.Save;
            this.saveMenuItem.Name = "saveMenuItem";
            this.saveMenuItem.Size = new System.Drawing.Size(124, 22);
            this.saveMenuItem.Text = "Зберегти";
            this.saveMenuItem.Click += new System.EventHandler(this.saveMenuItem_Click);
            // 
            // paymentsGridView
            // 
            this.paymentsGridView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.paymentsGridView.Appearance.FooterPanel.Options.UseFont = true;
            this.paymentsGridView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand5,
            this.gridBand6,
            this.gridBand2,
            this.gridBand3,
            this.gridBand7,
            this.gridBand4});
            this.paymentsGridView.ColumnPanelRowHeight = 40;
            this.paymentsGridView.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.contractorSrnColumn,
            this.contractorNameColumn,
            this.recipientAccountColumn,
            this.recipientBankMfoColumn,
            this.recipientBankNameColumn,
            this.paymentDateColumn,
            this.paymentDocumentColumn,
            this.debitColumn,
            this.debitPriceCurrencyColumn,
            this.creditColumn,
            this.creditPriceCurrencyColumn,
            this.purposeColumn,
            this.currencyNameColumn,
            this.rateColumn,
            this.purposeAccountColumn});
            this.paymentsGridView.GridControl = this.paymentsGrid;
            this.paymentsGridView.Name = "paymentsGridView";
            this.paymentsGridView.OptionsView.ColumnAutoWidth = true;
            this.paymentsGridView.OptionsView.ShowAutoFilterRow = true;
            this.paymentsGridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.paymentsGridView.OptionsView.ShowFooter = true;
            this.paymentsGridView.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.paymentsGridView_RowStyle);
            this.paymentsGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.paymentsGridView_KeyDown);
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand1.AppearanceHeader.Options.UseFont = true;
            this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand1.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridBand1.Caption = "Контрагент";
            this.gridBand1.Columns.Add(this.contractorSrnColumn);
            this.gridBand1.Columns.Add(this.contractorNameColumn);
            this.gridBand1.Columns.Add(this.recipientAccountColumn);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.Width = 423;
            // 
            // contractorSrnColumn
            // 
            this.contractorSrnColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.contractorSrnColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.contractorSrnColumn.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.contractorSrnColumn.Caption = "Код ЄДРПОУ";
            this.contractorSrnColumn.FieldName = "CONTRACTOR_SRN";
            this.contractorSrnColumn.MinWidth = 78;
            this.contractorSrnColumn.Name = "contractorSrnColumn";
            this.contractorSrnColumn.OptionsColumn.AllowEdit = false;
            this.contractorSrnColumn.OptionsColumn.AllowFocus = false;
            this.contractorSrnColumn.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "CONTRACTOR_SRN", "Всього :   {0}")});
            this.contractorSrnColumn.Visible = true;
            this.contractorSrnColumn.Width = 78;
            // 
            // contractorNameColumn
            // 
            this.contractorNameColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.contractorNameColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.contractorNameColumn.Caption = "Найменування";
            this.contractorNameColumn.FieldName = "CONTRACTOR_NAME";
            this.contractorNameColumn.MinWidth = 230;
            this.contractorNameColumn.Name = "contractorNameColumn";
            this.contractorNameColumn.OptionsColumn.AllowEdit = false;
            this.contractorNameColumn.OptionsColumn.AllowFocus = false;
            this.contractorNameColumn.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.contractorNameColumn.Visible = true;
            this.contractorNameColumn.Width = 230;
            // 
            // recipientAccountColumn
            // 
            this.recipientAccountColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.recipientAccountColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.recipientAccountColumn.Caption = "Рахунок";
            this.recipientAccountColumn.FieldName = "Recipient_Account_Num";
            this.recipientAccountColumn.MinWidth = 115;
            this.recipientAccountColumn.Name = "recipientAccountColumn";
            this.recipientAccountColumn.Visible = true;
            this.recipientAccountColumn.Width = 115;
            // 
            // gridBand5
            // 
            this.gridBand5.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand5.AppearanceHeader.Options.UseFont = true;
            this.gridBand5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand5.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridBand5.Caption = "Банк";
            this.gridBand5.Columns.Add(this.recipientBankMfoColumn);
            this.gridBand5.Columns.Add(this.recipientBankNameColumn);
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.Width = 225;
            // 
            // recipientBankMfoColumn
            // 
            this.recipientBankMfoColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.recipientBankMfoColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.recipientBankMfoColumn.Caption = "МФО";
            this.recipientBankMfoColumn.FieldName = "Recipient_Bank_Mfo";
            this.recipientBankMfoColumn.MinWidth = 75;
            this.recipientBankMfoColumn.Name = "recipientBankMfoColumn";
            this.recipientBankMfoColumn.Visible = true;
            // 
            // recipientBankNameColumn
            // 
            this.recipientBankNameColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.recipientBankNameColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.recipientBankNameColumn.Caption = "Наименування";
            this.recipientBankNameColumn.FieldName = "Recipient_Bank_Name";
            this.recipientBankNameColumn.MinWidth = 150;
            this.recipientBankNameColumn.Name = "recipientBankNameColumn";
            this.recipientBankNameColumn.Visible = true;
            this.recipientBankNameColumn.Width = 150;
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
            this.gridBand6.Width = 190;
            // 
            // paymentDateColumn
            // 
            this.paymentDateColumn.AppearanceCell.Options.UseTextOptions = true;
            this.paymentDateColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.paymentDateColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.paymentDateColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.paymentDateColumn.Caption = "Дата";
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
            this.paymentDocumentColumn.Caption = "Номер";
            this.paymentDocumentColumn.FieldName = "Payment_Document";
            this.paymentDocumentColumn.MinWidth = 90;
            this.paymentDocumentColumn.Name = "paymentDocumentColumn";
            this.paymentDocumentColumn.OptionsColumn.AllowEdit = false;
            this.paymentDocumentColumn.OptionsColumn.AllowFocus = false;
            this.paymentDocumentColumn.Visible = true;
            this.paymentDocumentColumn.Width = 115;
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand2.AppearanceHeader.Options.UseFont = true;
            this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand2.Caption = "Дебет";
            this.gridBand2.Columns.Add(this.debitColumn);
            this.gridBand2.Columns.Add(this.debitPriceCurrencyColumn);
            this.gridBand2.Name = "gridBand2";
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
            this.gridBand3.Caption = "Кредит";
            this.gridBand3.Columns.Add(this.creditColumn);
            this.gridBand3.Columns.Add(this.creditPriceCurrencyColumn);
            this.gridBand3.Name = "gridBand3";
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
            // gridBand7
            // 
            this.gridBand7.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand7.AppearanceHeader.Options.UseFont = true;
            this.gridBand7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand7.Caption = "Валюта";
            this.gridBand7.Columns.Add(this.currencyNameColumn);
            this.gridBand7.Columns.Add(this.rateColumn);
            this.gridBand7.Name = "gridBand7";
            this.gridBand7.Width = 150;
            // 
            // currencyNameColumn
            // 
            this.currencyNameColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.currencyNameColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.currencyNameColumn.Caption = "Валюта";
            this.currencyNameColumn.ColumnEdit = this.currencyLookUpEdit;
            this.currencyNameColumn.FieldName = "CURRENCYNAME";
            this.currencyNameColumn.MinWidth = 80;
            this.currencyNameColumn.Name = "currencyNameColumn";
            this.currencyNameColumn.Visible = true;
            this.currencyNameColumn.Width = 80;
            // 
            // currencyLookUpEdit
            // 
            this.currencyLookUpEdit.AutoHeight = false;
            this.currencyLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.currencyLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", "Валюта")});
            this.currencyLookUpEdit.Name = "currencyLookUpEdit";
            this.currencyLookUpEdit.ShowFooter = false;
            this.currencyLookUpEdit.ShowHeader = false;
            // 
            // rateColumn
            // 
            this.rateColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.rateColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.rateColumn.Caption = "Курс";
            this.rateColumn.DisplayFormat.FormatString = "### ##0.000000";
            this.rateColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.rateColumn.FieldName = "Rate";
            this.rateColumn.MinWidth = 70;
            this.rateColumn.Name = "rateColumn";
            this.rateColumn.OptionsColumn.AllowEdit = false;
            this.rateColumn.OptionsColumn.AllowFocus = false;
            this.rateColumn.Visible = true;
            this.rateColumn.Width = 70;
            // 
            // gridBand4
            // 
            this.gridBand4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand4.AppearanceHeader.Options.UseFont = true;
            this.gridBand4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand4.Caption = "Додаткова інформація";
            this.gridBand4.Columns.Add(this.purposeColumn);
            this.gridBand4.Columns.Add(this.purposeAccountColumn);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.Width = 389;
            // 
            // purposeColumn
            // 
            this.purposeColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.purposeColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.purposeColumn.Caption = "Призначення платежу";
            this.purposeColumn.FieldName = "Purpose";
            this.purposeColumn.MinWidth = 300;
            this.purposeColumn.Name = "purposeColumn";
            this.purposeColumn.OptionsColumn.AllowEdit = false;
            this.purposeColumn.OptionsColumn.AllowFocus = false;
            this.purposeColumn.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.purposeColumn.Visible = true;
            this.purposeColumn.Width = 300;
            // 
            // purposeAccountColumn
            // 
            this.purposeAccountColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.purposeAccountColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.purposeAccountColumn.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.purposeAccountColumn.Caption = "Рахунок призначення";
            this.purposeAccountColumn.ColumnEdit = this.accountsLookUpEdit;
            this.purposeAccountColumn.FieldName = "PURPOSE_ACCOUNT_NUM";
            this.purposeAccountColumn.MinWidth = 65;
            this.purposeAccountColumn.Name = "purposeAccountColumn";
            this.purposeAccountColumn.Visible = true;
            this.purposeAccountColumn.Width = 89;
            // 
            // accountsLookUpEdit
            // 
            this.accountsLookUpEdit.AutoHeight = false;
            this.accountsLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.accountsLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NUM", "Счет"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.accountsLookUpEdit.DisplayMember = "NUM";
            this.accountsLookUpEdit.Name = "accountsLookUpEdit";
            this.accountsLookUpEdit.ShowFooter = false;
            this.accountsLookUpEdit.ShowHeader = false;
            this.accountsLookUpEdit.ValueMember = "NUM";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.SystemColors.Info;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(12, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(127, 20);
            this.label15.TabIndex = 105;
            this.label15.Text = "Рахунок банку";
            // 
            // bankNameLabel
            // 
            this.bankNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bankNameLabel.AutoSize = true;
            this.bankNameLabel.BackColor = System.Drawing.SystemColors.Info;
            this.bankNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bankNameLabel.Location = new System.Drawing.Point(846, 9);
            this.bankNameLabel.Name = "bankNameLabel";
            this.bankNameLabel.Size = new System.Drawing.Size(0, 20);
            this.bankNameLabel.TabIndex = 106;
            // 
            // bankAccountCBox
            // 
            this.bankAccountCBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.bankAccountCBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.bankAccountCBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bankAccountCBox.FormattingEnabled = true;
            this.bankAccountCBox.Location = new System.Drawing.Point(145, 6);
            this.bankAccountCBox.Name = "bankAccountCBox";
            this.bankAccountCBox.Size = new System.Drawing.Size(121, 28);
            this.bankAccountCBox.TabIndex = 107;
            this.bankAccountCBox.SelectedIndexChanged += new System.EventHandler(this.bankAccountCBox_SelectedIndexChanged);
            // 
            // new_importBankPaymentsFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1829, 656);
            this.Controls.Add(this.bankAccountCBox);
            this.Controls.Add(this.bankNameLabel);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.paymentsGrid);
            this.Name = "new_importBankPaymentsFm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Імпорт платежів";
            ((System.ComponentModel.ISupportInitialize)(this.paymentsGrid)).EndInit();
            this.importCMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paymentsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currencyLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountsLookUpEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl paymentsGrid;
        private System.Windows.Forms.ContextMenuStrip importCMenu;
        private System.Windows.Forms.ToolStripMenuItem openMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rateMenu;
        private System.Windows.Forms.ToolStripMenuItem privatBankItemCurrency;
        private System.Windows.Forms.ToolStripMenuItem poltavaBankItemCurrency;
        private System.Windows.Forms.ToolStripMenuItem fikBankItemCurrency;
        private System.Windows.Forms.ToolStripMenuItem sberBankItemCurrency;
        private System.Windows.Forms.ToolStripMenuItem uahMenu;
        private System.Windows.Forms.ToolStripMenuItem privatBankItem;
        private System.Windows.Forms.ToolStripMenuItem poltavaBankItem;
        private System.Windows.Forms.ToolStripMenuItem fikBankItem;
        private System.Windows.Forms.ToolStripMenuItem sberBankItem;
        private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit currencyLookUpEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit accountsLookUpEdit;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label bankNameLabel;
        private System.Windows.Forms.ComboBox bankAccountCBox;
        private System.Windows.Forms.ToolStripMenuItem BankCreditDneprItem;
        private System.Windows.Forms.ToolStripMenuItem BankCreditDneprItemCurrency;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView paymentsGridView;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn contractorSrnColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn contractorNameColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn recipientAccountColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn recipientBankMfoColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn recipientBankNameColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn paymentDateColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn paymentDocumentColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn debitColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn debitPriceCurrencyColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn creditColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn creditPriceCurrencyColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn currencyNameColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn rateColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn purposeColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn purposeAccountColumn;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand6;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand7;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private System.Windows.Forms.ToolStripMenuItem privatBankCardItem;
    }
}