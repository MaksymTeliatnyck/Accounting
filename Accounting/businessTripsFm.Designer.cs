namespace Accounting
{
    partial class businessTripsFm
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
            this.addBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.businessTripGrid = new DevExpress.XtraGrid.GridControl();
            this.businessTripView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.docNumberColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.datePaymentColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.vatColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.contractorCodColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.contractorNameColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.accountNumColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.yearBeginCBox = new System.Windows.Forms.ComboBox();
            this.monthBeginCBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.yearEndCBox = new System.Windows.Forms.ComboBox();
            this.monthEndCBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.businessTripGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.businessTripView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // addBtn
            // 
            this.addBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.addBtn.Location = new System.Drawing.Point(6, 19);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(143, 24);
            this.addBtn.TabIndex = 114;
            this.addBtn.Text = "&Добавить";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(155, 19);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(143, 24);
            this.editBtn.TabIndex = 113;
            this.editBtn.Text = "Редактировать";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(304, 19);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(143, 24);
            this.deleteBtn.TabIndex = 111;
            this.deleteBtn.Text = "Удалить";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // businessTripGrid
            // 
            this.businessTripGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.businessTripGrid.Location = new System.Drawing.Point(12, 87);
            this.businessTripGrid.MainView = this.businessTripView;
            this.businessTripGrid.Name = "businessTripGrid";
            this.businessTripGrid.Size = new System.Drawing.Size(788, 354);
            this.businessTripGrid.TabIndex = 133;
            this.businessTripGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.businessTripView});
            // 
            // businessTripView
            // 
            this.businessTripView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.docNumberColumn,
            this.datePaymentColumn,
            this.vatColumn,
            this.contractorCodColumn,
            this.contractorNameColumn,
            this.accountNumColumn});
            this.businessTripView.GridControl = this.businessTripGrid;
            this.businessTripView.Name = "businessTripView";
            this.businessTripView.OptionsView.ShowAutoFilterRow = true;
            this.businessTripView.OptionsView.ShowFooter = true;
            this.businessTripView.OptionsView.ShowGroupPanel = false;
            this.businessTripView.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.businessTripView_RowClick);
            // 
            // docNumberColumn
            // 
            this.docNumberColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.docNumberColumn.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.docNumberColumn.Caption = "Номер документа";
            this.docNumberColumn.FieldName = "Doc_Number";
            this.docNumberColumn.Name = "docNumberColumn";
            this.docNumberColumn.OptionsColumn.AllowEdit = false;
            this.docNumberColumn.OptionsColumn.AllowFocus = false;
            this.docNumberColumn.Visible = true;
            this.docNumberColumn.VisibleIndex = 0;
            // 
            // datePaymentColumn
            // 
            this.datePaymentColumn.Caption = "Дата документа";
            this.datePaymentColumn.FieldName = "Date_Payment";
            this.datePaymentColumn.Name = "datePaymentColumn";
            this.datePaymentColumn.OptionsColumn.AllowEdit = false;
            this.datePaymentColumn.OptionsColumn.AllowFocus = false;
            this.datePaymentColumn.Visible = true;
            this.datePaymentColumn.VisibleIndex = 1;
            // 
            // vatColumn
            // 
            this.vatColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.vatColumn.Caption = "Сумма НДС";
            this.vatColumn.DisplayFormat.FormatString = "### ### ##0.00";
            this.vatColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.vatColumn.FieldName = "VAT";
            this.vatColumn.Name = "vatColumn";
            this.vatColumn.OptionsColumn.AllowEdit = false;
            this.vatColumn.OptionsColumn.AllowFocus = false;
            this.vatColumn.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "VAT", "{0:### ### ##0.00}")});
            this.vatColumn.Visible = true;
            this.vatColumn.VisibleIndex = 2;
            // 
            // contractorCodColumn
            // 
            this.contractorCodColumn.Caption = "Едрпоу";
            this.contractorCodColumn.FieldName = "CONTRACTOR_SRN";
            this.contractorCodColumn.Name = "contractorCodColumn";
            this.contractorCodColumn.OptionsColumn.AllowEdit = false;
            this.contractorCodColumn.OptionsColumn.AllowFocus = false;
            this.contractorCodColumn.Visible = true;
            this.contractorCodColumn.VisibleIndex = 3;
            // 
            // contractorNameColumn
            // 
            this.contractorNameColumn.Caption = "Контрагент";
            this.contractorNameColumn.FieldName = "CONTRACTOR_NAME";
            this.contractorNameColumn.Name = "contractorNameColumn";
            this.contractorNameColumn.OptionsColumn.AllowEdit = false;
            this.contractorNameColumn.OptionsColumn.AllowFocus = false;
            this.contractorNameColumn.Visible = true;
            this.contractorNameColumn.VisibleIndex = 4;
            // 
            // accountNumColumn
            // 
            this.accountNumColumn.Caption = "Счет";
            this.accountNumColumn.FieldName = "NUM";
            this.accountNumColumn.Name = "accountNumColumn";
            this.accountNumColumn.OptionsColumn.AllowEdit = false;
            this.accountNumColumn.OptionsColumn.AllowFocus = false;
            this.accountNumColumn.Visible = true;
            this.accountNumColumn.VisibleIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.addBtn);
            this.groupBox1.Controls.Add(this.editBtn);
            this.groupBox1.Controls.Add(this.deleteBtn);
            this.groupBox1.Location = new System.Drawing.Point(12, 444);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(788, 58);
            this.groupBox1.TabIndex = 136;
            this.groupBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(393, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 142;
            this.label6.Text = "Период по:";
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
            this.yearBeginCBox.Location = new System.Drawing.Point(95, 28);
            this.yearBeginCBox.Name = "yearBeginCBox";
            this.yearBeginCBox.Size = new System.Drawing.Size(121, 21);
            this.yearBeginCBox.TabIndex = 143;
            this.yearBeginCBox.TabStop = false;
            // 
            // monthBeginCBox
            // 
            this.monthBeginCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.monthBeginCBox.FormattingEnabled = true;
            this.monthBeginCBox.Items.AddRange(new object[] {
            "01 Январь",
            "02 Февраль",
            "03 Март",
            "04 Апрель",
            "05 Май",
            "06 Июнь",
            "07 Июль",
            "08 Август",
            "09 Сентябрь",
            "10 Октябрь",
            "11 Ноябрь",
            "12 Декабрь"});
            this.monthBeginCBox.Location = new System.Drawing.Point(265, 28);
            this.monthBeginCBox.Name = "monthBeginCBox";
            this.monthBeginCBox.Size = new System.Drawing.Size(121, 21);
            this.monthBeginCBox.TabIndex = 144;
            this.monthBeginCBox.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(6, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 137;
            this.label5.Text = "Период с:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(616, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 141;
            this.label4.Text = "Месяц";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 139;
            this.label2.Text = "Месяц";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 138;
            this.label1.Text = "Год";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(463, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 140;
            this.label3.Text = "Год";
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
            this.yearEndCBox.Location = new System.Drawing.Point(490, 28);
            this.yearEndCBox.Name = "yearEndCBox";
            this.yearEndCBox.Size = new System.Drawing.Size(121, 21);
            this.yearEndCBox.TabIndex = 145;
            this.yearEndCBox.TabStop = false;
            // 
            // monthEndCBox
            // 
            this.monthEndCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.monthEndCBox.FormattingEnabled = true;
            this.monthEndCBox.Items.AddRange(new object[] {
            "01 Январь",
            "02 Февраль",
            "03 Март",
            "04 Апрель",
            "05 Май",
            "06 Июнь",
            "07 Июль",
            "08 Август",
            "09 Сентябрь",
            "10 Октябрь",
            "11 Ноябрь",
            "12 Декабрь"});
            this.monthEndCBox.Location = new System.Drawing.Point(658, 28);
            this.monthEndCBox.Name = "monthEndCBox";
            this.monthEndCBox.Size = new System.Drawing.Size(121, 21);
            this.monthEndCBox.TabIndex = 146;
            this.monthEndCBox.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(787, 69);
            this.groupBox2.TabIndex = 147;
            this.groupBox2.TabStop = false;
            // 
            // businessTripsFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(807, 511);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.businessTripGrid);
            this.Name = "businessTripsFm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "НДС (счет 372)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.businessTripsFm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.businessTripGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.businessTripView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button deleteBtn;
        private DevExpress.XtraGrid.GridControl businessTripGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView businessTripView;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraGrid.Columns.GridColumn vatColumn;
        private DevExpress.XtraGrid.Columns.GridColumn contractorCodColumn;
        private DevExpress.XtraGrid.Columns.GridColumn contractorNameColumn;
        private DevExpress.XtraGrid.Columns.GridColumn accountNumColumn;
        private DevExpress.XtraGrid.Columns.GridColumn datePaymentColumn;
        private DevExpress.XtraGrid.Columns.GridColumn docNumberColumn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox yearBeginCBox;
        private System.Windows.Forms.ComboBox monthBeginCBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox yearEndCBox;
        private System.Windows.Forms.ComboBox monthEndCBox;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}