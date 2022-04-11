using Interfaces;

namespace model
{
    public class Client : Person, IValidateDataObject<Client>
    {
        public static Client client;

        private Client(Address endereco) : base(endereco)
        {

        }

        

        public static Client getInstance(Address endereco)
        {
            if(client == null)
            {
                client = new Client(endereco);
            }

            return client;
        }

        public Boolean validateObject(Client client)
        {
            if (client.name == null) return false;

            if (client.document == null) return false;

            if (client.email == null) return false;

            if (client.phone == null) return false;

            if (client.login == null) return false;

            if (!client.endereco.validateObject(endereco)) return false;

            return true;
        }

    }
}
