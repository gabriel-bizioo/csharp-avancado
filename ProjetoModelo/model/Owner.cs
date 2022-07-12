using System;
using Interfaces;
using DAO;
using DTO;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace model
{
    public class Owner : Person, IValidateDataObject, IDataController<OwnerDTO, Owner>
    {
        public static Owner owner;

        Guid uuid;


        public Owner(Address endereco) : base(endereco)
        {
            address = endereco;
        }
        
        private Owner() { }
        
        public static Owner getInstance(Address endereco)
        {
            if(owner == null)
            {
                owner = new Owner(endereco);
            }
            return owner;
        }

        public Boolean validateObject()
        {
            return true;
        }

        public int getID()
        {
            using(var context = new DaoContext())
            {
                var owner = context.Owner.FirstOrDefault(i => i.login == this.login);
                if (owner != null)
                {
                    return owner.ID;
                }
                else
                {
                    return 0;
                }
                
            }
        }

        public OwnerDTO convertModelToDTO()
        {
            OwnerDTO obj = new OwnerDTO();
            obj.owner_address = address.convertModelToDTO();
            obj.name = this.name;
            obj.email = this.email;
            obj.phone = this.phone;
            obj.login = this.login;
            obj.document = this.document;
            obj.passwd = this.passwd;
            obj.date_of_birth = this.date_of_birth;

            return obj;
        }

        public static Owner convertDTOToModel(OwnerDTO obj)
        {
            Owner owner = new Owner();
            if(obj.owner_address != null) { owner.address = Address.convertDTOToModel(obj.owner_address); }
            owner.name = obj.name;
            owner.email = obj.email;
            owner.document = obj.document;
            owner.phone = obj.phone;
            owner.login = obj.login;
            owner.passwd = obj.passwd;
            owner.date_of_birth = obj.date_of_birth;

            return owner;
        }

        public OwnerDTO findById(int id)
        {
            OwnerDTO owner = null;

            return owner;
        }

        public static object find(int id)
        {
            using (var context = new DaoContext())
            {
                var owner = context.Owner.Include(i => i.address).FirstOrDefault(c => c.ID == id);
                return new
                {
                    name = owner.name,
                    email = owner.email,
                    phone = owner.phone,
                    login = owner.login,
                    passwd = owner.passwd,
                    document = owner.document,
                    date_of_birth = owner.date_of_birth,
                    address = owner.address
                };
            }
        }

        public static Owner GetLogin(OwnerDTO ClientLogin)
        {
            Owner obj;

            using(var context = new DaoContext())
            {
                var owner = context.Owner.Single(c => c.login == ClientLogin.login && c.passwd == ClientLogin.passwd);

                if(owner != null)
                {
                    obj = new Owner
                    {
                        date_of_birth = owner.date_of_birth,
                        document = owner.document,
                        email = owner.email,
                        name = owner.name,
                        login = owner.login,
                        passwd = owner.passwd,
                        phone = owner.phone
                    };
                }
                else
                {
                    obj = null;
                }
            }

            return obj;
        }

        public List<OwnerDTO> getAll()
        {
            List<OwnerDTO> list = new List<OwnerDTO>();

            return list;
        }

        public int save()
        {
            var id = 0;

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

                var owner = new DAO.Owner
                {
                    name = this.name,
                    email = this.email,
                    phone = this.phone,
                    login = this.login,
                    passwd = this.passwd,
                    date_of_birth = this.date_of_birth,
                    address = save_address
                };

                context.Owner.Add(owner);

                context.SaveChanges();

                id = owner.ID;

            }
            return id;
        }

        public void update(OwnerDTO owner)
        {
            Console.WriteLine("Not yet implemented");
        }

        public void delete(OwnerDTO owner)
        {
            Console.WriteLine("Not yet implemented");
        }
    }
}
