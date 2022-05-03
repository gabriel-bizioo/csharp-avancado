using Microsoft.AspNetCore.Mvc;
using DTO;

namespace Controller.Controllers;

[ApiController]
[Route("store")]

public class StoreController : ControllerBase
{
    public void getAllStore() { }

    [HttpPost]
    [Route("register")]
    public object registerStore(StoreDTO store)
    {
        var storeModel = model.Store.convertDTOToModel(store);

        //var owner = model.Owner.convertDTOToModel(store.owner);

        // var ownerOBJ = owner.find();

        var id = storeModel.save(5);
        return new
        {
            nome = store.name,
            cnpj = store.cnpj,
            owner = store.owner,
            purchase = store.purchases,
            id = id
        };
    }

    [HttpGet]
    [Route("getStoreInformation /{id}")]
    public object getStoreInformation(int id)
    {
        var store = model.Store.getStoreInformation(id);

        return store;
    }
}

   

