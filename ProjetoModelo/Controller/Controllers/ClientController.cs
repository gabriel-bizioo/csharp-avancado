using System;
using DTO;
using model;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("client")]
    public class ClientController
    {
        [HttpPost]
        [Route("register")]
        public object registerClient([FromBody] ClientDTO clientDTO)
        {
            var client = model.Client.convertDTOToModel(clientDTO);

            var id = client.save();

            return new 
            {
                name = clientDTO.name,
                date_of_birth = clientDTO.date_of_birth,
                document = clientDTO.document,
                email = clientDTO.email,
                phone = clientDTO.phone,
                login = clientDTO.login,
                passwd = clientDTO.passwd,
                address = clientDTO.client_address,
                id = id
            };

        }

        [HttpGet]
        [Route("get")]
        public object getInformations([FromBody] int clientID)
        {
            var clientInfo = model.Client.find(clientID);

            return clientInfo;
        }
    }
}