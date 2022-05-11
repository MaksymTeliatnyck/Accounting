namespace Accounting
{
    partial class materialsFixedAssetsFm
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
            this.materialsFixedAssetsGrid = new DevExpress.XtraGrid.GridControl();
            this.materialsFixedAssetsGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.InventoryNumberColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.InventoryNameColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Balance_AccountColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SupplierColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BeginDateColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EndDateColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EndRegisterDateColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GroupColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NomenclatureColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NameColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FixedNumColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FixedPriceColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ReceiptNumColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OrderDateColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OrderNumColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.QuantityColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UnitPriceColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TotalPriceColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ExpDateColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PriceColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FlagNoteColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.printBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.materialsFixedAssetsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialsFixedAssetsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // materialsFixedAssetsGrid
            // 
            this.materialsFixedAssetsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialsFixedAssetsGrid.Location = new System.Drawing.Point(1, 1);
            this.materialsFixedAssetsGrid.MainView = this.materialsFixedAssetsGridView;
            this.materialsFixedAssetsGrid.Name = "materialsFixedAssetsGrid";
            this.materialsFixedAssetsGrid.Size = new System.Drawing.Size(1227, 559);
            this.materialsFixedAssetsGrid.TabIndex = 118;
            this.materialsFixedAssetsGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.materialsFixedAssetsGridView});
            // 
            // materialsFixedAssetsGridView
            // 
            this.materialsFixedAssetsGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.InventoryNumberColumn,
            this.InventoryNameColumn,
            this.Balance_AccountColumn,
            this.SupplierColumn,
            this.BeginDateColumn,
            this.EndDateColumn,
            this.EndRegisterDateColumn,
            this.GroupColumn,
            this.NomenclatureColumn,
            this.NameColumn,
            this.FixedNumColumn,
            this.FixedPriceColumn,
            this.ReceiptNumColumn,
            this.OrderDateColumn,
            this.OrderNumColumn,
            this.QuantityColumn,
            this.UnitPriceColumn,
            this.TotalPriceColumn,
            this.ExpDateColumn,
            this.PriceColumn,
            this.FlagNoteColumn});
            this.materialsFixedAssetsGridView.GridControl = this.materialsFixedAssetsGrid;
            this.materialsFixedAssetsGridView.Name = "materialsFixedAssetsGridView";
            this.materialsFixedAssetsGridView.OptionsView.ShowAutoFilterRow = true;
            this.materialsFixedAssetsGridView.OptionsView.ShowFooter = true;
            // 
            // InventoryNumberColumn
            // 
            this.InventoryNumberColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.InventoryNumberColumn.AppearanceHeader.Options.UseFont = true;
            this.InventoryNumberColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.InventoryNumberColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.InventoryNumberColumn.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.InventoryNumberColumn.Caption = "Инвентарный номер ОС";
            this.InventoryNumberColumn.FieldName = "InventoryNumber";
            this.InventoryNumberColumn.MinWidth = 80;
            this.InventoryNumberColumn.Name = "InventoryNumberColumn";
            this.InventoryNumberColumn.OptionsColumn.AllowEdit = false;
            this.InventoryNumberColumn.OptionsColumn.AllowFocus = false;
            this.InventoryNumberColumn.Visible = true;
            this.InventoryNumberColumn.VisibleIndex = 0;
            this.InventoryNumberColumn.Width = 120;
            // 
            // InventoryNameColumn
            // 
            this.InventoryNameColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.InventoryNameColumn.AppearanceHeader.Options.UseFont = true;
            this.InventoryNameColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.InventoryNameColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.InventoryNameColumn.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.InventoryNameColumn.Caption = "Наименование ОС";
            this.InventoryNameColumn.FieldName = "InventoryName";
            this.InventoryNameColumn.MinWidth = 300;
            this.InventoryNameColumn.Name = "InventoryNameColumn";
            this.InventoryNameColumn.OptionsColumn.AllowEdit = false;
            this.InventoryNameColumn.OptionsColumn.AllowFocus = false;
            this.InventoryNameColumn.Visible = true;
            this.InventoryNameColumn.VisibleIndex = 1;
            this.InventoryNameColumn.Width = 300;
            // 
            // Balance_AccountColumn
            // 
            this.Balance_AccountColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Balance_AccountColumn.AppearanceHeader.Options.UseFont = true;
            this.Balance_AccountColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.Balance_AccountColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Balance_AccountColumn.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.Balance_AccountColumn.Caption = "Счет учета ОС";
            this.Balance_AccountColumn.FieldName = "NUM";
            this.Balance_AccountColumn.MinWidth = 80;
            this.Balance_AccountColumn.Name = "Balance_AccountColumn";
            this.Balance_AccountColumn.OptionsColumn.AllowEdit = false;
            this.Balance_AccountColumn.OptionsColumn.AllowFocus = false;
            this.Balance_AccountColumn.Visible = true;
            this.Balance_AccountColumn.VisibleIndex = 2;
            this.Balance_AccountColumn.Width = 120;
            // 
            // SupplierColumn
            // 
            this.SupplierColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.SupplierColumn.AppearanceHeader.Options.UseFont = true;
            this.SupplierColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.SupplierColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SupplierColumn.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.SupplierColumn.Caption = "Ответственное лицо";
            this.SupplierColumn.FieldName = "NAME";
            this.SupplierColumn.MinWidth = 80;
            this.SupplierColumn.Name = "SupplierColumn";
            this.SupplierColumn.OptionsColumn.AllowEdit = false;
            this.SupplierColumn.OptionsColumn.AllowFocus = false;
            this.SupplierColumn.Visible = true;
            this.SupplierColumn.VisibleIndex = 3;
            this.SupplierColumn.Width = 120;
            // 
            // BeginDateColumn
            // 
            this.BeginDateColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BeginDateColumn.AppearanceHeader.Options.UseFont = true;
            this.BeginDateColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.BeginDateColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.BeginDateColumn.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.BeginDateColumn.Caption = "Принятие к учёту ОС";
            this.BeginDateColumn.FieldName = "BeginDate";
            this.BeginDateColumn.MinWidth = 80;
            this.BeginDateColumn.Name = "BeginDateColumn";
            this.BeginDateColumn.OptionsColumn.AllowEdit = false;
            this.BeginDateColumn.OptionsColumn.AllowFocus = false;
            this.BeginDateColumn.Visible = true;
            this.BeginDateColumn.VisibleIndex = 4;
            this.BeginDateColumn.Width = 120;
            // 
            // EndDateColumn
            // 
            this.EndDateColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.EndDateColumn.AppearanceHeader.Options.UseFont = true;
            this.EndDateColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.EndDateColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.EndDateColumn.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.EndDateColumn.Caption = "Срок полезного использования";
            this.EndDateColumn.FieldName = "UsefulMonth";
            this.EndDateColumn.MinWidth = 80;
            this.EndDateColumn.Name = "EndDateColumn";
            this.EndDateColumn.OptionsColumn.AllowEdit = false;
            this.EndDateColumn.OptionsColumn.AllowFocus = false;
            this.EndDateColumn.Visible = true;
            this.EndDateColumn.VisibleIndex = 5;
            this.EndDateColumn.Width = 120;
            // 
            // EndRegisterDateColumn
            // 
            this.EndRegisterDateColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.EndRegisterDateColumn.AppearanceHeader.Options.UseFont = true;
            this.EndRegisterDateColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.EndRegisterDateColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.EndRegisterDateColumn.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.EndRegisterDateColumn.Caption = "Снятие с учета ОС";
            this.EndRegisterDateColumn.FieldName = "EndRecordDate";
            this.EndRegisterDateColumn.MinWidth = 80;
            this.EndRegisterDateColumn.Name = "EndRegisterDateColumn";
            this.EndRegisterDateColumn.OptionsColumn.AllowEdit = false;
            this.EndRegisterDateColumn.OptionsColumn.AllowFocus = false;
            this.EndRegisterDateColumn.Visible = true;
            this.EndRegisterDateColumn.VisibleIndex = 6;
            this.EndRegisterDateColumn.Width = 120;
            // 
            // GroupColumn
            // 
            this.GroupColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.GroupColumn.AppearanceHeader.Options.UseFont = true;
            this.GroupColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.GroupColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GroupColumn.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.GroupColumn.Caption = "Группа ОС";
            this.GroupColumn.FieldName = "GROUPNAME";
            this.GroupColumn.MinWidth = 80;
            this.GroupColumn.Name = "GroupColumn";
            this.GroupColumn.OptionsColumn.AllowEdit = false;
            this.GroupColumn.OptionsColumn.AllowFocus = false;
            this.GroupColumn.Visible = true;
            this.GroupColumn.VisibleIndex = 7;
            this.GroupColumn.Width = 120;
            // 
            // NomenclatureColumn
            // 
            this.NomenclatureColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.NomenclatureColumn.AppearanceHeader.Options.UseFont = true;
            this.NomenclatureColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.NomenclatureColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NomenclatureColumn.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.NomenclatureColumn.Caption = "Ном. номер";
            this.NomenclatureColumn.FieldName = "NOMENCLATURE";
            this.NomenclatureColumn.MinWidth = 80;
            this.NomenclatureColumn.Name = "NomenclatureColumn";
            this.NomenclatureColumn.OptionsColumn.AllowEdit = false;
            this.NomenclatureColumn.OptionsColumn.AllowFocus = false;
            this.NomenclatureColumn.Visible = true;
            this.NomenclatureColumn.VisibleIndex = 8;
            this.NomenclatureColumn.Width = 120;
            // 
            // NameColumn
            // 
            this.NameColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.NameColumn.AppearanceHeader.Options.UseFont = true;
            this.NameColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.NameColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NameColumn.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.NameColumn.Caption = "Наименование";
            this.NameColumn.FieldName = "NOMEN";
            this.NameColumn.MinWidth = 300;
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.OptionsColumn.AllowEdit = false;
            this.NameColumn.OptionsColumn.AllowFocus = false;
            this.NameColumn.Visible = true;
            this.NameColumn.VisibleIndex = 9;
            this.NameColumn.Width = 300;
            // 
            // FixedNumColumn
            // 
            this.FixedNumColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.FixedNumColumn.AppearanceHeader.Options.UseFont = true;
            this.FixedNumColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.FixedNumColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.FixedNumColumn.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.FixedNumColumn.Caption = "Счет учета";
            this.FixedNumColumn.FieldName = "FIXED_NUM";
            this.FixedNumColumn.MinWidth = 80;
            this.FixedNumColumn.Name = "FixedNumColumn";
            this.FixedNumColumn.OptionsColumn.AllowEdit = false;
            this.FixedNumColumn.OptionsColumn.AllowFocus = false;
            this.FixedNumColumn.Visible = true;
            this.FixedNumColumn.VisibleIndex = 10;
            this.FixedNumColumn.Width = 120;
            // 
            // FixedPriceColumn
            // 
            this.FixedPriceColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.FixedPriceColumn.AppearanceHeader.Options.UseFont = true;
            this.FixedPriceColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.FixedPriceColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.FixedPriceColumn.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.FixedPriceColumn.Caption = "Сумма к учету";
            this.FixedPriceColumn.DisplayFormat.FormatString = "### ### ##0.00";
            this.FixedPriceColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.FixedPriceColumn.FieldName = "FIXED_PRICE";
            this.FixedPriceColumn.MinWidth = 75;
            this.FixedPriceColumn.Name = "FixedPriceColumn";
            this.FixedPriceColumn.OptionsColumn.AllowEdit = false;
            this.FixedPriceColumn.OptionsColumn.AllowFocus = false;
            this.FixedPriceColumn.Visible = true;
            this.FixedPriceColumn.VisibleIndex = 11;
            // 
            // ReceiptNumColumn
            // 
            this.ReceiptNumColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ReceiptNumColumn.AppearanceHeader.Options.UseFont = true;
            this.ReceiptNumColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.ReceiptNumColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ReceiptNumColumn.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.ReceiptNumColumn.Caption = "Номер прихода";
            this.ReceiptNumColumn.FieldName = "RECEIPT_NUM";
            this.ReceiptNumColumn.MinWidth = 80;
            this.ReceiptNumColumn.Name = "ReceiptNumColumn";
            this.ReceiptNumColumn.OptionsColumn.AllowEdit = false;
            this.ReceiptNumColumn.OptionsColumn.AllowFocus = false;
            this.ReceiptNumColumn.Visible = true;
            this.ReceiptNumColumn.VisibleIndex = 12;
            this.ReceiptNumColumn.Width = 120;
            // 
            // OrderDateColumn
            // 
            this.OrderDateColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.OrderDateColumn.AppearanceHeader.Options.UseFont = true;
            this.OrderDateColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.OrderDateColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.OrderDateColumn.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.OrderDateColumn.Caption = "Дата прихода";
            this.OrderDateColumn.FieldName = "ORDER_DATE";
            this.OrderDateColumn.MinWidth = 80;
            this.OrderDateColumn.Name = "OrderDateColumn";
            this.OrderDateColumn.OptionsColumn.AllowEdit = false;
            this.OrderDateColumn.OptionsColumn.AllowFocus = false;
            this.OrderDateColumn.Visible = true;
            this.OrderDateColumn.VisibleIndex = 13;
            this.OrderDateColumn.Width = 120;
            // 
            // OrderNumColumn
            // 
            this.OrderNumColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.OrderNumColumn.AppearanceHeader.Options.UseFont = true;
            this.OrderNumColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.OrderNumColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.OrderNumColumn.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.OrderNumColumn.Caption = "Балансовый счет";
            this.OrderNumColumn.FieldName = "ORDER_NUM";
            this.OrderNumColumn.MinWidth = 80;
            this.OrderNumColumn.Name = "OrderNumColumn";
            this.OrderNumColumn.OptionsColumn.AllowEdit = false;
            this.OrderNumColumn.OptionsColumn.AllowFocus = false;
            this.OrderNumColumn.Visible = true;
            this.OrderNumColumn.VisibleIndex = 14;
            this.OrderNumColumn.Width = 120;
            // 
            // QuantityColumn
            // 
            this.QuantityColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.QuantityColumn.AppearanceHeader.Options.UseFont = true;
            this.QuantityColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.QuantityColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.QuantityColumn.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.QuantityColumn.Caption = "Кол-во";
            this.QuantityColumn.FieldName = "QUANTITY";
            this.QuantityColumn.MinWidth = 80;
            this.QuantityColumn.Name = "QuantityColumn";
            this.QuantityColumn.OptionsColumn.AllowEdit = false;
            this.QuantityColumn.OptionsColumn.AllowFocus = false;
            this.QuantityColumn.Visible = true;
            this.QuantityColumn.VisibleIndex = 15;
            this.QuantityColumn.Width = 120;
            // 
            // UnitPriceColumn
            // 
            this.UnitPriceColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.UnitPriceColumn.AppearanceHeader.Options.UseFont = true;
            this.UnitPriceColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.UnitPriceColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.UnitPriceColumn.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.UnitPriceColumn.Caption = "Цена";
            this.UnitPriceColumn.FieldName = "UNIT_PRICE";
            this.UnitPriceColumn.MinWidth = 80;
            this.UnitPriceColumn.Name = "UnitPriceColumn";
            this.UnitPriceColumn.OptionsColumn.AllowEdit = false;
            this.UnitPriceColumn.OptionsColumn.AllowFocus = false;
            this.UnitPriceColumn.Visible = true;
            this.UnitPriceColumn.VisibleIndex = 16;
            this.UnitPriceColumn.Width = 120;
            // 
            // TotalPriceColumn
            // 
            this.TotalPriceColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.TotalPriceColumn.AppearanceHeader.Options.UseFont = true;
            this.TotalPriceColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.TotalPriceColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TotalPriceColumn.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.TotalPriceColumn.Caption = "Сумма прихода";
            this.TotalPriceColumn.FieldName = "TOTAL_PRICE";
            this.TotalPriceColumn.MinWidth = 80;
            this.TotalPriceColumn.Name = "TotalPriceColumn";
            this.TotalPriceColumn.OptionsColumn.AllowEdit = false;
            this.TotalPriceColumn.OptionsColumn.AllowFocus = false;
            this.TotalPriceColumn.Visible = true;
            this.TotalPriceColumn.VisibleIndex = 17;
            this.TotalPriceColumn.Width = 80;
            // 
            // ExpDateColumn
            // 
            this.ExpDateColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ExpDateColumn.AppearanceHeader.Options.UseFont = true;
            this.ExpDateColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.ExpDateColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ExpDateColumn.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.ExpDateColumn.Caption = "Дата списания";
            this.ExpDateColumn.FieldName = "EXP_DATE";
            this.ExpDateColumn.MinWidth = 80;
            this.ExpDateColumn.Name = "ExpDateColumn";
            this.ExpDateColumn.OptionsColumn.AllowEdit = false;
            this.ExpDateColumn.OptionsColumn.AllowFocus = false;
            this.ExpDateColumn.Visible = true;
            this.ExpDateColumn.VisibleIndex = 18;
            this.ExpDateColumn.Width = 120;
            // 
            // PriceColumn
            // 
            this.PriceColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.PriceColumn.AppearanceHeader.Options.UseFont = true;
            this.PriceColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.PriceColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PriceColumn.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.PriceColumn.Caption = "Сумма списания";
            this.PriceColumn.FieldName = "PRICE";
            this.PriceColumn.MinWidth = 80;
            this.PriceColumn.Name = "PriceColumn";
            this.PriceColumn.OptionsColumn.AllowEdit = false;
            this.PriceColumn.OptionsColumn.AllowFocus = false;
            this.PriceColumn.Visible = true;
            this.PriceColumn.VisibleIndex = 19;
            this.PriceColumn.Width = 162;
            // 
            // FlagNoteColumn
            // 
            this.FlagNoteColumn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.FlagNoteColumn.AppearanceHeader.Options.UseFont = true;
            this.FlagNoteColumn.AppearanceHeader.Options.UseTextOptions = true;
            this.FlagNoteColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.FlagNoteColumn.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.FlagNoteColumn.Caption = "Примечание";
            this.FlagNoteColumn.FieldName = "FLAGNOTE";
            this.FlagNoteColumn.MinWidth = 75;
            this.FlagNoteColumn.Name = "FlagNoteColumn";
            this.FlagNoteColumn.OptionsColumn.AllowEdit = false;
            this.FlagNoteColumn.OptionsColumn.AllowFocus = false;
            this.FlagNoteColumn.Visible = true;
            this.FlagNoteColumn.VisibleIndex = 20;
            this.FlagNoteColumn.Width = 90;
            // 
            // printBtn
            // 
            this.printBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.printBtn.Image = global::Accounting.Properties.Resources.PrintFixedAssetsCard;
            this.printBtn.Location = new System.Drawing.Point(1119, 1);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(101, 32);
            this.printBtn.TabIndex = 586;
            this.printBtn.Text = "Печать";
            this.printBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.printBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // materialsFixedAssetsFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 562);
            this.Controls.Add(this.printBtn);
            this.Controls.Add(this.materialsFixedAssetsGrid);
            this.Name = "materialsFixedAssetsFm";
            this.Text = "Сводная информация по основным средствам";
            ((System.ComponentModel.ISupportInitialize)(this.materialsFixedAssetsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialsFixedAssetsGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl materialsFixedAssetsGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView materialsFixedAssetsGridView;
        private DevExpress.XtraGrid.Columns.GridColumn NomenclatureColumn;
        private DevExpress.XtraGrid.Columns.GridColumn NameColumn;
        private DevExpress.XtraGrid.Columns.GridColumn FixedNumColumn;
        private DevExpress.XtraGrid.Columns.GridColumn ReceiptNumColumn;
        private DevExpress.XtraGrid.Columns.GridColumn OrderDateColumn;
        private DevExpress.XtraGrid.Columns.GridColumn OrderNumColumn;
        private DevExpress.XtraGrid.Columns.GridColumn QuantityColumn;
        private DevExpress.XtraGrid.Columns.GridColumn UnitPriceColumn;
        private DevExpress.XtraGrid.Columns.GridColumn TotalPriceColumn;
        private DevExpress.XtraGrid.Columns.GridColumn ExpDateColumn;
        private DevExpress.XtraGrid.Columns.GridColumn PriceColumn;
        private DevExpress.XtraGrid.Columns.GridColumn InventoryNumberColumn;
        private DevExpress.XtraGrid.Columns.GridColumn InventoryNameColumn;
        private DevExpress.XtraGrid.Columns.GridColumn Balance_AccountColumn;
        private DevExpress.XtraGrid.Columns.GridColumn SupplierColumn;
        private DevExpress.XtraGrid.Columns.GridColumn BeginDateColumn;
        private DevExpress.XtraGrid.Columns.GridColumn EndDateColumn;
        private DevExpress.XtraGrid.Columns.GridColumn EndRegisterDateColumn;
        private DevExpress.XtraGrid.Columns.GridColumn GroupColumn;
        private System.Windows.Forms.Button printBtn;
        private DevExpress.XtraGrid.Columns.GridColumn FixedPriceColumn;
        private DevExpress.XtraGrid.Columns.GridColumn FlagNoteColumn;
    }
}