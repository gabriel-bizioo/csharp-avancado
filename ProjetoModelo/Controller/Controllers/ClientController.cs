using System;
using Microsoft.AspNetCore.Mvc;
using DTO;
using model;

namespace Controller.Controllers;

[ApiController]
[Route("client")]

public class ClientController : ControllerBase
{
    [HttpPost]
    [Route("register")]

    public object registerAdress([FromBody] ClientDTO client)
    {
        var clientModel = model.Client.convertDTOToModel(client);
        var id = clientModel.save();
        return new
        {
            nome = client.name,
            dtAniversario = client.date_of_birth,
            documento = client.document,
            email = client.email,
            telefone = client.phone,
            login = client.login,
            senha = client.password,
            endereco = new
            {
                street = client.address.street,
                city = client.address.city,
                state = client.address.state,
                country = client.address.country,
                poste_code = client.address.poste_code,     
            },
            id = id
        };
    }
    
    [HttpGet]
    [Route("get/{document}")]
    public object getInformations(string document)
    {
        var client = model.Client.find(document);
        return client;
    }
}
