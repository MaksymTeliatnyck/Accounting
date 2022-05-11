namespace Accounting
{
    partial class optionsFm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataBaseTBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.passwordTBox = new System.Windows.Forms.TextBox();
            this.loginTBox = new System.Windows.Forms.TextBox();
            this.serverNameTBox = new System.Windows.Forms.TextBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.updatesIntervalUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.keybrdLangCBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updatesIntervalUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dataBaseTBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.passwordTBox);
            this.groupBox1.Controls.Add(this.loginTBox);
            this.groupBox1.Controls.Add(this.serverNameTBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 57);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Подключение";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(109, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "База данных";
            // 
            // dataBaseTBox
            // 
            this.dataBaseTBox.Location = new System.Drawing.Point(112, 32);
            this.dataBaseTBox.Name = "dataBaseTBox";
            this.dataBaseTBox.Size = new System.Drawing.Size(100, 20);
            this.dataBaseTBox.TabIndex = 8;
            this.dataBaseTBox.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(321, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Пароль";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Логин";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Сервер";
            // 
            // passwordTBox
            // 
            this.passwordTBox.Location = new System.Drawing.Point(324, 32);
            this.passwordTBox.Name = "passwordTBox";
            this.passwordTBox.Size = new System.Drawing.Size(100, 20);
            this.passwordTBox.TabIndex = 4;
            this.passwordTBox.UseSystemPasswordChar = true;
            // 
            // loginTBox
            // 
            this.loginTBox.Location = new System.Drawing.Point(218, 32);
            this.loginTBox.Name = "loginTBox";
            this.loginTBox.Size = new System.Drawing.Size(100, 20);
            this.loginTBox.TabIndex = 3;
            this.loginTBox.UseSystemPasswordChar = true;
            // 
            // serverNameTBox
            // 
            this.serverNameTBox.Location = new System.Drawing.Point(6, 32);
            this.serverNameTBox.Name = "serverNameTBox";
            this.serverNameTBox.Size = new System.Drawing.Size(100, 20);
            this.serverNameTBox.TabIndex = 2;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(367, 397);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.Text = "&Отмена";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(246, 397);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(115, 23);
            this.okBtn.TabIndex = 0;
            this.okBtn.Text = "Сохранить и &выйти";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // updatesIntervalUpDown
            // 
            this.updatesIntervalUpDown.Location = new System.Drawing.Point(12, 88);
            this.updatesIntervalUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.updatesIntervalUpDown.Name = "updatesIntervalUpDown";
            this.updatesIntervalUpDown.Size = new System.Drawing.Size(195, 20);
            this.updatesIntervalUpDown.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(198, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Интервал обновлений, мин. (0 - откл.)";
            // 
            // keybrdLangCBox
            // 
            this.keybrdLangCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.keybrdLangCBox.FormattingEnabled = true;
            this.keybrdLangCBox.Location = new System.Drawing.Point(12, 127);
            this.keybrdLangCBox.Name = "keybrdLangCBox";
            this.keybrdLangCBox.Size = new System.Drawing.Size(195, 21);
            this.keybrdLangCBox.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Язык ввода по умолчанию";
            // 
            // optionsFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 432);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.keybrdLangCBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.updatesIntervalUpDown);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.cancelBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "optionsFm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updatesIntervalUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox passwordTBox;
        private System.Windows.Forms.TextBox loginTBox;
        private System.Windows.Forms.TextBox serverNameTBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox dataBaseTBox;
        private System.Windows.Forms.NumericUpDown updatesIntervalUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox keybrdLangCBox;
        private System.Windows.Forms.Label label6;



    }
}