using System;
using DTO;
using model;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("store")]
    public class StoreController
    {

        [HttpGet]
        [Route("getAll")]
        public List<object> getAllStores()
        {
            var storelist = model.Store.getAllStores();

            return storelist; 
        }

        [HttpPost]
        [Route("register")]
        public object registerStore([FromBody] StoreDTO storeDTO)
        {
            var store = model.Store.convertDTOToModel(storeDTO);

            int id = store.save(store.owner.getID());

            return new
            {
                owner = storeDTO.Owner,
                name = storeDTO.name,
                cnpj = storeDTO.CNPJ,
                purchases = storeDTO.purchases,
                id = id
            };
        }

        [HttpGet]
        [Route("get")]
        public object getStoreInformation([FromBody] int storeID)
        {
            var store_info = model.Store.find(storeID);

            return store_info;
        }

    }
}