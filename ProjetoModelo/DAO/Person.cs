namespace DAO
{
    public class Person
    {
        public Person(string name, DateTime date_of_birth, string document, string email, string login, string passwd)
        {
            this.Name = name;
            this.DateOfBirth = date_of_birth;
            this.Document = document;
            this.Email = email;
            this.Login = login;
            this.Passwd = passwd;
        }

        public int ID;
        public string Name;
        public DateTime DateOfBirth;
        public string Document;
        public string Email;
        public string? Phone;
        public string Login;
        public string Passwd;
        public Address? Address;

    }
}

