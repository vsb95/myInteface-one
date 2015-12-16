namespace WindowsFormsApplication01
{
    partial class FormAdmin
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
            this.bExit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cBoxRoles = new System.Windows.Forms.ComboBox();
            this.bRegister = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tBoxPass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tBoxLogin = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bExit
            // 
            this.bExit.Location = new System.Drawing.Point(96, 328);
            this.bExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(96, 30);
            this.bExit.TabIndex = 23;
            this.bExit.Text = "Выход";
            this.bExit.UseVisualStyleBackColor = true;
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 19);
            this.label3.TabIndex = 22;
            this.label3.Text = "Роль";
            // 
            // cBoxRoles
            // 
            this.cBoxRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxRoles.FormattingEnabled = true;
            this.cBoxRoles.Location = new System.Drawing.Point(51, 101);
            this.cBoxRoles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cBoxRoles.Name = "cBoxRoles";
            this.cBoxRoles.Size = new System.Drawing.Size(196, 27);
            this.cBoxRoles.TabIndex = 21;
            // 
            // bRegister
            // 
            this.bRegister.Location = new System.Drawing.Point(65, 272);
            this.bRegister.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bRegister.Name = "bRegister";
            this.bRegister.Size = new System.Drawing.Size(166, 36);
            this.bRegister.TabIndex = 20;
            this.bRegister.Text = "Зарегистировать";
            this.bRegister.UseVisualStyleBackColor = true;
            this.bRegister.Click += new System.EventHandler(this.bRegister_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 19);
            this.label5.TabIndex = 18;
            this.label5.Text = "Регистрация";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 19);
            this.label2.TabIndex = 17;
            this.label2.Text = "Пароль";
            // 
            // tBoxPass
            // 
            this.tBoxPass.Location = new System.Drawing.Point(51, 221);
            this.tBoxPass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tBoxPass.Name = "tBoxPass";
            this.tBoxPass.Size = new System.Drawing.Size(196, 27);
            this.tBoxPass.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 19);
            this.label1.TabIndex = 15;
            this.label1.Text = "Логин";
            // 
            // tBoxLogin
            // 
            this.tBoxLogin.Location = new System.Drawing.Point(51, 154);
            this.tBoxLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tBoxLogin.Name = "tBoxLogin";
            this.tBoxLogin.Size = new System.Drawing.Size(196, 27);
            this.tBoxLogin.TabIndex = 14;
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Moccasin;
            this.ClientSize = new System.Drawing.Size(296, 370);
            this.Controls.Add(this.bExit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cBoxRoles);
            this.Controls.Add(this.bRegister);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tBoxPass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tBoxLogin);
            this.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormAdmin";
            this.Text = "Управление пользователями";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAdmin_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bExit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cBoxRoles;
        private System.Windows.Forms.Button bRegister;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tBoxPass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBoxLogin;
    }
}