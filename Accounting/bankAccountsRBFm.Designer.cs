namespace Accounting
{
    partial class bankAccountsRBFm
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
            this.components = new System.ComponentModel.Container();
            this.bankAccountsGrid = new DevExpress.XtraGrid.GridControl();
            this.bankAccountsView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.contractorNameColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.accountNumColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bankNameColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.currencyColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.accountTypeColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountsView)).BeginInit();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // bankAccountsGrid
            // 
            this.bankAccountsGrid.ContextMenuStrip = this.contextMenu;
            this.bankAccountsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bankAccountsGrid.Location = new System.Drawing.Point(0, 0);
            this.bankAccountsGrid.MainView = this.bankAccountsView;
            this.bankAccountsGrid.Name = "bankAccountsGrid";
            this.bankAccountsGrid.Size = new System.Drawing.Size(734, 362);
            this.bankAccountsGrid.TabIndex = 0;
            this.bankAccountsGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bankAccountsView});
            // 
            // bankAccountsView
            // 
            this.bankAccountsView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.contractorNameColumn,
            this.accountNumColumn,
            this.bankNameColumn,
            this.currencyColumn,
            this.accountTypeColumn});
            this.bankAccountsView.GridControl = this.bankAccountsGrid;
            this.bankAccountsView.Name = "bankAccountsView";
            this.bankAccountsView.OptionsView.ShowAutoFilterRow = true;
            this.bankAccountsView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.bankAccountsView.OptionsView.ShowGroupPanel = false;
            // 
            // contractorNameColumn
            // 
            this.contractorNameColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.contractorNameColumn.AppearanceHeader.Options.UseFont = true;
            this.contractorNameColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.contractorNameColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.contractorNameColumn.Caption = "Наименование контрагента";
            this.contractorNameColumn.Name = "contractorNameColumn";
            this.contractorNameColumn.Visible = true;
            this.contractorNameColumn.VisibleIndex = 0;
            this.contractorNameColumn.Width = 254;
            // 
            // accountNumColumn
            // 
            this.accountNumColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.accountNumColumn.AppearanceHeader.Options.UseFont = true;
            this.accountNumColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.accountNumColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.accountNumColumn.Caption = "Номер счёта";
            this.accountNumColumn.Name = "accountNumColumn";
            this.accountNumColumn.Visible = true;
            this.accountNumColumn.VisibleIndex = 1;
            this.accountNumColumn.Width = 114;
            // 
            // bankNameColumn
            // 
            this.bankNameColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bankNameColumn.AppearanceHeader.Options.UseFont = true;
            this.bankNameColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.bankNameColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bankNameColumn.Caption = "Банк";
            this.bankNameColumn.Name = "bankNameColumn";
            this.bankNameColumn.Visible = true;
            this.bankNameColumn.VisibleIndex = 2;
            this.bankNameColumn.Width = 172;
            // 
            // currencyColumn
            // 
            this.currencyColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currencyColumn.AppearanceHeader.Options.UseFont = true;
            this.currencyColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.currencyColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.currencyColumn.Caption = "Валюта";
            this.currencyColumn.Name = "currencyColumn";
            this.currencyColumn.Visible = true;
            this.currencyColumn.VisibleIndex = 3;
            this.currencyColumn.Width = 63;
            // 
            // accountTypeColumn
            // 
            this.accountTypeColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.accountTypeColumn.AppearanceHeader.Options.UseFont = true;
            this.accountTypeColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.accountTypeColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.accountTypeColumn.Caption = "Вид счёта";
            this.accountTypeColumn.Name = "accountTypeColumn";
            this.accountTypeColumn.Visible = true;
            this.accountTypeColumn.VisibleIndex = 4;
            this.accountTypeColumn.Width = 113;
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMenuItem,
            this.editMenuItem,
            this.deleteMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(155, 70);
            // 
            // addMenuItem
            // 
            this.addMenuItem.Image = global::Accounting.Properties.Resources.Edit_Add;
            this.addMenuItem.Name = "addMenuItem";
            this.addMenuItem.Size = new System.Drawing.Size(154, 22);
            this.addMenuItem.Text = "Добавить";
            this.addMenuItem.Click += new System.EventHandler(this.addMenuItem_Click);
            // 
            // editMenuItem
            // 
            this.editMenuItem.Image = global::Accounting.Properties.Resources.Edit_Update;
            this.editMenuItem.Name = "editMenuItem";
            this.editMenuItem.Size = new System.Drawing.Size(154, 22);
            this.editMenuItem.Text = "Редактировать";
            this.editMenuItem.Click += new System.EventHandler(this.editMenuItem_Click);
            // 
            // deleteMenuItem
            // 
            this.deleteMenuItem.Image = global::Accounting.Properties.Resources.Edit_Delete;
            this.deleteMenuItem.Name = "deleteMenuItem";
            this.deleteMenuItem.Size = new System.Drawing.Size(154, 22);
            this.deleteMenuItem.Text = "Удалить";
            this.deleteMenuItem.Click += new System.EventHandler(this.deleteMenuItem_Click);
            // 
            // bankAccountsFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 362);
            this.Controls.Add(this.bankAccountsGrid);
            this.Name = "bankAccountsFm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справочник - \"Банковские счета\"";
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountsView)).EndInit();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl bankAccountsGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView bankAccountsView;
        private DevExpress.XtraGrid.Columns.GridColumn contractorNameColumn;
        private DevExpress.XtraGrid.Columns.GridColumn accountNumColumn;
        private DevExpress.XtraGrid.Columns.GridColumn bankNameColumn;
        private DevExpress.XtraGrid.Columns.GridColumn currencyColumn;
        private DevExpress.XtraGrid.Columns.GridColumn accountTypeColumn;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem addMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteMenuItem;
    }
}