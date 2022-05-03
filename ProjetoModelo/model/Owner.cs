using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using Interfaces;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace model
{
    public class Owner : Person, IValidateDataObject, IDataController<OwnerDTO, Owner>
    {
        public static Owner owner;
        public List<OwnerDTO> ownerDTO = new List<OwnerDTO>();

        private Owner(Address address) : base(address)
        {
            this.address = address;
        }

        public Owner() { }

        public static Owner convertDTOToModel(OwnerDTO obj)
        {
            Owner owner = new Owner();

            if (obj.address != null) { owner.address = Address.convertDTOToModel(obj.address); }

            owner.id = obj.id;

            owner.name = obj.name;

            owner.date_of_birth = obj.date_of_birth;

            owner.document = obj.document;

            owner.email = obj.email;

            owner.phone = obj.phone;

            owner.login = obj.login;

            owner.password = obj.password;

            return owner;
        }

        public Boolean validateObject()
        {
            if(id == null) { return false; }
            if (name == null) {return false;}
            if (document == null) {return false;}
            //if (date_of_birth == null) {return false;}
            if (email == null) {return false;}
            if (phone == null) {return false;}
            if (login == null) {return false;}
            if(password == null) {return false;}
            return true;
        }

        public void delete(OwnerDTO obj)
        {

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

                var owner = new DAO.Owner
                {
                    ID = id,
                    address = address,
                    name = this.name,
                    date_of_birth = this.date_of_birth,
                    document = this.document,
                    email = this.email,
                    phone = this.phone,
                    login = this.login,
                    password = this.password
                };

                context.Owner.Add(owner);

                context.SaveChanges();

                id = owner.ID;

            }
            return id;
        }

        public void update(OwnerDTO obj)
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

        public OwnerDTO findById(int id)
        {

            return new OwnerDTO();
        }

        public List<OwnerDTO> getAll()
        {
            return this.ownerDTO;
        }


        public OwnerDTO convertModelToDTO()
        {
            var ownerDTO = new OwnerDTO();

            ownerDTO.id = this.id;

            ownerDTO.name = this.name;

            ownerDTO.address = this.address.convertModelToDTO();

            ownerDTO.date_of_birth = this.date_of_birth;

            ownerDTO.document = this.document;

            ownerDTO.email = this.email;

            ownerDTO.phone = this.phone;

            ownerDTO.login = this.login;

            ownerDTO.password = this.password;

            return ownerDTO;
        }


        public static Owner getInstance(Address endereco)
        {
            if (owner == null)
            {
                owner = new Owner(endereco);
            }

            return owner;
        }

    }
}

