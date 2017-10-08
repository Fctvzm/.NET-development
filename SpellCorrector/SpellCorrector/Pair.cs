using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellCorrector
{
    class Pair : IComparable<Pair>
    {
        public int first;
        public string second;

        public Pair(int _first, string _second)
        {
            this.first = _first;
            this.second = _second;
        }

        public int CompareTo(Pair other)
        {
            if (other == null)
                return 1;
            else
                return this.first.CompareTo(other.first);
        }

        public override string ToString()
        {
            return this.first + " " + this.second;
        }
    }
}
