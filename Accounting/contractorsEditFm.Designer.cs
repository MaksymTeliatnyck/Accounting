namespace Accounting
{
    partial class contractorsEditFm
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
            this.contractorSrnTBox = new System.Windows.Forms.TextBox();
            this.contractorNameTBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.contractorTinTBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // contractorSrnTBox
            // 
            this.contractorSrnTBox.Location = new System.Drawing.Point(101, 40);
            this.contractorSrnTBox.MaxLength = 12;
            this.contractorSrnTBox.Name = "contractorSrnTBox";
            this.contractorSrnTBox.Size = new System.Drawing.Size(397, 20);
            this.contractorSrnTBox.TabIndex = 2;
            this.contractorSrnTBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.contractorSrnTBox_KeyPress);
            // 
            // contractorNameTBox
            // 
            this.contractorNameTBox.Location = new System.Drawing.Point(101, 14);
            this.contractorNameTBox.MaxLength = 200;
            this.contractorNameTBox.Name = "contractorNameTBox";
            this.contractorNameTBox.Size = new System.Drawing.Size(397, 20);
            this.contractorNameTBox.TabIndex = 1;
            this.contractorNameTBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.contractorNameTBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Найменування";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Код за ЄДРПОУ";
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(342, 96);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 4;
            this.okBtn.Text = "&Зберегти";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(423, 96);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 5;
            this.cancelBtn.Text = "Відмінити";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Код ІПН";
            // 
            // contractorTinTBox
            // 
            this.contractorTinTBox.Location = new System.Drawing.Point(101, 66);
            this.contractorTinTBox.MaxLength = 12;
            this.contractorTinTBox.Name = "contractorTinTBox";
            this.contractorTinTBox.Size = new System.Drawing.Size(397, 20);
            this.contractorTinTBox.TabIndex = 3;
            this.contractorTinTBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.contractorTinTBox_KeyPress);
            // 
            // contractorsEditFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(510, 131);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.contractorTinTBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.contractorSrnTBox);
            this.Controls.Add(this.contractorNameTBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "contractorsEditFm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редагування контрагента";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox contractorSrnTBox;
        private System.Windows.Forms.TextBox contractorNameTBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox contractorTinTBox;
    }
}