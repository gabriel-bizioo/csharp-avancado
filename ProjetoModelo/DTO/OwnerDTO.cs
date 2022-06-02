using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OwnerDTO
    {
        public OwnerDTO(string name, DateTime date_of_birth, string document, string email, string login, string passwd)
        {
            this.Name = name;
            this.DateOfBirth = date_of_birth;
            this.Document = document;
            this.Email = email;
            this.Login = login;
            this.Passwd = passwd;
        }
        
        public AddressDTO? Address;

        public string Name;

        public DateTime DateOfBirth;

        public string Document;

        public string Email;

        public string? Phone;

        public string Login;

        public string Passwd;
    }
}
