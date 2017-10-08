namespace EndTerm
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.num = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Color3 = new System.Windows.Forms.Button();
            this.Color2 = new System.Windows.Forms.Button();
            this.Color1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.num);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.Color3);
            this.panel1.Controls.Add(this.Color2);
            this.panel1.Controls.Add(this.Color1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(79, 377);
            this.panel1.TabIndex = 0;
            // 
            // num
            // 
            this.num.Location = new System.Drawing.Point(14, 146);
            this.num.Name = "num";
            this.num.Size = new System.Drawing.Size(51, 23);
            this.num.TabIndex = 4;
            this.num.Text = "Enter";
            this.num.UseVisualStyleBackColor = true;
            this.num.Click += new System.EventHandler(this.num_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(14, 110);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(51, 20);
            this.textBox1.TabIndex = 3;
            // 
            // Color3
            // 
            this.Color3.Enabled = false;
            this.Color3.Location = new System.Drawing.Point(14, 71);
            this.Color3.Name = "Color3";
            this.Color3.Size = new System.Drawing.Size(51, 23);
            this.Color3.TabIndex = 2;
            this.Color3.Text = "Color3";
            this.Color3.UseVisualStyleBackColor = true;
            // 
            // Color2
            // 
            this.Color2.Enabled = false;
            this.Color2.Location = new System.Drawing.Point(14, 42);
            this.Color2.Name = "Color2";
            this.Color2.Size = new System.Drawing.Size(51, 23);
            this.Color2.TabIndex = 1;
            this.Color2.Text = "Color2";
            this.Color2.UseVisualStyleBackColor = true;
            // 
            // Color1
            // 
            this.Color1.Enabled = false;
            this.Color1.Location = new System.Drawing.Point(14, 13);
            this.Color1.Name = "Color1";
            this.Color1.Size = new System.Drawing.Size(51, 23);
            this.Color1.TabIndex = 0;
            this.Color1.Text = "Color1";
            this.Color1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(110, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(486, 377);
            this.panel2.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 401);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button num;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Color3;
        private System.Windows.Forms.Button Color2;
        private System.Windows.Forms.Button Color1;
        private System.Windows.Forms.Panel panel2;
    }
}

