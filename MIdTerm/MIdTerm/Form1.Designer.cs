namespace MIdTerm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.first_name = new System.Windows.Forms.TextBox();
            this.last_name = new System.Windows.Forms.TextBox();
            this.address = new System.Windows.Forms.TextBox();
            this.phone = new System.Windows.Forms.TextBox();
            this.patient = new System.Windows.Forms.RadioButton();
            this.physician = new System.Windows.Forms.RadioButton();
            this.sick_label = new System.Windows.Forms.Label();
            this.accept_label = new System.Windows.Forms.Label();
            this.physician_label = new System.Windows.Forms.Label();
            this.sickness = new System.Windows.Forms.TextBox();
            this.accepted_date = new System.Windows.Forms.TextBox();
            this.physician_patient = new System.Windows.Forms.TextBox();
            this.patient_panel = new System.Windows.Forms.Panel();
            this.insert = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.info_panel = new System.Windows.Forms.Panel();
            this.acceptinfo_label = new System.Windows.Forms.Label();
            this.acceptedname_label = new System.Windows.Forms.Label();
            this.phyinfo_label = new System.Windows.Forms.Label();
            this.sickinfo_label = new System.Windows.Forms.Label();
            this.position_label = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.sickinfoname_label = new System.Windows.Forms.Label();
            this.physicianname_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.patient_panel.SuspendLayout();
            this.info_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(440, 197);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(465, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "First Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(465, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Last Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(465, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Address";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(465, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Phone";
            // 
            // first_name
            // 
            this.first_name.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.first_name.Location = new System.Drawing.Point(576, 12);
            this.first_name.Multiline = true;
            this.first_name.Name = "first_name";
            this.first_name.Size = new System.Drawing.Size(204, 31);
            this.first_name.TabIndex = 5;
            // 
            // last_name
            // 
            this.last_name.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.last_name.Location = new System.Drawing.Point(576, 49);
            this.last_name.Multiline = true;
            this.last_name.Name = "last_name";
            this.last_name.Size = new System.Drawing.Size(204, 31);
            this.last_name.TabIndex = 6;
            // 
            // address
            // 
            this.address.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address.Location = new System.Drawing.Point(576, 86);
            this.address.Multiline = true;
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(204, 31);
            this.address.TabIndex = 7;
            // 
            // phone
            // 
            this.phone.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phone.Location = new System.Drawing.Point(576, 123);
            this.phone.Multiline = true;
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(204, 31);
            this.phone.TabIndex = 8;
            // 
            // patient
            // 
            this.patient.AutoSize = true;
            this.patient.Location = new System.Drawing.Point(475, 177);
            this.patient.Name = "patient";
            this.patient.Size = new System.Drawing.Size(58, 17);
            this.patient.TabIndex = 9;
            this.patient.TabStop = true;
            this.patient.Text = "Patient";
            this.patient.UseVisualStyleBackColor = true;
            this.patient.CheckedChanged += new System.EventHandler(this.patient_CheckedChanged);
            // 
            // physician
            // 
            this.physician.AutoSize = true;
            this.physician.Location = new System.Drawing.Point(562, 177);
            this.physician.Name = "physician";
            this.physician.Size = new System.Drawing.Size(70, 17);
            this.physician.TabIndex = 10;
            this.physician.TabStop = true;
            this.physician.Text = "Physician";
            this.physician.UseVisualStyleBackColor = true;
            this.physician.CheckedChanged += new System.EventHandler(this.physician_CheckedChanged);
            // 
            // sick_label
            // 
            this.sick_label.AutoSize = true;
            this.sick_label.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sick_label.Location = new System.Drawing.Point(13, 17);
            this.sick_label.Name = "sick_label";
            this.sick_label.Size = new System.Drawing.Size(78, 19);
            this.sick_label.TabIndex = 11;
            this.sick_label.Text = "Sickness";
            // 
            // accept_label
            // 
            this.accept_label.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accept_label.Location = new System.Drawing.Point(5, 51);
            this.accept_label.Name = "accept_label";
            this.accept_label.Size = new System.Drawing.Size(96, 42);
            this.accept_label.TabIndex = 12;
            this.accept_label.Text = "Accepted date";
            this.accept_label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // physician_label
            // 
            this.physician_label.AutoSize = true;
            this.physician_label.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.physician_label.Location = new System.Drawing.Point(11, 93);
            this.physician_label.Name = "physician_label";
            this.physician_label.Size = new System.Drawing.Size(82, 19);
            this.physician_label.TabIndex = 13;
            this.physician_label.Text = "Physician";
            // 
            // sickness
            // 
            this.sickness.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sickness.Location = new System.Drawing.Point(118, 14);
            this.sickness.Multiline = true;
            this.sickness.Name = "sickness";
            this.sickness.Size = new System.Drawing.Size(204, 31);
            this.sickness.TabIndex = 14;
            // 
            // accepted_date
            // 
            this.accepted_date.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accepted_date.Location = new System.Drawing.Point(118, 51);
            this.accepted_date.Multiline = true;
            this.accepted_date.Name = "accepted_date";
            this.accepted_date.Size = new System.Drawing.Size(204, 31);
            this.accepted_date.TabIndex = 15;
            // 
            // physician_patient
            // 
            this.physician_patient.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.physician_patient.Location = new System.Drawing.Point(118, 88);
            this.physician_patient.Multiline = true;
            this.physician_patient.Name = "physician_patient";
            this.physician_patient.Size = new System.Drawing.Size(204, 31);
            this.physician_patient.TabIndex = 16;
            // 
            // patient_panel
            // 
            this.patient_panel.Controls.Add(this.sickness);
            this.patient_panel.Controls.Add(this.physician_patient);
            this.patient_panel.Controls.Add(this.sick_label);
            this.patient_panel.Controls.Add(this.accepted_date);
            this.patient_panel.Controls.Add(this.accept_label);
            this.patient_panel.Controls.Add(this.physician_label);
            this.patient_panel.Location = new System.Drawing.Point(458, 209);
            this.patient_panel.Name = "patient_panel";
            this.patient_panel.Size = new System.Drawing.Size(335, 144);
            this.patient_panel.TabIndex = 17;
            this.patient_panel.Visible = false;
            // 
            // insert
            // 
            this.insert.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insert.Location = new System.Drawing.Point(661, 393);
            this.insert.Name = "insert";
            this.insert.Size = new System.Drawing.Size(119, 37);
            this.insert.TabIndex = 18;
            this.insert.Text = "Insert";
            this.insert.UseVisualStyleBackColor = true;
            this.insert.Click += new System.EventHandler(this.insert_Click);
            // 
            // clear
            // 
            this.clear.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clear.Location = new System.Drawing.Point(475, 393);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(119, 37);
            this.clear.TabIndex = 19;
            this.clear.Text = "Clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // info_panel
            // 
            this.info_panel.Controls.Add(this.acceptinfo_label);
            this.info_panel.Controls.Add(this.acceptedname_label);
            this.info_panel.Controls.Add(this.phyinfo_label);
            this.info_panel.Controls.Add(this.sickinfo_label);
            this.info_panel.Controls.Add(this.position_label);
            this.info_panel.Controls.Add(this.label5);
            this.info_panel.Controls.Add(this.sickinfoname_label);
            this.info_panel.Controls.Add(this.physicianname_label);
            this.info_panel.Location = new System.Drawing.Point(12, 228);
            this.info_panel.Name = "info_panel";
            this.info_panel.Size = new System.Drawing.Size(440, 202);
            this.info_panel.TabIndex = 20;
            this.info_panel.Visible = false;
            // 
            // acceptinfo_label
            // 
            this.acceptinfo_label.AutoSize = true;
            this.acceptinfo_label.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acceptinfo_label.Location = new System.Drawing.Point(156, 106);
            this.acceptinfo_label.Name = "acceptinfo_label";
            this.acceptinfo_label.Size = new System.Drawing.Size(0, 19);
            this.acceptinfo_label.TabIndex = 21;
            // 
            // acceptedname_label
            // 
            this.acceptedname_label.AutoSize = true;
            this.acceptedname_label.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acceptedname_label.Location = new System.Drawing.Point(22, 106);
            this.acceptedname_label.Name = "acceptedname_label";
            this.acceptedname_label.Size = new System.Drawing.Size(132, 19);
            this.acceptedname_label.TabIndex = 20;
            this.acceptedname_label.Text = "Accepted Date:";
            // 
            // phyinfo_label
            // 
            this.phyinfo_label.AutoSize = true;
            this.phyinfo_label.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phyinfo_label.Location = new System.Drawing.Point(116, 74);
            this.phyinfo_label.Name = "phyinfo_label";
            this.phyinfo_label.Size = new System.Drawing.Size(0, 19);
            this.phyinfo_label.TabIndex = 19;
            // 
            // sickinfo_label
            // 
            this.sickinfo_label.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sickinfo_label.Location = new System.Drawing.Point(114, 41);
            this.sickinfo_label.Name = "sickinfo_label";
            this.sickinfo_label.Size = new System.Drawing.Size(96, 33);
            this.sickinfo_label.TabIndex = 18;
            // 
            // position_label
            // 
            this.position_label.AutoSize = true;
            this.position_label.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.position_label.Location = new System.Drawing.Point(114, 7);
            this.position_label.Name = "position_label";
            this.position_label.Size = new System.Drawing.Size(0, 19);
            this.position_label.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 19);
            this.label5.TabIndex = 14;
            this.label5.Text = "Position:";
            // 
            // sickinfoname_label
            // 
            this.sickinfoname_label.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sickinfoname_label.Location = new System.Drawing.Point(22, 41);
            this.sickinfoname_label.Name = "sickinfoname_label";
            this.sickinfoname_label.Size = new System.Drawing.Size(96, 33);
            this.sickinfoname_label.TabIndex = 15;
            this.sickinfoname_label.Text = "Sickness:";
            // 
            // physicianname_label
            // 
            this.physicianname_label.AutoSize = true;
            this.physicianname_label.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.physicianname_label.Location = new System.Drawing.Point(22, 72);
            this.physicianname_label.Name = "physicianname_label";
            this.physicianname_label.Size = new System.Drawing.Size(86, 19);
            this.physicianname_label.TabIndex = 16;
            this.physicianname_label.Text = "Physician:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 474);
            this.Controls.Add(this.info_panel);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.insert);
            this.Controls.Add(this.patient_panel);
            this.Controls.Add(this.physician);
            this.Controls.Add(this.patient);
            this.Controls.Add(this.phone);
            this.Controls.Add(this.address);
            this.Controls.Add(this.last_name);
            this.Controls.Add(this.first_name);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.patient_panel.ResumeLayout(false);
            this.patient_panel.PerformLayout();
            this.info_panel.ResumeLayout(false);
            this.info_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox first_name;
        private System.Windows.Forms.TextBox last_name;
        private System.Windows.Forms.TextBox address;
        private System.Windows.Forms.TextBox phone;
        private System.Windows.Forms.RadioButton patient;
        private System.Windows.Forms.RadioButton physician;
        private System.Windows.Forms.Label sick_label;
        private System.Windows.Forms.Label accept_label;
        private System.Windows.Forms.Label physician_label;
        private System.Windows.Forms.TextBox sickness;
        private System.Windows.Forms.TextBox accepted_date;
        private System.Windows.Forms.TextBox physician_patient;
        private System.Windows.Forms.Panel patient_panel;
        private System.Windows.Forms.Button insert;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.Panel info_panel;
        private System.Windows.Forms.Label sickinfo_label;
        private System.Windows.Forms.Label position_label;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label sickinfoname_label;
        private System.Windows.Forms.Label physicianname_label;
        private System.Windows.Forms.Label acceptinfo_label;
        private System.Windows.Forms.Label acceptedname_label;
        private System.Windows.Forms.Label phyinfo_label;
    }
}

