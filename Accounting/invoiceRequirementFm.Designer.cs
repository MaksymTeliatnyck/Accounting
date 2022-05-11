namespace Accounting
{
	partial class invoiceRequirementFm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(invoiceRequirementFm));
            this.requirementGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.requirementOrdersGrid = new DevExpress.XtraGrid.GridControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.printRequirementBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.monthEndCBox = new System.Windows.Forms.ComboBox();
            this.monthCBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.yearCBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.yearEndCBox = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.requirementMaterialGrid = new DevExpress.XtraGrid.GridControl();
            this.requirementMaterialView = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridColumn11 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridColumn4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridColumn10 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColInventoryNumber = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColDescription = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.invoiceRequirementMaterialsFmBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.requirementGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requirementOrdersGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.requirementMaterialGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requirementMaterialView)).BeginInit();
            this.SuspendLayout();
            // 
            // requirementGridView
            // 
            this.requirementGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn9});
            this.requirementGridView.GridControl = this.requirementOrdersGrid;
            this.requirementGridView.Name = "requirementGridView";
            this.requirementGridView.OptionsBehavior.Editable = false;
            this.requirementGridView.OptionsView.ShowAutoFilterRow = true;
            this.requirementGridView.OptionsView.ShowGroupPanel = false;
            this.requirementGridView.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.requirementGridView_RowClick);
            this.requirementGridView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.requirementGridView_FocusedRowChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.Caption = "Дата";
            this.gridColumn1.FieldName = "Date";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 383;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.Caption = "Відповідальна особа";
            this.gridColumn2.FieldName = "RESPONSIBLE_PERSON";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 388;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn9.AppearanceHeader.Options.UseFont = true;
            this.gridColumn9.Caption = "№";
            this.gridColumn9.FieldName = "Number";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 0;
            this.gridColumn9.Width = 125;
            // 
            // requirementOrdersGrid
            // 
            this.requirementOrdersGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.requirementOrdersGrid.Location = new System.Drawing.Point(6, 51);
            this.requirementOrdersGrid.MainView = this.requirementGridView;
            this.requirementOrdersGrid.Name = "requirementOrdersGrid";
            this.requirementOrdersGrid.Size = new System.Drawing.Size(1157, 275);
            this.requirementOrdersGrid.TabIndex = 0;
            this.requirementOrdersGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.requirementGridView});
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.printRequirementBtn);
            this.groupBox1.Controls.Add(this.addBtn);
            this.groupBox1.Controls.Add(this.editBtn);
            this.groupBox1.Controls.Add(this.deleteBtn);
            this.groupBox1.Controls.Add(this.requirementOrdersGrid);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1169, 332);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Вимоги";
            // 
            // printRequirementBtn
            // 
            this.printRequirementBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.printRequirementBtn.Enabled = false;
            this.printRequirementBtn.Image = global::Accounting.Properties.Resources.PrintFixedAssetsCard;
            this.printRequirementBtn.Location = new System.Drawing.Point(1056, 18);
            this.printRequirementBtn.Name = "printRequirementBtn";
            this.printRequirementBtn.Size = new System.Drawing.Size(107, 23);
            this.printRequirementBtn.TabIndex = 104;
            this.printRequirementBtn.Text = "Друк";
            this.printRequirementBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.printRequirementBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.printRequirementBtn.UseVisualStyleBackColor = true;
            this.printRequirementBtn.Click += new System.EventHandler(this.printRequirementBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addBtn.Image = global::Accounting.Properties.Resources.Edit_Add;
            this.addBtn.Location = new System.Drawing.Point(6, 19);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(112, 25);
            this.addBtn.TabIndex = 101;
            this.addBtn.Text = "&Додати";
            this.addBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editBtn.Enabled = false;
            this.editBtn.Image = global::Accounting.Properties.Resources.Edit_Update;
            this.editBtn.Location = new System.Drawing.Point(118, 19);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(113, 25);
            this.editBtn.TabIndex = 102;
            this.editBtn.Text = "&Редагувати";
            this.editBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.editBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteBtn.Enabled = false;
            this.deleteBtn.Image = global::Accounting.Properties.Resources.Edit_Delete;
            this.deleteBtn.Location = new System.Drawing.Point(231, 19);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(112, 25);
            this.deleteBtn.TabIndex = 103;
            this.deleteBtn.Text = "&Видалити";
            this.deleteBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.deleteBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 101;
            this.label6.Text = "Період з:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(397, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 102;
            this.label5.Text = "Період по:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(224, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 103;
            this.label2.Text = "Місяць";
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
            this.monthEndCBox.Location = new System.Drawing.Point(670, 12);
            this.monthEndCBox.Name = "monthEndCBox";
            this.monthEndCBox.Size = new System.Drawing.Size(121, 21);
            this.monthEndCBox.TabIndex = 104;
            this.monthEndCBox.TabStop = false;
            // 
            // monthCBox
            // 
            this.monthCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.monthCBox.FormattingEnabled = true;
            this.monthCBox.Items.AddRange(new object[] {
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
            this.monthCBox.Location = new System.Drawing.Point(270, 12);
            this.monthCBox.Name = "monthCBox";
            this.monthCBox.Size = new System.Drawing.Size(121, 21);
            this.monthCBox.TabIndex = 105;
            this.monthCBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 106;
            this.label1.Text = "Рік";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(624, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 107;
            this.label4.Text = "Місяць";
            // 
            // yearCBox
            // 
            this.yearCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearCBox.FormattingEnabled = true;
            this.yearCBox.Items.AddRange(new object[] {
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
            this.yearCBox.Location = new System.Drawing.Point(97, 12);
            this.yearCBox.Name = "yearCBox";
            this.yearCBox.Size = new System.Drawing.Size(121, 21);
            this.yearCBox.TabIndex = 108;
            this.yearCBox.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(466, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 109;
            this.label3.Text = "Рік";
            // 
            // yearEndCBox
            // 
            this.yearEndCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearEndCBox.FormattingEnabled = true;
            this.yearEndCBox.Items.AddRange(new object[] {
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
            this.yearEndCBox.Location = new System.Drawing.Point(497, 12);
            this.yearEndCBox.Name = "yearEndCBox";
            this.yearEndCBox.Size = new System.Drawing.Size(121, 21);
            this.yearEndCBox.TabIndex = 110;
            this.yearEndCBox.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(6, 39);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(1179, 676);
            this.splitContainer1.SplitterDistance = 338;
            this.splitContainer1.TabIndex = 111;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.requirementMaterialGrid);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1166, 328);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Матеріали";
            // 
            // requirementMaterialGrid
            // 
            this.requirementMaterialGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.requirementMaterialGrid.Location = new System.Drawing.Point(6, 13);
            this.requirementMaterialGrid.MainView = this.requirementMaterialView;
            this.requirementMaterialGrid.Name = "requirementMaterialGrid";
            this.requirementMaterialGrid.Size = new System.Drawing.Size(1160, 309);
            this.requirementMaterialGrid.TabIndex = 1;
            this.requirementMaterialGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.requirementMaterialView});
            // 
            // requirementMaterialView
            // 
            this.requirementMaterialView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand2,
            this.gridBand3});
            this.requirementMaterialView.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.bandedGridColumn1,
            this.gridColInventoryNumber,
            this.gridColDescription});
            this.requirementMaterialView.GridControl = this.requirementMaterialGrid;
            this.requirementMaterialView.Name = "requirementMaterialView";
            this.requirementMaterialView.OptionsBehavior.Editable = false;
            this.requirementMaterialView.OptionsView.ShowAutoFilterRow = true;
            this.requirementMaterialView.OptionsView.ShowFooter = true;
            this.requirementMaterialView.OptionsView.ShowGroupPanel = false;
            // 
            // gridBand1
            // 
            this.gridBand1.Columns.Add(this.gridColumn11);
            this.gridBand1.Columns.Add(this.gridColumn7);
            this.gridBand1.Columns.Add(this.bandedGridColumn1);
            this.gridBand1.Columns.Add(this.gridColumn3);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.Width = 405;
            // 
            // gridColumn11
            // 
            this.gridColumn11.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn11.AppearanceHeader.Options.UseFont = true;
            this.gridColumn11.Caption = "Номенкл.номер";
            this.gridColumn11.FieldName = "NOMENCLATURE";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.Width = 81;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn7.AppearanceHeader.Options.UseFont = true;
            this.gridColumn7.Caption = "Бал. рах.";
            this.gridColumn7.FieldName = "NUM";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.Width = 51;
            // 
            // bandedGridColumn1
            // 
            this.bandedGridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bandedGridColumn1.AppearanceHeader.Options.UseFont = true;
            this.bandedGridColumn1.Caption = "№ надходження";
            this.bandedGridColumn1.FieldName = "RECEIPT_NUM";
            this.bandedGridColumn1.Name = "bandedGridColumn1";
            this.bandedGridColumn1.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn1.OptionsColumn.AllowFocus = false;
            this.bandedGridColumn1.Visible = true;
            this.bandedGridColumn1.Width = 54;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.Caption = "Найменування";
            this.gridColumn3.FieldName = "NAME";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.Width = 219;
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand2.AppearanceHeader.Options.UseFont = true;
            this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand2.Caption = "Кількість";
            this.gridBand2.Columns.Add(this.gridColumn4);
            this.gridBand2.Columns.Add(this.gridColumn12);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.Width = 164;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Затребувано";
            this.gridColumn4.FieldName = "Required_Quantity";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Required_Quantity", "{0:### ##0.0#}")});
            this.gridColumn4.Visible = true;
            this.gridColumn4.Width = 89;
            // 
            // gridColumn12
            // 
            this.gridColumn12.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn12.AppearanceHeader.Options.UseFont = true;
            this.gridColumn12.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn12.Caption = "Відпущено";
            this.gridColumn12.FieldName = "EXPEN_QUANTITY";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            this.gridColumn12.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "EXPEN_QUANTITY", "{0:### ##0.0#}")});
            this.gridColumn12.Visible = true;
            // 
            // gridBand3
            // 
            this.gridBand3.Columns.Add(this.gridColumn10);
            this.gridBand3.Columns.Add(this.gridColumn5);
            this.gridBand3.Columns.Add(this.gridColumn6);
            this.gridBand3.Columns.Add(this.gridColumn8);
            this.gridBand3.Columns.Add(this.gridColInventoryNumber);
            this.gridBand3.Columns.Add(this.gridColDescription);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.Width = 552;
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn10.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn10.AppearanceHeader.Options.UseFont = true;
            this.gridColumn10.Caption = "Од.вим.";
            this.gridColumn10.FieldName = "MEASURE";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.Width = 50;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn5.AppearanceHeader.Options.UseFont = true;
            this.gridColumn5.Caption = "Ціна";
            this.gridColumn5.DisplayFormat.FormatString = "### ### ##0.00";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn5.FieldName = "UNIT_PRICE";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.Width = 90;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn6.AppearanceHeader.Options.UseFont = true;
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
            this.gridColumn6.Width = 91;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn8.AppearanceHeader.Options.UseFont = true;
            this.gridColumn8.Caption = "Кредит рах.";
            this.gridColumn8.FieldName = "EXPEN_ACCOUNT";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.Width = 80;
            // 
            // gridColInventoryNumber
            // 
            this.gridColInventoryNumber.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColInventoryNumber.AppearanceHeader.Options.UseFont = true;
            this.gridColInventoryNumber.Caption = "Картка ОЗ";
            this.gridColInventoryNumber.FieldName = "InventoryNumber";
            this.gridColInventoryNumber.Name = "gridColInventoryNumber";
            this.gridColInventoryNumber.OptionsColumn.AllowEdit = false;
            this.gridColInventoryNumber.OptionsColumn.AllowFocus = false;
            this.gridColInventoryNumber.Visible = true;
            this.gridColInventoryNumber.Width = 81;
            // 
            // gridColDescription
            // 
            this.gridColDescription.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColDescription.AppearanceHeader.Options.UseFont = true;
            this.gridColDescription.Caption = "Додаткова інформація";
            this.gridColDescription.FieldName = "Description";
            this.gridColDescription.Name = "gridColDescription";
            this.gridColDescription.OptionsColumn.AllowEdit = false;
            this.gridColDescription.OptionsColumn.AllowFocus = false;
            this.gridColDescription.Visible = true;
            this.gridColDescription.Width = 160;
            // 
            // invoiceRequirementMaterialsFmBtn
            // 
            this.invoiceRequirementMaterialsFmBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.invoiceRequirementMaterialsFmBtn.Image = global::Accounting.Properties.Resources.PrintFixedAssetsMaterials;
            this.invoiceRequirementMaterialsFmBtn.Location = new System.Drawing.Point(1001, 5);
            this.invoiceRequirementMaterialsFmBtn.Name = "invoiceRequirementMaterialsFmBtn";
            this.invoiceRequirementMaterialsFmBtn.Size = new System.Drawing.Size(184, 28);
            this.invoiceRequirementMaterialsFmBtn.TabIndex = 595;
            this.invoiceRequirementMaterialsFmBtn.Text = "Вимоги та основні засоби";
            this.invoiceRequirementMaterialsFmBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.invoiceRequirementMaterialsFmBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.invoiceRequirementMaterialsFmBtn.UseVisualStyleBackColor = true;
            this.invoiceRequirementMaterialsFmBtn.Click += new System.EventHandler(this.minvoiceRequirementMaterialsFmBtn_Click);
            // 
            // invoiceRequirementFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 719);
            this.Controls.Add(this.invoiceRequirementMaterialsFmBtn);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.monthEndCBox);
            this.Controls.Add(this.monthCBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.yearCBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.yearEndCBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "invoiceRequirementFm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Вимоги";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.invoiceRequirementFm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.requirementGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requirementOrdersGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.requirementMaterialGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requirementMaterialView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraGrid.Views.Grid.GridView requirementGridView;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.GridControl requirementOrdersGrid;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox monthEndCBox;
		private System.Windows.Forms.ComboBox monthCBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox yearCBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox yearEndCBox;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Button addBtn;
		private System.Windows.Forms.Button editBtn;
		private System.Windows.Forms.Button deleteBtn;
		private DevExpress.XtraGrid.GridControl requirementMaterialGrid;
		private System.Windows.Forms.GroupBox groupBox2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
		private System.Windows.Forms.Button printRequirementBtn;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView requirementMaterialView;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn11;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn3;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn4;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn12;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn10;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn5;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn6;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn7;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn8;
		private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn1;
		private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
		private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColInventoryNumber;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColDescription;
        private System.Windows.Forms.Button invoiceRequirementMaterialsFmBtn;

	}
}