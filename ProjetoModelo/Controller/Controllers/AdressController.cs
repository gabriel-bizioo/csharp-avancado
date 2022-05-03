using System;
using Microsoft.AspNetCore.Mvc;
using DTO;
using model;

namespace Controller.Controllers;

[ApiController]
[Route("address")]

public class AdressController : ControllerBase
{
    [HttpPost]
    [Route("register")]

    public object registerAdress([FromBody] AddressDTO address) 
    {
        var addressModel = model.Address.convertDTOToModel(address);
        var id = addressModel.save();
        return new
        {
            rua = address.street,
            estado = address.state,
            cidade = address.city,
            pais = address.country,
            codigoPostal = address.poste_code,
            id = id
        };
    }

    [HttpDelete]
    public object removeAdress(AddressDTO address) 
    {
        // var addressModel = model.Address.convertDTOToModel(address);
         //addressModel.delete(address)
        return new
        {
            //status = "ok",
            //mensagem = "Excluido com sucesso"
        };
    }

    [HttpPut]
    public void updateAdress(AddressDTO adress) { }
}