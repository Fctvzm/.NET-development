using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Automation;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace TaskTimer
{
    public partial class Form1 : Form
    {
        List<TaskBar> tasks;
        List<string> websites;
        Dictionary<string, string> process_types;
        List<SerData> data;
        int h, m;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tasks = new List<TaskBar>();
            if (!File.Exists("Tasks.XML")) tasks = new List<TaskBar>();
            else
            {
                FileStream fs = new FileStream("Tasks.XML", FileMode.Open);
                XmlSerializer xml = new XmlSerializer(typeof(List<SerData>));
                data = (List<SerData>)xml.Deserialize(fs);

                for (int i = 0; i < data.Count; i++)
                {
                    tasks.Add(new TaskBar(data[i].second, data[i].minute, data[i].hour));
                    tasks[tasks.Count - 1].task_name = data[i].name;
                    tasks[tasks.Count - 1].aim_text = "undefined";
                    tasks[tasks.Count - 1].timer_label = data[i].hour + " : " + data[i].minute + " : " + data[i].second;
                    add_Control(i);
                }
                fs.Close();

            }
            process_types = new Dictionary<string, string>();
            websites = new List<string>();
            process_types.Add("wmplayer", "Entertainment");
            process_types.Add("wordpad", "Reading");
            process_types.Add("vshost", "Programming");
            process_types.Add("chrome", "Social Media");
            websites.Add("www.instagram.com");
            websites.Add("www.youtube.com");
            websites.Add("vk.com");
        }

        private void AddTask_Click(object sender, EventArgs e)
        {
            h = int.Parse(hours.Text);
            m = int.Parse(minutes.Text);
            if (taskName.TextLength > 0 && (h > 0 || m > 0))
            {
                bool active = false;
                if (Start.Checked) active = true;
                tasks.Add(new TaskBar(active));
                int max = (h * 60 + m) * 60;
                tasks[tasks.Count - 1].aim_text = h + " : " + m + " : " + "0";
                tasks[tasks.Count - 1].task_name = taskName.Text;
                tasks[tasks.Count - 1].progress_max = max;
                add_Control(tasks.Count - 1);
            }
            else MessageBox.Show("Enter correct values");
        }

        public void redraw_Control(TaskBar t)
        {
            int index = tasks.IndexOf(t);
            int top = tasks[index].Top;
            Controls.Remove(t);
            for (int i = index + 1; i < tasks.Count; i++)
            {
                tasks[i].Top = top;
                tasks[i].Left = 12;
                top += 60;
            }
            tasks.Remove(tasks[index]);
            Refresh();
        }

        private void add_Control(int index)
        {
            Controls.Add(tasks[index]);
            if (index - 1 >= 0)
            {
                tasks[index].Top = tasks[index - 1].Top + 60;
                tasks[index].Left = 12;
            }
            else
            {
                tasks[0].Top = 53;
                tasks[0].Left = 12;
            }
            Refresh();
        }

        string patternUrl = @"^(https:\/\/)?([\w\.\-]+)\/";
        bool process_exist;

        private void update_Click(object sender, EventArgs e)
        {
            foreach (var PType in process_types)
            {
                process_exist = false;

                if (PType.Key == "vshost")
                {
                    Process[] PVshosts = Process.GetProcesses().Where(pro => pro.ProcessName.EndsWith(".vshost")).ToArray();
                    int size = PVshosts.Length;
                    foreach (var PVhost in PVshosts)
                        if (PVhost.ProcessName.StartsWith("TaskTimer"))
                            size--;
                    process_exist = (size == 0) ? false : true;
                }
                else if (PType.Key == "chrome")
                {
                    string url = GetActiveTabUrl();
                    if (url != null && Regex.IsMatch(url, patternUrl))
                    {
                        Match m = Regex.Match(url, patternUrl);
                        foreach (var site in websites)
                            if (site == m.Groups[2].ToString())
                                process_exist = true;
                    }
                }
                else
                {
                    Process[] processes = Process.GetProcessesByName(PType.Key);
                    process_exist = (processes.Length == 0) ? false : true;
                }
                searching(PType.Value, PType.Key);
            }

            chart1.Series[0].Points.Clear();
            foreach (var t in tasks)
            {
                chart1.Series[0].Points.AddXY(t.task_name, t.time_value);
            }
        }


        private void searching (string taskName, string processName)
        {
            bool task_exist = false;
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].task_name == taskName)
                {
                    if (process_exist)
                    {
                        if (tasks[i].status == "Start") tasks[i].start_stop();
                    }
                    else if (!process_exist)
                    {
                        if (tasks[i].status == "Stop" && tasks[i].process_name == processName) tasks[i].start_stop();
                    }
                    
                    task_exist = true;
                }
            }

            if (process_exist && !task_exist)
            {
                tasks.Add(new TaskBar(true));
                tasks[tasks.Count - 1].aim_text = "undefiened";
                tasks[tasks.Count - 1].task_name = taskName;
                tasks[tasks.Count - 1].progress_max = 3600;
                tasks[tasks.Count - 1].process_name = processName;
                add_Control(tasks.Count - 1);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            data = new List<SerData>();
            foreach (var task in tasks)
            {
                data.Add(new SerData(task.task_name, task.second, task.minute, task.hour));
            }
            FileStream fs = new FileStream("Tasks.XML", FileMode.Create);
            XmlSerializer xml = new XmlSerializer(typeof(List<SerData>));
            xml.Serialize(fs, data);
            fs.Close();
        }

        private string GetActiveTabUrl()
        {
            Process [] ChromeWindows = Process.GetProcessesByName("chrome");
            foreach (var chrome in ChromeWindows)
            {
                if (chrome.MainWindowHandle == IntPtr.Zero) continue;

                AutomationElement element = AutomationElement.FromHandle(chrome.MainWindowHandle);
                if (element == null)
                    return null;
                Condition conditions = new AndCondition(
                    new PropertyCondition(AutomationElement.ProcessIdProperty, chrome.Id),
                    new PropertyCondition(AutomationElement.IsControlElementProperty, true),
                    new PropertyCondition(AutomationElement.IsContentElementProperty, true),
                    new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));

                AutomationElement elementx = element.FindFirst(TreeScope.Descendants, conditions);
                return ((ValuePattern)elementx.GetCurrentPattern(ValuePattern.Pattern)).Current.Value + "/";
            }
            return null;
        }
    }
}
