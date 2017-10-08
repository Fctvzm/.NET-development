using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace validation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.AliceBlue;
            this.Opacity = 0.9;
        }

        private void zip_code_TextChanged(object sender, EventArgs e)
        {

        }

        string isPhone = @"^(\(\d{3}\)|\d{3})[\s\-]?(\d{3})\-?(\d{4})$";
        string isZip = @"^01{4}(\-1{4})?$";
        string pattern = @"^.*\.?(.*)?";
        string isEmail = @"^([\w!#$%&'*+\-/=?\^_`{|}~.]+)@[\w\-]+\.\w{2,3}$";
        private void button1_Click(object sender, EventArgs e)
        {
           
            string phone = phone_number.Text;
            string email_input = email.Text;
            string zip_input = zip_code.Text;
            string message = "";
            if (!Regex.IsMatch(phone, isPhone)) message += "phone number ";
            else {
                phone_number.Text = ReformatPhone(phone);
            }
            if (!Regex.IsMatch(email_input, isEmail)) message += "email ";
            if (!Regex.IsMatch(zip_input, isZip)) message += "zip code ";
            if (message.Length == 0) MessageBox.Show("Everything is correct");
            else MessageBox.Show("Enter valid input!", message);   
        }

        string ReformatPhone(string str) {
            Match m = Regex.Match(str, isPhone);
            string pattern = @"^\(?(\d{3})\)?$";
            Match first = Regex.Match(m.Groups[1].ToString(), pattern);
            string output = String.Format("({0}) {1}-{2}", first.Groups[1], m.Groups[2], m.Groups[3]);
            return output;
        }
    }
}
