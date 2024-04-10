using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSVProcessor.DTOs;
using CSVProcessor.Interfaces;
using Microsoft.Data.SqlClient;

namespace CSVProcessor.DataAccess
{
    public class ADOContactWriter : IContactWriter
    {
        public void Write(IList<ContactDTO> contacts)
        {
            var conn = new SqlConnection("server=(local);integrated security=sspi;database=SRP");
            conn.Open();
            foreach (var contact in contacts)
            {
                var command = conn.CreateCommand();
                command.CommandText = "INSERT INTO People (FirstName, LastName, Email) VALUES (@FirstName, @LastName, @Email)";
                command.Parameters.AddWithValue("@FirstName", contact.FirstName);
                command.Parameters.AddWithValue("@LastName", contact.LastName);
                command.Parameters.AddWithValue("@Email", contact.Email);
                command.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}