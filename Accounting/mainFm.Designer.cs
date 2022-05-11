namespace Accounting
{
    partial class mainFm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainFm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileTSMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.exitTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsTSMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontalTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceTSMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.receiptsBtn = new System.Windows.Forms.ToolStripButton();
            this.receiptsCurrencyBtn = new System.Windows.Forms.ToolStripButton();
            this.expendituresBtn = new System.Windows.Forms.ToolStripButton();
            this.StockBalanceBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.invoiceRequirementBtn = new System.Windows.Forms.ToolStripButton();
            this.fixedAssetsOrderBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.newBankPaymentsBtn = new System.Windows.Forms.ToolStripButton();
            this.calcWithBuyersBtn = new System.Windows.Forms.ToolStripButton();
            this.dictionariesBtn = new System.Windows.Forms.ToolStripSplitButton();
            this.nomenclGroupsTSMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.contractorsTSMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.suppliersTSMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.banksMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bankAccountsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountsTSMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.periodsTSMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fixedAssetsGroupRBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerOrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.reportsBtn = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.windowsBarPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.dictionaryCPVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileTSMenu,
            this.windowsTSMenu,
            this.serviceTSMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip.TabIndex = 9;
            // 
            // fileTSMenu
            // 
            this.fileTSMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitTSMenuItem});
            this.fileTSMenu.Name = "fileTSMenu";
            this.fileTSMenu.Size = new System.Drawing.Size(48, 20);
            this.fileTSMenu.Text = "Файл";
            // 
            // exitTSMenuItem
            // 
            this.exitTSMenuItem.Image = global::Accounting.Properties.Resources.Exit;
            this.exitTSMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.exitTSMenuItem.Name = "exitTSMenuItem";
            this.exitTSMenuItem.Size = new System.Drawing.Size(102, 22);
            this.exitTSMenuItem.Text = "Вихід";
            this.exitTSMenuItem.Click += new System.EventHandler(this.exitTSMenuItem_Click);
            // 
            // windowsTSMenu
            // 
            this.windowsTSMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cascadeTSMenuItem,
            this.horizontalTSMenuItem,
            this.verticalTSMenuItem,
            this.closeAllTSMenuItem});
            this.windowsTSMenu.Name = "windowsTSMenu";
            this.windowsTSMenu.Size = new System.Drawing.Size(48, 20);
            this.windowsTSMenu.Text = "Вікна";
            // 
            // cascadeTSMenuItem
            // 
            this.cascadeTSMenuItem.Image = global::Accounting.Properties.Resources.Title_Cascade;
            this.cascadeTSMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cascadeTSMenuItem.Name = "cascadeTSMenuItem";
            this.cascadeTSMenuItem.Size = new System.Drawing.Size(168, 22);
            this.cascadeTSMenuItem.Text = "Каскадом";
            this.cascadeTSMenuItem.Click += new System.EventHandler(this.cascadeTSMenuItem_Click);
            // 
            // horizontalTSMenuItem
            // 
            this.horizontalTSMenuItem.Image = global::Accounting.Properties.Resources.Tile_Horizontal;
            this.horizontalTSMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.horizontalTSMenuItem.Name = "horizontalTSMenuItem";
            this.horizontalTSMenuItem.Size = new System.Drawing.Size(168, 22);
            this.horizontalTSMenuItem.Text = "Горизонтально";
            this.horizontalTSMenuItem.Click += new System.EventHandler(this.horizontalTSMenuItem_Click);
            // 
            // verticalTSMenuItem
            // 
            this.verticalTSMenuItem.Image = global::Accounting.Properties.Resources.Tile_Vertical;
            this.verticalTSMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.verticalTSMenuItem.Name = "verticalTSMenuItem";
            this.verticalTSMenuItem.Size = new System.Drawing.Size(168, 22);
            this.verticalTSMenuItem.Text = "Вертикально";
            this.verticalTSMenuItem.Click += new System.EventHandler(this.verticalTSMenuItem_Click);
            // 
            // closeAllTSMenuItem
            // 
            this.closeAllTSMenuItem.Image = global::Accounting.Properties.Resources.Close;
            this.closeAllTSMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.closeAllTSMenuItem.Name = "closeAllTSMenuItem";
            this.closeAllTSMenuItem.Size = new System.Drawing.Size(168, 22);
            this.closeAllTSMenuItem.Text = "Закрити всі вікна";
            this.closeAllTSMenuItem.Click += new System.EventHandler(this.closeAllTSMenuItem_Click);
            // 
            // serviceTSMenu
            // 
            this.serviceTSMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsTSMenuItem});
            this.serviceTSMenu.Name = "serviceTSMenu";
            this.serviceTSMenu.Size = new System.Drawing.Size(55, 20);
            this.serviceTSMenu.Text = "Сервіс";
            // 
            // optionsTSMenuItem
            // 
            this.optionsTSMenuItem.Image = global::Accounting.Properties.Resources.Config;
            this.optionsTSMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.optionsTSMenuItem.Name = "optionsTSMenuItem";
            this.optionsTSMenuItem.Size = new System.Drawing.Size(156, 22);
            this.optionsTSMenuItem.Text = "Налаштування";
            this.optionsTSMenuItem.Click += new System.EventHandler(this.optionsTSMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.receiptsBtn,
            this.receiptsCurrencyBtn,
            this.expendituresBtn,
            this.StockBalanceBtn,
            this.toolStripSeparator1,
            this.invoiceRequirementBtn,
            this.fixedAssetsOrderBtn,
            this.toolStripSeparator5,
            this.newBankPaymentsBtn,
            this.calcWithBuyersBtn,
            this.dictionariesBtn,
            this.toolStripSeparator3,
            this.reportsBtn});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1008, 39);
            this.toolStrip.TabIndex = 11;
            // 
            // receiptsBtn
            // 
            this.receiptsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.receiptsBtn.Image = global::Accounting.Properties.Resources.Receipt;
            this.receiptsBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.receiptsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.receiptsBtn.Name = "receiptsBtn";
            this.receiptsBtn.Size = new System.Drawing.Size(36, 36);
            this.receiptsBtn.Text = "Склад надходження";
            this.receiptsBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // receiptsCurrencyBtn
            // 
            this.receiptsCurrencyBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.receiptsCurrencyBtn.Image = global::Accounting.Properties.Resources.ReceiptCurrency;
            this.receiptsCurrencyBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.receiptsCurrencyBtn.Name = "receiptsCurrencyBtn";
            this.receiptsCurrencyBtn.Size = new System.Drawing.Size(36, 36);
            this.receiptsCurrencyBtn.Text = "Надходження (рах. 632)";
            this.receiptsCurrencyBtn.Click += new System.EventHandler(this.receiptsCurrencyBtn_Click);
            // 
            // expendituresBtn
            // 
            this.expendituresBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.expendituresBtn.Image = global::Accounting.Properties.Resources.Expenditure;
            this.expendituresBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.expendituresBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.expendituresBtn.Name = "expendituresBtn";
            this.expendituresBtn.Size = new System.Drawing.Size(36, 36);
            this.expendituresBtn.Text = "Склад списання";
            this.expendituresBtn.Click += new System.EventHandler(this.expendituresBtn_Click);
            // 
            // StockBalanceBtn
            // 
            this.StockBalanceBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StockBalanceBtn.Image = global::Accounting.Properties.Resources.estoque;
            this.StockBalanceBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StockBalanceBtn.Name = "StockBalanceBtn";
            this.StockBalanceBtn.Size = new System.Drawing.Size(36, 36);
            this.StockBalanceBtn.Text = "Залишок на складі";
            this.StockBalanceBtn.Click += new System.EventHandler(this.StockBalanceBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // invoiceRequirementBtn
            // 
            this.invoiceRequirementBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.invoiceRequirementBtn.Image = ((System.Drawing.Image)(resources.GetObject("invoiceRequirementBtn.Image")));
            this.invoiceRequirementBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.invoiceRequirementBtn.Name = "invoiceRequirementBtn";
            this.invoiceRequirementBtn.Size = new System.Drawing.Size(36, 36);
            this.invoiceRequirementBtn.Text = "Вимоги";
            this.invoiceRequirementBtn.ToolTipText = "Вимоги";
            this.invoiceRequirementBtn.Click += new System.EventHandler(this.invoiceRequirementBtn_Click);
            // 
            // fixedAssetsOrderBtn
            // 
            this.fixedAssetsOrderBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fixedAssetsOrderBtn.Image = global::Accounting.Properties.Resources.FixedAssets;
            this.fixedAssetsOrderBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fixedAssetsOrderBtn.Name = "fixedAssetsOrderBtn";
            this.fixedAssetsOrderBtn.Size = new System.Drawing.Size(36, 36);
            this.fixedAssetsOrderBtn.Text = "Основні засоби";
            this.fixedAssetsOrderBtn.Click += new System.EventHandler(this.fixedAssetsOrderBtn_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.AutoSize = false;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(3, 39);
            // 
            // newBankPaymentsBtn
            // 
            this.newBankPaymentsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newBankPaymentsBtn.Image = global::Accounting.Properties.Resources.Bank_currency;
            this.newBankPaymentsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newBankPaymentsBtn.Name = "newBankPaymentsBtn";
            this.newBankPaymentsBtn.Size = new System.Drawing.Size(36, 36);
            this.newBankPaymentsBtn.Text = "Банківські операції";
            this.newBankPaymentsBtn.ToolTipText = "Банківські операції";
            this.newBankPaymentsBtn.Click += new System.EventHandler(this.newBankPaymentsBtn_Click);
            // 
            // calcWithBuyersBtn
            // 
            this.calcWithBuyersBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.calcWithBuyersBtn.Image = ((System.Drawing.Image)(resources.GetObject("calcWithBuyersBtn.Image")));
            this.calcWithBuyersBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.calcWithBuyersBtn.Name = "calcWithBuyersBtn";
            this.calcWithBuyersBtn.Size = new System.Drawing.Size(36, 36);
            this.calcWithBuyersBtn.ToolTipText = "Розрахунки з покупцями та замовниками";
            this.calcWithBuyersBtn.Click += new System.EventHandler(this.calcWithBuyersBtn_Click);
            // 
            // dictionariesBtn
            // 
            this.dictionariesBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dictionariesBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nomenclGroupsTSMenu,
            this.contractorsTSMenu,
            this.suppliersTSMenu,
            this.toolStripMenuItem1,
            this.banksMenuItem,
            this.bankAccountsMenuItem,
            this.accountsTSMenu,
            this.toolStripMenuItem3,
            this.periodsTSMenu,
            this.fixedAssetsGroupRBToolStripMenuItem,
            this.regionToolStripMenuItem,
            this.customerOrdersToolStripMenuItem,
            this.dictionaryCPVToolStripMenuItem});
            this.dictionariesBtn.Image = global::Accounting.Properties.Resources.Dictionary;
            this.dictionariesBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.dictionariesBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dictionariesBtn.Name = "dictionariesBtn";
            this.dictionariesBtn.Size = new System.Drawing.Size(48, 36);
            this.dictionariesBtn.Text = "Класифікатори";
            // 
            // nomenclGroupsTSMenu
            // 
            this.nomenclGroupsTSMenu.Image = global::Accounting.Properties.Resources.Document;
            this.nomenclGroupsTSMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.nomenclGroupsTSMenu.Name = "nomenclGroupsTSMenu";
            this.nomenclGroupsTSMenu.Size = new System.Drawing.Size(312, 22);
            this.nomenclGroupsTSMenu.Text = "Номенклатура";
            this.nomenclGroupsTSMenu.Click += new System.EventHandler(this.nomenclGroupsTSMenu_Click);
            // 
            // contractorsTSMenu
            // 
            this.contractorsTSMenu.Image = global::Accounting.Properties.Resources.Document;
            this.contractorsTSMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.contractorsTSMenu.Name = "contractorsTSMenu";
            this.contractorsTSMenu.Size = new System.Drawing.Size(312, 22);
            this.contractorsTSMenu.Text = "Контрагенти";
            this.contractorsTSMenu.Click += new System.EventHandler(this.contractorsTSMenu_Click);
            // 
            // suppliersTSMenu
            // 
            this.suppliersTSMenu.Image = global::Accounting.Properties.Resources.Document;
            this.suppliersTSMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.suppliersTSMenu.Name = "suppliersTSMenu";
            this.suppliersTSMenu.Size = new System.Drawing.Size(312, 22);
            this.suppliersTSMenu.Text = "Відповідальні особи";
            this.suppliersTSMenu.Click += new System.EventHandler(this.suppliersTSMenu_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(309, 6);
            // 
            // banksMenuItem
            // 
            this.banksMenuItem.Image = global::Accounting.Properties.Resources.Document;
            this.banksMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.banksMenuItem.Name = "banksMenuItem";
            this.banksMenuItem.Size = new System.Drawing.Size(312, 22);
            this.banksMenuItem.Text = "Банки";
            this.banksMenuItem.Visible = false;
            this.banksMenuItem.Click += new System.EventHandler(this.banksMenuItem_Click);
            // 
            // bankAccountsMenuItem
            // 
            this.bankAccountsMenuItem.Image = global::Accounting.Properties.Resources.Document;
            this.bankAccountsMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bankAccountsMenuItem.Name = "bankAccountsMenuItem";
            this.bankAccountsMenuItem.Size = new System.Drawing.Size(312, 22);
            this.bankAccountsMenuItem.Text = "Банківські рахунки";
            this.bankAccountsMenuItem.Visible = false;
            this.bankAccountsMenuItem.Click += new System.EventHandler(this.bankAccountsMenuItem_Click);
            // 
            // accountsTSMenu
            // 
            this.accountsTSMenu.Image = global::Accounting.Properties.Resources.Document;
            this.accountsTSMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.accountsTSMenu.Name = "accountsTSMenu";
            this.accountsTSMenu.Size = new System.Drawing.Size(312, 22);
            this.accountsTSMenu.Text = "Рахунки";
            this.accountsTSMenu.Click += new System.EventHandler(this.accountsTSMenu_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(309, 6);
            this.toolStripMenuItem3.Visible = false;
            // 
            // periodsTSMenu
            // 
            this.periodsTSMenu.Image = global::Accounting.Properties.Resources.Document;
            this.periodsTSMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.periodsTSMenu.Name = "periodsTSMenu";
            this.periodsTSMenu.Size = new System.Drawing.Size(312, 22);
            this.periodsTSMenu.Text = "Періоди";
            this.periodsTSMenu.Visible = false;
            this.periodsTSMenu.Click += new System.EventHandler(this.periodsTSMenu_Click);
            // 
            // fixedAssetsGroupRBToolStripMenuItem
            // 
            this.fixedAssetsGroupRBToolStripMenuItem.Image = global::Accounting.Properties.Resources.Document;
            this.fixedAssetsGroupRBToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fixedAssetsGroupRBToolStripMenuItem.Name = "fixedAssetsGroupRBToolStripMenuItem";
            this.fixedAssetsGroupRBToolStripMenuItem.Size = new System.Drawing.Size(312, 22);
            this.fixedAssetsGroupRBToolStripMenuItem.Text = "Основні засоби";
            this.fixedAssetsGroupRBToolStripMenuItem.Click += new System.EventHandler(this.fixedAssetsGroupRBToolStripMenuItem_Click);
            // 
            // regionToolStripMenuItem
            // 
            this.regionToolStripMenuItem.Image = global::Accounting.Properties.Resources.Document;
            this.regionToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.regionToolStripMenuItem.Name = "regionToolStripMenuItem";
            this.regionToolStripMenuItem.Size = new System.Drawing.Size(312, 22);
            this.regionToolStripMenuItem.Text = "Дільнці та відділи";
            this.regionToolStripMenuItem.Click += new System.EventHandler(this.regionToolStripMenuItem_Click);
            // 
            // customerOrdersToolStripMenuItem
            // 
            this.customerOrdersToolStripMenuItem.Image = global::Accounting.Properties.Resources.Document;
            this.customerOrdersToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.customerOrdersToolStripMenuItem.Name = "customerOrdersToolStripMenuItem";
            this.customerOrdersToolStripMenuItem.Size = new System.Drawing.Size(312, 22);
            this.customerOrdersToolStripMenuItem.Text = "Закази";
            this.customerOrdersToolStripMenuItem.Click += new System.EventHandler(this.customerOrdersToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.AutoSize = false;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(3, 39);
            // 
            // reportsBtn
            // 
            this.reportsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.reportsBtn.Image = global::Accounting.Properties.Resources.Report1;
            this.reportsBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.reportsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.reportsBtn.Name = "reportsBtn";
            this.reportsBtn.Size = new System.Drawing.Size(36, 36);
            this.reportsBtn.Text = "Звіти";
            this.reportsBtn.Click += new System.EventHandler(this.reportsBtn_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 452);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1008, 22);
            this.statusStrip.TabIndex = 12;
            // 
            // windowsBarPanel
            // 
            this.windowsBarPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.windowsBarPanel.Location = new System.Drawing.Point(0, 426);
            this.windowsBarPanel.Name = "windowsBarPanel";
            this.windowsBarPanel.Size = new System.Drawing.Size(1008, 26);
            this.windowsBarPanel.TabIndex = 18;
            // 
            // dictionaryCPVToolStripMenuItem
            // 
            this.dictionaryCPVToolStripMenuItem.Image = global::Accounting.Properties.Resources.Document;
            this.dictionaryCPVToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.dictionaryCPVToolStripMenuItem.Name = "dictionaryCPVToolStripMenuItem";
            this.dictionaryCPVToolStripMenuItem.Size = new System.Drawing.Size(312, 22);
            this.dictionaryCPVToolStripMenuItem.Text = "Єдиний закупівельний словник ДК 021:2015";
            this.dictionaryCPVToolStripMenuItem.Click += new System.EventHandler(this.dictionaryCPVToolStripMenuItem_Click);
            // 
            // mainFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(1008, 474);
            this.Controls.Add(this.windowsBarPanel);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "mainFm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "АІС \"Техвагонмаш\" - Бухгалтерский облік";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainFm_FormClosing);
            this.Load += new System.EventHandler(this.mainFm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStripButton receiptsBtn;
        public System.Windows.Forms.ToolStripButton reportsBtn;
        public System.Windows.Forms.ToolStripButton expendituresBtn;

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileTSMenu;
        private System.Windows.Forms.ToolStripMenuItem exitTSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviceTSMenu;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripMenuItem windowsTSMenu;
        private System.Windows.Forms.ToolStripMenuItem cascadeTSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horizontalTSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticalTSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsTSMenuItem;
        private System.Windows.Forms.ToolStripSplitButton dictionariesBtn;
        private System.Windows.Forms.ToolStripMenuItem nomenclGroupsTSMenu;
        private System.Windows.Forms.ToolStripMenuItem contractorsTSMenu;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripMenuItem suppliersTSMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem accountsTSMenu;
        private System.Windows.Forms.FlowLayoutPanel windowsBarPanel;
        private System.Windows.Forms.ToolStripMenuItem periodsTSMenu;
        private System.Windows.Forms.ToolStripMenuItem closeAllTSMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem banksMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bankAccountsMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        public System.Windows.Forms.ToolStripButton invoiceRequirementBtn;
        public System.Windows.Forms.ToolStripButton calcWithBuyersBtn;
        private System.Windows.Forms.ToolStripButton receiptsCurrencyBtn;
        private System.Windows.Forms.ToolStripButton newBankPaymentsBtn;
        private System.Windows.Forms.ToolStripMenuItem fixedAssetsGroupRBToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton fixedAssetsOrderBtn;
        private System.Windows.Forms.ToolStripMenuItem regionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripButton StockBalanceBtn;
        private System.Windows.Forms.ToolStripMenuItem customerOrdersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dictionaryCPVToolStripMenuItem;
  
    }
}
