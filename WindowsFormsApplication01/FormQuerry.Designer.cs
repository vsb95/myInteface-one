namespace WindowsFormsApplication01
{
    partial class FormQuerry
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
            this.bCancel = new System.Windows.Forms.Button();
            this.buttonQuerry1 = new System.Windows.Forms.Button();
            this.buttonQuerry2 = new System.Windows.Forms.Button();
            this.buttonQuerry3 = new System.Windows.Forms.Button();
            this.buttonQuerry4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(580, 278);
            this.bCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(84, 27);
            this.bCancel.TabIndex = 4;
            this.bCancel.Text = "Отмена";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // buttonQuerry1
            // 
            this.buttonQuerry1.Location = new System.Drawing.Point(12, 12);
            this.buttonQuerry1.Name = "buttonQuerry1";
            this.buttonQuerry1.Size = new System.Drawing.Size(652, 56);
            this.buttonQuerry1.TabIndex = 5;
            this.buttonQuerry1.Text = "Вывести все формы предприятия \"Юстерн\"";
            this.buttonQuerry1.UseVisualStyleBackColor = true;
            this.buttonQuerry1.Click += new System.EventHandler(this.buttonQuerry1_Click);
            // 
            // buttonQuerry2
            // 
            this.buttonQuerry2.Location = new System.Drawing.Point(12, 74);
            this.buttonQuerry2.Name = "buttonQuerry2";
            this.buttonQuerry2.Size = new System.Drawing.Size(652, 56);
            this.buttonQuerry2.TabIndex = 6;
            this.buttonQuerry2.Text = "Вывести все формы, исполнителем которых был Петров П.А";
            this.buttonQuerry2.UseVisualStyleBackColor = true;
            this.buttonQuerry2.Click += new System.EventHandler(this.buttonQuerry2_Click);
            // 
            // buttonQuerry3
            // 
            this.buttonQuerry3.Location = new System.Drawing.Point(12, 136);
            this.buttonQuerry3.Name = "buttonQuerry3";
            this.buttonQuerry3.Size = new System.Drawing.Size(652, 56);
            this.buttonQuerry3.TabIndex = 7;
            this.buttonQuerry3.Text = "Посчитать и вывести число всех погибших и пострадавших женщин, предприятия \"Юстер" +
    "н\" за все годы";
            this.buttonQuerry3.UseVisualStyleBackColor = true;
            this.buttonQuerry3.Click += new System.EventHandler(this.buttonQuerry3_Click);
            // 
            // buttonQuerry4
            // 
            this.buttonQuerry4.Location = new System.Drawing.Point(12, 198);
            this.buttonQuerry4.Name = "buttonQuerry4";
            this.buttonQuerry4.Size = new System.Drawing.Size(652, 56);
            this.buttonQuerry4.TabIndex = 8;
            this.buttonQuerry4.Text = "Посчитать и вывести общую стоимость испорченного оборудования";
            this.buttonQuerry4.UseVisualStyleBackColor = true;
            this.buttonQuerry4.Click += new System.EventHandler(this.buttonQuerry4_Click);
            // 
            // FormQuerry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Moccasin;
            this.ClientSize = new System.Drawing.Size(688, 326);
            this.Controls.Add(this.buttonQuerry4);
            this.Controls.Add(this.buttonQuerry3);
            this.Controls.Add(this.buttonQuerry2);
            this.Controls.Add(this.buttonQuerry1);
            this.Controls.Add(this.bCancel);
            this.Font = new System.Drawing.Font("Times New Roman", 10.2F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormQuerry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormQuerry";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormQuerry_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button buttonQuerry1;
        private System.Windows.Forms.Button buttonQuerry2;
        private System.Windows.Forms.Button buttonQuerry3;
        private System.Windows.Forms.Button buttonQuerry4;
    }
}