using System.Text;

namespace DAO
{
    class Program
    {
        static void Main(string[] args)
        {
            // InsertData();
            // PrintData();
        }

        // public static void InsertData()
        // {
        //     using(var context = new DaoContext())
        //     {
        //         context.Database.EnsureCreated();

        //         Street = "Rua Angelo Dallarmi 303",
        //             City =  "Curitiba",
        //             State = "PR",
        //             Country = "Brasil",
        //             PostalCode = "82015-750"
        //         context.Address.Add(new Address()
        //         {
                    
        //         });

        //         context.SaveChanges();
        //     }
        // }

        // public static void PrintData()
        // {
        //     // Gets and prints all books in database
        //     using (var context = new DaoContext())
        //     {
        //         var enderecos = context.Address;

        //         foreach (var endereco in enderecos)
        //         {
        //             var data = new StringBuilder();
        //             data.AppendLine($"ID: {endereco.ID}");
        //             data.AppendLine($"Rua: {endereco.Street}");
        //             data.AppendLine($"Cidade: {endereco.City}");
        //             data.AppendLine($"Estado: {endereco.State}");
        //             Console.WriteLine(data.ToString());
        //         }
        //     }
        // }
    }
}