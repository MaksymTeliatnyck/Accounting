namespace Accounting
{
    partial class nomenclatureEditFm
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
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nomenclatureTBox = new System.Windows.Forms.TextBox();
            this.nameTBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.generateChkBox = new System.Windows.Forms.CheckBox();
            this.unitsEdit = new DevExpress.XtraEditors.GridLookUpEdit();
            this.unitsEditView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.unitLocalNameColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.unitFullNameColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.balanceAccountEdit = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.unitsEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitsEditView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.balanceAccountEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(462, 179);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 6;
            this.cancelBtn.Text = "Відмінити";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(381, 179);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 5;
            this.okBtn.Text = "&Зберегти";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Номенклатурный номер";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Найменування";
            // 
            // nomenclatureTBox
            // 
            this.nomenclatureTBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nomenclatureTBox.Location = new System.Drawing.Point(141, 40);
            this.nomenclatureTBox.MaxLength = 12;
            this.nomenclatureTBox.Name = "nomenclatureTBox";
            this.nomenclatureTBox.Size = new System.Drawing.Size(397, 20);
            this.nomenclatureTBox.TabIndex = 2;
            // 
            // nameTBox
            // 
            this.nameTBox.Location = new System.Drawing.Point(141, 66);
            this.nameTBox.MaxLength = 200;
            this.nameTBox.Multiline = true;
            this.nameTBox.Name = "nameTBox";
            this.nameTBox.Size = new System.Drawing.Size(397, 58);
            this.nameTBox.TabIndex = 3;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(24, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(111, 13);
            this.label15.TabIndex = 116;
            this.label15.Text = "Балансовий рахунок";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 13);
            this.label4.TabIndex = 118;
            this.label4.Text = "Одиниці вимірювання";
            // 
            // generateChkBox
            // 
            this.generateChkBox.AutoSize = true;
            this.generateChkBox.Checked = true;
            this.generateChkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.generateChkBox.Location = new System.Drawing.Point(8, 184);
            this.generateChkBox.Name = "generateChkBox";
            this.generateChkBox.Size = new System.Drawing.Size(275, 17);
            this.generateChkBox.TabIndex = 8;
            this.generateChkBox.Text = "Включити автоматичне формування ном. номеру";
            this.generateChkBox.UseVisualStyleBackColor = true;
            // 
            // unitsEdit
            // 
            this.unitsEdit.Location = new System.Drawing.Point(141, 130);
            this.unitsEdit.Name = "unitsEdit";
            this.unitsEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.unitsEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.unitsEdit.Properties.ImmediatePopup = true;
            this.unitsEdit.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.unitsEdit.Properties.PopupFormSize = new System.Drawing.Size(300, 0);
            this.unitsEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.unitsEdit.Properties.View = this.unitsEditView;
            this.unitsEdit.Properties.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.unitsEdit_Properties_QueryPopUp);
            this.unitsEdit.Size = new System.Drawing.Size(397, 20);
            this.unitsEdit.TabIndex = 4;
            // 
            // unitsEditView
            // 
            this.unitsEditView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.unitLocalNameColumn,
            this.unitFullNameColumn});
            this.unitsEditView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.unitsEditView.Name = "unitsEditView";
            this.unitsEditView.OptionsFind.AlwaysVisible = true;
            this.unitsEditView.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.unitsEditView.OptionsFind.SearchInPreview = true;
            this.unitsEditView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.unitsEditView.OptionsView.ShowAutoFilterRow = true;
            this.unitsEditView.OptionsView.ShowGroupPanel = false;
            // 
            // unitLocalNameColumn
            // 
            this.unitLocalNameColumn.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.unitLocalNameColumn.AppearanceCell.Options.UseFont = true;
            this.unitLocalNameColumn.Caption = "Одиниці виміру";
            this.unitLocalNameColumn.FieldName = "UnitLocalName";
            this.unitLocalNameColumn.Name = "unitLocalNameColumn";
            this.unitLocalNameColumn.OptionsColumn.AllowEdit = false;
            this.unitLocalNameColumn.OptionsColumn.AllowFocus = false;
            this.unitLocalNameColumn.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.unitLocalNameColumn.Visible = true;
            this.unitLocalNameColumn.VisibleIndex = 0;
            this.unitLocalNameColumn.Width = 200;
            // 
            // unitFullNameColumn
            // 
            this.unitFullNameColumn.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.unitFullNameColumn.AppearanceCell.Options.UseFont = true;
            this.unitFullNameColumn.Caption = "Повна назва";
            this.unitFullNameColumn.FieldName = "UnitFullName";
            this.unitFullNameColumn.Name = "unitFullNameColumn";
            this.unitFullNameColumn.OptionsColumn.AllowEdit = false;
            this.unitFullNameColumn.OptionsColumn.AllowFocus = false;
            this.unitFullNameColumn.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.unitFullNameColumn.Visible = true;
            this.unitFullNameColumn.VisibleIndex = 1;
            this.unitFullNameColumn.Width = 92;
            // 
            // balanceAccountEdit
            // 
            this.balanceAccountEdit.Location = new System.Drawing.Point(141, 12);
            this.balanceAccountEdit.Name = "balanceAccountEdit";
            this.balanceAccountEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.balanceAccountEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NUM", "Балансоий рахунок")});
            this.balanceAccountEdit.Properties.ImmediatePopup = true;
            this.balanceAccountEdit.Properties.PopupWidth = 300;
            this.balanceAccountEdit.Properties.ShowHeader = false;
            this.balanceAccountEdit.Size = new System.Drawing.Size(397, 20);
            this.balanceAccountEdit.TabIndex = 119;
            this.balanceAccountEdit.EditValueChanged += new System.EventHandler(this.balanceAccountEdit_EditValueChanged);
            // 
            // nomenclatureEditFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(550, 214);
            this.Controls.Add(this.unitsEdit);
            this.Controls.Add(this.generateChkBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nomenclatureTBox);
            this.Controls.Add(this.nameTBox);
            this.Controls.Add(this.balanceAccountEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "nomenclatureEditFm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редагування";
            ((System.ComponentModel.ISupportInitialize)(this.unitsEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitsEditView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.balanceAccountEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nomenclatureTBox;
        private System.Windows.Forms.TextBox nameTBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox generateChkBox;
        private DevExpress.XtraEditors.GridLookUpEdit unitsEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView unitsEditView;
        private DevExpress.XtraGrid.Columns.GridColumn unitLocalNameColumn;
        private DevExpress.XtraGrid.Columns.GridColumn unitFullNameColumn;
        private DevExpress.XtraEditors.LookUpEdit balanceAccountEdit;
    }
}