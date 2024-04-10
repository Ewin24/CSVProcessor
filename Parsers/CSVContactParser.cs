using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSVProcessor.DTOs;
using CSVProcessor.Interfaces;

namespace CSVProcessor.Parsers
{
    public class CSVContactParser : IContactParser
    {
        public IList<ContactDTO> Parse(string csvData)
        {
            IList<ContactDTO> contacts = new List<ContactDTO>();
            string[] lines = csvData.Split(new string[] { @"\r\l" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                string[] columns = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                var contact = new ContactDTO
                {
                    FirstName = columns[0],
                    LastName = columns[1],
                    Email = columns[2]
                };
                contacts.Add(contact);
            }

            return contacts;
        }
    }
}