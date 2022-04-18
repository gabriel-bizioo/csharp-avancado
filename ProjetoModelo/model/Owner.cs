using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using Interfaces;
using DTO;

namespace model
{
    public class Owner : Person, IValidateDataObject, IDataController<OwnerDTO, Owner>
    {
        public static Owner owner;
        public List<OwnerDTO> ownerDTO = new List<OwnerDTO>();

        private Owner(Address address) : base(address)
        {

        }

        public static Owner convertDTOToModel(OwnerDTO obj)
        {
            Owner owner = new Owner(Address.convertDTOToModel(obj.address));

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
                var address = new DAO.Owner
                {
                    name = this.name,
                    date_of_birth = this.date_of_birth,
                    document = this.document,
                    email = this.email,
                    phone = this.phone,
                    login = this.login,
                    password = this.password
                };

                context.OwnerList.Add(address);

                context.SaveChanges();

                id = address.ID;

            }
            return id;
        }

        public void update(ClientDTO obj)
        {

        }

        public ClientDTO findById(int id)
        {

            return new ClientDTO();
        }

        public List<OwnerDTO> getAll()
        {
            return this.ownerDTO;
        }


        public OwnerDTO convertModelToDTO()
        {
            var ownerDTO = new OwnerDTO();

            ownerDTO.name = this.name;

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

