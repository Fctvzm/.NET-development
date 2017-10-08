namespace validation
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
            System.Windows.Forms.Label label3;
            this.email = new System.Windows.Forms.TextBox();
            this.phone_number = new System.Windows.Forms.TextBox();
            this.zip_code = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            label3.Font = new System.Drawing.Font("Arial", 8F);
            label3.ForeColor = System.Drawing.Color.Black;
            label3.Location = new System.Drawing.Point(66, 117);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(200, 26);
            label3.TabIndex = 5;
            label3.Text = "phone_number";
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(70, 83);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(160, 20);
            this.email.TabIndex = 0;
            // 
            // phone_number
            // 
            this.phone_number.Location = new System.Drawing.Point(69, 146);
            this.phone_number.Name = "phone_number";
            this.phone_number.Size = new System.Drawing.Size(160, 20);
            this.phone_number.TabIndex = 1;
            // 
            // zip_code
            // 
            this.zip_code.Location = new System.Drawing.Point(69, 203);
            this.zip_code.Name = "zip_code";
            this.zip_code.Size = new System.Drawing.Size(160, 20);
            this.zip_code.TabIndex = 2;
            this.zip_code.TextChanged += new System.EventHandler(this.zip_code_TextChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(66, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 40);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter the information";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 8F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(66, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "email";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 8F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(66, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "zip code";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.InfoText;
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(85, 249);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 38);
            this.button1.TabIndex = 7;
            this.button1.Text = "Validate";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(300, 309);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.zip_code);
            this.Controls.Add(this.phone_number);
            this.Controls.Add(this.email);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.TextBox phone_number;
        private System.Windows.Forms.TextBox zip_code;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}

