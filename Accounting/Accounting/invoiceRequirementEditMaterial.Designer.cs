namespace Accounting
{
	partial class invoiceRequirementEditMaterial
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
            this.viewSelectDateBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.expEndDateDTP = new System.Windows.Forms.DateTimePicker();
            this.expStartDateDTP = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.remainsGrid = new DevExpress.XtraGrid.GridControl();
            this.remainsView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GC_NOMENCLATURE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GC_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GC_MEASURE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GC_RECEIPT_NUM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GC_ORDER_DATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GC_PRICE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GC_DEBIT_NUM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GC_Credit_Account = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GC_SelectItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckSelect = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.GC_SetCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GC_EXP_DATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.remainsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.remainsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.Location = new System.Drawing.Point(952, 526);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(143, 24);
            this.okBtn.TabIndex = 559;
            this.okBtn.Text = "&Добавить";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.Location = new System.Drawing.Point(1101, 526);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(143, 24);
            this.cancelBtn.TabIndex = 560;
            this.cancelBtn.Text = "&Отмена";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // viewSelectDateBtn
            // 
            this.viewSelectDateBtn.Location = new System.Drawing.Point(389, 9);
            this.viewSelectDateBtn.Name = "viewSelectDateBtn";
            this.viewSelectDateBtn.Size = new System.Drawing.Size(75, 22);
            this.viewSelectDateBtn.TabIndex = 574;
            this.viewSelectDateBtn.Text = "Показать";
            this.viewSelectDateBtn.UseVisualStyleBackColor = true;
            this.viewSelectDateBtn.Click += new System.EventHandler(this.viewSelectDateBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(189, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 577;
            this.label3.Text = "по";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 575;
            this.label2.Text = "с";
            // 
            // expEndDateDTP
            // 
            this.expEndDateDTP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.expEndDateDTP.Location = new System.Drawing.Point(212, 11);
            this.expEndDateDTP.Name = "expEndDateDTP";
            this.expEndDateDTP.Size = new System.Drawing.Size(160, 20);
            this.expEndDateDTP.TabIndex = 576;
            this.expEndDateDTP.Value = new System.DateTime(2014, 8, 4, 0, 0, 0, 0);
            // 
            // expStartDateDTP
            // 
            this.expStartDateDTP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.expStartDateDTP.Location = new System.Drawing.Point(23, 10);
            this.expStartDateDTP.Name = "expStartDateDTP";
            this.expStartDateDTP.Size = new System.Drawing.Size(160, 20);
            this.expStartDateDTP.TabIndex = 575;
            this.expStartDateDTP.Value = new System.DateTime(2014, 8, 4, 0, 0, 0, 0);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.viewSelectDateBtn);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.expEndDateDTP);
            this.groupBox1.Controls.Add(this.expStartDateDTP);
            this.groupBox1.Location = new System.Drawing.Point(127, -2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 34);
            this.groupBox1.TabIndex = 575;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 578;
            this.label1.Text = "Списания за период:";
            // 
            // remainsGrid
            // 
            this.remainsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.remainsGrid.Location = new System.Drawing.Point(12, 38);
            this.remainsGrid.MainView = this.remainsView;
            this.remainsGrid.Name = "remainsGrid";
            this.remainsGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckSelect});
            this.remainsGrid.Size = new System.Drawing.Size(1232, 482);
            this.remainsGrid.TabIndex = 579;
            this.remainsGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.remainsView});
            // 
            // remainsView
            // 
            this.remainsView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.GC_NOMENCLATURE,
            this.GC_NAME,
            this.GC_MEASURE,
            this.GC_RECEIPT_NUM,
            this.GC_ORDER_DATE,
            this.GC_PRICE,
            this.GC_DEBIT_NUM,
            this.GC_Credit_Account,
            this.GC_SelectItem,
            this.GC_SetCol,
            this.GC_EXP_DATE});
            this.remainsView.GridControl = this.remainsGrid;
            this.remainsView.Name = "remainsView";
            this.remainsView.OptionsView.ShowAutoFilterRow = true;
            this.remainsView.OptionsView.ShowFooter = true;
            this.remainsView.OptionsView.ShowGroupPanel = false;
            // 
            // GC_NOMENCLATURE
            // 
            this.GC_NOMENCLATURE.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.GC_NOMENCLATURE.AppearanceHeader.Options.UseFont = true;
            this.GC_NOMENCLATURE.Caption = "Номенкл.номер";
            this.GC_NOMENCLATURE.FieldName = "NOMENCLATURE";
            this.GC_NOMENCLATURE.Name = "GC_NOMENCLATURE";
            this.GC_NOMENCLATURE.OptionsColumn.ReadOnly = true;
            this.GC_NOMENCLATURE.Visible = true;
            this.GC_NOMENCLATURE.VisibleIndex = 0;
            this.GC_NOMENCLATURE.Width = 101;
            // 
            // GC_NAME
            // 
            this.GC_NAME.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.GC_NAME.AppearanceHeader.Options.UseFont = true;
            this.GC_NAME.Caption = "Наименование";
            this.GC_NAME.FieldName = "NAME";
            this.GC_NAME.Name = "GC_NAME";
            this.GC_NAME.OptionsColumn.ReadOnly = true;
            this.GC_NAME.Visible = true;
            this.GC_NAME.VisibleIndex = 1;
            this.GC_NAME.Width = 285;
            // 
            // GC_MEASURE
            // 
            this.GC_MEASURE.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.GC_MEASURE.AppearanceHeader.Options.UseFont = true;
            this.GC_MEASURE.Caption = "Ед.изм.";
            this.GC_MEASURE.FieldName = "MEASURE";
            this.GC_MEASURE.Name = "GC_MEASURE";
            this.GC_MEASURE.OptionsColumn.ReadOnly = true;
            this.GC_MEASURE.Visible = true;
            this.GC_MEASURE.VisibleIndex = 2;
            this.GC_MEASURE.Width = 57;
            // 
            // GC_RECEIPT_NUM
            // 
            this.GC_RECEIPT_NUM.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.GC_RECEIPT_NUM.AppearanceHeader.Options.UseFont = true;
            this.GC_RECEIPT_NUM.Caption = "Ном.прихода";
            this.GC_RECEIPT_NUM.FieldName = "RECEIPT_NUM";
            this.GC_RECEIPT_NUM.Name = "GC_RECEIPT_NUM";
            this.GC_RECEIPT_NUM.OptionsColumn.AllowEdit = false;
            this.GC_RECEIPT_NUM.OptionsColumn.AllowFocus = false;
            this.GC_RECEIPT_NUM.OptionsColumn.ReadOnly = true;
            this.GC_RECEIPT_NUM.Visible = true;
            this.GC_RECEIPT_NUM.VisibleIndex = 3;
            this.GC_RECEIPT_NUM.Width = 88;
            // 
            // GC_ORDER_DATE
            // 
            this.GC_ORDER_DATE.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.GC_ORDER_DATE.AppearanceHeader.Options.UseFont = true;
            this.GC_ORDER_DATE.Caption = "Дата прихода";
            this.GC_ORDER_DATE.FieldName = "ORDER_DATE";
            this.GC_ORDER_DATE.Name = "GC_ORDER_DATE";
            this.GC_ORDER_DATE.OptionsColumn.AllowEdit = false;
            this.GC_ORDER_DATE.OptionsColumn.AllowFocus = false;
            this.GC_ORDER_DATE.OptionsColumn.ReadOnly = true;
            this.GC_ORDER_DATE.Visible = true;
            this.GC_ORDER_DATE.VisibleIndex = 4;
            this.GC_ORDER_DATE.Width = 100;
            // 
            // GC_PRICE
            // 
            this.GC_PRICE.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.GC_PRICE.AppearanceHeader.Options.UseFont = true;
            this.GC_PRICE.Caption = "Сумма списания";
            this.GC_PRICE.DisplayFormat.FormatString = "### ### ##0.00";
            this.GC_PRICE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.GC_PRICE.FieldName = "PRICE";
            this.GC_PRICE.Name = "GC_PRICE";
            this.GC_PRICE.OptionsColumn.AllowEdit = false;
            this.GC_PRICE.OptionsColumn.AllowFocus = false;
            this.GC_PRICE.OptionsColumn.ReadOnly = true;
            this.GC_PRICE.Visible = true;
            this.GC_PRICE.VisibleIndex = 7;
            this.GC_PRICE.Width = 100;
            // 
            // GC_DEBIT_NUM
            // 
            this.GC_DEBIT_NUM.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.GC_DEBIT_NUM.AppearanceHeader.Options.UseFont = true;
            this.GC_DEBIT_NUM.Caption = "Дебет счет";
            this.GC_DEBIT_NUM.FieldName = "DEBIT_NUM";
            this.GC_DEBIT_NUM.Name = "GC_DEBIT_NUM";
            this.GC_DEBIT_NUM.OptionsColumn.AllowEdit = false;
            this.GC_DEBIT_NUM.OptionsColumn.AllowFocus = false;
            this.GC_DEBIT_NUM.OptionsColumn.ReadOnly = true;
            this.GC_DEBIT_NUM.Visible = true;
            this.GC_DEBIT_NUM.VisibleIndex = 5;
            this.GC_DEBIT_NUM.Width = 95;
            // 
            // GC_Credit_Account
            // 
            this.GC_Credit_Account.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.GC_Credit_Account.AppearanceHeader.Options.UseFont = true;
            this.GC_Credit_Account.Caption = "Кредит счет";
            this.GC_Credit_Account.FieldName = "CREDIT_ACCOUNT";
            this.GC_Credit_Account.Name = "GC_Credit_Account";
            this.GC_Credit_Account.OptionsColumn.AllowEdit = false;
            this.GC_Credit_Account.OptionsColumn.AllowFocus = false;
            this.GC_Credit_Account.OptionsColumn.ReadOnly = true;
            this.GC_Credit_Account.Visible = true;
            this.GC_Credit_Account.VisibleIndex = 8;
            this.GC_Credit_Account.Width = 105;
            // 
            // GC_SelectItem
            // 
            this.GC_SelectItem.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.GC_SelectItem.AppearanceHeader.Options.UseFont = true;
            this.GC_SelectItem.Caption = "Выбрать";
            this.GC_SelectItem.ColumnEdit = this.repositoryItemCheckSelect;
            this.GC_SelectItem.FieldName = "ISSELECT";
            this.GC_SelectItem.Name = "GC_SelectItem";
            this.GC_SelectItem.Visible = true;
            this.GC_SelectItem.VisibleIndex = 9;
            this.GC_SelectItem.Width = 61;
            // 
            // repositoryItemCheckSelect
            // 
            this.repositoryItemCheckSelect.AutoHeight = false;
            this.repositoryItemCheckSelect.DisplayValueChecked = "1";
            this.repositoryItemCheckSelect.DisplayValueUnchecked = "0";
            this.repositoryItemCheckSelect.Name = "repositoryItemCheckSelect";
            this.repositoryItemCheckSelect.ValueChecked = "1";
            this.repositoryItemCheckSelect.ValueGrayed = "";
            this.repositoryItemCheckSelect.ValueUnchecked = "0";
            // 
            // GC_SetCol
            // 
            this.GC_SetCol.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.GC_SetCol.AppearanceHeader.Options.UseFont = true;
            this.GC_SetCol.Caption = "Количество";
            this.GC_SetCol.FieldName = "SETKOL";
            this.GC_SetCol.Name = "GC_SetCol";
            this.GC_SetCol.OptionsColumn.AllowEdit = false;
            this.GC_SetCol.OptionsColumn.AllowFocus = false;
            this.GC_SetCol.OptionsColumn.ReadOnly = true;
            this.GC_SetCol.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SETKOL", "{0:### ### ##0.0#}")});
            this.GC_SetCol.Visible = true;
            this.GC_SetCol.VisibleIndex = 10;
            this.GC_SetCol.Width = 78;
            // 
            // GC_EXP_DATE
            // 
            this.GC_EXP_DATE.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.GC_EXP_DATE.AppearanceHeader.Options.UseFont = true;
            this.GC_EXP_DATE.Caption = "Дата списания";
            this.GC_EXP_DATE.FieldName = "EXP_DATE";
            this.GC_EXP_DATE.Name = "GC_EXP_DATE";
            this.GC_EXP_DATE.OptionsColumn.AllowEdit = false;
            this.GC_EXP_DATE.OptionsColumn.AllowFocus = false;
            this.GC_EXP_DATE.OptionsColumn.ReadOnly = true;
            this.GC_EXP_DATE.Visible = true;
            this.GC_EXP_DATE.VisibleIndex = 6;
            this.GC_EXP_DATE.Width = 95;
            // 
            // invoiceRequirementEditMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 558);
            this.Controls.Add(this.remainsGrid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.cancelBtn);
            this.Name = "invoiceRequirementEditMaterial";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление материалов";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.remainsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.remainsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckSelect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button viewSelectDateBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker expEndDateDTP;
        private System.Windows.Forms.DateTimePicker expStartDateDTP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl remainsGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView remainsView;
        private DevExpress.XtraGrid.Columns.GridColumn GC_NOMENCLATURE;
        private DevExpress.XtraGrid.Columns.GridColumn GC_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn GC_MEASURE;
        private DevExpress.XtraGrid.Columns.GridColumn GC_RECEIPT_NUM;
        private DevExpress.XtraGrid.Columns.GridColumn GC_ORDER_DATE;
        private DevExpress.XtraGrid.Columns.GridColumn GC_PRICE;
        private DevExpress.XtraGrid.Columns.GridColumn GC_DEBIT_NUM;
        private DevExpress.XtraGrid.Columns.GridColumn GC_Credit_Account;
        private DevExpress.XtraGrid.Columns.GridColumn GC_SelectItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckSelect;
        private DevExpress.XtraGrid.Columns.GridColumn GC_SetCol;
        private DevExpress.XtraGrid.Columns.GridColumn GC_EXP_DATE;
	}
}