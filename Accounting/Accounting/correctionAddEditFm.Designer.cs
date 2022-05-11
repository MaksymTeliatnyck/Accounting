namespace Accounting
{
    partial class correctionAddEditFm
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
            this.correctionDatePicker = new DevExpress.XtraEditors.DateEdit();
            this.label13 = new System.Windows.Forms.Label();
            this.correctionPriceTBox = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.correctionTBox = new System.Windows.Forms.TextBox();
            this.IncreaseValueChBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.correctionDatePicker.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.correctionDatePicker.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Image = global::Accounting.Properties.Resources.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(253, 208);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(143, 32);
            this.cancelBtn.TabIndex = 77;
            this.cancelBtn.Text = "&Отмена";
            this.cancelBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cancelBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Image = global::Accounting.Properties.Resources.Save_go;
            this.okBtn.Location = new System.Drawing.Point(104, 208);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(143, 32);
            this.okBtn.TabIndex = 78;
            this.okBtn.Text = "&Сохранить";
            this.okBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.okBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // correctionDatePicker
            // 
            this.correctionDatePicker.EditValue = null;
            this.correctionDatePicker.Location = new System.Drawing.Point(15, 92);
            this.correctionDatePicker.Name = "correctionDatePicker";
            this.correctionDatePicker.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.correctionDatePicker.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.correctionDatePicker.Size = new System.Drawing.Size(143, 20);
            this.correctionDatePicker.TabIndex = 553;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(12, 76);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(33, 13);
            this.label13.TabIndex = 552;
            this.label13.Text = "Дата";
            // 
            // correctionPriceTBox
            // 
            this.correctionPriceTBox.BackColor = System.Drawing.Color.White;
            this.correctionPriceTBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.correctionPriceTBox.ForeColor = System.Drawing.Color.Black;
            this.correctionPriceTBox.Location = new System.Drawing.Point(15, 140);
            this.correctionPriceTBox.Name = "correctionPriceTBox";
            this.correctionPriceTBox.Size = new System.Drawing.Size(143, 21);
            this.correctionPriceTBox.TabIndex = 555;
            this.correctionPriceTBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.correctionPriceTBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.correctionPriceTBox_KeyPress);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label25.Location = new System.Drawing.Point(12, 123);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(41, 13);
            this.label25.TabIndex = 554;
            this.label25.Text = "Сумма";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(148, 13);
            this.label8.TabIndex = 557;
            this.label8.Text = "Назначение корректировки";
            // 
            // correctionTBox
            // 
            this.correctionTBox.Location = new System.Drawing.Point(16, 21);
            this.correctionTBox.MaxLength = 500;
            this.correctionTBox.Multiline = true;
            this.correctionTBox.Name = "correctionTBox";
            this.correctionTBox.Size = new System.Drawing.Size(358, 46);
            this.correctionTBox.TabIndex = 556;
            // 
            // IncreaseValueChBox
            // 
            this.IncreaseValueChBox.AutoSize = true;
            this.IncreaseValueChBox.Location = new System.Drawing.Point(16, 168);
            this.IncreaseValueChBox.Name = "IncreaseValueChBox";
            this.IncreaseValueChBox.Size = new System.Drawing.Size(144, 17);
            this.IncreaseValueChBox.TabIndex = 558;
            this.IncreaseValueChBox.Text = "Увеличение стоимости";
            this.IncreaseValueChBox.UseVisualStyleBackColor = true;
            // 
            // correctionAddEditFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 244);
            this.Controls.Add(this.IncreaseValueChBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.correctionTBox);
            this.Controls.Add(this.correctionPriceTBox);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.correctionDatePicker);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.cancelBtn);
            this.MaximizeBox = false;
            this.Name = "correctionAddEditFm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Корректировка";
            ((System.ComponentModel.ISupportInitialize)(this.correctionDatePicker.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.correctionDatePicker.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private DevExpress.XtraEditors.DateEdit correctionDatePicker;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox correctionPriceTBox;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox correctionTBox;
        private System.Windows.Forms.CheckBox IncreaseValueChBox;
    }
}