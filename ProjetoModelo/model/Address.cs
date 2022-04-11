using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;
using Interfaces;

    public class Address : IValidateDataObject<Address>
    {
        
        String street;
        String city;
        String state;
        String country;
        String post_code;

        public Address(string street, string city, string state, string country, string post_code)
        {
            this.street = street;
            this.city = city;
            this.state = state;
            this.country = country;
            this.post_code = post_code;
        }

        public void setStreet(string street)
        {
            this.street = street;
        }

        public void setCity(string city)
        {
            this.city = city;
        }

        public void setState(string state)
        {
            this.state = state;
        }

        public void setCountry(string country)
        {
            this.country = country;
        }

        public void setPostCode(string post_code)
        {
            this.post_code = post_code;
        }

        public string getStreet()
        {
            return street;
        }

        public string getCity()
        {
            return city;
        }

        public string getState()
        {
            return state;
        }

        public string getCountry()
        {
            return country;
        }

        public string getPostalCode()
        {
            return post_code;
        }
        
        public Boolean validateObject(Address adr)
        {
            if(adr.street == null)
            {
                return false;
            }
            if(adr.city == null)
            {
                return false;
            }
            if(adr.state == null)
            {
                return false;
            }
            if(adr.country == null)
            {
                return false;
            }
            if(adr.post_code == null)
            {
                return false;
            }
            return true;
        }

    }