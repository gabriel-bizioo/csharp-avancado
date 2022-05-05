using System;
using DTO;
using model;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("owner")]
    public class OwnerController
    {
        [HttpPost]
        [Route("register")]
        public object registerOwner([FromBody]OwnerDTO ownerDTO)
        {
            var owner = model.Owner.convertDTOToModel(ownerDTO);

            var id = owner.save();

            return new 
            {
                name = ownerDTO.name,
                date_of_birth = ownerDTO.date_of_birth,
                document = ownerDTO.document,
                email = ownerDTO.email,
                phone = ownerDTO.phone,
                login = ownerDTO.login,
                passwd = ownerDTO.passwd,
                address = Address.convertDTOToModel(ownerDTO.owner_address),
                ID = id
            };

        }

        [HttpGet]
        [Route("get")]
        public object getInformations([FromBody] int ownerID)
        {
            var ownerInfo = model.Owner.find(ownerID);

            return ownerInfo;
        }
    }
}