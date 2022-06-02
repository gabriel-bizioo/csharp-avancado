﻿using Interfaces;
using System.Linq;
namespace DAO;

public class Client : Person
{
    public Client(string name, DateTime date_of_birth, string document, string email,
         string login, string passwd) : base(name, date_of_birth, document, email, login, passwd)
        {
            this.Name = name;
            this.DateOfBirth = date_of_birth;
            this.Document = document;
            this.Email = email;
            this.Login = login;
            this.Passwd = passwd;
        }
}

