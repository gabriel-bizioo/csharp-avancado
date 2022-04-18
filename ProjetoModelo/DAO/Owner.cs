using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using Interfaces;
using DTO;

namespace DAO
{
    public class Owner : Person, IValidateDataObject, IDataController<OwnerDTO, Owner>
    {
        public static Owner owner;
        public List<OwnerDTO> clientDTO = new List<OwnerDTO>();

        private Owner(Address address) : base(address)
        {

        }

        public static Owner convertDTOToModel(OwnerDTO obj)
        {
            Client client = new Owner(Address.convertDTOToModel(obj.address));

            client.name = obj.name;

            client.date_of_birth = obj.date_of_birth;

            client.document = obj.document;

            client.email = obj.email;

            client.phone = obj.phone;

            client.login = obj.login;

            client.password = obj.password;

            return client;
        }

    }
}
