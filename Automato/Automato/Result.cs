using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automato
{
    //Zaitkaliyeva Assem 15BD02083
    public partial class Result : Form
    {
        public Result()
        {
            InitializeComponent();
        }
        // data must be in the format of table with states q1, q2, q3 and so on 
        // and in the end must include final states with ","
        private void enter_Click(object sender, EventArgs e)
        {
            DFA.init(input.Text);
            DFA.converting();
            output.Text = DFA.show();
        }

        private void input_TextChanged(object sender, EventArgs e)
        {
            if (input.TextLength > 0)
            {
                enter.Enabled = true;
                minimize.Enabled = true;
            }
            else
            {
                enter.Enabled = false;
                minimize.Enabled = false;
            }
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            DFA.init(input.Text);
            DFA.minimize();
            output.Text = DFA.show();
        }
    }
}
