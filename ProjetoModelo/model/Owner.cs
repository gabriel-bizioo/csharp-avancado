using System;
using Interfaces;
using DTO;

namespace model
{
    public class Owner : Person, IValidateDataObject, IDataController<OwnerDTO, Owner>
    {
        public static Owner owner;

        Guid uuid;

        private Owner(Address endereco) : base(endereco)
        {

        }
        
        
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

        public OwnerDTO convertModelToDTO()
        {
            OwnerDTO obj = new OwnerDTO();
            this.name = obj.name;
            this.email = obj.email;
            this.phone = obj.phone;
            this.login = obj.login;
            this.passwd = obj.passwd;
            this.date_of_birth = obj.date_of_birth;

            return obj;
        }

        public Owner convertDTOToModel(OwnerDTO obj)
        {
            Owner owner = new Owner(Address.convertDTOToModel(obj.owner_address));

            owner.name = obj.name;
            owner.email = obj.email;
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

        public List<OwnerDTO> getAll()
        {
            List<OwnerDTO> list = new List<OwnerDTO>();

            return list;
        }

        public int save()
        {
            return 0;
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
