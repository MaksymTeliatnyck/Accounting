namespace Accounting
{
    partial class expendituresSingleEditFm
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
            this.projectTBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.expDTPicker = new DevExpress.XtraEditors.DateEdit();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.creditCBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.expDTPicker.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expDTPicker.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // projectTBox
            // 
            this.projectTBox.Location = new System.Drawing.Point(131, 12);
            this.projectTBox.Name = "projectTBox";
            this.projectTBox.Size = new System.Drawing.Size(176, 20);
            this.projectTBox.TabIndex = 1;
            this.projectTBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.projectTBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Проект";
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(151, 116);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 4;
            this.okBtn.Text = "Зберегти";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(232, 116);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 5;
            this.cancelBtn.Text = "Відмінити";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // expDTPicker
            // 
            this.expDTPicker.EditValue = null;
            this.expDTPicker.Location = new System.Drawing.Point(131, 38);
            this.expDTPicker.Name = "expDTPicker";
            this.expDTPicker.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.expDTPicker.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.expDTPicker.Size = new System.Drawing.Size(176, 20);
            this.expDTPicker.TabIndex = 2;
            this.expDTPicker.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.expDTPicker_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(41, 41);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 13);
            this.label13.TabIndex = 125;
            this.label13.Text = "Дата списання";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(10, 67);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(115, 13);
            this.label15.TabIndex = 127;
            this.label15.Text = "Рахунок за кредитом";
            // 
            // creditCBox
            // 
            this.creditCBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.creditCBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.creditCBox.DropDownWidth = 50;
            this.creditCBox.FormattingEnabled = true;
            this.creditCBox.Location = new System.Drawing.Point(131, 64);
            this.creditCBox.Name = "creditCBox";
            this.creditCBox.Size = new System.Drawing.Size(176, 21);
            this.creditCBox.TabIndex = 3;
            this.creditCBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.creditCBox_KeyUp);
            // 
            // expendituresSingleEditFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(319, 149);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.creditCBox);
            this.Controls.Add(this.expDTPicker);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.projectTBox);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "expendituresSingleEditFm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редагування";
            ((System.ComponentModel.ISupportInitialize)(this.expDTPicker.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expDTPicker.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox projectTBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private DevExpress.XtraEditors.DateEdit expDTPicker;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox creditCBox;
    }
}