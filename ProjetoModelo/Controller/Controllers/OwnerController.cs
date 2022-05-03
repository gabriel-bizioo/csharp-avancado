using Microsoft.AspNetCore.Mvc;
using DTO;

namespace Controller.Controllers;

[ApiController]
[Route("owner")]

public class OwnerController : ControllerBase
{
    [HttpPost]
    [Route("register")]
    public object registerOwner([FromBody] OwnerDTO owner) 
    {
        var ownerModel = model.Owner.convertDTOToModel(owner);
        var id = ownerModel.save();
        return new
        {
            nome = owner.name,
            dtAniversario = owner.date_of_birth,
            documento = owner.document,
            email = owner.email,
            telefone = owner.phone,
            login = owner.login,
            senha = owner.password,
            endereco = new
            {
                street = owner.address.street,
                city = owner.address.city,
                state = owner.address.state,
                country = owner.address.country,
                poste_code = owner.address.poste_code
            },
            id = id
        };
    }

    [HttpGet]
    [Route("get/{document}")]
    public object getInformations(string document)
    {
        var owner = model.Owner.find(document);
        return owner;
    }
}