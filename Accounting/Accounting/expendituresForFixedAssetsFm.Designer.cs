namespace Accounting
{
    partial class expendituresForFixedAssetsFm
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
            this.GC_EXP_DATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckSelect = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.GC_Credit_Account = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GC_DEBIT_NUM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GC_PRICE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GC_ORDER_DATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GC_RECEIPT_NUM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GC_MEASURE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GC_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ExpendituresForFixedAssetsView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GC_NOMENCLATURE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GC_SetPRICE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ExpendituresForFixedAssetsGrid = new DevExpress.XtraGrid.GridControl();
            this.viewSelectDateBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.expEndDateDTP = new System.Windows.Forms.DateTimePicker();
            this.expStartDateDTP = new System.Windows.Forms.DateTimePicker();
            this.cancelBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExpendituresForFixedAssetsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExpendituresForFixedAssetsGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.GC_EXP_DATE.Visible = true;
            this.GC_EXP_DATE.VisibleIndex = 6;
            this.GC_EXP_DATE.Width = 95;
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
            // GC_Credit_Account
            // 
            this.GC_Credit_Account.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.GC_Credit_Account.AppearanceHeader.Options.UseFont = true;
            this.GC_Credit_Account.Caption = "Кредит счет";
            this.GC_Credit_Account.FieldName = "CREDIT_ACCOUNT";
            this.GC_Credit_Account.Name = "GC_Credit_Account";
            this.GC_Credit_Account.OptionsColumn.AllowEdit = false;
            this.GC_Credit_Account.OptionsColumn.AllowFocus = false;
            this.GC_Credit_Account.Visible = true;
            this.GC_Credit_Account.VisibleIndex = 9;
            this.GC_Credit_Account.Width = 105;
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
            this.GC_DEBIT_NUM.Visible = true;
            this.GC_DEBIT_NUM.VisibleIndex = 5;
            this.GC_DEBIT_NUM.Width = 95;
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
            this.GC_PRICE.Visible = true;
            this.GC_PRICE.VisibleIndex = 7;
            this.GC_PRICE.Width = 100;
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
            this.GC_ORDER_DATE.Visible = true;
            this.GC_ORDER_DATE.VisibleIndex = 4;
            this.GC_ORDER_DATE.Width = 100;
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
            this.GC_RECEIPT_NUM.Visible = true;
            this.GC_RECEIPT_NUM.VisibleIndex = 3;
            this.GC_RECEIPT_NUM.Width = 88;
            // 
            // GC_MEASURE
            // 
            this.GC_MEASURE.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.GC_MEASURE.AppearanceHeader.Options.UseFont = true;
            this.GC_MEASURE.Caption = "Ед.изм.";
            this.GC_MEASURE.FieldName = "MEASURE";
            this.GC_MEASURE.Name = "GC_MEASURE";
            this.GC_MEASURE.OptionsColumn.AllowEdit = false;
            this.GC_MEASURE.OptionsColumn.AllowFocus = false;
            this.GC_MEASURE.Visible = true;
            this.GC_MEASURE.VisibleIndex = 2;
            this.GC_MEASURE.Width = 57;
            // 
            // GC_NAME
            // 
            this.GC_NAME.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.GC_NAME.AppearanceHeader.Options.UseFont = true;
            this.GC_NAME.Caption = "Наименование";
            this.GC_NAME.FieldName = "NAME";
            this.GC_NAME.Name = "GC_NAME";
            this.GC_NAME.OptionsColumn.AllowEdit = false;
            this.GC_NAME.OptionsColumn.AllowFocus = false;
            this.GC_NAME.Visible = true;
            this.GC_NAME.VisibleIndex = 1;
            this.GC_NAME.Width = 285;
            // 
            // ExpendituresForFixedAssetsView
            // 
            this.ExpendituresForFixedAssetsView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.GC_NOMENCLATURE,
            this.GC_NAME,
            this.GC_MEASURE,
            this.GC_RECEIPT_NUM,
            this.GC_ORDER_DATE,
            this.GC_DEBIT_NUM,
            this.GC_EXP_DATE,
            this.GC_PRICE,
            this.GC_SetPRICE,
            this.GC_Credit_Account});
            this.ExpendituresForFixedAssetsView.GridControl = this.ExpendituresForFixedAssetsGrid;
            this.ExpendituresForFixedAssetsView.Name = "ExpendituresForFixedAssetsView";
            this.ExpendituresForFixedAssetsView.OptionsView.ShowAutoFilterRow = true;
            this.ExpendituresForFixedAssetsView.OptionsView.ShowFooter = true;
            this.ExpendituresForFixedAssetsView.OptionsView.ShowGroupPanel = false;
            this.ExpendituresForFixedAssetsView.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.ExpendituresForFixedAssetsView_RowClick);
            // 
            // GC_NOMENCLATURE
            // 
            this.GC_NOMENCLATURE.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.GC_NOMENCLATURE.AppearanceHeader.Options.UseFont = true;
            this.GC_NOMENCLATURE.Caption = "Номенкл.номер";
            this.GC_NOMENCLATURE.FieldName = "NOMENCLATURE";
            this.GC_NOMENCLATURE.Name = "GC_NOMENCLATURE";
            this.GC_NOMENCLATURE.OptionsColumn.AllowEdit = false;
            this.GC_NOMENCLATURE.OptionsColumn.AllowFocus = false;
            this.GC_NOMENCLATURE.Visible = true;
            this.GC_NOMENCLATURE.VisibleIndex = 0;
            this.GC_NOMENCLATURE.Width = 101;
            // 
            // GC_SetPRICE
            // 
            this.GC_SetPRICE.AppearanceCell.BackColor = System.Drawing.Color.Beige;
            this.GC_SetPRICE.AppearanceCell.BackColor2 = System.Drawing.Color.Beige;
            this.GC_SetPRICE.AppearanceCell.Options.UseBackColor = true;
            this.GC_SetPRICE.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GC_SetPRICE.AppearanceHeader.Options.UseFont = true;
            this.GC_SetPRICE.Caption = "Cумма материалов";
            this.GC_SetPRICE.DisplayFormat.FormatString = "### ### ##0.00";
            this.GC_SetPRICE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.GC_SetPRICE.FieldName = "SETPRICE";
            this.GC_SetPRICE.Name = "GC_SetPRICE";
            this.GC_SetPRICE.Visible = true;
            this.GC_SetPRICE.VisibleIndex = 8;
            this.GC_SetPRICE.Width = 122;
            // 
            // ExpendituresForFixedAssetsGrid
            // 
            this.ExpendituresForFixedAssetsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExpendituresForFixedAssetsGrid.Location = new System.Drawing.Point(4, 41);
            this.ExpendituresForFixedAssetsGrid.MainView = this.ExpendituresForFixedAssetsView;
            this.ExpendituresForFixedAssetsGrid.Name = "ExpendituresForFixedAssetsGrid";
            this.ExpendituresForFixedAssetsGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckSelect});
            this.ExpendituresForFixedAssetsGrid.Size = new System.Drawing.Size(1272, 511);
            this.ExpendituresForFixedAssetsGrid.TabIndex = 582;
            this.ExpendituresForFixedAssetsGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ExpendituresForFixedAssetsView});
            // 
            // viewSelectDateBtn
            // 
            this.viewSelectDateBtn.Image = global::Accounting.Properties.Resources.PrintFixedAssetsMaterials;
            this.viewSelectDateBtn.Location = new System.Drawing.Point(496, 5);
            this.viewSelectDateBtn.Name = "viewSelectDateBtn";
            this.viewSelectDateBtn.Size = new System.Drawing.Size(90, 32);
            this.viewSelectDateBtn.TabIndex = 574;
            this.viewSelectDateBtn.Text = "Показать";
            this.viewSelectDateBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.viewSelectDateBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.viewSelectDateBtn.UseVisualStyleBackColor = true;
            this.viewSelectDateBtn.Click += new System.EventHandler(this.viewSelectDateBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 581;
            this.label1.Text = "Списания за период:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.expEndDateDTP);
            this.groupBox1.Controls.Add(this.expStartDateDTP);
            this.groupBox1.Location = new System.Drawing.Point(118, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 33);
            this.groupBox1.TabIndex = 580;
            this.groupBox1.TabStop = false;
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
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Image = global::Accounting.Properties.Resources.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(1152, 555);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(125, 32);
            this.cancelBtn.TabIndex = 584;
            this.cancelBtn.Text = "&Отмена";
            this.cancelBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cancelBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // expendituresForFixedAssetsFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 588);
            this.Controls.Add(this.viewSelectDateBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ExpendituresForFixedAssetsGrid);
            this.Name = "expendituresForFixedAssetsFm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Список материалов";
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExpendituresForFixedAssetsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExpendituresForFixedAssetsGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn GC_EXP_DATE;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckSelect;
        private DevExpress.XtraGrid.Columns.GridColumn GC_Credit_Account;
        private DevExpress.XtraGrid.Columns.GridColumn GC_DEBIT_NUM;
        private DevExpress.XtraGrid.Columns.GridColumn GC_PRICE;
        private DevExpress.XtraGrid.Columns.GridColumn GC_ORDER_DATE;
        private DevExpress.XtraGrid.Columns.GridColumn GC_RECEIPT_NUM;
        private DevExpress.XtraGrid.Columns.GridColumn GC_MEASURE;
        private DevExpress.XtraGrid.Columns.GridColumn GC_NAME;
        private DevExpress.XtraGrid.Views.Grid.GridView ExpendituresForFixedAssetsView;
        private DevExpress.XtraGrid.Columns.GridColumn GC_NOMENCLATURE;
        private DevExpress.XtraGrid.GridControl ExpendituresForFixedAssetsGrid;
        private System.Windows.Forms.Button viewSelectDateBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker expEndDateDTP;
        private System.Windows.Forms.DateTimePicker expStartDateDTP;
        private System.Windows.Forms.Button cancelBtn;
        private DevExpress.XtraGrid.Columns.GridColumn GC_SetPRICE;
    }
}