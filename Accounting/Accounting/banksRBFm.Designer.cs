namespace Accounting
{
    partial class banksRBFm
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
            this.banksGrid = new DevExpress.XtraGrid.GridControl();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.banksView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.mfoColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bankNameColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.currentAccountColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.srnColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cityColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.addressColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.banksGrid)).BeginInit();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.banksView)).BeginInit();
            this.SuspendLayout();
            // 
            // banksGrid
            // 
            this.banksGrid.ContextMenuStrip = this.contextMenu;
            this.banksGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.banksGrid.Location = new System.Drawing.Point(0, 0);
            this.banksGrid.MainView = this.banksView;
            this.banksGrid.Name = "banksGrid";
            this.banksGrid.Size = new System.Drawing.Size(834, 462);
            this.banksGrid.TabIndex = 0;
            this.banksGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.banksView});
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem,
            this.редактироватьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(155, 70);
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.Image = global::Accounting.Properties.Resources.Edit_Add;
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            // 
            // редактироватьToolStripMenuItem
            // 
            this.редактироватьToolStripMenuItem.Image = global::Accounting.Properties.Resources.Edit_Update;
            this.редактироватьToolStripMenuItem.Name = "редактироватьToolStripMenuItem";
            this.редактироватьToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.редактироватьToolStripMenuItem.Text = "Редактировать";
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Image = global::Accounting.Properties.Resources.Edit_Delete;
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            // 
            // banksView
            // 
            this.banksView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.mfoColumn,
            this.bankNameColumn,
            this.currentAccountColumn,
            this.srnColumn,
            this.cityColumn,
            this.addressColumn});
            this.banksView.GridControl = this.banksGrid;
            this.banksView.Name = "banksView";
            this.banksView.OptionsView.ShowAutoFilterRow = true;
            this.banksView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.banksView.OptionsView.ShowGroupPanel = false;
            // 
            // mfoColumn
            // 
            this.mfoColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mfoColumn.AppearanceHeader.Options.UseFont = true;
            this.mfoColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.mfoColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.mfoColumn.Caption = "МФО";
            this.mfoColumn.Name = "mfoColumn";
            this.mfoColumn.Visible = true;
            this.mfoColumn.VisibleIndex = 0;
            this.mfoColumn.Width = 72;
            // 
            // bankNameColumn
            // 
            this.bankNameColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bankNameColumn.AppearanceHeader.Options.UseFont = true;
            this.bankNameColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.bankNameColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bankNameColumn.Caption = "Наименование";
            this.bankNameColumn.Name = "bankNameColumn";
            this.bankNameColumn.Visible = true;
            this.bankNameColumn.VisibleIndex = 2;
            this.bankNameColumn.Width = 181;
            // 
            // currentAccountColumn
            // 
            this.currentAccountColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentAccountColumn.AppearanceHeader.Options.UseFont = true;
            this.currentAccountColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.currentAccountColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.currentAccountColumn.Caption = "Кор. счёт";
            this.currentAccountColumn.Name = "currentAccountColumn";
            this.currentAccountColumn.Visible = true;
            this.currentAccountColumn.VisibleIndex = 3;
            this.currentAccountColumn.Width = 139;
            // 
            // srnColumn
            // 
            this.srnColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.srnColumn.AppearanceHeader.Options.UseFont = true;
            this.srnColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.srnColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.srnColumn.Caption = "Едрпоу";
            this.srnColumn.Name = "srnColumn";
            this.srnColumn.Visible = true;
            this.srnColumn.VisibleIndex = 1;
            this.srnColumn.Width = 139;
            // 
            // cityColumn
            // 
            this.cityColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cityColumn.AppearanceHeader.Options.UseFont = true;
            this.cityColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.cityColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cityColumn.Caption = "Город";
            this.cityColumn.Name = "cityColumn";
            this.cityColumn.Visible = true;
            this.cityColumn.VisibleIndex = 4;
            this.cityColumn.Width = 139;
            // 
            // addressColumn
            // 
            this.addressColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addressColumn.AppearanceHeader.Options.UseFont = true;
            this.addressColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.addressColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.addressColumn.Caption = "Адрес";
            this.addressColumn.Name = "addressColumn";
            this.addressColumn.Visible = true;
            this.addressColumn.VisibleIndex = 5;
            this.addressColumn.Width = 146;
            // 
            // banksRBFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 462);
            this.Controls.Add(this.banksGrid);
            this.Name = "banksRBFm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справочник - \"Банки\"";
            ((System.ComponentModel.ISupportInitialize)(this.banksGrid)).EndInit();
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.banksView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl banksGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView banksView;
        private DevExpress.XtraGrid.Columns.GridColumn mfoColumn;
        private DevExpress.XtraGrid.Columns.GridColumn bankNameColumn;
        private DevExpress.XtraGrid.Columns.GridColumn currentAccountColumn;
        private DevExpress.XtraGrid.Columns.GridColumn srnColumn;
        private DevExpress.XtraGrid.Columns.GridColumn cityColumn;
        private DevExpress.XtraGrid.Columns.GridColumn addressColumn;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
    }
}