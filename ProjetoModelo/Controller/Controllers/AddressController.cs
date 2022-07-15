using System;
using DTO;
using model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace Controller.Controllers
{


    [ApiController]
    [Route("address")]
    public class AddressController : ControllerBase
    {
        [HttpPost]
        [Route("register")]
        public IActionResult registerAddress([FromBody] AddressDTO addressDTO)
        {
                var address = model.Address.convertDTOToModel(addressDTO);
                Response.Headers.Add("Access-Control-Allow-Origin", "*");

                var id = address.save();
                var NewAddress = new
                {
                    street = addressDTO.street,
                    state = addressDTO.state,
                    city = addressDTO.city,
                    country = addressDTO.country,
                    postal_code = addressDTO.postal_code,
                    id = id
                };

            var response = new ObjectResult(NewAddress);

            return response;
        }

        [Authorize]
        [HttpDelete]
        [Route("remove/{id}")]
        public IActionResult removeAddress(int id)
        {
            model.Address.delete(id);

            Response.Headers.Add("Access-Control-Allow-Origin", "*");

            var status = new
            {
                status = "Object removed"
            };

            var result = new ObjectResult(status);

            return result;
        }

        [Authorize]
        [HttpPut]
        [Route("update/{id}")]
        public IActionResult updateAddress(int id, [FromBody]AddressDTO address)
        {
            model.Address.update(id, address);

            Response.Headers.Add("Access-Control-Allow-Origin", "*");

            var status = new
            {
                status = "Object updated"
            };

            var result = new ObjectResult(status);

            return result;
        }
    }
}