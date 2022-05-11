namespace Accounting
{
	partial class editInvoiceRequirement
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.label17 = new System.Windows.Forms.Label();
            this.invoiceDatePicker = new System.Windows.Forms.DateTimePicker();
            this.okBtn = new System.Windows.Forms.Button();
            this.reportBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.requirementMaterialGrid = new DevExpress.XtraGrid.GridControl();
            this.requirementMaterialView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColInventoryNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SelectIRButtonEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColInventoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColFixedAssets_Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.addBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.numberTBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.supplierNewCBox = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.fullNameCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nabNumberCol = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.requirementMaterialGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requirementMaterialView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectIRButtonEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierNewCBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(88, 7);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(89, 13);
            this.label17.TabIndex = 546;
            this.label17.Text = "Дата створення";
            // 
            // invoiceDatePicker
            // 
            this.invoiceDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.invoiceDatePicker.Location = new System.Drawing.Point(91, 23);
            this.invoiceDatePicker.Name = "invoiceDatePicker";
            this.invoiceDatePicker.Size = new System.Drawing.Size(160, 20);
            this.invoiceDatePicker.TabIndex = 541;
            this.invoiceDatePicker.Value = new System.DateTime(2014, 7, 22, 0, 0, 0, 0);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(921, 477);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(143, 24);
            this.okBtn.TabIndex = 549;
            this.okBtn.Text = "&Зберегти";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // reportBtn
            // 
            this.reportBtn.Location = new System.Drawing.Point(772, 477);
            this.reportBtn.Name = "reportBtn";
            this.reportBtn.Size = new System.Drawing.Size(143, 24);
            this.reportBtn.TabIndex = 550;
            this.reportBtn.Text = "&Друк";
            this.reportBtn.UseVisualStyleBackColor = true;
            this.reportBtn.Click += new System.EventHandler(this.reportBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(1070, 477);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(143, 24);
            this.cancelBtn.TabIndex = 551;
            this.cancelBtn.Text = "&Відмінити";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // requirementMaterialGrid
            // 
            this.requirementMaterialGrid.Location = new System.Drawing.Point(12, 50);
            this.requirementMaterialGrid.MainView = this.requirementMaterialView;
            this.requirementMaterialGrid.Name = "requirementMaterialGrid";
            this.requirementMaterialGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.SelectIRButtonEdit});
            this.requirementMaterialGrid.Size = new System.Drawing.Size(1201, 421);
            this.requirementMaterialGrid.TabIndex = 552;
            this.requirementMaterialGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.requirementMaterialView});
            // 
            // requirementMaterialView
            // 
            this.requirementMaterialView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn9,
            this.gridColInventoryNumber,
            this.gridColInventoryName,
            this.gridColFixedAssets_Id,
            this.gridColDescription});
            this.requirementMaterialView.GridControl = this.requirementMaterialGrid;
            this.requirementMaterialView.Name = "requirementMaterialView";
            this.requirementMaterialView.OptionsView.ShowAutoFilterRow = true;
            this.requirementMaterialView.OptionsView.ShowFooter = true;
            this.requirementMaterialView.OptionsView.ShowGroupPanel = false;
            this.requirementMaterialView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.requirementMaterialView_FocusedRowChanged);
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Найменування";
            this.gridColumn3.FieldName = "NAME";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 330;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "К-сть";
            this.gridColumn4.FieldName = "Required_Quantity";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Required_Quantity", "{0:### ##0.##}")});
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            this.gridColumn4.Width = 64;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn5.AppearanceHeader.Options.UseFont = true;
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "Ціна";
            this.gridColumn5.DisplayFormat.FormatString = "### ### ##0.00";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn5.FieldName = "UNIT_PRICE";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 6;
            this.gridColumn5.Width = 92;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn6.AppearanceHeader.Options.UseFont = true;
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.Caption = "Сума";
            this.gridColumn6.DisplayFormat.FormatString = "### ### ##0.00";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn6.FieldName = "TOTAL_PRICE";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOTAL_PRICE", "{0:### ### ##0.00}")});
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 7;
            this.gridColumn6.Width = 104;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn7.AppearanceHeader.Options.UseFont = true;
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.Caption = "Бал. рах.";
            this.gridColumn7.FieldName = "NUM";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            this.gridColumn7.Width = 82;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn8.AppearanceHeader.Options.UseFont = true;
            this.gridColumn8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.Caption = "Кредит рах.";
            this.gridColumn8.FieldName = "EXPEN_ACCOUNT";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 8;
            this.gridColumn8.Width = 122;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "Од.вим.";
            this.gridColumn1.FieldName = "MEASURE";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 4;
            this.gridColumn1.Width = 64;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Номенкл.номер";
            this.gridColumn2.FieldName = "NOMENCLATURE";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 133;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn9.AppearanceHeader.Options.UseFont = true;
            this.gridColumn9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.Caption = "№ надходження";
            this.gridColumn9.FieldName = "RECEIPT_NUM";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 2;
            this.gridColumn9.Width = 93;
            // 
            // gridColInventoryNumber
            // 
            this.gridColInventoryNumber.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColInventoryNumber.AppearanceHeader.Options.UseFont = true;
            this.gridColInventoryNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColInventoryNumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColInventoryNumber.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColInventoryNumber.Caption = "Картка ОЗ";
            this.gridColInventoryNumber.ColumnEdit = this.SelectIRButtonEdit;
            this.gridColInventoryNumber.FieldName = "InventoryNumber";
            this.gridColInventoryNumber.Name = "gridColInventoryNumber";
            this.gridColInventoryNumber.OptionsColumn.ReadOnly = true;
            this.gridColInventoryNumber.Visible = true;
            this.gridColInventoryNumber.VisibleIndex = 9;
            this.gridColInventoryNumber.Width = 130;
            // 
            // SelectIRButtonEdit
            // 
            serializableAppearanceObject1.Image = global::Accounting.Properties.Resources.Edit_Delete;
            serializableAppearanceObject1.Options.UseImage = true;
            this.SelectIRButtonEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.TopCenter, global::Accounting.Properties.Resources.Edit_Delete, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.SelectIRButtonEdit.Name = "SelectIRButtonEdit";
            this.SelectIRButtonEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.SelectIRButtonEdit_ButtonClick);
            // 
            // gridColInventoryName
            // 
            this.gridColInventoryName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColInventoryName.AppearanceHeader.Options.UseFont = true;
            this.gridColInventoryName.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColInventoryName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColInventoryName.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColInventoryName.Caption = "Найменування ОЗ";
            this.gridColInventoryName.FieldName = "InventoryName";
            this.gridColInventoryName.Name = "gridColInventoryName";
            this.gridColInventoryName.Visible = true;
            this.gridColInventoryName.VisibleIndex = 10;
            this.gridColInventoryName.Width = 237;
            // 
            // gridColFixedAssets_Id
            // 
            this.gridColFixedAssets_Id.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColFixedAssets_Id.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColFixedAssets_Id.FieldName = "FixedAssets_Id";
            this.gridColFixedAssets_Id.Name = "gridColFixedAssets_Id";
            this.gridColFixedAssets_Id.OptionsColumn.AllowEdit = false;
            this.gridColFixedAssets_Id.OptionsColumn.ReadOnly = true;
            // 
            // gridColDescription
            // 
            this.gridColDescription.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColDescription.AppearanceHeader.Options.UseFont = true;
            this.gridColDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColDescription.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColDescription.Caption = "Додаткова інформація";
            this.gridColDescription.FieldName = "Description";
            this.gridColDescription.Name = "gridColDescription";
            this.gridColDescription.Visible = true;
            this.gridColDescription.VisibleIndex = 11;
            this.gridColDescription.Width = 283;
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(12, 477);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(130, 24);
            this.addBtn.TabIndex = 554;
            this.addBtn.Text = "&Додати";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Enabled = false;
            this.deleteBtn.Location = new System.Drawing.Point(148, 477);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(143, 24);
            this.deleteBtn.TabIndex = 553;
            this.deleteBtn.Text = "&Видалити";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // numberTBox
            // 
            this.numberTBox.Location = new System.Drawing.Point(12, 23);
            this.numberTBox.Name = "numberTBox";
            this.numberTBox.Size = new System.Drawing.Size(63, 20);
            this.numberTBox.TabIndex = 555;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 556;
            this.label1.Text = "Номер";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(254, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 557;
            this.label3.Text = "Відповідальна особа";
            // 
            // supplierNewCBox
            // 
            this.supplierNewCBox.Location = new System.Drawing.Point(257, 23);
            this.supplierNewCBox.Name = "supplierNewCBox";
            this.supplierNewCBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)});
            this.supplierNewCBox.Properties.ImmediatePopup = true;
            this.supplierNewCBox.Properties.NullText = "";
            this.supplierNewCBox.Properties.PopupFormSize = new System.Drawing.Size(300, 0);
            this.supplierNewCBox.Properties.View = this.gridLookUpEdit1View;
            this.supplierNewCBox.Properties.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.supplierNewCBox_Properties_QueryPopUp);
            this.supplierNewCBox.Size = new System.Drawing.Size(444, 20);
            this.supplierNewCBox.TabIndex = 605;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.fullNameCol,
            this.nabNumberCol});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // fullNameCol
            // 
            this.fullNameCol.AppearanceHeader.Options.UseTextOptions = true;
            this.fullNameCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fullNameCol.Caption = "Повна назва";
            this.fullNameCol.FieldName = "FullName";
            this.fullNameCol.Name = "fullNameCol";
            this.fullNameCol.Visible = true;
            this.fullNameCol.VisibleIndex = 0;
            this.fullNameCol.Width = 309;
            // 
            // nabNumberCol
            // 
            this.nabNumberCol.AppearanceHeader.Options.UseTextOptions = true;
            this.nabNumberCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.nabNumberCol.Caption = "Таб./номер";
            this.nabNumberCol.FieldName = "AccountNumber";
            this.nabNumberCol.MaxWidth = 75;
            this.nabNumberCol.Name = "nabNumberCol";
            this.nabNumberCol.Visible = true;
            this.nabNumberCol.VisibleIndex = 1;
            // 
            // editInvoiceRequirement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 514);
            this.Controls.Add(this.supplierNewCBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numberTBox);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.requirementMaterialGrid);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.reportBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.invoiceDatePicker);
            this.Name = "editInvoiceRequirement";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.editInvoiceRequirement_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.requirementMaterialGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requirementMaterialView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectIRButtonEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierNewCBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker invoiceDatePicker;
		private System.Windows.Forms.Button okBtn;
		private System.Windows.Forms.Button reportBtn;
		private System.Windows.Forms.Button cancelBtn;
		private DevExpress.XtraGrid.GridControl requirementMaterialGrid;
		private DevExpress.XtraGrid.Views.Grid.GridView requirementMaterialView;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private System.Windows.Forms.Button addBtn;
		private System.Windows.Forms.Button deleteBtn;
		private System.Windows.Forms.TextBox numberTBox;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColInventoryNumber;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit SelectIRButtonEdit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColFixedAssets_Id;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDescription;
        private DevExpress.XtraGrid.Columns.GridColumn gridColInventoryName;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.GridLookUpEdit supplierNewCBox;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn fullNameCol;
        private DevExpress.XtraGrid.Columns.GridColumn nabNumberCol;
	}
}