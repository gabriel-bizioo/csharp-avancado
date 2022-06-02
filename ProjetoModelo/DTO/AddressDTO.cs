using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AddressDTO
    {

        public AddressDTO(string street, string city, string state, string country, string postal_code)
        {
            this.Street = street;
            this.City = city;
            this.State = state;
            this.Country = country;
            this.PostalCode = postal_code;
        } 

        public string Street;
        public string City;
        public string State;
        public string Country;
        public string PostalCode;
    }
}
