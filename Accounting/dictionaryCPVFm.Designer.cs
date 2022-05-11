namespace Accounting
{
    partial class dictionaryCPVFm
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
            this.dictionaryTree = new DevExpress.XtraTreeList.TreeList();
            this.CodeCPVCol = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.GroupingCol = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.DescriptionUACol = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dictionaryTree)).BeginInit();
            this.SuspendLayout();
            // 
            // dictionaryTree
            // 
            this.dictionaryTree.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.CodeCPVCol,
            this.GroupingCol,
            this.DescriptionUACol});
            this.dictionaryTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dictionaryTree.KeyFieldName = "Id";
            this.dictionaryTree.Location = new System.Drawing.Point(0, 0);
            this.dictionaryTree.Name = "dictionaryTree";
            this.dictionaryTree.OptionsBehavior.EnableFiltering = true;
            this.dictionaryTree.OptionsBehavior.ExpandNodesOnIncrementalSearch = true;
            this.dictionaryTree.OptionsBehavior.PopulateServiceColumns = true;
            this.dictionaryTree.OptionsFilter.FilterMode = DevExpress.XtraTreeList.FilterMode.Smart;
            this.dictionaryTree.OptionsPrint.UsePrintStyles = true;
            this.dictionaryTree.OptionsView.ShowAutoFilterRow = true;
            this.dictionaryTree.OptionsView.ShowIndentAsRowStyle = true;
            this.dictionaryTree.ParentFieldName = "ParentId";
            this.dictionaryTree.PreviewFieldName = "CodeCPV";
            this.dictionaryTree.RootValue = null;
            this.dictionaryTree.Size = new System.Drawing.Size(1392, 729);
            this.dictionaryTree.TabIndex = 0;
            this.dictionaryTree.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.Light;
            // 
            // CodeCPVCol
            // 
            this.CodeCPVCol.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.CodeCPVCol.AppearanceHeader.Options.UseFont = true;
            this.CodeCPVCol.AppearanceHeader.Options.UseTextOptions = true;
            this.CodeCPVCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CodeCPVCol.Caption = "Код";
            this.CodeCPVCol.FieldName = "CodeCPV";
            this.CodeCPVCol.Name = "CodeCPVCol";
            this.CodeCPVCol.OptionsColumn.ReadOnly = true;
            this.CodeCPVCol.Visible = true;
            this.CodeCPVCol.VisibleIndex = 0;
            this.CodeCPVCol.Width = 382;
            // 
            // GroupingCol
            // 
            this.GroupingCol.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.GroupingCol.AppearanceHeader.Options.UseFont = true;
            this.GroupingCol.AppearanceHeader.Options.UseTextOptions = true;
            this.GroupingCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GroupingCol.Caption = "Групування";
            this.GroupingCol.FieldName = "Grouping";
            this.GroupingCol.Name = "GroupingCol";
            this.GroupingCol.Visible = true;
            this.GroupingCol.VisibleIndex = 1;
            this.GroupingCol.Width = 155;
            // 
            // DescriptionUACol
            // 
            this.DescriptionUACol.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.DescriptionUACol.AppearanceHeader.Options.UseFont = true;
            this.DescriptionUACol.AppearanceHeader.Options.UseTextOptions = true;
            this.DescriptionUACol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DescriptionUACol.Caption = "Детально";
            this.DescriptionUACol.FieldName = "DescriptionUA";
            this.DescriptionUACol.Name = "DescriptionUACol";
            this.DescriptionUACol.OptionsColumn.ReadOnly = true;
            this.DescriptionUACol.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
            this.DescriptionUACol.Visible = true;
            this.DescriptionUACol.VisibleIndex = 2;
            this.DescriptionUACol.Width = 837;
            // 
            // dictionaryCPVFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1392, 729);
            this.Controls.Add(this.dictionaryTree);
            this.Name = "dictionaryCPVFm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Єдиний закупівельний словник ДК 021:2015";
            ((System.ComponentModel.ISupportInitialize)(this.dictionaryTree)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList dictionaryTree;
        private DevExpress.XtraTreeList.Columns.TreeListColumn CodeCPVCol;
        private DevExpress.XtraTreeList.Columns.TreeListColumn DescriptionUACol;
        private DevExpress.XtraTreeList.Columns.TreeListColumn GroupingCol;
    }
}