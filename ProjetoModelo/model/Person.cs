using Interfaces;
namespace model;
public class Person
{
    protected string name;
    protected DateTime date_of_birth;
    protected string document;
    protected string email;
    protected string phone;
    protected string login;
    protected string password;
    protected Address address;

    public Person(Address address)
    {
      this.address = address;
    }

    public void setName(string name)
    {
        this.name = name;
    }

    public void setDateOfBirth(DateTime date)
    {
        this.date_of_birth = date;
    }

    public void setDocument(string document)
    {
        this.document = document;
    }

    public void setEmail(string email)
    {
        this.email = email;
    }

    public void setPhone(string phone)
    {
        this.phone = phone;
    }

    public void setLogin(string login)
    {
        this.login = login;
    }

    public string getName()
    {
        return name;
    }

    public DateTime getDateOfBirth()
    {
        return date_of_birth;
    }

    public string getDocument()
    {
        return document;
    }

    public string getEmail()
    {
        return email;
    }

    public string getPhone()
    {
        return phone;
    }

    public string getLogin()
    {
        return login;
    }

    public Address getAddress()
    {
        return address;
    }

}
