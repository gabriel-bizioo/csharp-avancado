using Interfaces;
namespace model;
public class Person
{
    protected string Name;
    protected DateTime DateOfBirth;
    protected string Document;
    protected string Email;
    protected string? Phone;
    protected string Login;
    protected string Passwd;
    protected Address? Address;

    public Person(string name, DateTime date_of_birth, string document, string email, string login, string passwd)
    {
      this.Name = name;
      this.DateOfBirth = date_of_birth;
      this.Document = document;
      this.Email = email;
      this.Login = login;
      this.Passwd = passwd;
    }

    public void setName(string name)
    {
        this.Name = name;
    }

    public void setDateOfBirth(DateTime date)
    {
        this.DateOfBirth = date;
    }

    public void setDocument(string document)
    {
        this.Document = document;
    }

    public void setEmail(string email)
    {
        this.Email = email;
    }

    public void setPhone(string phone)
    {
        this.Phone = phone;
    }

    public void setLogin(string login)
    {
        this.Login = login;
    }

    public string getName()
    {
        return Name;
    }

    public DateTime getDateOfBirth()
    {
        return DateOfBirth;
    }

    public string getDocument()
    {
        return Document;
    }

    public string getEmail()
    {
        return Email;
    }

    public string getPhone()
    {
        if(this.Phone != null)
            return Phone;

        throw new NullReferenceException();
    }

    public string getLogin()
    {
        return Login;
    }

    public Address getAddress()
    {
        if(this.Address != null)
            return Address;

        throw new NullReferenceException();
    }
}
