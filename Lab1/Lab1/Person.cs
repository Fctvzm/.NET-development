using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Person
    {
        string firstName, lastName;
        int age;
        public enum Genders { Male, Female };
        public Genders gender;

        public Person(string _firstName, string _lastName, int _age)
        {
            firstName = _firstName;
            lastName = _lastName;
            age = _age;
        }
        public Person(string _firstName, string _lastName, int _age, Genders _gender) :
            this(_firstName, _lastName, _age)
        {
            gender = _gender;
        }
        public override string ToString()
        {
            return firstName + " " + lastName + " " + age + " " + gender;
        }
    }
}
