using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace MIdTerm
{
    public partial class Form1 : Form
    {
        BindingList<Person> people;
        public Form1()
        {
            InitializeComponent();
            if (File.Exists("People.Data"))
            {

                FileStream fs2 = new FileStream("People.Data", FileMode.Open);
                BinaryFormatter bf2 = new BinaryFormatter();
                people = (BindingList<Person>)bf2.Deserialize(fs2);
                fs2.Close();
            }
            else
            {
                people = new BindingList<Person>();
            }
            dataGridView1.DataSource = people;
            dataGridView1.Refresh();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileStream fs1 = new FileStream("People.Data", FileMode.Create);
            BinaryFormatter bf1 = new BinaryFormatter();
            bf1.Serialize(fs1, people);
            fs1.Close();
        }

        private void patient_CheckedChanged(object sender, EventArgs e)
        {
            if (patient.Checked)
            {
                sick_label.Text = "Sickness";
                accept_label.Text = "Accepted date";
                patient_panel.Controls.Add(physician_label);
                patient_panel.Controls.Add(physician_patient);
                patient_panel.Refresh();
                patient_panel.Visible = true;
            }
        }

        private void physician_CheckedChanged(object sender, EventArgs e)
        {
            if (physician.Checked)
            {
                sick_label.Text = "Education";
                accept_label.Text = "Joined date";
                patient_panel.Controls.Remove(physician_label);
                patient_panel.Controls.Remove(physician_patient);
                patient_panel.Refresh();
                patient_panel.Visible = true;
            }
        }

        private void insert_Click(object sender, EventArgs e)
        {
            if ((first_name.TextLength > 0 && last_name.TextLength > 0 &&
                address.TextLength > 0 && phone.TextLength > 0 &&
                sickness.TextLength > 0 && accepted_date.TextLength > 0) &&
                ((patient.Checked && physician_patient.TextLength > 0) || physician.Checked))
            {
                Person person = new Person();
                bool found = false;
                if (patient.Checked)
                {
                    person = new Patient(first_name.Text, last_name.Text, phone.Text, address.Text, sickness.Text, accepted_date.Text, physician_patient.Text);

                    foreach (Person doctor in people)
                    {
                        if (doctor.Id.Equals(physician_patient.Text) && doctor is Staff)
                        {
                            found = true;
                            Staff staff = doctor as Staff;
                            staff.addPatient(person as Patient);
                            break;
                        }
                    }
                    if (!found)
                    {
                        MessageBox.Show("Enter the valid Id of physician");
                        return;
                    }
                }
                else if (physician.Checked)
                {
                    person = new Staff(first_name.Text, last_name.Text, phone.Text, address.Text, sickness.Text, accepted_date.Text);
                }
                people.Add(person);
                dataGridView1.Refresh();
            }
            else MessageBox.Show("Enter full information");
        }

        private void clear_Click(object sender, EventArgs e)
        {
            first_name.Clear();
            last_name.Clear();
            address.Clear();
            sickness.Clear();
            phone.Clear();
            accepted_date.Clear();
            physician_patient.Clear();
            patient_panel.Visible = false;
            patient.Checked = false;
            physician.Checked = false;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Person current = (Person)dataGridView1.CurrentRow.DataBoundItem;
            if (current is Patient)
            {
                Patient p = (Patient)current;
                position_label.Text = "patient";
                sickinfo_label.Text = p.Sickness;
                phyinfo_label.Text = p.Doctor;
                acceptinfo_label.Text = p.Accepted;
            }
            else if (current is Staff)
            {
                Staff s = (Staff)current;
                position_label.Text = "physician";
                sickinfoname_label.Text = "Education:";
                sickinfo_label.Text = s.Education;
                physicianname_label.Text = "Patients:";
                if (s.patients != null)
                {
                    foreach (Patient p in s.patients)
                    {
                        phyinfo_label.Text += p.FirstName + " ";
                    }
                } else
                {
                    phyinfo_label.Text = "No patients";
                }
                acceptedname_label.Text = "Joined date:";
                acceptinfo_label.Text = s.Joined;
            }
            info_panel.Refresh();
            info_panel.Visible = true;
        }
    }
}
