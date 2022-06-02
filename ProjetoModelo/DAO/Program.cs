using System.Text;

namespace DAO
{
    class Program
    {
        static void Main(string[] args)
        {
            InsertData();
            PrintData();
        }

        public static void InsertData()
        {
            using(var context = new DaoContext())
            {
                context.Database.EnsureCreated();

                context.Address.Add(new Address
                {
                    street = "Rua Angelo Dallarmi 303",
                    city =  "Curitiba",
                    state = "PR",
                    country = "Brasil",
                    postal_code = "82015-750"
                });

                context.SaveChanges();
            }
        }

        public static void PrintData()
        {
            // Gets and prints all books in database
            using (var context = new DaoContext())
            {
                var enderecos = context.Address;

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