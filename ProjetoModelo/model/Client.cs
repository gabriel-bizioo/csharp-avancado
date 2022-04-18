using Interfaces;
using DAO;
using DTO;

namespace model
{
    public class Client : Person, IValidateDataObject, IDataController<ClientDTO, Client>
    {
        public static Client client;

        Guid uuid;
        
        private Client(Address address) : base(address)
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
        
        public bool validateObject()
        {
            return true;
        }

        public ClientDTO convertModeltoDTO()
        {
            ClientDTO obj = new ClientDTO();
            this.name = obj.name;
            this.email = obj.email;
            this.phone = obj.phone;
            this.login = obj.login;
            this.passwd = obj.passwd;
            this.date_of_birth = obj.date_of_birth;

            return obj;
        }

        public Client convertDTOToModel(ClientDTO obj)
        {
            Client client = new Client(Address.convertDTOToModel(obj.client_address));

            client.name = obj.name;
            client.email = obj.email;
            client.phone = obj.phone;
            client.login = obj.login;
            client.passwd = obj.passwd;
            client.date_of_birth = obj.date_of_birth;

            return client;
        }

        public ClientDTO findById(int id)
        {
            ClientDTO client = null;

            return client;
        }

        public List<ClientDTO> getAll()
        {
            List<ClientDTO> list = new List<ClientDTO>();

            return list;
        }

        public int save()
        {
            var id = 0;

            using (var context = new DaoContext())
            {
                var address = new DAO.Address
                {
                    street = this.address.getStreet(),
                    city = this.address.getCity(),
                    state = this.address.getState(),
                    country = this.address.getCountry(),
                    postal_code = this.address.getPostalCode()
                };


            }
            return 0;
        }

        public void update(ClientDTO client)
        {
            Console.WriteLine("Not yet implemented");
        }

        public void delete(ClientDTO client)
        {
            Console.WriteLine("Not yet implemented");
        }


    }
}
