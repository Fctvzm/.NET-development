using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIdTerm
{
    [Serializable]
    class Staff : Person
    {
        public List<Patient> patients;

        public Staff() : base()
        {
            patients = new List<Patient>();
        }

        public Staff (string firstName, string lastName, string phone, string address, string education, string joined) :
            base (firstName, lastName, phone, address)
        {
            Education = education;
            Joined = joined;
        }

        public void addPatient(Patient p)
        {
            patients.Add(p);
        }

        public void removePatient(int id)
        {
            foreach (Patient p in patients)
            {
                if (p.Id == id)
                {
                    patients.Remove(p);
                    break;
                }
            }
        }

        public string Education
        {
            get; set;
        }

        public string Joined
        {
            get; set;
        }

       

    }
}
