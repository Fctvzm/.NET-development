using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace TaskTimer
{
    public partial class TaskBar : UserControl
    {
        public int hour = 0, minute = 0, second = 0;
        public TaskBar()
        {
            InitializeComponent();
        }

        public TaskBar(bool active) : this()
        {
            if (active) start_Click(start, new EventArgs());
        }

        public TaskBar (int second, int minute, int hour) : this()
        {
            this.second = second;
            this.minute = minute;
            this.hour = hour;
        }

        public string aim_text
        {
            get { return aim.Text; }
            set { aim.Text = value; }
        }

        public string task_name
        {
            get { return nameOfTask.Text; }
            set { nameOfTask.Text = value; }
        }

        public int progress_max
        {
            get { return progressBar1.Maximum; }
            set { progressBar1.Maximum = value; }
        }
        public int time_value
        {
            get { return hour * 60 + minute * 60 + second; }
        }

        public string status
        {
            get { return start.Text; }
        }

        public string timer_label
        {
            get { return timerShow.Text; }
            set { timerShow.Text = value; }
        }

        public string process_name { get; set; }

        private void timer_Tick(object sender, EventArgs e)
        {
            progressBar1.Style = ProgressBarStyle.Marquee;
            second++;
            minute += (second / 60);
            hour += (minute / 60);
            if (second == 60) second = 0;
            if (minute == 60) minute = 0;
            //progressBar1.Value++;
            timerShow.Text = hour + " : " + minute + " : " + second;
        }

        private void start_Click(object sender, EventArgs e)
        {
            if (start.Text.Equals("Start"))
            {
                timer.Start();
                start.Text = "Stop";
                BackColor = Color.Aquamarine;
            }
            else
            {
                timer.Stop();
                start.Text = "Start";
                BackColor = DefaultBackColor;
            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            timer.Stop();
            progressBar1.Value = 0;
            second = 0;
            minute = 0;
            hour = 0;
            timer.Start();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            var parent = this.Parent as Form1;
            parent.redraw_Control(this);
        }

        public void start_stop ()
        {
            start_Click(start, new EventArgs());
        }
    }
}
