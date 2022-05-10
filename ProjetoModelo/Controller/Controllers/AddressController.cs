using System;
using DTO;
using model;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers
{


    [ApiController]
    [Route("address")]
    public class AddressController
    {
        [HttpPost]
        [Route("register")]
        public object registerAddress([FromBody] AddressDTO addressDTO)
        {
                var address = model.Address.convertDTOToModel(addressDTO);

                var id = address.save();
                return new 
                {
                    street = addressDTO.street,
                    state = addressDTO.state,
                    city = addressDTO.city,
                    country = addressDTO.country,
                    postal_code = addressDTO.postal_code,
                    id = id
                };
        }

        [HttpDelete]
        [Route("remove/{id}")]
        public string removeAddress(int id)
        {
            model.Address.delete(id);

            return "address removed";
        }

        [HttpPut]
        [Route("update/{id}")]
        public string updateAddress(int id, [FromBody]AddressDTO address)
        {
            model.Address.update(id, address);

            return "address updated";
        }
    }
}