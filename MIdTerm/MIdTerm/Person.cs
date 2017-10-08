using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MIdTerm
{
    [Serializable]
    class Person
    {
        private string _firstName, _lastName, _phone;
        public static int increment;

        public int Id
        {
            get; private set;
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = Char.ToUpper(value[0]) + value.Substring(1).ToLower(); ; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = Char.ToUpper(value[0]) + value.Substring(1).ToLower(); ; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = ReformatPhone(value); }
        }

        public string Address
        {
            get; set;
        }

        public Person()
        {
            Id = increment++;
        }

        public Person(string firstName, string lastName, string phone, string address) : this()
        {
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Address = address;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Person other = (Person)obj;
            return other.Id == this.Id;
        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        string isPhone = @"^(\(\d{3}\)|\d{3})[\s\-]?(\d{3})\-?(\d{4})$";
        string ReformatPhone(string str)
        {
            Match m = Regex.Match(str, isPhone);
            string pattern = @"^\(?(\d{3})\)?$";
            Match first = Regex.Match(m.Groups[1].ToString(), pattern);
            string output = String.Format("({0}) {1}-{2}", first.Groups[1], m.Groups[2], m.Groups[3]);
            return output;
        }

    }
}
