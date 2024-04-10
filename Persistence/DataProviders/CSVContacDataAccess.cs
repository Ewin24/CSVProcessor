using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSVProcessor.Interfaces;

namespace CSVProcessor.Persistence.DataProviders
{
    public class CSVContactDataProvider : IContactDataProvider
    {
        private readonly string _filename;

        public CSVContactDataProvider(string filename)
        {
            _filename = filename;
        }

        public string Read()
        {
            TextReader tr = new StreamReader(_filename);
            tr.ReadToEnd();
            tr.Close();
            return tr.ToString();
        }
    }
}