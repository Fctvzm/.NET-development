using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieReview
{
    /// <summary>
    /// This is a main form
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes WebDriver
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            WebDriver.init();
        }

        /// <summary>
        /// This button sends a text from textbox and starts a thread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string output = null;
            Thread newThread = new Thread(() => { output = WebDriver.FindingMovieReview(textBox1.Text); });
            newThread.Start();
            newThread.Join();
            richTextBox1.Text = output;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0) button1.Enabled = true;
        }
    }
}