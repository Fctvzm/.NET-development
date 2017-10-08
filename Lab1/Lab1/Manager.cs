using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Manager : Person
    {
        string firstName, lastName, phoneNumber, officeLocation;
        int age;
        Genders gender;

        public Manager (string firstName, string lastName, int age, Genders gender, 
            string _phoneNumber, string _officeLocation) :
            base(firstName, lastName, age, gender)
        {
            phoneNumber = _phoneNumber;
            officeLocation = _officeLocation;
        }

        public override string ToString()
        {
            return base.ToString() + " " + phoneNumber + " " + officeLocation;
        }
    }
}
