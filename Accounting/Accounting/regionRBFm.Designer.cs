namespace Accounting
{
    partial class regionRBFm
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
            this.NameTBox = new System.Windows.Forms.TextBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.regionGrid = new DevExpress.XtraGrid.GridControl();
            this.regionView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gClName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gClType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gClDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TypeTBox = new System.Windows.Forms.TextBox();
            this.DescriptionTBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.regionGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.regionView)).BeginInit();
            this.SuspendLayout();
            // 
            // NameTBox
            // 
            this.NameTBox.Location = new System.Drawing.Point(3, 473);
            this.NameTBox.MaxLength = 200;
            this.NameTBox.Name = "NameTBox";
            this.NameTBox.Size = new System.Drawing.Size(226, 20);
            this.NameTBox.TabIndex = 15;
            // 
            // addBtn
            // 
            this.addBtn.Image = global::Accounting.Properties.Resources.Edit_Add;
            this.addBtn.Location = new System.Drawing.Point(787, 499);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(85, 25);
            this.addBtn.TabIndex = 19;
            this.addBtn.Text = "&Добавить";
            this.addBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Image = global::Accounting.Properties.Resources.Edit_Delete;
            this.deleteBtn.Location = new System.Drawing.Point(878, 499);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(85, 25);
            this.deleteBtn.TabIndex = 20;
            this.deleteBtn.Text = "&Удалить";
            this.deleteBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.deleteBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Image = global::Accounting.Properties.Resources.Save;
            this.saveBtn.Location = new System.Drawing.Point(141, 499);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(132, 25);
            this.saveBtn.TabIndex = 17;
            this.saveBtn.Text = "&Сохранить";
            this.saveBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.saveBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Image = global::Accounting.Properties.Resources.Save_go;
            this.okBtn.Location = new System.Drawing.Point(3, 499);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(132, 25);
            this.okBtn.TabIndex = 18;
            this.okBtn.Text = "Сохранить и &выйти";
            this.okBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.okBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // regionGrid
            // 
            this.regionGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.regionGrid.Location = new System.Drawing.Point(3, 2);
            this.regionGrid.MainView = this.regionView;
            this.regionGrid.Name = "regionGrid";
            this.regionGrid.Size = new System.Drawing.Size(960, 465);
            this.regionGrid.TabIndex = 21;
            this.regionGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.regionView});
            // 
            // regionView
            // 
            this.regionView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gClName,
            this.gClType,
            this.gClDescription});
            this.regionView.GridControl = this.regionGrid;
            this.regionView.Name = "regionView";
            this.regionView.OptionsBehavior.Editable = false;
            // 
            // gClName
            // 
            this.gClName.Caption = "Имя";
            this.gClName.FieldName = "Name";
            this.gClName.Name = "gClName";
            this.gClName.Visible = true;
            this.gClName.VisibleIndex = 0;
            this.gClName.Width = 200;
            // 
            // gClType
            // 
            this.gClType.Caption = "Тип";
            this.gClType.FieldName = "Type";
            this.gClType.Name = "gClType";
            this.gClType.Visible = true;
            this.gClType.VisibleIndex = 1;
            this.gClType.Width = 97;
            // 
            // gClDescription
            // 
            this.gClDescription.Caption = "Описание";
            this.gClDescription.FieldName = "Description";
            this.gClDescription.Name = "gClDescription";
            this.gClDescription.Visible = true;
            this.gClDescription.VisibleIndex = 2;
            this.gClDescription.Width = 645;
            // 
            // TypeTBox
            // 
            this.TypeTBox.Location = new System.Drawing.Point(235, 473);
            this.TypeTBox.MaxLength = 200;
            this.TypeTBox.Name = "TypeTBox";
            this.TypeTBox.Size = new System.Drawing.Size(156, 20);
            this.TypeTBox.TabIndex = 22;
            this.TypeTBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TypeTBox_KeyPress);
            // 
            // DescriptionTBox
            // 
            this.DescriptionTBox.Location = new System.Drawing.Point(397, 473);
            this.DescriptionTBox.MaxLength = 200;
            this.DescriptionTBox.Name = "DescriptionTBox";
            this.DescriptionTBox.Size = new System.Drawing.Size(566, 20);
            this.DescriptionTBox.TabIndex = 23;
            // 
            // regionRBFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 526);
            this.Controls.Add(this.DescriptionTBox);
            this.Controls.Add(this.TypeTBox);
            this.Controls.Add(this.regionGrid);
            this.Controls.Add(this.NameTBox);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.okBtn);
            this.MaximizeBox = false;
            this.Name = "regionRBFm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Участки и отделы";
            ((System.ComponentModel.ISupportInitialize)(this.regionGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.regionView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NameTBox;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button okBtn;
        private DevExpress.XtraGrid.GridControl regionGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView regionView;
        private DevExpress.XtraGrid.Columns.GridColumn gClName;
        private DevExpress.XtraGrid.Columns.GridColumn gClType;
        private DevExpress.XtraGrid.Columns.GridColumn gClDescription;
        private System.Windows.Forms.TextBox TypeTBox;
        private System.Windows.Forms.TextBox DescriptionTBox;
    }
}