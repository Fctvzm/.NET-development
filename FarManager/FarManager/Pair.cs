using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarManager
{
    class Pair
    {
        public int index;
        public FileSystemInfo[] files;
        public string fileName;

        public Pair (int _index, FileSystemInfo[] _files, string _fileName) {
            index = _index;
            files = _files;
            fileName = _fileName;
        }

        
     }
}
