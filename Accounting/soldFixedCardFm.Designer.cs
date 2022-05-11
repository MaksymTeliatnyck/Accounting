namespace Accounting
{
    partial class soldFixedCardFm
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
            this.saveBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.fixedCardNumberLbl = new System.Windows.Forms.Label();
            this.dateSoldDatePicker = new DevExpress.XtraEditors.DateEdit();
            this.materialsGrid = new DevExpress.XtraGrid.GridControl();
            this.materialsGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.NomenclatureNameColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NameColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FixedPriceColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SoldPriceColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.partialSoldStatusChk = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dateSoldDatePicker.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateSoldDatePicker.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.partialSoldStatusChk.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // saveBtn
            // 
            this.saveBtn.Image = global::Accounting.Properties.Resources.Save_go;
            this.saveBtn.Location = new System.Drawing.Point(280, 318);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(143, 32);
            this.saveBtn.TabIndex = 571;
            this.saveBtn.Text = "&Сохранить";
            this.saveBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.saveBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Image = global::Accounting.Properties.Resources.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(429, 318);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(143, 32);
            this.cancelBtn.TabIndex = 570;
            this.cancelBtn.Text = "&Отмена";
            this.cancelBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cancelBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 569;
            this.label1.Text = "Дата продажи";
            // 
            // fixedCardNumberLbl
            // 
            this.fixedCardNumberLbl.AutoSize = true;
            this.fixedCardNumberLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fixedCardNumberLbl.Location = new System.Drawing.Point(12, 9);
            this.fixedCardNumberLbl.Name = "fixedCardNumberLbl";
            this.fixedCardNumberLbl.Size = new System.Drawing.Size(72, 20);
            this.fixedCardNumberLbl.TabIndex = 568;
            this.fixedCardNumberLbl.Text = "1234567";
            // 
            // dateSoldDatePicker
            // 
            this.dateSoldDatePicker.EditValue = null;
            this.dateSoldDatePicker.Location = new System.Drawing.Point(120, 42);
            this.dateSoldDatePicker.Name = "dateSoldDatePicker";
            this.dateSoldDatePicker.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateSoldDatePicker.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateSoldDatePicker.Size = new System.Drawing.Size(121, 20);
            this.dateSoldDatePicker.TabIndex = 567;
            // 
            // materialsGrid
            // 
            this.materialsGrid.Location = new System.Drawing.Point(16, 68);
            this.materialsGrid.MainView = this.materialsGridView;
            this.materialsGrid.Name = "materialsGrid";
            this.materialsGrid.Size = new System.Drawing.Size(556, 244);
            this.materialsGrid.TabIndex = 572;
            this.materialsGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.materialsGridView});
            // 
            // materialsGridView
            // 
            this.materialsGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.NomenclatureNameColumn,
            this.NameColumn,
            this.FixedPriceColumn,
            this.SoldPriceColumn});
            this.materialsGridView.GridControl = this.materialsGrid;
            this.materialsGridView.Name = "materialsGridView";
            this.materialsGridView.OptionsView.ShowFooter = true;
            // 
            // NomenclatureNameColumn
            // 
            this.NomenclatureNameColumn.Caption = "Номенклатурный номер";
            this.NomenclatureNameColumn.FieldName = "NOMENCLATURE";
            this.NomenclatureNameColumn.Name = "NomenclatureNameColumn";
            this.NomenclatureNameColumn.OptionsColumn.AllowEdit = false;
            this.NomenclatureNameColumn.Visible = true;
            this.NomenclatureNameColumn.VisibleIndex = 0;
            // 
            // NameColumn
            // 
            this.NameColumn.Caption = "Наименование";
            this.NameColumn.FieldName = "NAME";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.OptionsColumn.AllowEdit = false;
            this.NameColumn.Visible = true;
            this.NameColumn.VisibleIndex = 1;
            // 
            // FixedPriceColumn
            // 
            this.FixedPriceColumn.Caption = "Начальная стоимость";
            this.FixedPriceColumn.DisplayFormat.FormatString = "### ### ##0.00";
            this.FixedPriceColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.FixedPriceColumn.FieldName = "FixedPrice";
            this.FixedPriceColumn.Name = "FixedPriceColumn";
            this.FixedPriceColumn.OptionsColumn.AllowEdit = false;
            this.FixedPriceColumn.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "FixedPrice", "{0:### ### ##0.00}")});
            this.FixedPriceColumn.Visible = true;
            this.FixedPriceColumn.VisibleIndex = 2;
            // 
            // SoldPriceColumn
            // 
            this.SoldPriceColumn.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.SoldPriceColumn.AppearanceCell.Options.UseFont = true;
            this.SoldPriceColumn.Caption = "Сумма продажи";
            this.SoldPriceColumn.DisplayFormat.FormatString = "### ### ##0.00";
            this.SoldPriceColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.SoldPriceColumn.FieldName = "SoldPrice";
            this.SoldPriceColumn.Name = "SoldPriceColumn";
            this.SoldPriceColumn.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SoldPrice", "{0:### ### ##0.00}")});
            this.SoldPriceColumn.Visible = true;
            this.SoldPriceColumn.VisibleIndex = 3;
            // 
            // partialSoldStatusChk
            // 
            this.partialSoldStatusChk.Location = new System.Drawing.Point(265, 43);
            this.partialSoldStatusChk.Name = "partialSoldStatusChk";
            this.partialSoldStatusChk.Properties.Caption = "Частичная продажа";
            this.partialSoldStatusChk.Size = new System.Drawing.Size(137, 19);
            this.partialSoldStatusChk.TabIndex = 573;
            this.partialSoldStatusChk.CheckedChanged += new System.EventHandler(this.partialSoldStatusChk_CheckedChanged);
            // 
            // soldFixedCardFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.partialSoldStatusChk);
            this.Controls.Add(this.materialsGrid);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fixedCardNumberLbl);
            this.Controls.Add(this.dateSoldDatePicker);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "soldFixedCardFm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Продажа основного средства";
            ((System.ComponentModel.ISupportInitialize)(this.dateSoldDatePicker.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateSoldDatePicker.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.partialSoldStatusChk.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label fixedCardNumberLbl;
        private DevExpress.XtraEditors.DateEdit dateSoldDatePicker;
        private DevExpress.XtraGrid.GridControl materialsGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView materialsGridView;
        private DevExpress.XtraGrid.Columns.GridColumn NomenclatureNameColumn;
        private DevExpress.XtraGrid.Columns.GridColumn NameColumn;
        private DevExpress.XtraGrid.Columns.GridColumn FixedPriceColumn;
        private DevExpress.XtraGrid.Columns.GridColumn SoldPriceColumn;
        private DevExpress.XtraEditors.CheckEdit partialSoldStatusChk;
    }
}