namespace Accounting
{
    partial class calcWithBuyersAddEditFm
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
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.balanceAccountCBox = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.documentNameTBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.documentDatePicker = new DevExpress.XtraEditors.DateEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.purposeAccountCBox = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.currencyCBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.paymentTBox = new DevExpress.XtraEditors.TextEdit();
            this.paymentCurrencyTBox = new DevExpress.XtraEditors.TextEdit();
            this.paymentRateTBox = new DevExpress.XtraEditors.TextEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.debitCreditCBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.customerOrdersEdit = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.buyersTab = new DevExpress.XtraTab.XtraTabControl();
            this.contractorTabPage = new DevExpress.XtraTab.XtraTabPage();
            this.contractorChkBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.srnTBox = new System.Windows.Forms.TextBox();
            this.contractorsEdit = new DevExpress.XtraEditors.GridLookUpEdit();
            this.contractorsEditView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.nameColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.srnColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.employeeTabPage = new DevExpress.XtraTab.XtraTabPage();
            this.employeesEdit = new DevExpress.XtraEditors.GridLookUpEdit();
            this.employeesEditView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.empNameColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.empNumberColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.empNumberTBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.employeesChkBox = new System.Windows.Forms.CheckBox();
            this.commentTBox = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.documentDatePicker.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentDatePicker.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentCurrencyTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentRateTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerOrdersEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buyersTab)).BeginInit();
            this.buyersTab.SuspendLayout();
            this.contractorTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contractorsEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contractorsEditView)).BeginInit();
            this.employeeTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeesEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeesEditView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commentTBox.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(301, 479);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(143, 24);
            this.okBtn.TabIndex = 18;
            this.okBtn.Text = "Зберегти";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(450, 479);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(143, 24);
            this.cancelBtn.TabIndex = 19;
            this.cancelBtn.Text = "Відмінити";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(377, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 112;
            this.label1.Text = "Сума у гривні";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 203);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(111, 13);
            this.label15.TabIndex = 114;
            this.label15.Text = "Балансовий рахунок";
            // 
            // balanceAccountCBox
            // 
            this.balanceAccountCBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.balanceAccountCBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.balanceAccountCBox.DropDownWidth = 50;
            this.balanceAccountCBox.FormattingEnabled = true;
            this.balanceAccountCBox.Location = new System.Drawing.Point(13, 219);
            this.balanceAccountCBox.Name = "balanceAccountCBox";
            this.balanceAccountCBox.Size = new System.Drawing.Size(164, 21);
            this.balanceAccountCBox.TabIndex = 11;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(33, 13);
            this.label13.TabIndex = 123;
            this.label13.Text = "Дата";
            // 
            // documentNameTBox
            // 
            this.documentNameTBox.Location = new System.Drawing.Point(143, 22);
            this.documentNameTBox.MaxLength = 50;
            this.documentNameTBox.Name = "documentNameTBox";
            this.documentNameTBox.Size = new System.Drawing.Size(450, 20);
            this.documentNameTBox.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(140, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 125;
            this.label4.Text = "Номер";
            // 
            // documentDatePicker
            // 
            this.documentDatePicker.EditValue = null;
            this.documentDatePicker.Location = new System.Drawing.Point(12, 22);
            this.documentDatePicker.Name = "documentDatePicker";
            this.documentDatePicker.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.documentDatePicker.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.documentDatePicker.Size = new System.Drawing.Size(125, 20);
            this.documentDatePicker.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 555;
            this.label2.Text = "Рахунок призначення";
            // 
            // purposeAccountCBox
            // 
            this.purposeAccountCBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.purposeAccountCBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.purposeAccountCBox.DropDownWidth = 50;
            this.purposeAccountCBox.FormattingEnabled = true;
            this.purposeAccountCBox.Location = new System.Drawing.Point(183, 219);
            this.purposeAccountCBox.Name = "purposeAccountCBox";
            this.purposeAccountCBox.Size = new System.Drawing.Size(191, 21);
            this.purposeAccountCBox.TabIndex = 12;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(9, 248);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(45, 13);
            this.label22.TabIndex = 557;
            this.label22.Text = "Валюта";
            // 
            // currencyCBox
            // 
            this.currencyCBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.currencyCBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.currencyCBox.DropDownWidth = 50;
            this.currencyCBox.FormattingEnabled = true;
            this.currencyCBox.Location = new System.Drawing.Point(12, 264);
            this.currencyCBox.Name = "currencyCBox";
            this.currencyCBox.Size = new System.Drawing.Size(165, 21);
            this.currencyCBox.TabIndex = 14;
            this.currencyCBox.SelectedValueChanged += new System.EventHandler(this.currencyCBox_SelectedValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(183, 249);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 567;
            this.label8.Text = "Сума у валюті";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(377, 249);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 569;
            this.label9.Text = "Курс";
            // 
            // paymentTBox
            // 
            this.paymentTBox.Location = new System.Drawing.Point(380, 219);
            this.paymentTBox.Name = "paymentTBox";
            this.paymentTBox.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.paymentTBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.paymentTBox.Properties.Appearance.Options.UseFont = true;
            this.paymentTBox.Properties.Appearance.Options.UseTextOptions = true;
            this.paymentTBox.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.paymentTBox.Properties.Mask.EditMask = "n2";
            this.paymentTBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.paymentTBox.Properties.NullText = "0,00";
            this.paymentTBox.Properties.NullValuePrompt = "0,00";
            this.paymentTBox.Properties.NullValuePromptShowForEmptyValue = true;
            this.paymentTBox.Size = new System.Drawing.Size(213, 20);
            this.paymentTBox.TabIndex = 13;
            // 
            // paymentCurrencyTBox
            // 
            this.paymentCurrencyTBox.Location = new System.Drawing.Point(183, 265);
            this.paymentCurrencyTBox.Name = "paymentCurrencyTBox";
            this.paymentCurrencyTBox.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.paymentCurrencyTBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.paymentCurrencyTBox.Properties.Appearance.Options.UseFont = true;
            this.paymentCurrencyTBox.Properties.Appearance.Options.UseTextOptions = true;
            this.paymentCurrencyTBox.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.paymentCurrencyTBox.Properties.Mask.EditMask = "n2";
            this.paymentCurrencyTBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.paymentCurrencyTBox.Properties.NullText = "0,00";
            this.paymentCurrencyTBox.Properties.NullValuePrompt = "0,00";
            this.paymentCurrencyTBox.Properties.NullValuePromptShowForEmptyValue = true;
            this.paymentCurrencyTBox.Size = new System.Drawing.Size(191, 20);
            this.paymentCurrencyTBox.TabIndex = 15;
            // 
            // paymentRateTBox
            // 
            this.paymentRateTBox.Location = new System.Drawing.Point(380, 265);
            this.paymentRateTBox.Name = "paymentRateTBox";
            this.paymentRateTBox.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.paymentRateTBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.paymentRateTBox.Properties.Appearance.Options.UseFont = true;
            this.paymentRateTBox.Properties.Appearance.Options.UseTextOptions = true;
            this.paymentRateTBox.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.paymentRateTBox.Properties.Mask.EditMask = "n6";
            this.paymentRateTBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.paymentRateTBox.Properties.NullText = "0,000000";
            this.paymentRateTBox.Properties.NullValuePrompt = "0,000000";
            this.paymentRateTBox.Properties.NullValuePromptShowForEmptyValue = true;
            this.paymentRateTBox.Size = new System.Drawing.Size(213, 20);
            this.paymentRateTBox.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 292);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 575;
            this.label7.Text = "Коментар";
            // 
            // debitCreditCBox
            // 
            this.debitCreditCBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.debitCreditCBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.debitCreditCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.debitCreditCBox.DropDownWidth = 50;
            this.debitCreditCBox.FormattingEnabled = true;
            this.debitCreditCBox.Location = new System.Drawing.Point(12, 62);
            this.debitCreditCBox.Name = "debitCreditCBox";
            this.debitCreditCBox.Size = new System.Drawing.Size(125, 21);
            this.debitCreditCBox.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 577;
            this.label10.Text = "Оперція";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(140, 45);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 579;
            this.label11.Text = "Заказ";
            // 
            // customerOrdersEdit
            // 
            this.customerOrdersEdit.Location = new System.Drawing.Point(143, 62);
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
            this.customerOrdersEdit.Properties.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.customerOrdersEdit_Properties_QueryPopUp);
            this.customerOrdersEdit.Size = new System.Drawing.Size(450, 20);
            this.customerOrdersEdit.TabIndex = 4;
            this.customerOrdersEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.customerOrdersEdit_ButtonClick);
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
            // buyersTab
            // 
            this.buyersTab.Location = new System.Drawing.Point(12, 99);
            this.buyersTab.Name = "buyersTab";
            this.buyersTab.SelectedTabPage = this.contractorTabPage;
            this.buyersTab.Size = new System.Drawing.Size(581, 95);
            this.buyersTab.TabIndex = 593;
            this.buyersTab.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.contractorTabPage,
            this.employeeTabPage});
            // 
            // contractorTabPage
            // 
            this.contractorTabPage.Controls.Add(this.contractorChkBox);
            this.contractorTabPage.Controls.Add(this.label5);
            this.contractorTabPage.Controls.Add(this.label3);
            this.contractorTabPage.Controls.Add(this.srnTBox);
            this.contractorTabPage.Controls.Add(this.contractorsEdit);
            this.contractorTabPage.Name = "contractorTabPage";
            this.contractorTabPage.Size = new System.Drawing.Size(575, 67);
            this.contractorTabPage.Text = "Контрагент";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(477, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 561;
            this.label3.Text = "Код за ЄДРПОУ";
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
            this.contractorsEdit.Properties.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.contractorsEdit_Properties_QueryPopUp);
            this.contractorsEdit.Size = new System.Drawing.Size(434, 20);
            this.contractorsEdit.TabIndex = 6;
            this.contractorsEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.contractorsEdit_ButtonClick);
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
            this.employeeTabPage.Controls.Add(this.label6);
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
            this.employeesEdit.Properties.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.employeesEdit_Properties_QueryPopUp);
            this.employeesEdit.Size = new System.Drawing.Size(434, 20);
            this.employeesEdit.TabIndex = 9;
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(477, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 564;
            this.label6.Text = "Таб. номер";
            // 
            // empNumberTBox
            // 
            this.empNumberTBox.Location = new System.Drawing.Point(480, 25);
            this.empNumberTBox.MaxLength = 12;
            this.empNumberTBox.Name = "empNumberTBox";
            this.empNumberTBox.ReadOnly = true;
            this.empNumberTBox.Size = new System.Drawing.Size(84, 20);
            this.empNumberTBox.TabIndex = 10;
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
            // commentTBox
            // 
            this.commentTBox.Location = new System.Drawing.Point(12, 308);
            this.commentTBox.Name = "commentTBox";
            this.commentTBox.Size = new System.Drawing.Size(581, 165);
            this.commentTBox.TabIndex = 594;
            // 
            // calcWithBuyersAddEditFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(605, 515);
            this.Controls.Add(this.commentTBox);
            this.Controls.Add(this.buyersTab);
            this.Controls.Add(this.customerOrdersEdit);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.debitCreditCBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.paymentRateTBox);
            this.Controls.Add(this.paymentCurrencyTBox);
            this.Controls.Add(this.paymentTBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.currencyCBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.purposeAccountCBox);
            this.Controls.Add(this.documentDatePicker);
            this.Controls.Add(this.documentNameTBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.balanceAccountCBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.cancelBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "calcWithBuyersAddEditFm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редагувати документ";
            ((System.ComponentModel.ISupportInitialize)(this.documentDatePicker.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentDatePicker.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentCurrencyTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentRateTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerOrdersEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.commentTBox.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox balanceAccountCBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox documentNameTBox;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.DateEdit documentDatePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox purposeAccountCBox;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox currencyCBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraEditors.TextEdit paymentTBox;
        private DevExpress.XtraEditors.TextEdit paymentCurrencyTBox;
        private DevExpress.XtraEditors.TextEdit paymentRateTBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox debitCreditCBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private DevExpress.XtraEditors.GridLookUpEdit customerOrdersEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraTab.XtraTabControl buyersTab;
        private DevExpress.XtraTab.XtraTabPage contractorTabPage;
        private System.Windows.Forms.CheckBox contractorChkBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox srnTBox;
        private DevExpress.XtraEditors.GridLookUpEdit contractorsEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView contractorsEditView;
        private DevExpress.XtraGrid.Columns.GridColumn nameColumn;
        private DevExpress.XtraGrid.Columns.GridColumn srnColumn;
        private DevExpress.XtraTab.XtraTabPage employeeTabPage;
        private DevExpress.XtraEditors.GridLookUpEdit employeesEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView employeesEditView;
        private DevExpress.XtraGrid.Columns.GridColumn empNameColumn;
        private DevExpress.XtraGrid.Columns.GridColumn empNumberColumn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox empNumberTBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox employeesChkBox;
        private DevExpress.XtraEditors.MemoEdit commentTBox;
    }
}