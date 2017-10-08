namespace TaskTimer
{
    partial class TaskBar
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.nameOfTask = new System.Windows.Forms.Label();
            this.timerShow = new System.Windows.Forms.Label();
            this.aim = new System.Windows.Forms.Label();
            this.reset = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.Delete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(258, 17);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(207, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // nameOfTask
            // 
            this.nameOfTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameOfTask.Location = new System.Drawing.Point(11, 17);
            this.nameOfTask.Name = "nameOfTask";
            this.nameOfTask.Size = new System.Drawing.Size(109, 23);
            this.nameOfTask.TabIndex = 1;
            this.nameOfTask.Text = "task";
            this.nameOfTask.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerShow
            // 
            this.timerShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timerShow.Location = new System.Drawing.Point(126, 17);
            this.timerShow.Name = "timerShow";
            this.timerShow.Size = new System.Drawing.Size(57, 23);
            this.timerShow.TabIndex = 2;
            this.timerShow.Text = "0 : 0 : 0";
            this.timerShow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // aim
            // 
            this.aim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.aim.Location = new System.Drawing.Point(189, 17);
            this.aim.Name = "aim";
            this.aim.Size = new System.Drawing.Size(63, 23);
            this.aim.TabIndex = 3;
            this.aim.Text = "0 : 0 : 0";
            this.aim.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // reset
            // 
            this.reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reset.Location = new System.Drawing.Point(508, 17);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(32, 23);
            this.reset.TabIndex = 5;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // start
            // 
            this.start.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.start.Location = new System.Drawing.Point(471, 17);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(31, 23);
            this.start.TabIndex = 6;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Delete
            // 
            this.Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Delete.Location = new System.Drawing.Point(546, 17);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(32, 23);
            this.Delete.TabIndex = 7;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // TaskBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.start);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.aim);
            this.Controls.Add(this.timerShow);
            this.Controls.Add(this.nameOfTask);
            this.Controls.Add(this.progressBar1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "TaskBar";
            this.Size = new System.Drawing.Size(587, 56);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label nameOfTask;
        private System.Windows.Forms.Label timerShow;
        private System.Windows.Forms.Label aim;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button Delete;
    }
}
