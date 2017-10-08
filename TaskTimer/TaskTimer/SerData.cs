using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTimer
{
    [Serializable]
    public class SerData
    {
        public string name { get; set; }

        public int second { get; set; }
        public int minute { get; set; }
        public int hour { get; set; }

        public SerData () { }

        public SerData (string name, int s, int m, int h)
        {
            this.name = name;
            second = s;
            minute = m;
            hour = h;
        }
    }
}
