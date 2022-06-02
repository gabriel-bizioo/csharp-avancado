using DTO;
using model;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers
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
                name = ownerDTO.Name,
                date_of_birth = ownerDTO.DateOfBirth,
                document = ownerDTO.Document,
                email = ownerDTO.Email,
                phone = ownerDTO.Phone,
                login = ownerDTO.Login,
                passwd = ownerDTO.Passwd,
                address = Address.convertDTOToModel(ownerDTO.Address),
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