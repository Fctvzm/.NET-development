namespace OOPpaint
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
            this.paintPanel = new System.Windows.Forms.Panel();
            this.rectangle = new System.Windows.Forms.Button();
            this.ellipse = new System.Windows.Forms.Button();
            this.triangle = new System.Windows.Forms.Button();
            this.Color = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // paintPanel
            // 
            this.paintPanel.Location = new System.Drawing.Point(12, 12);
            this.paintPanel.Name = "paintPanel";
            this.paintPanel.Size = new System.Drawing.Size(591, 394);
            this.paintPanel.TabIndex = 0;
            this.paintPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.paintPanel_MouseDown);
            this.paintPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.paintPanel_MouseMove);
            this.paintPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.paintPanel_MouseUp);
            // 
            // rectangle
            // 
            this.rectangle.Location = new System.Drawing.Point(622, 22);
            this.rectangle.Name = "rectangle";
            this.rectangle.Size = new System.Drawing.Size(75, 23);
            this.rectangle.TabIndex = 1;
            this.rectangle.Text = "rectangle";
            this.rectangle.UseVisualStyleBackColor = true;
            this.rectangle.Click += new System.EventHandler(this.rectangle_Click);
            // 
            // ellipse
            // 
            this.ellipse.Location = new System.Drawing.Point(622, 62);
            this.ellipse.Name = "ellipse";
            this.ellipse.Size = new System.Drawing.Size(75, 23);
            this.ellipse.TabIndex = 2;
            this.ellipse.Text = "ellipse";
            this.ellipse.UseVisualStyleBackColor = true;
            this.ellipse.Click += new System.EventHandler(this.ellipse_Click);
            // 
            // triangle
            // 
            this.triangle.Location = new System.Drawing.Point(622, 100);
            this.triangle.Name = "triangle";
            this.triangle.Size = new System.Drawing.Size(75, 23);
            this.triangle.TabIndex = 3;
            this.triangle.Text = "triangle";
            this.triangle.UseVisualStyleBackColor = true;
            this.triangle.Click += new System.EventHandler(this.triangle_Click);
            // 
            // Color
            // 
            this.Color.Location = new System.Drawing.Point(622, 141);
            this.Color.Name = "Color";
            this.Color.Size = new System.Drawing.Size(75, 23);
            this.Color.TabIndex = 0;
            this.Color.Text = "Color";
            this.Color.UseVisualStyleBackColor = true;
            this.Color.Click += new System.EventHandler(this.Color_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(619, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Coordinates";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 418);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Color);
            this.Controls.Add(this.triangle);
            this.Controls.Add(this.ellipse);
            this.Controls.Add(this.rectangle);
            this.Controls.Add(this.paintPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel paintPanel;
        private System.Windows.Forms.Button rectangle;
        private System.Windows.Forms.Button ellipse;
        private System.Windows.Forms.Button triangle;
        private System.Windows.Forms.Button Color;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label1;
    }
}

