using Microsoft.AspNetCore.Mvc;
using DTO;


namespace Controller.Controllers;

[ApiController]
[Route("store")]

public class StoreController : ControllerBase
{
    [HttpGet]
    [Route ("get/all")]
    public object getAllStore()
    {
        var lojas = model.Store.getStores();
        return lojas;
    }

    [HttpPost]
    [Route("register")]
    public Object regiterStore([FromBody] StoreDTO storeDTO)
    {
        var store = model.Store.convertDTOToModel(storeDTO);
        var id = store.save(model.Store.getOwnerId(store.getOwner()));
        return new
        {
            name = storeDTO.name,
            cnpj = storeDTO.cnpj,
            owner = storeDTO.owner.name,
            id = id
        };
    }

    [HttpGet]
    [Route("getStoreInformation/{cnpj}")]
    public object getStoreInformation(string cnpj)
    {
        var store = model.Store.getStoreInformation(cnpj);

        return store;
    }
}

   

