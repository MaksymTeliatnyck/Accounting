namespace Accounting
{
    partial class expendituresFm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            this.projectTBox = new System.Windows.Forms.TextBox();
            this.expDTPicker = new System.Windows.Forms.DateTimePicker();
            this.nomenclatureTBox = new System.Windows.Forms.TextBox();
            this.nomenclNameTBox = new System.Windows.Forms.TextBox();
            this.measureTBox = new System.Windows.Forms.TextBox();
            this.quantityTBox = new System.Windows.Forms.TextBox();
            this.expenditureBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.remainsGrid = new System.Windows.Forms.DataGridView();
            this.sumTBox = new System.Windows.Forms.TextBox();
            this.creditCBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.priceSumTBox = new System.Windows.Forms.TextBox();
            this.quantitySumTBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.openAccountsRBFm = new System.Windows.Forms.Button();
            this.expEditBtn = new System.Windows.Forms.Button();
            this.balanceTBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.totalExpPriceTBox = new System.Windows.Forms.TextBox();
            this.quantityExpSumTBox = new System.Windows.Forms.TextBox();
            this.sumRButton = new System.Windows.Forms.RadioButton();
            this.quantityRButton = new System.Windows.Forms.RadioButton();
            this.ReceiptNumColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RemainsQuantityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RemainsSumColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DebitNumColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CorrectionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.remainsGrid)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // projectTBox
            // 
            this.projectTBox.Location = new System.Drawing.Point(12, 25);
            this.projectTBox.MaxLength = 12;
            this.projectTBox.Name = "projectTBox";
            this.projectTBox.Size = new System.Drawing.Size(264, 20);
            this.projectTBox.TabIndex = 0;
            this.projectTBox.TextChanged += new System.EventHandler(this.projectTBox_TextChanged);
            this.projectTBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.projectTBox_KeyPress);
            // 
            // expDTPicker
            // 
            this.expDTPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.expDTPicker.Location = new System.Drawing.Point(282, 25);
            this.expDTPicker.Name = "expDTPicker";
            this.expDTPicker.Size = new System.Drawing.Size(400, 20);
            this.expDTPicker.TabIndex = 1;
            this.expDTPicker.Value = new System.DateTime(2012, 5, 7, 0, 0, 0, 0);
            this.expDTPicker.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.expDTPicker_KeyPress);
            // 
            // nomenclatureTBox
            // 
            this.nomenclatureTBox.Location = new System.Drawing.Point(12, 64);
            this.nomenclatureTBox.MaxLength = 12;
            this.nomenclatureTBox.Name = "nomenclatureTBox";
            this.nomenclatureTBox.Size = new System.Drawing.Size(88, 20);
            this.nomenclatureTBox.TabIndex = 2;
            this.nomenclatureTBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nomenclatureTBox_KeyPress);
            // 
            // nomenclNameTBox
            // 
            this.nomenclNameTBox.Location = new System.Drawing.Point(106, 64);
            this.nomenclNameTBox.Name = "nomenclNameTBox";
            this.nomenclNameTBox.ReadOnly = true;
            this.nomenclNameTBox.Size = new System.Drawing.Size(395, 20);
            this.nomenclNameTBox.TabIndex = 104;
            this.nomenclNameTBox.TabStop = false;
            this.nomenclNameTBox.MouseHover += new System.EventHandler(this.nomenclNameTBox_MouseHover);
            // 
            // measureTBox
            // 
            this.measureTBox.Location = new System.Drawing.Point(507, 64);
            this.measureTBox.Name = "measureTBox";
            this.measureTBox.ReadOnly = true;
            this.measureTBox.Size = new System.Drawing.Size(58, 20);
            this.measureTBox.TabIndex = 105;
            this.measureTBox.TabStop = false;
            // 
            // quantityTBox
            // 
            this.quantityTBox.Location = new System.Drawing.Point(12, 103);
            this.quantityTBox.MaxLength = 12;
            this.quantityTBox.Name = "quantityTBox";
            this.quantityTBox.ReadOnly = true;
            this.quantityTBox.Size = new System.Drawing.Size(101, 20);
            this.quantityTBox.TabIndex = 3;
            this.quantityTBox.TextChanged += new System.EventHandler(this.quantityTBox_TextChanged);
            this.quantityTBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.quantityTBox_KeyPress);
            // 
            // expenditureBtn
            // 
            this.expenditureBtn.Location = new System.Drawing.Point(12, 129);
            this.expenditureBtn.Name = "expenditureBtn";
            this.expenditureBtn.Size = new System.Drawing.Size(671, 23);
            this.expenditureBtn.TabIndex = 7;
            this.expenditureBtn.Text = "Списати на видаток";
            this.expenditureBtn.UseVisualStyleBackColor = true;
            this.expenditureBtn.Click += new System.EventHandler(this.expenditureBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 109;
            this.label1.Text = "Проект";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(279, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 110;
            this.label2.Text = "Дата";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 111;
            this.label3.Text = "Номенкл. номер";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(103, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 112;
            this.label4.Text = "Найменування";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(504, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 113;
            this.label5.Text = "Од. вимір.";
            // 
            // remainsGrid
            // 
            this.remainsGrid.AllowUserToAddRows = false;
            this.remainsGrid.AllowUserToDeleteRows = false;
            this.remainsGrid.AllowUserToResizeColumns = false;
            this.remainsGrid.AllowUserToResizeRows = false;
            this.remainsGrid.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.remainsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.remainsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.remainsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ReceiptNumColumn,
            this.OrderDateColumn,
            this.RemainsQuantityColumn,
            this.RemainsSumColumn,
            this.UnitPriceColumn,
            this.DebitNumColumn,
            this.CorrectionColumn});
            this.remainsGrid.Location = new System.Drawing.Point(12, 158);
            this.remainsGrid.MultiSelect = false;
            this.remainsGrid.Name = "remainsGrid";
            this.remainsGrid.ReadOnly = true;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.remainsGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.remainsGrid.RowHeadersWidth = 25;
            this.remainsGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.remainsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.remainsGrid.Size = new System.Drawing.Size(671, 287);
            this.remainsGrid.TabIndex = 115;
            this.remainsGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.remainsGrid_CellDoubleClick);
            this.remainsGrid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.remainsGrid_RowsAdded);
            this.remainsGrid.Click += new System.EventHandler(this.remainsGrid_Click);
            // 
            // sumTBox
            // 
            this.sumTBox.Location = new System.Drawing.Point(129, 103);
            this.sumTBox.MaxLength = 12;
            this.sumTBox.Name = "sumTBox";
            this.sumTBox.ReadOnly = true;
            this.sumTBox.Size = new System.Drawing.Size(130, 20);
            this.sumTBox.TabIndex = 118;
            this.sumTBox.TextChanged += new System.EventHandler(this.sumTBox_TextChanged);
            this.sumTBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sumTBox_KeyPress);
            // 
            // creditCBox
            // 
            this.creditCBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.creditCBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.creditCBox.FormattingEnabled = true;
            this.creditCBox.Location = new System.Drawing.Point(265, 103);
            this.creditCBox.Name = "creditCBox";
            this.creditCBox.Size = new System.Drawing.Size(80, 21);
            this.creditCBox.TabIndex = 4;
            this.creditCBox.TextChanged += new System.EventHandler(this.creditCBox_TextChanged);
            this.creditCBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.creditCBox_KeyUp);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(262, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 121;
            this.label9.Text = "Кредит рах.";
            // 
            // priceSumTBox
            // 
            this.priceSumTBox.Location = new System.Drawing.Point(327, 447);
            this.priceSumTBox.Name = "priceSumTBox";
            this.priceSumTBox.ReadOnly = true;
            this.priceSumTBox.Size = new System.Drawing.Size(119, 20);
            this.priceSumTBox.TabIndex = 122;
            this.priceSumTBox.TabStop = false;
            // 
            // quantitySumTBox
            // 
            this.quantitySumTBox.Location = new System.Drawing.Point(215, 447);
            this.quantitySumTBox.Name = "quantitySumTBox";
            this.quantitySumTBox.ReadOnly = true;
            this.quantitySumTBox.Size = new System.Drawing.Size(109, 20);
            this.quantitySumTBox.TabIndex = 123;
            this.quantitySumTBox.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(0, 445);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(694, 24);
            this.panel1.TabIndex = 124;
            // 
            // openAccountsRBFm
            // 
            this.openAccountsRBFm.Location = new System.Drawing.Point(351, 103);
            this.openAccountsRBFm.Name = "openAccountsRBFm";
            this.openAccountsRBFm.Size = new System.Drawing.Size(24, 21);
            this.openAccountsRBFm.TabIndex = 129;
            this.openAccountsRBFm.Text = "...";
            this.openAccountsRBFm.UseVisualStyleBackColor = true;
            this.openAccountsRBFm.Click += new System.EventHandler(this.openAccountsRBFm_Click);
            // 
            // expEditBtn
            // 
            this.expEditBtn.Location = new System.Drawing.Point(482, 1);
            this.expEditBtn.Name = "expEditBtn";
            this.expEditBtn.Size = new System.Drawing.Size(201, 23);
            this.expEditBtn.TabIndex = 130;
            this.expEditBtn.Text = "Редагувати списання";
            this.expEditBtn.UseVisualStyleBackColor = true;
            this.expEditBtn.Click += new System.EventHandler(this.expEditBtn_Click);
            // 
            // balanceTBox
            // 
            this.balanceTBox.Location = new System.Drawing.Point(571, 64);
            this.balanceTBox.Name = "balanceTBox";
            this.balanceTBox.ReadOnly = true;
            this.balanceTBox.Size = new System.Drawing.Size(111, 20);
            this.balanceTBox.TabIndex = 131;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(568, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 13);
            this.label11.TabIndex = 132;
            this.label11.Text = "Бал. рахунок";
            // 
            // toolTip
            // 
            this.toolTip.ToolTipTitle = "Наименование:";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.totalExpPriceTBox);
            this.panel2.Controls.Add(this.quantityExpSumTBox);
            this.panel2.Location = new System.Drawing.Point(0, 470);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(694, 24);
            this.panel2.TabIndex = 133;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(239, 4);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(33, 13);
            this.label13.TabIndex = 3;
            this.label13.Text = "Сума";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 4);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Кількість";
            // 
            // totalExpPriceTBox
            // 
            this.totalExpPriceTBox.Location = new System.Drawing.Point(286, 1);
            this.totalExpPriceTBox.Name = "totalExpPriceTBox";
            this.totalExpPriceTBox.ReadOnly = true;
            this.totalExpPriceTBox.Size = new System.Drawing.Size(150, 20);
            this.totalExpPriceTBox.TabIndex = 1;
            // 
            // quantityExpSumTBox
            // 
            this.quantityExpSumTBox.Location = new System.Drawing.Point(83, 1);
            this.quantityExpSumTBox.Name = "quantityExpSumTBox";
            this.quantityExpSumTBox.ReadOnly = true;
            this.quantityExpSumTBox.Size = new System.Drawing.Size(150, 20);
            this.quantityExpSumTBox.TabIndex = 0;
            // 
            // sumRButton
            // 
            this.sumRButton.AutoSize = true;
            this.sumRButton.Enabled = false;
            this.sumRButton.Location = new System.Drawing.Point(129, 85);
            this.sumRButton.Name = "sumRButton";
            this.sumRButton.Size = new System.Drawing.Size(51, 17);
            this.sumRButton.TabIndex = 134;
            this.sumRButton.TabStop = true;
            this.sumRButton.Text = "Сума";
            this.sumRButton.UseVisualStyleBackColor = true;
            this.sumRButton.CheckedChanged += new System.EventHandler(this.sumRButton_CheckedChanged);
            // 
            // quantityRButton
            // 
            this.quantityRButton.AutoSize = true;
            this.quantityRButton.Enabled = false;
            this.quantityRButton.Location = new System.Drawing.Point(12, 85);
            this.quantityRButton.Name = "quantityRButton";
            this.quantityRButton.Size = new System.Drawing.Size(71, 17);
            this.quantityRButton.TabIndex = 135;
            this.quantityRButton.TabStop = true;
            this.quantityRButton.Text = "Кількість";
            this.quantityRButton.UseVisualStyleBackColor = true;
            this.quantityRButton.CheckedChanged += new System.EventHandler(this.quantityRButton_CheckedChanged);
            // 
            // ReceiptNumColumn
            // 
            this.ReceiptNumColumn.DataPropertyName = "Receipt_Num";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ReceiptNumColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.ReceiptNumColumn.HeaderText = "Номер надходження";
            this.ReceiptNumColumn.Name = "ReceiptNumColumn";
            this.ReceiptNumColumn.ReadOnly = true;
            this.ReceiptNumColumn.Width = 92;
            // 
            // OrderDateColumn
            // 
            this.OrderDateColumn.DataPropertyName = "Order_Date";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.OrderDateColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.OrderDateColumn.FillWeight = 253.8071F;
            this.OrderDateColumn.HeaderText = "Дата надходження";
            this.OrderDateColumn.Name = "OrderDateColumn";
            this.OrderDateColumn.ReadOnly = true;
            this.OrderDateColumn.Width = 98;
            // 
            // RemainsQuantityColumn
            // 
            this.RemainsQuantityColumn.DataPropertyName = "Remains_Quantity";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N5";
            dataGridViewCellStyle13.NullValue = null;
            this.RemainsQuantityColumn.DefaultCellStyle = dataGridViewCellStyle13;
            this.RemainsQuantityColumn.FillWeight = 61.54822F;
            this.RemainsQuantityColumn.HeaderText = "Кількість залишку";
            this.RemainsQuantityColumn.Name = "RemainsQuantityColumn";
            this.RemainsQuantityColumn.ReadOnly = true;
            this.RemainsQuantityColumn.Width = 110;
            // 
            // RemainsSumColumn
            // 
            this.RemainsSumColumn.DataPropertyName = "Remains_Sum";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "N2";
            dataGridViewCellStyle14.NullValue = null;
            this.RemainsSumColumn.DefaultCellStyle = dataGridViewCellStyle14;
            this.RemainsSumColumn.FillWeight = 61.54822F;
            this.RemainsSumColumn.HeaderText = "Сума залишку";
            this.RemainsSumColumn.Name = "RemainsSumColumn";
            this.RemainsSumColumn.ReadOnly = true;
            this.RemainsSumColumn.Width = 120;
            // 
            // UnitPriceColumn
            // 
            this.UnitPriceColumn.DataPropertyName = "Unit_Price";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Format = "N2";
            dataGridViewCellStyle15.NullValue = null;
            this.UnitPriceColumn.DefaultCellStyle = dataGridViewCellStyle15;
            this.UnitPriceColumn.FillWeight = 61.54822F;
            this.UnitPriceColumn.HeaderText = "Ціна за од.";
            this.UnitPriceColumn.Name = "UnitPriceColumn";
            this.UnitPriceColumn.ReadOnly = true;
            // 
            // DebitNumColumn
            // 
            this.DebitNumColumn.DataPropertyName = "Debit_Num";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DebitNumColumn.DefaultCellStyle = dataGridViewCellStyle16;
            this.DebitNumColumn.FillWeight = 61.54822F;
            this.DebitNumColumn.HeaderText = "Дебет";
            this.DebitNumColumn.Name = "DebitNumColumn";
            this.DebitNumColumn.ReadOnly = true;
            this.DebitNumColumn.Width = 70;
            // 
            // CorrectionColumn
            // 
            this.CorrectionColumn.DataPropertyName = "Correction";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.Red;
            this.CorrectionColumn.DefaultCellStyle = dataGridViewCellStyle17;
            this.CorrectionColumn.HeaderText = "Кориг.";
            this.CorrectionColumn.MinimumWidth = 60;
            this.CorrectionColumn.Name = "CorrectionColumn";
            this.CorrectionColumn.ReadOnly = true;
            this.CorrectionColumn.Width = 60;
            // 
            // expendituresFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 494);
            this.Controls.Add(this.quantityRButton);
            this.Controls.Add(this.sumRButton);
            this.Controls.Add(this.priceSumTBox);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.balanceTBox);
            this.Controls.Add(this.expEditBtn);
            this.Controls.Add(this.quantitySumTBox);
            this.Controls.Add(this.openAccountsRBFm);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.creditCBox);
            this.Controls.Add(this.sumTBox);
            this.Controls.Add(this.remainsGrid);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.expenditureBtn);
            this.Controls.Add(this.quantityTBox);
            this.Controls.Add(this.measureTBox);
            this.Controls.Add(this.nomenclNameTBox);
            this.Controls.Add(this.nomenclatureTBox);
            this.Controls.Add(this.expDTPicker);
            this.Controls.Add(this.projectTBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "expendituresFm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Списання матеріалів";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.expendituresFm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.accountantExpFm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.remainsGrid)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox projectTBox;
        private System.Windows.Forms.DateTimePicker expDTPicker;
        private System.Windows.Forms.TextBox nomenclatureTBox;
        private System.Windows.Forms.TextBox nomenclNameTBox;
        private System.Windows.Forms.TextBox measureTBox;
        private System.Windows.Forms.TextBox quantityTBox;
        private System.Windows.Forms.Button expenditureBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView remainsGrid;
        private System.Windows.Forms.TextBox sumTBox;
        private System.Windows.Forms.ComboBox creditCBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox priceSumTBox;
        private System.Windows.Forms.TextBox quantitySumTBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button openAccountsRBFm;
        private System.Windows.Forms.Button expEditBtn;
        private System.Windows.Forms.TextBox balanceTBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox totalExpPriceTBox;
        private System.Windows.Forms.TextBox quantityExpSumTBox;
        private System.Windows.Forms.RadioButton sumRButton;
        private System.Windows.Forms.RadioButton quantityRButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptNumColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RemainsQuantityColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RemainsSumColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPriceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DebitNumColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CorrectionColumn;

    }
}
