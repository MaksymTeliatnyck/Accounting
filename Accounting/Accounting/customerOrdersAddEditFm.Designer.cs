namespace Accounting
{
    partial class customerOrdersAddEditFm
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
            this.label7 = new System.Windows.Forms.Label();
            this.detailsTBox = new System.Windows.Forms.TextBox();
            this.orderPriceTBox = new DevExpress.XtraEditors.TextEdit();
            this.label22 = new System.Windows.Forms.Label();
            this.currencyCBox = new System.Windows.Forms.ComboBox();
            this.orderDatePicker = new DevExpress.XtraEditors.DateEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.orderNumberTBox = new DevExpress.XtraEditors.TextEdit();
            this.contractorsEdit = new DevExpress.XtraEditors.GridLookUpEdit();
            this.contractorsEditView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.nameColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.srnColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.currencyPriceTBox = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.orderPriceTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDatePicker.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDatePicker.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderNumberTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contractorsEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contractorsEditView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currencyPriceTBox.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 13);
            this.label7.TabIndex = 586;
            this.label7.Text = "Детальна інформація";
            // 
            // detailsTBox
            // 
            this.detailsTBox.Location = new System.Drawing.Point(12, 162);
            this.detailsTBox.MaxLength = 500;
            this.detailsTBox.Multiline = true;
            this.detailsTBox.Name = "detailsTBox";
            this.detailsTBox.Size = new System.Drawing.Size(531, 71);
            this.detailsTBox.TabIndex = 6;
            // 
            // orderPriceTBox
            // 
            this.orderPriceTBox.Location = new System.Drawing.Point(12, 114);
            this.orderPriceTBox.Name = "orderPriceTBox";
            this.orderPriceTBox.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.orderPriceTBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.orderPriceTBox.Properties.Appearance.Options.UseFont = true;
            this.orderPriceTBox.Properties.Appearance.Options.UseTextOptions = true;
            this.orderPriceTBox.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.orderPriceTBox.Properties.Mask.EditMask = "n2";
            this.orderPriceTBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.orderPriceTBox.Properties.NullText = "0,00";
            this.orderPriceTBox.Properties.NullValuePrompt = "0,00";
            this.orderPriceTBox.Properties.NullValuePromptShowForEmptyValue = true;
            this.orderPriceTBox.Size = new System.Drawing.Size(163, 20);
            this.orderPriceTBox.TabIndex = 4;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(341, 98);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(45, 13);
            this.label22.TabIndex = 584;
            this.label22.Text = "Валюта";
            // 
            // currencyCBox
            // 
            this.currencyCBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.currencyCBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.currencyCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.currencyCBox.DropDownWidth = 50;
            this.currencyCBox.FormattingEnabled = true;
            this.currencyCBox.Location = new System.Drawing.Point(344, 113);
            this.currencyCBox.Name = "currencyCBox";
            this.currencyCBox.Size = new System.Drawing.Size(199, 21);
            this.currencyCBox.TabIndex = 5;
            // 
            // orderDatePicker
            // 
            this.orderDatePicker.EditValue = null;
            this.orderDatePicker.Location = new System.Drawing.Point(344, 23);
            this.orderDatePicker.Name = "orderDatePicker";
            this.orderDatePicker.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.orderDatePicker.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.orderDatePicker.Size = new System.Drawing.Size(199, 20);
            this.orderDatePicker.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 583;
            this.label4.Text = "Номер заказу";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(341, 7);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 13);
            this.label13.TabIndex = 582;
            this.label13.Text = "Дата заказу";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 581;
            this.label1.Text = "Сума (грн)";
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(251, 259);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(143, 24);
            this.okBtn.TabIndex = 7;
            this.okBtn.Text = "Зберегти";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(400, 259);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(143, 24);
            this.cancelBtn.TabIndex = 8;
            this.cancelBtn.Text = "Відмінити";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // orderNumberTBox
            // 
            this.orderNumberTBox.EditValue = "";
            this.orderNumberTBox.Location = new System.Drawing.Point(14, 23);
            this.orderNumberTBox.Name = "orderNumberTBox";
            this.orderNumberTBox.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.orderNumberTBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.orderNumberTBox.Properties.Appearance.Options.UseFont = true;
            this.orderNumberTBox.Properties.Appearance.Options.UseTextOptions = true;
            this.orderNumberTBox.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.orderNumberTBox.Properties.Mask.EditMask = "([1-9])(\\.([0-9][0-9]|[0-9][0-9][0-9]|[0-9][0-9][0-9][0-9])){2}";
            this.orderNumberTBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.orderNumberTBox.Properties.Mask.ShowPlaceHolders = false;
            this.orderNumberTBox.Properties.MaxLength = 12;
            this.orderNumberTBox.Properties.NullText = "0";
            this.orderNumberTBox.Properties.NullValuePrompt = "0";
            this.orderNumberTBox.Size = new System.Drawing.Size(324, 20);
            this.orderNumberTBox.TabIndex = 1;
            this.orderNumberTBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.orderNumberTBox_KeyPress);
            // 
            // contractorsEdit
            // 
            this.contractorsEdit.Location = new System.Drawing.Point(12, 71);
            this.contractorsEdit.Name = "contractorsEdit";
            this.contractorsEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.contractorsEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.contractorsEdit.Properties.ImmediatePopup = true;
            this.contractorsEdit.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.contractorsEdit.Properties.PopupFormSize = new System.Drawing.Size(300, 0);
            this.contractorsEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.contractorsEdit.Properties.View = this.contractorsEditView;
            this.contractorsEdit.Properties.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.contractorsEdit_Properties_QueryPopUp);
            this.contractorsEdit.Size = new System.Drawing.Size(531, 20);
            this.contractorsEdit.TabIndex = 3;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 587;
            this.label2.Text = "Договір";
            // 
            // currencyPriceTBox
            // 
            this.currencyPriceTBox.Location = new System.Drawing.Point(181, 113);
            this.currencyPriceTBox.Name = "currencyPriceTBox";
            this.currencyPriceTBox.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.currencyPriceTBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.currencyPriceTBox.Properties.Appearance.Options.UseFont = true;
            this.currencyPriceTBox.Properties.Appearance.Options.UseTextOptions = true;
            this.currencyPriceTBox.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.currencyPriceTBox.Properties.Mask.EditMask = "n2";
            this.currencyPriceTBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.currencyPriceTBox.Properties.NullText = "0,00";
            this.currencyPriceTBox.Properties.NullValuePrompt = "0,00";
            this.currencyPriceTBox.Properties.NullValuePromptShowForEmptyValue = true;
            this.currencyPriceTBox.Size = new System.Drawing.Size(157, 20);
            this.currencyPriceTBox.TabIndex = 588;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(178, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 589;
            this.label3.Text = "Сума (валюта)";
            // 
            // customerOrdersAddEditFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(555, 295);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.currencyPriceTBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.contractorsEdit);
            this.Controls.Add(this.orderNumberTBox);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.detailsTBox);
            this.Controls.Add(this.orderPriceTBox);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.currencyCBox);
            this.Controls.Add(this.orderDatePicker);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "customerOrdersAddEditFm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редагувати заказ";
            ((System.ComponentModel.ISupportInitialize)(this.orderPriceTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDatePicker.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDatePicker.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderNumberTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contractorsEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contractorsEditView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currencyPriceTBox.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox detailsTBox;
        private DevExpress.XtraEditors.TextEdit orderPriceTBox;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox currencyCBox;
        private DevExpress.XtraEditors.DateEdit orderDatePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private DevExpress.XtraEditors.TextEdit orderNumberTBox;
        private DevExpress.XtraEditors.GridLookUpEdit contractorsEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView contractorsEditView;
        private DevExpress.XtraGrid.Columns.GridColumn nameColumn;
        private DevExpress.XtraGrid.Columns.GridColumn srnColumn;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit currencyPriceTBox;
        private System.Windows.Forms.Label label3;
    }
}