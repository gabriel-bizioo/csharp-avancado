﻿using System;
using System.Text;

namespace DAO
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        private void InsertData()
        {
            using(var context = new DaoContext())
            {
                context.Database.EnsureCreated();

                context.AddressList.Add(new Address
                {
                    ID = 1,
                    street = "Rua Angelo Dallarmi 303",
                    city =  "Curitiba",
                    state = "PR",
                    country = "Brasil",
                    postal_code = "82015-750"
                });

                context.SaveChanges();
            }
        }

        private static void PrintData()
        {
            // Gets and prints all books in database
            using (var context = new DaoContext())
            {
                var enderecos = context.AddressList;

                foreach (var endereco in enderecos)
                {
                    var data = new StringBuilder();
                    data.AppendLine($"ID: {endereco.ID}");
                    data.AppendLine($"Rua: {endereco.street}");
                    data.AppendLine($"Cidade: {endereco.city}");
                    data.AppendLine($"Estado: {endereco.state}");
                    Console.WriteLine(data.ToString());
                }
            }
        }
    }
}