using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBinding
{
    class Person
    {
        string _name;
       public static int cnt;
        public int id
        {
            get; private set;
        }
        public string name
        {
            get { return _name; }
            set
            {
                _name = Char.ToUpper(value[0]) + value.Substring(1).ToLower();
            }
        }
        public Person() {
            id = cnt++;
        }
        public Person(string s) : this()
        {
            name = s;
        }
        
    }
}
