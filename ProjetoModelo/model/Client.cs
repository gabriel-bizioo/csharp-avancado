using Interfaces;
using DTO;
using DAO;
using Microsoft.EntityFrameworkCore;

namespace model
{
    public class Client : Person, IValidateDataObject, IDataController<ClientDTO, Client>
    {
        public static Client client;
        public List<ClientDTO> clientDTO = new List<ClientDTO>();

        private Client(Address address) : base(address)
        {
            this.address = address;
        }

        public static Client convertDTOToModel(ClientDTO obj)
        {
            Client client = new Client(Address.convertDTOToModel(obj.address));

            if (obj.address != null) { client.address = Address.convertDTOToModel(obj.address); }

            client.name = obj.name;

            client.date_of_birth = obj.date_of_birth;

            client.document = obj.document;

            client.email = obj.email;

            client.phone = obj.phone;

            client.login = obj.login;

            client.password = obj.password;

            return client;
        }

        public Boolean validateObject()
        {
            if (name == null) { return false; }
            if (document == null) { return false; }
            if (date_of_birth == null) { return false; }
            if (email == null) { return false; }
            if (phone == null) { return false; }
            if (login == null) { return false; }
            if (password == null) { return false; }
            return true;
        }

        public void delete(ClientDTO obj)
        {

        }

        public int save()
        {
            var id = 0;

            using (var context = new DaoContext())
            {
                var client = new DAO.Client
                {
                    name = this.name,
                    date_of_birth = this.date_of_birth,
                    document = this.document,
                    email = this.email,
                    phone = this.phone,
                    login = this.login,
                    password = this.password
                };

                context.Client.Add(client);

                context.SaveChanges();

                id = client.ID;

            }
            return id;
        }

        public void update(ClientDTO obj)
        {

        }

        public static object find(String document)
        {
            using (var context = new DaoContext())
            {
                var client = context.Client.Include(i => i.address).FirstOrDefault(d => d.document == document);
                return new
                {
                    name = client.name,
                    date_of_birth = client.date_of_birth,
                    document = client.document,
                    email = client.email,
                    login = client.login,
                    password = client.password,
                    phone = client.phone,
                    address = client.address
                };
            }
        }

        public ClientDTO findById(int id)
        {

            return new ClientDTO();
        }

        public List<ClientDTO> getAll()
        {
            return this.clientDTO;
        }


        public ClientDTO convertModelToDTO()
        {
            var clientDTO = new ClientDTO();

            clientDTO.name = this.name;

            clientDTO.date_of_birth = this.date_of_birth;

            clientDTO.document = this.document;

            clientDTO.email= this.email;

            clientDTO.phone = this.phone;

            clientDTO.login = this.login;

            clientDTO.password = this.password;

            return clientDTO;
        }


        public static Client getInstance(Address endereco)
        {
            if(client == null)
            {
                client = new Client(endereco);
            }

            return client;
        }

    }
}
