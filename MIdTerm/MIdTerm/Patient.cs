using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIdTerm
{
    [Serializable]
    class Patient : Person
    {
        
        public Patient() : base() { }

        public Patient(string firstName, string lastName, string phone, string address, string sickness, string accepted, string doctor) : 
            base(firstName, lastName, phone, address) 
        {
            Sickness = sickness;
            Accepted = accepted;
            Doctor = doctor;
        }

        public string Sickness
        {
            get; set;
        }

        public string Accepted
        {
            get; set;
        }

        public string Doctor
        {
            get; set;
        }

    }
}
