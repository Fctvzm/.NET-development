using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBinding
{
    public partial class Form1 : Form
    {
        BindingList<Person> list;
        public Form1()
        {
            InitializeComponent();
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {

           list =  new BindingList<Person>();
            list.Add(new Person("asem"));
            list.AllowRemove = true;
            list.AllowNew = true;
            dataGridView1.DataSource = list;
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(Person.cnt+"");
        }
    }
}
