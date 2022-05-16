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
   [Route("remove/{id}")]
   public void removeAddress(int id)
   {
      model.Address.delete(id);
   }
    [HttpPut]
    [Route("update/{id}")]
    public void updateAddress(int id, AddressDTO address)
    {
        model.Address.update(id, address);
    }
}