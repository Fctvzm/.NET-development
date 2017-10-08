using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Searcher_Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static string placeholder = "Enter the text here";
        static string[] drives = Environment.GetLogicalDrives();
        static int len = placeholder.Length;
        static bool begin = true;
        private Point mouse_offset;
        List<FileInfo> files;

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = placeholder;
            Cursor.Current = Cursors.Arrow;
            toolTip1.SetToolTip(button1, "Search in C disk");
            toolTip2.SetToolTip(button2, "Search in E disk");
            toolTip3.SetToolTip(button3, "Search in D disk");
            toolTip4.SetToolTip(button4, "Close");
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            if (len < richTextBox1.TextLength && begin &&
                 richTextBox1.Text.Substring(0, 1) != "\n")
            {
                richTextBox1.ForeColor = Color.FromArgb(247, 247, 247);
                richTextBox1.Text = richTextBox1.Text.Substring(0, 1);
                begin = false;
                richTextBox1.SelectionStart = 1;
            }
            else if (richTextBox1.TextLength == 0 && !begin)
            {
                begin = true;
                richTextBox1.ForeColor = Color.FromArgb(185, 185, 189);
                richTextBox1.Text = "Enter the text here";
            }
            if (richTextBox1.TextLength > 0 &&
                richTextBox1.Text.Substring(richTextBox1.TextLength - 1) == "\n")
            {
                richTextBox1.Text = richTextBox1.Text.Substring(0, richTextBox1.TextLength - 1);
                richTextBox1.SelectionStart = richTextBox1.TextLength;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            singleSearch(@"D:\");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            singleSearch(@"C:\");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            singleSearch(@"E:\");
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && !begin)
            {
                textBox1.Text = "";
                Cursor.Current = Cursors.WaitCursor;
                files = new List<FileInfo>();
                Search(new DirectoryInfo(@"C:\Users\Асем Зайткалиева\Desktop"), richTextBox1.Text);
                if (files.Count == 0)
                    textBox1.Text = "There is no file with such name";
                else showFiles();
                Cursor.Current = Cursors.Arrow;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_offset = new Point(-e.X, -e.Y);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = MousePosition;
                mousePos.Offset(mouse_offset.X, mouse_offset.Y);
                Location = mousePos;
            }
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
        }

        public void singleSearch (string hardDisk)
        {
            Cursor.Current = Cursors.WaitCursor;
            files = new List<FileInfo>();
            if (new DriveInfo(hardDisk).IsReady && !begin)
            {
                Search(new DirectoryInfo(hardDisk), richTextBox1.Text);
                if (files.Count == 0)
                    textBox1.Text = "There is no file with such name";
                else showFiles();
            }
            else if (!new DriveInfo(hardDisk).IsReady) textBox1.Text = "Device is not ready";
            else textBox1.Text = "";
            Cursor.Current = Cursors.Arrow;
        }

        public void Search(DirectoryInfo dir, string name)
        {
            try
            {
                foreach (FileInfo FInfo in dir.GetFiles())
                {
                    if (FInfo.Name.Equals(name))
                        files.Add(FInfo);
                }
                foreach(DirectoryInfo DInfo in dir.GetDirectories())  
                    Search(DInfo, name);
            }
            catch { }
        }

        public void showFiles() {
            foreach (FileInfo item in files)
            {
                textBox1.AppendText(String.Format("Found in the path: {0}\n",
                        Path.GetDirectoryName(item.FullName)));
            }
            
        }
    }
}
