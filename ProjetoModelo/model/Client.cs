using Interfaces;
using DAO;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace model
{
    public class Client : Person, IValidateDataObject, IDataController<ClientDTO, Client>
    {

        Guid uuid;
        
        private Client(string name, DateTime date_of_birth, string document, string email,
         string login, string passwd) : base(name, date_of_birth, document, email, login, passwd){}

        public static Client getInstance(Address endereco)
        {
            throw new NotImplementedException();
        }
        
        public Boolean validateObject()
        {
            if(Document == null) return false;
            if(Name == null) return false;
            if(Email == null) return false;
            if(Phone == null) return false;
            if(Login == null) return false;
            if(Passwd == null) return false;

            return true;
        }

        public ClientDTO convertModelToDTO()
        {
            ClientDTO obj = new ClientDTO(this.Name, this.DateOfBirth, this.Email, this.Document, this.Login, this.Passwd);

            obj.Phone = this.Phone;

            return obj;
        }

        public static Client convertDTOToModel(ClientDTO obj)
        {
            Client Client = new Client(obj.Name, obj.DateOfBirth,
             obj.Document, obj.Email, obj.Login, obj.Passwd);

            if(obj.Address != null) { Client.Address = Address.convertDTOToModel(obj.Address); }

            return Client;
        }

        public ClientDTO findById(int id)
        {
            throw new NotImplementedException();
        }

        public static object find(int id)
        {
            using(var context = new DaoContext())
            {
                var client = context.Client.Include(i => i.Address).FirstOrDefault(c => c.ID == id);
                if(client != null)
                {
                    return new
                    {
                        name = client.Name,
                        email = client.Email,
                        phone = client.Phone,
                        login = client.Login,
                        passwd = client.Passwd,
                        document = client.Document,
                        date_of_birth = client.DateOfBirth,
                        address = client.Address
                    };
                }
                return new
                {
                    status = "failed"
                };
            }
        }
        public static Client GetLogin(ClientDTO ClientLogin)
        {
            Client? obj;

            using(var context = new DaoContext())
            {
                var Client = context.Client.Single(c => c.Login == ClientLogin.Login && c.Passwd == ClientLogin.Passwd);

                if(Client != null)
                {
                    obj = new Client(Client.Name, Client.DateOfBirth, Client.Document, Client.Email, Client.Login, Client.Passwd)
                    {
                        Phone = Client.Phone
                    };
                }
                else
                {
                    obj = null;
                }
                
            }

            return obj;
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
                if(this.Address != null)
                {
                    var save_address = new DAO.Address(this.Address.getStreet(), this.Address.getCity(), 
                    this.Address.getState(), this.Address.getCountry(), this.Address.getPostalCode());
                    var client = new DAO.Client(this.Name, this.DateOfBirth, this.Email, this.Document, this.Login, this.Passwd);

                    context.Client.Add(client);
                    context.SaveChanges();
                    id = client.ID;
                }
                else
                {
                    var client = new DAO.Client(this.Name, this.DateOfBirth, this.Document, this.Email, this.Login, this.Passwd)
                    {
                        Phone = this.Phone
                    };
                    context.Client.Add(client);
                    context.SaveChanges();
                    id = client.ID;
                }          
            }
            return id;
        }

        public int getId()
        {
            using(var context = new DaoContext())
            {
                var Client = context.Client.FirstOrDefault(c => c.Login == this.Login && c.Passwd == this.Passwd);
                if(Client != null)
                {
                    return Client.ID;
                }
                else
                {
                    return -1;
                }
            }
        }

        public void update(ClientDTO client)
        {
            throw new NotImplementedException();
        }

        public void delete(ClientDTO client)
        {
            throw new NotImplementedException();
        }
    }
}
