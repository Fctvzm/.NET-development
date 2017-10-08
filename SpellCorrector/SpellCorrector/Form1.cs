using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SpellCorrector
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string t, line;
        string[] lines = File.ReadAllLines(@"C:\Users\Асем Зайткалиева\Downloads\words");
        bool found;
        int end, cur, ans;
        List<Pair> list;

        private void text_keypress(object sender, KeyPressEventArgs e)
        {
            line = richTextBox1.Text;
            t = line;
            end = richTextBox1.SelectionStart;

            if (!Char.IsLetter(e.KeyChar) && end > 0 && Char.IsLetter(t[end - 1]))
            {  
                found = false;
                listBox1.Items.Clear();

                cur = end;
                while (cur > 0 && Char.IsLetter(t[cur - 1])) cur--; 

                t = t.Substring(cur, end - cur);
                line = line.Substring(0, end - t.Length);

                foreach (string w in lines) {
                    if (t == w) {
                        found = true;
                        break;
                    }
                }

                if (!found) {
                    list = new List<Pair>();
                    foreach (string w in lines) {
                        ans = Algorithm.MinEditDis(t, w);
                        list.Add(new Pair(ans, w));
                    }

                    list.Sort();

                    if (!checkBox1.Checked) {
                        for (int i = 0; i < 5; i++)
                            listBox1.Items.Add(list[i].second);
                    } else {
                        richTextBox1.Text = line + list[0].second;
                        richTextBox1.SelectionStart = line.Length + list[0].second.Length + 1;
                    }
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = line + listBox1.SelectedItem.ToString();
            richTextBox1.SelectionStart = line.Length + listBox1.SelectedItem.ToString().Length + 1;
        }

    }
}
