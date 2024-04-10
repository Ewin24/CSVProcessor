using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSVProcessor
{
    public class CsvFileProcessor
    {
        public void Process(string filename){
            TextReader tr = new StreamReader(filename);
        }
    }
}