using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSVProcessor.DTOs;

namespace CSVProcessor.Interfaces
{
    public interface IContactDataProvider
    {
        string Read();
    }
    public interface IContactParser
    {
        IList<ContactDTO> Parse(string contactList);
    }
    public interface IContactWriter
    {
        void Write(IList<ContactDTO> contactData);
    }
    public class ContactProcessor
    {
        public void Process(IContactDataProvider cdp, IContactParser cp, IContactWriter cw)
        {
            var providedData = cdp.Read();
            var parsedData = cp.Parse(providedData);
            cw.Write(parsedData);
        }
    }
}