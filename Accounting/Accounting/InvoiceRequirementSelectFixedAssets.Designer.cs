namespace Accounting
{
    partial class InvoiceRequirementSelectFixedAssets
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
            this.gridFixedAssetsOrder = new DevExpress.XtraGrid.GridControl();
            this.gridViewFixedAssetsOrder = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColInventoryNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColInventoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColBeginDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColSUPPLIERNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColGROUPNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CancelBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridFixedAssetsOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFixedAssetsOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // gridFixedAssetsOrder
            // 
            this.gridFixedAssetsOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridFixedAssetsOrder.Location = new System.Drawing.Point(-1, 0);
            this.gridFixedAssetsOrder.MainView = this.gridViewFixedAssetsOrder;
            this.gridFixedAssetsOrder.Name = "gridFixedAssetsOrder";
            this.gridFixedAssetsOrder.Size = new System.Drawing.Size(1110, 415);
            this.gridFixedAssetsOrder.TabIndex = 0;
            this.gridFixedAssetsOrder.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewFixedAssetsOrder});
            // 
            // gridViewFixedAssetsOrder
            // 
            this.gridViewFixedAssetsOrder.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColId,
            this.gridColInventoryNumber,
            this.gridColInventoryName,
            this.gridColBeginDate,
            this.gridColSUPPLIERNAME,
            this.gridColGROUPNAME});
            this.gridViewFixedAssetsOrder.GridControl = this.gridFixedAssetsOrder;
            this.gridViewFixedAssetsOrder.Name = "gridViewFixedAssetsOrder";
            this.gridViewFixedAssetsOrder.OptionsView.ShowAutoFilterRow = true;
            this.gridViewFixedAssetsOrder.OptionsView.ShowFooter = true;
            this.gridViewFixedAssetsOrder.DoubleClick += new System.EventHandler(this.gridViewFixedAssetsOrder_DoubleClick);
            // 
            // gridColId
            // 
            this.gridColId.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColId.AppearanceHeader.Options.UseFont = true;
            this.gridColId.FieldName = "Id";
            this.gridColId.MaxWidth = 160;
            this.gridColId.MinWidth = 80;
            this.gridColId.Name = "gridColId";
            this.gridColId.OptionsColumn.AllowEdit = false;
            this.gridColId.OptionsColumn.ReadOnly = true;
            this.gridColId.Width = 80;
            // 
            // gridColInventoryNumber
            // 
            this.gridColInventoryNumber.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColInventoryNumber.AppearanceHeader.Options.UseFont = true;
            this.gridColInventoryNumber.Caption = "Инвентарный номер";
            this.gridColInventoryNumber.FieldName = "InventoryNumber";
            this.gridColInventoryNumber.MaxWidth = 150;
            this.gridColInventoryNumber.Name = "gridColInventoryNumber";
            this.gridColInventoryNumber.OptionsColumn.AllowEdit = false;
            this.gridColInventoryNumber.OptionsColumn.ReadOnly = true;
            this.gridColInventoryNumber.Visible = true;
            this.gridColInventoryNumber.VisibleIndex = 0;
            this.gridColInventoryNumber.Width = 144;
            // 
            // gridColInventoryName
            // 
            this.gridColInventoryName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColInventoryName.AppearanceHeader.Options.UseFont = true;
            this.gridColInventoryName.Caption = "Наименование";
            this.gridColInventoryName.FieldName = "InventoryName";
            this.gridColInventoryName.Name = "gridColInventoryName";
            this.gridColInventoryName.OptionsColumn.AllowEdit = false;
            this.gridColInventoryName.OptionsColumn.ReadOnly = true;
            this.gridColInventoryName.Visible = true;
            this.gridColInventoryName.VisibleIndex = 1;
            this.gridColInventoryName.Width = 385;
            // 
            // gridColBeginDate
            // 
            this.gridColBeginDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColBeginDate.AppearanceHeader.Options.UseFont = true;
            this.gridColBeginDate.Caption = "Дата принятия к учету";
            this.gridColBeginDate.FieldName = "BeginDate";
            this.gridColBeginDate.MaxWidth = 180;
            this.gridColBeginDate.Name = "gridColBeginDate";
            this.gridColBeginDate.OptionsColumn.AllowEdit = false;
            this.gridColBeginDate.OptionsColumn.ReadOnly = true;
            this.gridColBeginDate.Visible = true;
            this.gridColBeginDate.VisibleIndex = 2;
            this.gridColBeginDate.Width = 110;
            // 
            // gridColSUPPLIERNAME
            // 
            this.gridColSUPPLIERNAME.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColSUPPLIERNAME.AppearanceHeader.Options.UseFont = true;
            this.gridColSUPPLIERNAME.Caption = "Ответственное лицо";
            this.gridColSUPPLIERNAME.FieldName = "SUPPLIERNAME";
            this.gridColSUPPLIERNAME.Name = "gridColSUPPLIERNAME";
            this.gridColSUPPLIERNAME.OptionsColumn.AllowEdit = false;
            this.gridColSUPPLIERNAME.OptionsColumn.ReadOnly = true;
            this.gridColSUPPLIERNAME.Visible = true;
            this.gridColSUPPLIERNAME.VisibleIndex = 3;
            this.gridColSUPPLIERNAME.Width = 241;
            // 
            // gridColGROUPNAME
            // 
            this.gridColGROUPNAME.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColGROUPNAME.AppearanceHeader.Options.UseFont = true;
            this.gridColGROUPNAME.Caption = "Группа";
            this.gridColGROUPNAME.FieldName = "GROUPNAME";
            this.gridColGROUPNAME.MaxWidth = 200;
            this.gridColGROUPNAME.Name = "gridColGROUPNAME";
            this.gridColGROUPNAME.OptionsColumn.AllowEdit = false;
            this.gridColGROUPNAME.OptionsColumn.ReadOnly = true;
            this.gridColGROUPNAME.Visible = true;
            this.gridColGROUPNAME.VisibleIndex = 4;
            this.gridColGROUPNAME.Width = 132;
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.Location = new System.Drawing.Point(1023, 422);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 1;
            this.CancelBtn.Text = "Отмена";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // InvoiceRequirementSelectFixedAssets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 457);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.gridFixedAssetsOrder);
            this.Name = "InvoiceRequirementSelectFixedAssets";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выберите основное средство";
            ((System.ComponentModel.ISupportInitialize)(this.gridFixedAssetsOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFixedAssetsOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridFixedAssetsOrder;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewFixedAssetsOrder;
        private DevExpress.XtraGrid.Columns.GridColumn gridColId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColInventoryNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gridColInventoryName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColBeginDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSUPPLIERNAME;
        private DevExpress.XtraGrid.Columns.GridColumn gridColGROUPNAME;
        private System.Windows.Forms.Button CancelBtn;
    }
}