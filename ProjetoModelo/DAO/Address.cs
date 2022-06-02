namespace DAO;

    public class Address
    {
        public Address(string street, string city, string state, string country, string postal_code)
        {
            this.Street = street;
            this.City = city;
            this.State = state;
            this.Country = country;
            this.PostalCode = postal_code;
        }
        
        public int ID;
        public String Street;
        public String City;
        public String State;
        public String Country;
        public String PostalCode;

    }