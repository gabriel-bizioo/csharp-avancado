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
            this.address = address;
        }


        public static Client getInstance(Address endereco)
        {
            if(client == null)
            {
                client = new Client(endereco);
            }

            return client;
        }
        
        public Boolean validateObject()
        {
            if(document == null) return false;
            if(name == null) return false;
            if(email == null) return false;
            if(phone == null) return false;
            if(login == null) return false;
            if(passwd == null) return false;

            return true;
        }

        public ClientDTO convertModelToDTO()
        {
            ClientDTO obj = new ClientDTO();
            obj.name = this.name;
            obj.email = this.email;
            obj.phone = this.phone;
            obj.document = this.document;
            obj.login = this.login;
            obj.passwd = this.passwd;
            obj.date_of_birth = this.date_of_birth;

            return obj;
        }

        public static Client convertDTOToModel(ClientDTO obj)
        {
            Client client = new Client(Address.convertDTOToModel(obj.client_address));

            client.name = obj.name;
            client.email = obj.email;
            client.phone = obj.phone;
            client.login = obj.login;
            client.passwd = obj.passwd;
            client.document = obj.document;
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
            int id = 0;

            using (var context = new DaoContext())
            {
                var save_address = new DAO.Address
                {
                    street = this.address.getStreet(),
                    city = this.address.getCity(),
                    state = this.address.getState(),
                    country = this.address.getCountry(),
                    postal_code = this.address.getPostalCode()
                };

                var client = new DAO.Client
                {
                    name = this.name,
                    email = this.email,
                    phone = this.phone,
                    login = this.login,
                    passwd = this.passwd,
                    date_of_birth = this.date_of_birth,
                    address = save_address
                };


                context.Client.Add(client);

                context.SaveChanges();

                id = client.ID;


            }
            return id;
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
