namespace Accounting
{
    partial class expendituresEditFm
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
            this.deleteBtn = new System.Windows.Forms.Button();
            this.expendGrid = new DevExpress.XtraGrid.GridControl();
            this.expendView = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridColumn10 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.reportBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.closeMonthChBox = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.monthEndCBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.yearEndCBox = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.monthCBox = new System.Windows.Forms.ComboBox();
            this.yearCBox = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.editBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.label7 = new System.Windows.Forms.Label();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.expendGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expendView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // deleteBtn
            // 
            this.deleteBtn.Image = global::Accounting.Properties.Resources.Edit_Delete;
            this.deleteBtn.Location = new System.Drawing.Point(130, 93);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(112, 24);
            this.deleteBtn.TabIndex = 3;
            this.deleteBtn.Text = "Видалити";
            this.deleteBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.deleteBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // expendGrid
            // 
            this.expendGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.expendGrid.Location = new System.Drawing.Point(12, 123);
            this.expendGrid.MainView = this.expendView;
            this.expendGrid.Name = "expendGrid";
            this.expendGrid.Size = new System.Drawing.Size(1413, 526);
            this.expendGrid.TabIndex = 0;
            this.expendGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.expendView});
            // 
            // expendView
            // 
            this.expendView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.expendView.Appearance.FooterPanel.Options.UseFont = true;
            this.expendView.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.expendView.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.expendView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand2});
            this.expendView.ColumnPanelRowHeight = 50;
            this.expendView.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn12,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn9,
            this.gridColumn15,
            this.gridColumn17,
            this.gridColumn8,
            this.gridColumn10,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn11,
            this.gridColumn13,
            this.gridColumn16});
            this.expendView.GridControl = this.expendGrid;
            this.expendView.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QUANTITY", this.gridColumn6, "")});
            this.expendView.Name = "expendView";
            this.expendView.OptionsView.ShowAutoFilterRow = true;
            this.expendView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.expendView.OptionsView.ShowFooter = true;
            this.expendView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.expendView_KeyUp);
            this.expendView.DoubleClick += new System.EventHandler(this.expendView_DoubleClick);
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand1.AppearanceHeader.Options.UseFont = true;
            this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand1.Caption = "Надходження";
            this.gridBand1.Columns.Add(this.gridColumn1);
            this.gridBand1.Columns.Add(this.gridColumn2);
            this.gridBand1.Columns.Add(this.gridColumn12);
            this.gridBand1.Columns.Add(this.gridColumn3);
            this.gridBand1.Columns.Add(this.gridColumn4);
            this.gridBand1.Columns.Add(this.gridColumn5);
            this.gridBand1.Columns.Add(this.gridColumn9);
            this.gridBand1.Columns.Add(this.gridColumn15);
            this.gridBand1.Columns.Add(this.gridColumn17);
            this.gridBand1.Columns.Add(this.gridColumn8);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 790;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.BackColor = System.Drawing.Color.Snow;
            this.gridColumn1.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn1.Caption = "Дата";
            this.gridColumn1.FieldName = "ORDER_DATE";
            this.gridColumn1.MinWidth = 72;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ORDER_DATE", "Всього:   {0}")});
            this.gridColumn1.Visible = true;
            this.gridColumn1.Width = 72;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.BackColor = System.Drawing.Color.Snow;
            this.gridColumn2.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn2.Caption = "Номер";
            this.gridColumn2.FieldName = "RECEIPT_NUM";
            this.gridColumn2.MinWidth = 70;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.Width = 70;
            // 
            // gridColumn12
            // 
            this.gridColumn12.AppearanceCell.BackColor = System.Drawing.Color.Snow;
            this.gridColumn12.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn12.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn12.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn12.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn12.Caption = "Дебет рахунку";
            this.gridColumn12.FieldName = "DEBIT_ACCOUNT_NUM";
            this.gridColumn12.MinWidth = 58;
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            this.gridColumn12.OptionsColumn.ReadOnly = true;
            this.gridColumn12.Visible = true;
            this.gridColumn12.Width = 58;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.BackColor = System.Drawing.Color.Snow;
            this.gridColumn3.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn3.Caption = "Номенклатурний номер";
            this.gridColumn3.FieldName = "NOMENCLATURE";
            this.gridColumn3.MinWidth = 110;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.Width = 110;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.BackColor = System.Drawing.Color.Snow;
            this.gridColumn4.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Найменування";
            this.gridColumn4.FieldName = "NAME";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn4.Visible = true;
            this.gridColumn4.Width = 180;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.BackColor = System.Drawing.Color.Snow;
            this.gridColumn5.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn5.Caption = "Од. вим.";
            this.gridColumn5.FieldName = "MEASURE";
            this.gridColumn5.MinWidth = 50;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.Width = 50;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.BackColor = System.Drawing.Color.Snow;
            this.gridColumn9.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn9.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn9.Caption = "Бал. рах.";
            this.gridColumn9.FieldName = "BALANCE_ACCOUNT_NUM";
            this.gridColumn9.MinWidth = 50;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.OptionsColumn.ReadOnly = true;
            this.gridColumn9.Visible = true;
            this.gridColumn9.Width = 50;
            // 
            // gridColumn15
            // 
            this.gridColumn15.AppearanceCell.BackColor = System.Drawing.Color.Snow;
            this.gridColumn15.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn15.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn15.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn15.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn15.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn15.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn15.Caption = "Кіль-сть";
            this.gridColumn15.FieldName = "RECEIPT_QUANTITY";
            this.gridColumn15.MinWidth = 50;
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsColumn.AllowFocus = false;
            this.gridColumn15.OptionsColumn.ReadOnly = true;
            this.gridColumn15.Visible = true;
            this.gridColumn15.Width = 50;
            // 
            // gridColumn17
            // 
            this.gridColumn17.AppearanceCell.BackColor = System.Drawing.Color.Snow;
            this.gridColumn17.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn17.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn17.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn17.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn17.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn17.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn17.Caption = "Сума";
            this.gridColumn17.DisplayFormat.FormatString = "## ### ##0.00";
            this.gridColumn17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn17.FieldName = "TOTAL_PRICE";
            this.gridColumn17.MinWidth = 75;
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.OptionsColumn.AllowFocus = false;
            this.gridColumn17.OptionsColumn.ReadOnly = true;
            this.gridColumn17.Visible = true;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.BackColor = System.Drawing.Color.Snow;
            this.gridColumn8.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn8.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn8.Caption = "Ціна за од.";
            this.gridColumn8.DisplayFormat.FormatString = "## ### ##0.00";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn8.FieldName = "UNIT_PRICE";
            this.gridColumn8.MinWidth = 75;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            this.gridColumn8.Visible = true;
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand2.AppearanceHeader.Options.UseFont = true;
            this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand2.Caption = "Списання";
            this.gridBand2.Columns.Add(this.gridColumn10);
            this.gridBand2.Columns.Add(this.gridColumn6);
            this.gridBand2.Columns.Add(this.gridColumn7);
            this.gridBand2.Columns.Add(this.gridColumn11);
            this.gridBand2.Columns.Add(this.gridColumn13);
            this.gridBand2.Columns.Add(this.gridColumn16);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 1;
            this.gridBand2.Width = 400;
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceCell.BackColor = System.Drawing.Color.Ivory;
            this.gridColumn10.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn10.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn10.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn10.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn10.Caption = "Дата";
            this.gridColumn10.FieldName = "EXP_DATE";
            this.gridColumn10.MinWidth = 72;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.OptionsColumn.ReadOnly = true;
            this.gridColumn10.Visible = true;
            this.gridColumn10.Width = 72;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.BackColor = System.Drawing.Color.Ivory;
            this.gridColumn6.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn6.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn6.Caption = "Коль-сть";
            this.gridColumn6.FieldName = "QUANTITY";
            this.gridColumn6.MinWidth = 75;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QUANTITY", "{0:### ### ##0.#####}")});
            this.gridColumn6.Visible = true;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.BackColor = System.Drawing.Color.Ivory;
            this.gridColumn7.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn7.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn7.Caption = "Сума";
            this.gridColumn7.DisplayFormat.FormatString = "## ### ##0.00";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn7.FieldName = "EXP_PRICE";
            this.gridColumn7.MinWidth = 75;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "EXP_PRICE", "{0:### ### ##0.00}")});
            this.gridColumn7.Visible = true;
            // 
            // gridColumn11
            // 
            this.gridColumn11.AppearanceCell.BackColor = System.Drawing.Color.Ivory;
            this.gridColumn11.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn11.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn11.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn11.Caption = "Проект";
            this.gridColumn11.FieldName = "PROJECT_NUM";
            this.gridColumn11.MinWidth = 50;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.OptionsColumn.ReadOnly = true;
            this.gridColumn11.Visible = true;
            this.gridColumn11.Width = 50;
            // 
            // gridColumn13
            // 
            this.gridColumn13.AppearanceCell.BackColor = System.Drawing.Color.Ivory;
            this.gridColumn13.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn13.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn13.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn13.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn13.Caption = "Кредит рах.";
            this.gridColumn13.FieldName = "CREDIT_ACCOUNT_NUM";
            this.gridColumn13.MinWidth = 63;
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.OptionsColumn.ReadOnly = true;
            this.gridColumn13.Visible = true;
            this.gridColumn13.Width = 63;
            // 
            // gridColumn16
            // 
            this.gridColumn16.AppearanceCell.BackColor = System.Drawing.Color.Ivory;
            this.gridColumn16.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn16.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn16.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn16.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn16.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn16.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn16.Caption = "Кіль-сть залишку";
            this.gridColumn16.DisplayFormat.FormatString = "### ### ##0.##";
            this.gridColumn16.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn16.FieldName = "REMAINS";
            this.gridColumn16.MinWidth = 65;
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.OptionsColumn.AllowFocus = false;
            this.gridColumn16.OptionsColumn.ReadOnly = true;
            this.gridColumn16.Visible = true;
            this.gridColumn16.Width = 65;
            // 
            // reportBtn
            // 
            this.reportBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.reportBtn.Image = global::Accounting.Properties.Resources.PrintFixedAssetsCard;
            this.reportBtn.Location = new System.Drawing.Point(1302, 87);
            this.reportBtn.Name = "reportBtn";
            this.reportBtn.Size = new System.Drawing.Size(123, 24);
            this.reportBtn.TabIndex = 40;
            this.reportBtn.Text = "Сформувати звіт";
            this.reportBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.reportBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.reportBtn.UseVisualStyleBackColor = true;
            this.reportBtn.Click += new System.EventHandler(this.reportBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.closeMonthChBox);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.monthEndCBox);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.yearEndCBox);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.monthCBox);
            this.groupBox2.Controls.Add(this.yearCBox);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1413, 69);
            this.groupBox2.TabIndex = 149;
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(6, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 137;
            this.label8.Text = "Період з:";
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(616, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 141;
            this.label9.Text = "Місяць";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(393, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 13);
            this.label10.TabIndex = 142;
            this.label10.Text = "Період по:";
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
            "2020",
            "2021",
            "2022",
            "2023"});
            this.yearEndCBox.Location = new System.Drawing.Point(490, 14);
            this.yearEndCBox.Name = "yearEndCBox";
            this.yearEndCBox.Size = new System.Drawing.Size(121, 21);
            this.yearEndCBox.TabIndex = 145;
            this.yearEndCBox.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(463, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(22, 13);
            this.label11.TabIndex = 140;
            this.label11.Text = "Рік";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(69, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(22, 13);
            this.label12.TabIndex = 138;
            this.label12.Text = "Рік";
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
            this.monthCBox.Location = new System.Drawing.Point(265, 14);
            this.monthCBox.Name = "monthCBox";
            this.monthCBox.Size = new System.Drawing.Size(121, 21);
            this.monthCBox.TabIndex = 144;
            this.monthCBox.TabStop = false;
            // 
            // yearCBox
            // 
            this.yearCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearCBox.FormattingEnabled = true;
            this.yearCBox.Items.AddRange(new object[] {
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
            "2020",
            "2021",
            "2022",
            "2023"});
            this.yearCBox.Location = new System.Drawing.Point(95, 14);
            this.yearCBox.Name = "yearCBox";
            this.yearCBox.Size = new System.Drawing.Size(121, 21);
            this.yearCBox.TabIndex = 143;
            this.yearCBox.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(221, 17);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 13);
            this.label13.TabIndex = 139;
            this.label13.Text = "Місяць";
            // 
            // editBtn
            // 
            this.editBtn.Image = global::Accounting.Properties.Resources.Edit_Update;
            this.editBtn.Location = new System.Drawing.Point(12, 93);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(112, 24);
            this.editBtn.TabIndex = 150;
            this.editBtn.Text = "Редагувати";
            this.editBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.editBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Linen;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.labelControl1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.labelControl2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 655);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1413, 35);
            this.groupBox1.TabIndex = 155;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(268, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 165;
            this.label1.Text = "- редагувати запис";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(128, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(137, 13);
            this.labelControl1.TabIndex = 164;
            this.labelControl1.Text = "Подвійний клік мишкою";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 163;
            this.label7.Text = "- видалити запис";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Location = new System.Drawing.Point(6, 16);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(18, 13);
            this.labelControl2.TabIndex = 161;
            this.labelControl2.Text = "Del";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(260, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 159;
            // 
            // expendituresEditFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1434, 702);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.reportBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.expendGrid);
            this.Name = "expendituresEditFm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Списання за період";
            ((System.ComponentModel.ISupportInitialize)(this.expendGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expendView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button deleteBtn;
        private DevExpress.XtraGrid.GridControl expendGrid;
        private System.Windows.Forms.Button reportBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox closeMonthChBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox monthEndCBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox yearEndCBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox monthCBox;
        private System.Windows.Forms.ComboBox yearCBox;
        private System.Windows.Forms.Label label13;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView expendView;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn12;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn4;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn5;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn9;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn15;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn17;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn8;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn10;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn6;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn7;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn11;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn13;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn16;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}