namespace Accounting
{
    partial class contractorsRBFm
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
            this.addBtn = new System.Windows.Forms.Button();
            this.contractorsGrid = new DevExpress.XtraGrid.GridControl();
            this.contractorsGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.vendorNameColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.vendorSrnColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.vendorTinColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.editBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.contractorsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contractorsGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // deleteBtn
            // 
            this.deleteBtn.Image = global::Accounting.Properties.Resources.Edit_Delete;
            this.deleteBtn.Location = new System.Drawing.Point(232, 12);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(110, 23);
            this.deleteBtn.TabIndex = 6;
            this.deleteBtn.Text = "&Видалити";
            this.deleteBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.deleteBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Image = global::Accounting.Properties.Resources.Edit_Add;
            this.addBtn.Location = new System.Drawing.Point(12, 12);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(110, 23);
            this.addBtn.TabIndex = 5;
            this.addBtn.Text = "&Додати";
            this.addBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // contractorsGrid
            // 
            this.contractorsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contractorsGrid.Location = new System.Drawing.Point(12, 41);
            this.contractorsGrid.MainView = this.contractorsGridView;
            this.contractorsGrid.Name = "contractorsGrid";
            this.contractorsGrid.Size = new System.Drawing.Size(995, 589);
            this.contractorsGrid.TabIndex = 0;
            this.contractorsGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.contractorsGridView});
            // 
            // contractorsGridView
            // 
            this.contractorsGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.vendorNameColumn,
            this.vendorSrnColumn,
            this.vendorTinColumn});
            this.contractorsGridView.GridControl = this.contractorsGrid;
            this.contractorsGridView.Name = "contractorsGridView";
            this.contractorsGridView.OptionsSelection.MultiSelect = true;
            this.contractorsGridView.OptionsView.ShowAutoFilterRow = true;
            this.contractorsGridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.contractorsGridView.OptionsView.ShowGroupPanel = false;
            this.contractorsGridView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.contractorsGridView_KeyUp);
            this.contractorsGridView.DoubleClick += new System.EventHandler(this.contractorsGridView_DoubleClick);
            // 
            // vendorNameColumn
            // 
            this.vendorNameColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.vendorNameColumn.AppearanceHeader.Options.UseFont = true;
            this.vendorNameColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.vendorNameColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.vendorNameColumn.Caption = "Найменування";
            this.vendorNameColumn.FieldName = "Name";
            this.vendorNameColumn.Name = "vendorNameColumn";
            this.vendorNameColumn.OptionsColumn.AllowEdit = false;
            this.vendorNameColumn.OptionsColumn.AllowFocus = false;
            this.vendorNameColumn.OptionsColumn.AllowMove = false;
            this.vendorNameColumn.OptionsColumn.AllowSize = false;
            this.vendorNameColumn.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.vendorNameColumn.Visible = true;
            this.vendorNameColumn.VisibleIndex = 0;
            this.vendorNameColumn.Width = 797;
            // 
            // vendorSrnColumn
            // 
            this.vendorSrnColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.vendorSrnColumn.AppearanceHeader.Options.UseFont = true;
            this.vendorSrnColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.vendorSrnColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.vendorSrnColumn.Caption = "Код за ЄДРПОУ";
            this.vendorSrnColumn.FieldName = "Srn";
            this.vendorSrnColumn.MaxWidth = 100;
            this.vendorSrnColumn.MinWidth = 100;
            this.vendorSrnColumn.Name = "vendorSrnColumn";
            this.vendorSrnColumn.OptionsColumn.AllowEdit = false;
            this.vendorSrnColumn.OptionsColumn.AllowFocus = false;
            this.vendorSrnColumn.OptionsColumn.AllowMove = false;
            this.vendorSrnColumn.OptionsColumn.AllowSize = false;
            this.vendorSrnColumn.Visible = true;
            this.vendorSrnColumn.VisibleIndex = 1;
            this.vendorSrnColumn.Width = 100;
            // 
            // vendorTinColumn
            // 
            this.vendorTinColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.vendorTinColumn.AppearanceHeader.Options.UseFont = true;
            this.vendorTinColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.vendorTinColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.vendorTinColumn.Caption = "Код ІПН";
            this.vendorTinColumn.FieldName = "Tin";
            this.vendorTinColumn.MaxWidth = 100;
            this.vendorTinColumn.Name = "vendorTinColumn";
            this.vendorTinColumn.OptionsColumn.AllowEdit = false;
            this.vendorTinColumn.OptionsColumn.AllowFocus = false;
            this.vendorTinColumn.Visible = true;
            this.vendorTinColumn.VisibleIndex = 2;
            this.vendorTinColumn.Width = 100;
            // 
            // editBtn
            // 
            this.editBtn.Image = global::Accounting.Properties.Resources.Edit_Update;
            this.editBtn.Location = new System.Drawing.Point(122, 12);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(110, 23);
            this.editBtn.TabIndex = 7;
            this.editBtn.Text = "&Редагувати";
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
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.labelControl2);
            this.groupBox1.Controls.Add(this.labelControl1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(12, 636);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(995, 31);
            this.groupBox1.TabIndex = 613;
            this.groupBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(184, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 163;
            this.label7.Text = "- видалити запис";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 13);
            this.label8.TabIndex = 162;
            this.label8.Text = "- додати новий запис";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Location = new System.Drawing.Point(160, 13);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(18, 13);
            this.labelControl2.TabIndex = 161;
            this.labelControl2.Text = "Del";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(11, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(18, 13);
            this.labelControl1.TabIndex = 160;
            this.labelControl1.Text = "Ins";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(260, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 13);
            this.label9.TabIndex = 159;
            // 
            // contractorsRBFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 679);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.contractorsGrid);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.deleteBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "contractorsRBFm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Контрагенти";
            ((System.ComponentModel.ISupportInitialize)(this.contractorsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contractorsGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button addBtn;
        private DevExpress.XtraGrid.GridControl contractorsGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView contractorsGridView;
        private DevExpress.XtraGrid.Columns.GridColumn vendorNameColumn;
        private DevExpress.XtraGrid.Columns.GridColumn vendorSrnColumn;
        private System.Windows.Forms.Button editBtn;
        private DevExpress.XtraGrid.Columns.GridColumn vendorTinColumn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Label label9;
    }
}