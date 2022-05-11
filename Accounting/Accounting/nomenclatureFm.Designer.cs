namespace Accounting
{
    partial class nomenclatureFm
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
            this.nomenclGrid = new DevExpress.XtraGrid.GridControl();
            this.nomenclGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.nomenclatureColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nameColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.measureColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.balanceColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.editBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nomenclGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nomenclGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nomenclGrid
            // 
            this.nomenclGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nomenclGrid.Location = new System.Drawing.Point(12, 41);
            this.nomenclGrid.MainView = this.nomenclGridView;
            this.nomenclGrid.Name = "nomenclGrid";
            this.nomenclGrid.Size = new System.Drawing.Size(995, 590);
            this.nomenclGrid.TabIndex = 1;
            this.nomenclGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.nomenclGridView});
            // 
            // nomenclGridView
            // 
            this.nomenclGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.nomenclatureColumn,
            this.nameColumn,
            this.measureColumn,
            this.balanceColumn});
            this.nomenclGridView.GridControl = this.nomenclGrid;
            this.nomenclGridView.Name = "nomenclGridView";
            this.nomenclGridView.OptionsView.ShowAutoFilterRow = true;
            this.nomenclGridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.nomenclGridView.OptionsView.ShowGroupPanel = false;
            this.nomenclGridView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nomenclGridView_KeyUp);
            this.nomenclGridView.DoubleClick += new System.EventHandler(this.nomenclGridView_DoubleClick);
            // 
            // nomenclatureColumn
            // 
            this.nomenclatureColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nomenclatureColumn.AppearanceHeader.Options.UseFont = true;
            this.nomenclatureColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.nomenclatureColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.nomenclatureColumn.Caption = "Ном. номер";
            this.nomenclatureColumn.FieldName = "NOMENCLATURE";
            this.nomenclatureColumn.MaxWidth = 100;
            this.nomenclatureColumn.MinWidth = 100;
            this.nomenclatureColumn.Name = "nomenclatureColumn";
            this.nomenclatureColumn.OptionsColumn.AllowEdit = false;
            this.nomenclatureColumn.OptionsColumn.AllowFocus = false;
            this.nomenclatureColumn.OptionsColumn.AllowMove = false;
            this.nomenclatureColumn.OptionsColumn.AllowSize = false;
            this.nomenclatureColumn.Visible = true;
            this.nomenclatureColumn.VisibleIndex = 0;
            this.nomenclatureColumn.Width = 100;
            // 
            // nameColumn
            // 
            this.nameColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameColumn.AppearanceHeader.Options.UseFont = true;
            this.nameColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.nameColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.nameColumn.Caption = "Найменування";
            this.nameColumn.FieldName = "NAME";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.OptionsColumn.AllowEdit = false;
            this.nameColumn.OptionsColumn.AllowFocus = false;
            this.nameColumn.OptionsColumn.AllowMove = false;
            this.nameColumn.OptionsColumn.AllowSize = false;
            this.nameColumn.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.nameColumn.Visible = true;
            this.nameColumn.VisibleIndex = 1;
            this.nameColumn.Width = 563;
            // 
            // measureColumn
            // 
            this.measureColumn.AppearanceCell.Options.UseTextOptions = true;
            this.measureColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.measureColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.measureColumn.AppearanceHeader.Options.UseFont = true;
            this.measureColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.measureColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.measureColumn.Caption = "Од. вим.";
            this.measureColumn.FieldName = "UNITLOCALNAME";
            this.measureColumn.MaxWidth = 90;
            this.measureColumn.MinWidth = 90;
            this.measureColumn.Name = "measureColumn";
            this.measureColumn.OptionsColumn.AllowEdit = false;
            this.measureColumn.OptionsColumn.AllowFocus = false;
            this.measureColumn.OptionsColumn.AllowMove = false;
            this.measureColumn.OptionsColumn.AllowSize = false;
            this.measureColumn.Visible = true;
            this.measureColumn.VisibleIndex = 2;
            this.measureColumn.Width = 90;
            // 
            // balanceColumn
            // 
            this.balanceColumn.AppearanceCell.Options.UseTextOptions = true;
            this.balanceColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.balanceColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.balanceColumn.AppearanceHeader.Options.UseFont = true;
            this.balanceColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.balanceColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.balanceColumn.Caption = "Бал. рах.";
            this.balanceColumn.FieldName = "NUM";
            this.balanceColumn.MaxWidth = 85;
            this.balanceColumn.MinWidth = 85;
            this.balanceColumn.Name = "balanceColumn";
            this.balanceColumn.OptionsColumn.AllowEdit = false;
            this.balanceColumn.OptionsColumn.AllowFocus = false;
            this.balanceColumn.Visible = true;
            this.balanceColumn.VisibleIndex = 3;
            this.balanceColumn.Width = 85;
            // 
            // editBtn
            // 
            this.editBtn.Image = global::Accounting.Properties.Resources.Edit_Update;
            this.editBtn.Location = new System.Drawing.Point(122, 12);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(110, 23);
            this.editBtn.TabIndex = 10;
            this.editBtn.Text = "&Редагувати";
            this.editBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.editBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Image = global::Accounting.Properties.Resources.Edit_Add;
            this.addBtn.Location = new System.Drawing.Point(12, 12);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(110, 23);
            this.addBtn.TabIndex = 8;
            this.addBtn.Text = "&Додати";
            this.addBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Image = global::Accounting.Properties.Resources.Edit_Delete;
            this.deleteBtn.Location = new System.Drawing.Point(232, 12);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(110, 23);
            this.deleteBtn.TabIndex = 9;
            this.deleteBtn.Text = "&Видалити";
            this.deleteBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.deleteBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
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
            this.groupBox1.Location = new System.Drawing.Point(12, 637);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(995, 30);
            this.groupBox1.TabIndex = 614;
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
            // nomenclatureFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 679);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.nomenclGrid);
            this.Name = "nomenclatureFm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Номенклатура";
            ((System.ComponentModel.ISupportInitialize)(this.nomenclGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nomenclGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl nomenclGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView nomenclGridView;
        private DevExpress.XtraGrid.Columns.GridColumn nomenclatureColumn;
        private DevExpress.XtraGrid.Columns.GridColumn nameColumn;
        private DevExpress.XtraGrid.Columns.GridColumn measureColumn;
        private DevExpress.XtraGrid.Columns.GridColumn balanceColumn;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Label label9;
    }
}