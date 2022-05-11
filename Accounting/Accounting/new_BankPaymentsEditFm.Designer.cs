namespace Accounting
{
    partial class new_BankPaymentsEditFm
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
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.purposeTBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.purposeAccountCBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.documentNumTBox = new System.Windows.Forms.TextBox();
            this.bankAccountCBox = new System.Windows.Forms.ComboBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.debitCreditCBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.currencyCBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.paymentDatePicker = new DevExpress.XtraEditors.DateEdit();
            this.employeesChkBox = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.srnTBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.contractorChkBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.priceTBox = new DevExpress.XtraEditors.TextEdit();
            this.sumCurrencyTBox = new DevExpress.XtraEditors.TextEdit();
            this.rateTBox = new DevExpress.XtraEditors.TextEdit();
            this.label13 = new System.Windows.Forms.Label();
            this.paymentConvertGBox = new System.Windows.Forms.GroupBox();
            this.rateConvertTBox = new DevExpress.XtraEditors.TextEdit();
            this.sumCurrencyConvertTBox = new DevExpress.XtraEditors.TextEdit();
            this.label14 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.currencyConvertCBox = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.buyersTab = new DevExpress.XtraTab.XtraTabControl();
            this.contractorTabPage = new DevExpress.XtraTab.XtraTabPage();
            this.contractorsEdit = new DevExpress.XtraEditors.GridLookUpEdit();
            this.contractorsEditView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.nameColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.srnColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.employeeTabPage = new DevExpress.XtraTab.XtraTabPage();
            this.employeesEdit = new DevExpress.XtraEditors.GridLookUpEdit();
            this.employeesEditView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.empNameColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.empNumberColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label15 = new System.Windows.Forms.Label();
            this.empNumberTBox = new System.Windows.Forms.TextBox();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.customerOrdersEdit = new DevExpress.XtraEditors.GridLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentDatePicker.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentDatePicker.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sumCurrencyTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rateTBox.Properties)).BeginInit();
            this.paymentConvertGBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rateConvertTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sumCurrencyConvertTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buyersTab)).BeginInit();
            this.buyersTab.SuspendLayout();
            this.contractorTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contractorsEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contractorsEditView)).BeginInit();
            this.employeeTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeesEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeesEditView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerOrdersEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 375);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 13);
            this.label8.TabIndex = 119;
            this.label8.Text = "Призначення платежу";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 117;
            this.label7.Text = "Операція";
            // 
            // purposeTBox
            // 
            this.purposeTBox.Location = new System.Drawing.Point(17, 391);
            this.purposeTBox.MaxLength = 500;
            this.purposeTBox.Multiline = true;
            this.purposeTBox.Name = "purposeTBox";
            this.purposeTBox.Size = new System.Drawing.Size(572, 71);
            this.purposeTBox.TabIndex = 19;
            this.purposeTBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.purposeTBox_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(188, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 13);
            this.label6.TabIndex = 116;
            this.label6.Text = "Рахунок призначення";
            // 
            // purposeAccountCBox
            // 
            this.purposeAccountCBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.purposeAccountCBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.purposeAccountCBox.DisplayMember = "Num";
            this.purposeAccountCBox.FormattingEnabled = true;
            this.purposeAccountCBox.Location = new System.Drawing.Point(191, 210);
            this.purposeAccountCBox.Name = "purposeAccountCBox";
            this.purposeAccountCBox.Size = new System.Drawing.Size(191, 21);
            this.purposeAccountCBox.TabIndex = 11;
            this.purposeAccountCBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.purposeAccountCBox_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(388, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 113;
            this.label4.Text = "Сума у гривні";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 114;
            this.label3.Text = "Рахунок банку";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 118;
            this.label2.Text = "Дата";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(140, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 112;
            this.label1.Text = "Номер платіжного документа";
            // 
            // documentNumTBox
            // 
            this.documentNumTBox.Location = new System.Drawing.Point(143, 25);
            this.documentNumTBox.MaxLength = 25;
            this.documentNumTBox.Name = "documentNumTBox";
            this.documentNumTBox.Size = new System.Drawing.Size(446, 20);
            this.documentNumTBox.TabIndex = 2;
            this.documentNumTBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.documentNumTBox_KeyPress);
            // 
            // bankAccountCBox
            // 
            this.bankAccountCBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.bankAccountCBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.bankAccountCBox.DisplayMember = "Num";
            this.bankAccountCBox.FormattingEnabled = true;
            this.bankAccountCBox.Location = new System.Drawing.Point(18, 210);
            this.bankAccountCBox.Name = "bankAccountCBox";
            this.bankAccountCBox.Size = new System.Drawing.Size(164, 21);
            this.bankAccountCBox.TabIndex = 10;
            this.bankAccountCBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.bankAccountCBox_KeyUp);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(464, 480);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(125, 23);
            this.cancelBtn.TabIndex = 21;
            this.cancelBtn.Text = "Відмінити";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(333, 480);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(125, 23);
            this.okBtn.TabIndex = 20;
            this.okBtn.Text = "Зберегти";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // debitCreditCBox
            // 
            this.debitCreditCBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.debitCreditCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.debitCreditCBox.DropDownWidth = 50;
            this.debitCreditCBox.FormattingEnabled = true;
            this.debitCreditCBox.Location = new System.Drawing.Point(13, 64);
            this.debitCreditCBox.Name = "debitCreditCBox";
            this.debitCreditCBox.Size = new System.Drawing.Size(124, 21);
            this.debitCreditCBox.TabIndex = 3;
            this.debitCreditCBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.debitCreditCBox_KeyUp);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(388, 244);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 544;
            this.label9.Text = "Курс валюти";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(15, 244);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(45, 13);
            this.label22.TabIndex = 546;
            this.label22.Text = "Валюта";
            // 
            // currencyCBox
            // 
            this.currencyCBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.currencyCBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.currencyCBox.DropDownWidth = 50;
            this.currencyCBox.FormattingEnabled = true;
            this.currencyCBox.Location = new System.Drawing.Point(17, 259);
            this.currencyCBox.Name = "currencyCBox";
            this.currencyCBox.Size = new System.Drawing.Size(165, 21);
            this.currencyCBox.TabIndex = 13;
            this.currencyCBox.SelectedValueChanged += new System.EventHandler(this.currencyCBox_SelectedValueChanged);
            this.currencyCBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.currencyCBox_KeyUp);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(188, 244);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 13);
            this.label10.TabIndex = 549;
            this.label10.Text = "Сума у валюті";
            // 
            // paymentDatePicker
            // 
            this.paymentDatePicker.EditValue = null;
            this.paymentDatePicker.Location = new System.Drawing.Point(12, 25);
            this.paymentDatePicker.Name = "paymentDatePicker";
            this.paymentDatePicker.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.paymentDatePicker.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.paymentDatePicker.Size = new System.Drawing.Size(125, 20);
            this.paymentDatePicker.TabIndex = 1;
            this.paymentDatePicker.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.paymentDatePicker_KeyPress);
            // 
            // employeesChkBox
            // 
            this.employeesChkBox.AutoSize = true;
            this.employeesChkBox.Location = new System.Drawing.Point(21, 28);
            this.employeesChkBox.Name = "employeesChkBox";
            this.employeesChkBox.Size = new System.Drawing.Size(15, 14);
            this.employeesChkBox.TabIndex = 8;
            this.employeesChkBox.UseVisualStyleBackColor = true;
            this.employeesChkBox.CheckedChanged += new System.EventHandler(this.employeesChkBox_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(477, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 13);
            this.label11.TabIndex = 561;
            this.label11.Text = "Код за ЄДРПОУ";
            // 
            // srnTBox
            // 
            this.srnTBox.Location = new System.Drawing.Point(480, 25);
            this.srnTBox.MaxLength = 12;
            this.srnTBox.Name = "srnTBox";
            this.srnTBox.ReadOnly = true;
            this.srnTBox.Size = new System.Drawing.Size(84, 20);
            this.srnTBox.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(39, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 13);
            this.label12.TabIndex = 559;
            this.label12.Text = "ПІБ працівника";
            // 
            // contractorChkBox
            // 
            this.contractorChkBox.AutoSize = true;
            this.contractorChkBox.Location = new System.Drawing.Point(21, 28);
            this.contractorChkBox.Name = "contractorChkBox";
            this.contractorChkBox.Size = new System.Drawing.Size(15, 14);
            this.contractorChkBox.TabIndex = 5;
            this.contractorChkBox.UseVisualStyleBackColor = true;
            this.contractorChkBox.CheckedChanged += new System.EventHandler(this.contractorChkBox_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 108;
            this.label5.Text = "Найменування";
            // 
            // priceTBox
            // 
            this.priceTBox.Location = new System.Drawing.Point(391, 210);
            this.priceTBox.Name = "priceTBox";
            this.priceTBox.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.priceTBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.priceTBox.Properties.Appearance.Options.UseFont = true;
            this.priceTBox.Properties.Appearance.Options.UseTextOptions = true;
            this.priceTBox.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.priceTBox.Properties.Mask.EditMask = "n2";
            this.priceTBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.priceTBox.Properties.NullText = "0,00";
            this.priceTBox.Properties.NullValuePrompt = "0,00";
            this.priceTBox.Properties.NullValuePromptShowForEmptyValue = true;
            this.priceTBox.Size = new System.Drawing.Size(198, 20);
            this.priceTBox.TabIndex = 12;
            this.priceTBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.priceTBox_KeyPress);
            // 
            // sumCurrencyTBox
            // 
            this.sumCurrencyTBox.Location = new System.Drawing.Point(191, 260);
            this.sumCurrencyTBox.Name = "sumCurrencyTBox";
            this.sumCurrencyTBox.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.sumCurrencyTBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sumCurrencyTBox.Properties.Appearance.Options.UseFont = true;
            this.sumCurrencyTBox.Properties.Appearance.Options.UseTextOptions = true;
            this.sumCurrencyTBox.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.sumCurrencyTBox.Properties.Mask.EditMask = "n2";
            this.sumCurrencyTBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.sumCurrencyTBox.Properties.NullText = "0,00";
            this.sumCurrencyTBox.Properties.NullValuePrompt = "0,00";
            this.sumCurrencyTBox.Properties.NullValuePromptShowForEmptyValue = true;
            this.sumCurrencyTBox.Size = new System.Drawing.Size(191, 20);
            this.sumCurrencyTBox.TabIndex = 14;
            // 
            // rateTBox
            // 
            this.rateTBox.Location = new System.Drawing.Point(390, 260);
            this.rateTBox.Name = "rateTBox";
            this.rateTBox.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.rateTBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.rateTBox.Properties.Appearance.Options.UseFont = true;
            this.rateTBox.Properties.Appearance.Options.UseTextOptions = true;
            this.rateTBox.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.rateTBox.Properties.Mask.EditMask = "n6";
            this.rateTBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.rateTBox.Properties.NullText = "0,000000";
            this.rateTBox.Properties.NullValuePrompt = "0,000000";
            this.rateTBox.Properties.NullValuePromptShowForEmptyValue = true;
            this.rateTBox.Size = new System.Drawing.Size(199, 20);
            this.rateTBox.TabIndex = 15;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(140, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 13);
            this.label13.TabIndex = 582;
            this.label13.Text = "Заказ";
            // 
            // paymentConvertGBox
            // 
            this.paymentConvertGBox.BackColor = System.Drawing.Color.PaleTurquoise;
            this.paymentConvertGBox.Controls.Add(this.rateConvertTBox);
            this.paymentConvertGBox.Controls.Add(this.sumCurrencyConvertTBox);
            this.paymentConvertGBox.Controls.Add(this.label14);
            this.paymentConvertGBox.Controls.Add(this.label17);
            this.paymentConvertGBox.Controls.Add(this.currencyConvertCBox);
            this.paymentConvertGBox.Controls.Add(this.label18);
            this.paymentConvertGBox.ForeColor = System.Drawing.Color.Black;
            this.paymentConvertGBox.Location = new System.Drawing.Point(17, 295);
            this.paymentConvertGBox.Name = "paymentConvertGBox";
            this.paymentConvertGBox.Size = new System.Drawing.Size(572, 68);
            this.paymentConvertGBox.TabIndex = 589;
            this.paymentConvertGBox.TabStop = false;
            this.paymentConvertGBox.Text = "* Дані для конвертації валюти";
            // 
            // rateConvertTBox
            // 
            this.rateConvertTBox.Location = new System.Drawing.Point(440, 37);
            this.rateConvertTBox.Name = "rateConvertTBox";
            this.rateConvertTBox.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.rateConvertTBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.rateConvertTBox.Properties.Appearance.Options.UseFont = true;
            this.rateConvertTBox.Properties.Appearance.Options.UseTextOptions = true;
            this.rateConvertTBox.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.rateConvertTBox.Properties.Mask.EditMask = "n6";
            this.rateConvertTBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.rateConvertTBox.Properties.NullText = "0,000000";
            this.rateConvertTBox.Properties.NullValuePrompt = "0,000000";
            this.rateConvertTBox.Properties.NullValuePromptShowForEmptyValue = true;
            this.rateConvertTBox.Size = new System.Drawing.Size(120, 20);
            this.rateConvertTBox.TabIndex = 18;
            // 
            // sumCurrencyConvertTBox
            // 
            this.sumCurrencyConvertTBox.Location = new System.Drawing.Point(244, 37);
            this.sumCurrencyConvertTBox.Name = "sumCurrencyConvertTBox";
            this.sumCurrencyConvertTBox.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.sumCurrencyConvertTBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sumCurrencyConvertTBox.Properties.Appearance.Options.UseFont = true;
            this.sumCurrencyConvertTBox.Properties.Appearance.Options.UseTextOptions = true;
            this.sumCurrencyConvertTBox.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.sumCurrencyConvertTBox.Properties.Mask.EditMask = "n2";
            this.sumCurrencyConvertTBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.sumCurrencyConvertTBox.Properties.NullText = "0,00";
            this.sumCurrencyConvertTBox.Properties.NullValuePrompt = "0,00";
            this.sumCurrencyConvertTBox.Properties.NullValuePromptShowForEmptyValue = true;
            this.sumCurrencyConvertTBox.Size = new System.Drawing.Size(191, 20);
            this.sumCurrencyConvertTBox.TabIndex = 17;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(241, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 13);
            this.label14.TabIndex = 578;
            this.label14.Text = "Сума у валюті";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(15, 21);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(45, 13);
            this.label17.TabIndex = 577;
            this.label17.Text = "Валюта";
            // 
            // currencyConvertCBox
            // 
            this.currencyConvertCBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.currencyConvertCBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.currencyConvertCBox.DropDownWidth = 50;
            this.currencyConvertCBox.FormattingEnabled = true;
            this.currencyConvertCBox.Location = new System.Drawing.Point(17, 36);
            this.currencyConvertCBox.Name = "currencyConvertCBox";
            this.currencyConvertCBox.Size = new System.Drawing.Size(221, 21);
            this.currencyConvertCBox.TabIndex = 16;
            this.currencyConvertCBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.currencyConvertCBox_KeyUp);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(438, 21);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(71, 13);
            this.label18.TabIndex = 575;
            this.label18.Text = "Курс валюти";
            // 
            // buyersTab
            // 
            this.buyersTab.Location = new System.Drawing.Point(12, 96);
            this.buyersTab.Name = "buyersTab";
            this.buyersTab.SelectedTabPage = this.contractorTabPage;
            this.buyersTab.Size = new System.Drawing.Size(581, 95);
            this.buyersTab.TabIndex = 590;
            this.buyersTab.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.contractorTabPage,
            this.employeeTabPage});
            // 
            // contractorTabPage
            // 
            this.contractorTabPage.Controls.Add(this.contractorChkBox);
            this.contractorTabPage.Controls.Add(this.label5);
            this.contractorTabPage.Controls.Add(this.label11);
            this.contractorTabPage.Controls.Add(this.srnTBox);
            this.contractorTabPage.Controls.Add(this.contractorsEdit);
            this.contractorTabPage.Name = "contractorTabPage";
            this.contractorTabPage.Size = new System.Drawing.Size(575, 67);
            this.contractorTabPage.Text = "Контрагент";
            // 
            // contractorsEdit
            // 
            this.contractorsEdit.Location = new System.Drawing.Point(42, 25);
            this.contractorsEdit.Name = "contractorsEdit";
            this.contractorsEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.contractorsEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.contractorsEdit.Properties.ImmediatePopup = true;
            this.contractorsEdit.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.contractorsEdit.Properties.PopupFormSize = new System.Drawing.Size(300, 0);
            this.contractorsEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.contractorsEdit.Properties.View = this.contractorsEditView;
            this.contractorsEdit.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.contractorsEdit_Properties_ButtonClick);
            this.contractorsEdit.Size = new System.Drawing.Size(434, 20);
            this.contractorsEdit.TabIndex = 6;
            this.contractorsEdit.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.contractorsEdit_QueryPopUp);
            this.contractorsEdit.EditValueChanged += new System.EventHandler(this.contractorsEdit_EditValueChanged);
            // 
            // contractorsEditView
            // 
            this.contractorsEditView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.nameColumn,
            this.srnColumn});
            this.contractorsEditView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.contractorsEditView.Name = "contractorsEditView";
            this.contractorsEditView.OptionsFind.AlwaysVisible = true;
            this.contractorsEditView.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.contractorsEditView.OptionsFind.SearchInPreview = true;
            this.contractorsEditView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.contractorsEditView.OptionsView.ShowAutoFilterRow = true;
            this.contractorsEditView.OptionsView.ShowGroupPanel = false;
            // 
            // nameColumn
            // 
            this.nameColumn.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameColumn.AppearanceCell.Options.UseFont = true;
            this.nameColumn.Caption = "Найменування";
            this.nameColumn.FieldName = "Name";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.OptionsColumn.AllowEdit = false;
            this.nameColumn.OptionsColumn.AllowFocus = false;
            this.nameColumn.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.nameColumn.Visible = true;
            this.nameColumn.VisibleIndex = 0;
            this.nameColumn.Width = 200;
            // 
            // srnColumn
            // 
            this.srnColumn.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.srnColumn.AppearanceCell.Options.UseFont = true;
            this.srnColumn.Caption = "Код за ЄДРПОУ";
            this.srnColumn.FieldName = "Srn";
            this.srnColumn.Name = "srnColumn";
            this.srnColumn.OptionsColumn.AllowEdit = false;
            this.srnColumn.OptionsColumn.AllowFocus = false;
            this.srnColumn.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.srnColumn.Visible = true;
            this.srnColumn.VisibleIndex = 1;
            this.srnColumn.Width = 92;
            // 
            // employeeTabPage
            // 
            this.employeeTabPage.Controls.Add(this.employeesEdit);
            this.employeeTabPage.Controls.Add(this.label15);
            this.employeeTabPage.Controls.Add(this.empNumberTBox);
            this.employeeTabPage.Controls.Add(this.label12);
            this.employeeTabPage.Controls.Add(this.employeesChkBox);
            this.employeeTabPage.Name = "employeeTabPage";
            this.employeeTabPage.Size = new System.Drawing.Size(575, 67);
            this.employeeTabPage.Text = "Працівник підприємства";
            // 
            // employeesEdit
            // 
            this.employeesEdit.Location = new System.Drawing.Point(42, 25);
            this.employeesEdit.Name = "employeesEdit";
            this.employeesEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.employeesEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.employeesEdit.Properties.ImmediatePopup = true;
            this.employeesEdit.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.employeesEdit.Properties.PopupFormSize = new System.Drawing.Size(300, 0);
            this.employeesEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.employeesEdit.Properties.View = this.employeesEditView;
            this.employeesEdit.Properties.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.gridLookUpEdit1_Properties_QueryPopUp);
            this.employeesEdit.Size = new System.Drawing.Size(434, 20);
            this.employeesEdit.TabIndex = 9;
            this.employeesEdit.EditValueChanged += new System.EventHandler(this.employeesEdit_EditValueChanged);
            // 
            // employeesEditView
            // 
            this.employeesEditView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.empNameColumn,
            this.empNumberColumn});
            this.employeesEditView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.employeesEditView.Name = "employeesEditView";
            this.employeesEditView.OptionsFind.AlwaysVisible = true;
            this.employeesEditView.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.employeesEditView.OptionsFind.SearchInPreview = true;
            this.employeesEditView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.employeesEditView.OptionsView.ShowAutoFilterRow = true;
            this.employeesEditView.OptionsView.ShowGroupPanel = false;
            // 
            // empNameColumn
            // 
            this.empNameColumn.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.empNameColumn.AppearanceCell.Options.UseFont = true;
            this.empNameColumn.Caption = "ПІБ(посада)";
            this.empNameColumn.FieldName = "Name";
            this.empNameColumn.Name = "empNameColumn";
            this.empNameColumn.OptionsColumn.AllowEdit = false;
            this.empNameColumn.OptionsColumn.AllowFocus = false;
            this.empNameColumn.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.empNameColumn.Visible = true;
            this.empNameColumn.VisibleIndex = 0;
            this.empNameColumn.Width = 200;
            // 
            // empNumberColumn
            // 
            this.empNumberColumn.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.empNumberColumn.AppearanceCell.Options.UseFont = true;
            this.empNumberColumn.Caption = "Табельний номер";
            this.empNumberColumn.FieldName = "Number";
            this.empNumberColumn.Name = "empNumberColumn";
            this.empNumberColumn.OptionsColumn.AllowEdit = false;
            this.empNumberColumn.OptionsColumn.AllowFocus = false;
            this.empNumberColumn.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.empNumberColumn.Visible = true;
            this.empNumberColumn.VisibleIndex = 1;
            this.empNumberColumn.Width = 92;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(477, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 13);
            this.label15.TabIndex = 564;
            this.label15.Text = "Таб. номер";
            // 
            // empNumberTBox
            // 
            this.empNumberTBox.Location = new System.Drawing.Point(480, 25);
            this.empNumberTBox.MaxLength = 12;
            this.empNumberTBox.Name = "empNumberTBox";
            this.empNumberTBox.ReadOnly = true;
            this.empNumberTBox.Size = new System.Drawing.Size(84, 20);
            this.empNumberTBox.TabIndex = 9;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.gridView1.OptionsFind.SearchInPreview = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.Caption = "Заказ";
            this.gridColumn1.FieldName = "OrderNumber";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 100;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.Caption = "Контрагент";
            this.gridColumn2.FieldName = "ContractorName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 300;
            // 
            // customerOrdersEdit
            // 
            this.customerOrdersEdit.Location = new System.Drawing.Point(143, 65);
            this.customerOrdersEdit.Name = "customerOrdersEdit";
            this.customerOrdersEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.customerOrdersEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.customerOrdersEdit.Properties.ImmediatePopup = true;
            this.customerOrdersEdit.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.customerOrdersEdit.Properties.PopupFormSize = new System.Drawing.Size(300, 0);
            this.customerOrdersEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.customerOrdersEdit.Properties.View = this.gridView1;
            this.customerOrdersEdit.Properties.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.gridLookUpEdit1_Properties_QueryPopUp_1);
            this.customerOrdersEdit.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.customerOrdersEdit_Properties_ButtonClick);
            this.customerOrdersEdit.Size = new System.Drawing.Size(445, 20);
            this.customerOrdersEdit.TabIndex = 4;
            this.customerOrdersEdit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.customerOrdersEdit_KeyUp);
            // 
            // new_BankPaymentsEditFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(605, 515);
            this.Controls.Add(this.customerOrdersEdit);
            this.Controls.Add(this.buyersTab);
            this.Controls.Add(this.paymentConvertGBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.rateTBox);
            this.Controls.Add(this.sumCurrencyTBox);
            this.Controls.Add(this.priceTBox);
            this.Controls.Add(this.paymentDatePicker);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.currencyCBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.debitCreditCBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.purposeTBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.purposeAccountCBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.documentNumTBox);
            this.Controls.Add(this.bankAccountCBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "new_BankPaymentsEditFm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редагувати платіж";
            ((System.ComponentModel.ISupportInitialize)(this.paymentDatePicker.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentDatePicker.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sumCurrencyTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rateTBox.Properties)).EndInit();
            this.paymentConvertGBox.ResumeLayout(false);
            this.paymentConvertGBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rateConvertTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sumCurrencyConvertTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buyersTab)).EndInit();
            this.buyersTab.ResumeLayout(false);
            this.contractorTabPage.ResumeLayout(false);
            this.contractorTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contractorsEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contractorsEditView)).EndInit();
            this.employeeTabPage.ResumeLayout(false);
            this.employeeTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeesEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeesEditView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerOrdersEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox purposeTBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox purposeAccountCBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox documentNumTBox;
        private System.Windows.Forms.ComboBox bankAccountCBox;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.ComboBox debitCreditCBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox currencyCBox;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraEditors.DateEdit paymentDatePicker;
        private System.Windows.Forms.CheckBox employeesChkBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox srnTBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox contractorChkBox;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit priceTBox;
        private DevExpress.XtraEditors.TextEdit sumCurrencyTBox;
        private DevExpress.XtraEditors.TextEdit rateTBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox paymentConvertGBox;
        private DevExpress.XtraEditors.TextEdit rateConvertTBox;
        private DevExpress.XtraEditors.TextEdit sumCurrencyConvertTBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox currencyConvertCBox;
        private System.Windows.Forms.Label label18;
        private DevExpress.XtraTab.XtraTabControl buyersTab;
        private DevExpress.XtraTab.XtraTabPage contractorTabPage;
        private DevExpress.XtraTab.XtraTabPage employeeTabPage;
        private DevExpress.XtraEditors.GridLookUpEdit contractorsEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView contractorsEditView;
        private DevExpress.XtraGrid.Columns.GridColumn nameColumn;
        private DevExpress.XtraGrid.Columns.GridColumn srnColumn;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox empNumberTBox;
        private DevExpress.XtraEditors.GridLookUpEdit employeesEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView employeesEditView;
        private DevExpress.XtraGrid.Columns.GridColumn empNameColumn;
        private DevExpress.XtraGrid.Columns.GridColumn empNumberColumn;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.GridLookUpEdit customerOrdersEdit;
    }
}